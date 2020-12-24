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

            //We can perform async operations if needed!

            _dbContext = new BookDbContext(builder.Options);
        }

        public Task BeginTransactionAsync()
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

        public IEnumerator<Book> GetEnumerator()
        {
            return GetQueryable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => GetQueryable().ElementType;
        public Expression Expression => GetQueryable().Expression;
        public IQueryProvider Provider => GetQueryable().Provider;

        private IQueryable<Book> GetQueryable()
        {
            return _dbContext.Books.AsQueryable();
        }

        public IAsyncEnumerator<Book> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return _dbContext.Books.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }
    }
}
