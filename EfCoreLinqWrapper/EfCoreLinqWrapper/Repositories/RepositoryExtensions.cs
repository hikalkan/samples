using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EfCoreLinqWrapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreLinqWrapper.Repositories
{
    public static class RepositoryExtensions
    {
        public static IAbpQueryable<Book> Where(this IAbpQueryable<Book> abpQueryable, Expression<Func<Book, bool>> predicate)
        {
            return new QueryableWrapper(abpQueryable.AsQueryable().Where(predicate), abpQueryable);
        }

        public static async Task<List<Book>> ToListAsync(this IAbpQueryable<Book> abpQueryable)
        {
            await abpQueryable.BeginTransactionAsync();
            return await abpQueryable.AsQueryable().ToListAsync();
        }
    }
}
