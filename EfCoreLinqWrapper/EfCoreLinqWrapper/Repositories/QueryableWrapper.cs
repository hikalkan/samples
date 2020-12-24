using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EfCoreLinqWrapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreLinqWrapper.Repositories
{
    public class QueryableWrapper : IAbpQueryable<Book>, IAsyncEnumerable<Book>
    {
        private readonly IQueryable<Book> _queryable;
        private readonly IAbpQueryable<Book> _abpQueryable;

        public QueryableWrapper(IQueryable<Book> queryable, IAbpQueryable<Book> abpQueryable)
        {
            _queryable = queryable;
            _abpQueryable = abpQueryable;
        }

        public Task BeginTransactionAsync()
        {
            return _abpQueryable.BeginTransactionAsync();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return _queryable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType => _queryable.ElementType;
        public Expression Expression => _queryable.Expression;
        public IQueryProvider Provider => _queryable.Provider;

        public IAsyncEnumerator<Book> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return _queryable.AsAsyncEnumerable().GetAsyncEnumerator(cancellationToken);
        }
    }
}
