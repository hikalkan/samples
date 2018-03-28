using System;
using System.Linq;
using EfCoreDemo.Ef;
using EfCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //using (var dbContext = new IdentityDbContext(CreateDbContextOptions<IdentityDbContext>()))
            //{
            //    dbContext.Users.Add(new IdentityUser(Guid.NewGuid(), "john", "123"));
            //    dbContext.Users.Add(new IdentityUser(Guid.NewGuid(), "neo", "123"));
            //    dbContext.SaveChanges();
            //}

            using (var dbContext = new IdentityDbContext(CreateDbContextOptions<IdentityDbContext>()))
            {
                foreach (var user in dbContext.Users.ToList())
                {
                    Console.WriteLine(user);
                }
            }

            using (var dbContext = new QaDbContext(CreateDbContextOptions<QaDbContext>()))
            {
                foreach (var user in dbContext.Users.ToList())
                {
                    Console.WriteLine(user);
                }

                foreach (var question in dbContext.Questions.ToList())
                {
                    Console.WriteLine(question);
                }
            }

            Console.ReadLine();
        }

        public static DbContextOptions<TDbContext> CreateDbContextOptions<TDbContext>() 
            where TDbContext : DbContext
        {
            return new DbContextOptionsBuilder<TDbContext>()
                   .UseSqlServer("Server=localhost;Database=EfCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true")
                   .Options;
        }
    }
}
