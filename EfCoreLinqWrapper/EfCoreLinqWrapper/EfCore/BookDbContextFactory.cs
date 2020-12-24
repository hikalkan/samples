using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreLinqWrapper.EfCore
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDbContext>
    {
        public BookDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BookDbContext>()
                .UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=EfCoreLinqWrapperTests;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookDbContext(builder.Options);
        }
    }
}
