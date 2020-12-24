using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EfCoreLinqWrapper.EfCore;
using EfCoreLinqWrapper.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreLinqWrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bookRepository = new BookRepository();

            var books = await bookRepository.GetListAsync();
            
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }

    public class BookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookRepository()
        {
            var builder = new DbContextOptionsBuilder<BookDbContext>()
                .UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=EfCoreLinqWrapperTests;Trusted_Connection=True;MultipleActiveResultSets=true");

            _dbContext = new BookDbContext(builder.Options);
        }

        public async Task<List<Book>> GetListAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}
