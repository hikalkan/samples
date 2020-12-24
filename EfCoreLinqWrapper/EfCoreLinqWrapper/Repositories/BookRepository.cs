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
    public class BookRepository : IQueryable<Book>, IAsyncEnumerable<Book>
    {
        private BookDbContext _dbContext;

        public BookRepository()
        {
            GetOrCreateDbContextAsync();
        }

        private async Task<BookDbContext> GetOrCreateDbContextAsync()
        {
            if (_dbContext != null)
            {
                return _dbContext;
            }

            var builder = new DbContextOptionsBuilder<BookDbContext>()
                .UseSqlServer(
                    "Server=(LocalDb)\\MSSQLLocalDB;Database=EfCoreLinqWrapperTests;Trusted_Connection=True;MultipleActiveResultSets=true");

            //We can perform async operations if needed!

            _dbContext = new BookDbContext(builder.Options);
            return _dbContext;
        }

        public async Task<List<Book>> GetListAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType { get; }
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }

        public IAsyncEnumerator<Book> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new AsyncEnumeratorWrapper(this, cancellationToken);
        }

        private class AsyncEnumeratorWrapper : IAsyncEnumerator<Book>
        {
            private readonly BookRepository _bookRepository;
            private readonly CancellationToken _cancellationToken;
            private IAsyncEnumerator<Book> _enumerator;

            public AsyncEnumeratorWrapper(BookRepository bookRepository, CancellationToken cancellationToken = default)
            {
                _bookRepository = bookRepository;
                _cancellationToken = cancellationToken;
            }

            public ValueTask DisposeAsync()
            {
                return _enumerator.DisposeAsync();
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                var enumerator = await GetEnumeratorAsync();
                return await enumerator.MoveNextAsync();
            }

            private async Task<IAsyncEnumerator<Book>> GetEnumeratorAsync()
            {
                if (_enumerator != null)
                {
                    return _enumerator;
                }

                var dbContext = await _bookRepository.GetOrCreateDbContextAsync();
                _enumerator = dbContext.Books.AsAsyncEnumerable().GetAsyncEnumerator(_cancellationToken);
                return _enumerator;
            }

            public Book Current => _enumerator?.Current;
        }
    }
}
