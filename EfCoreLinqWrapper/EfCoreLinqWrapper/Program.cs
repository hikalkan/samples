using System;
using System.Threading.Tasks;
using EfCoreLinqWrapper.Repositories;

namespace EfCoreLinqWrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bookRepository = new BookRepository();

            var books = await bookRepository.Where(b => b.Name.StartsWith("B")).ToListAsync();

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            await bookRepository.CommitAsync();

            Console.WriteLine("------------------");

            bookRepository = new BookRepository();

            var query = (from book1 in bookRepository
                where book1.Name.Contains("one")
                select book1);

            foreach (var book in await query.ToListAsync())
            {
                Console.WriteLine(book);
            }

            await bookRepository.CommitAsync();
        }
    }
}
