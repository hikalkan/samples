using System;
using System.Threading.Tasks;
using EfCoreLinqWrapper.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EfCoreLinqWrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bookRepository = new BookRepository();

            var books = await bookRepository.ToListAsync();

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
