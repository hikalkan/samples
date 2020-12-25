using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EfCoreLinqWrapper.EfCore;
using EfCoreLinqWrapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreLinqWrapper.Repositories
{
    public class BookRepository : IAbpQueryable<Book>, IAsyncEnumerable<Book>
    {
        private readonly BookDbContext _dbContext;

        public BookRepository()
        {
            var builder = new DbContextOptionsBuilder<BookDbContext>()
                .UseSqlServer(
                    "Server=(LocalDb)\\MSSQLLocalDB;Database=EfCoreLinqWrapperTests;Trusted_Connection=True;MultipleActiveResultSets=true");

            _dbContext = new BookDbContext(builder.Options);
        }

        public Task InitAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                return Task.CompletedTask;
            }

            return _dbContext.Database.BeginTransactionAsync();
        }


        public async Task CommitAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public IQueryable<Book> GetQueryable()
        {
            return _dbContext.Books.AsQueryable();
        }

        public IAsyncEnumerator<Book> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return _dbContext.Books.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }
    }
}
