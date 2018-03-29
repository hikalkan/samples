using System;
using Microsoft.EntityFrameworkCore;

namespace EfCoreValueConverterDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new QaDbContext(CreateDbContextOptions<QaDbContext>()))
            {
                var userJohn = new QaUser("john");
                var userNeo = new QaUser("neo")
                {
                    ExtraProperties =
                    {
                        ["Age"] = 42
                    }
                };

                context.Users.Add(userJohn);
                context.Users.Add(userNeo);
                context.SaveChanges();
            }

            using (var context = new QaDbContext(CreateDbContextOptions<QaDbContext>()))
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine(user);
                }
            }

            Console.ReadLine();
        }

        public static DbContextOptions<TDbContext> CreateDbContextOptions<TDbContext>()
            where TDbContext : DbContext
        {
            return new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer("Server=localhost;Database=EfCoreValueConverterDemo;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
        }
    }
}
