using System;
using System.Threading.Tasks;
using EfCoreCollectionBugRepro.EfCore;
using EfCoreCollectionBugRepro.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Shouldly;
using Xunit;

namespace EfCoreCollectionBugRepro.Tests
{
    public class MyTests : IDisposable
    {
        private readonly SqliteConnection _connection;

        public MyTests()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            CreateDbContext().GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        [Fact]
        public async Task Should_Be_Able_To_Add_Items_To_Collection_Inside_Constructor()
        {
            using (var context = CreateDbContext())
            {
                context.People.Add(new Person("john")); //Adding a change log in the conctructor
                await context.SaveChangesAsync();
            }

            using (var context = CreateDbContext())
            {
                //IMPORTANT: Removing Include(p => p.ChangeLogs) makes it working!
                var john = await context.People.Include(p => p.ChangeLogs).SingleAsync(p => p.Name == "john");
                john.ChangeLogs.Count.ShouldBe(1); //BUT getting 2 items
            }
        }

        [Fact]
        public async Task Should_Be_Able_To_Add_Items_To_Collection_Inside_Constructor_With_LazyLoad_Enabled()
        {
            using (var context = CreateDbContext(lazyLoad: true))
            {
                var person = new Person("john"); //Adding a change log in the conctructor
                person.ChangeName("john-changed"); //Creates a 2nd change log

                context.People.Add(person);
                await context.SaveChangesAsync();
            }

            using (var context = CreateDbContext(lazyLoad: true))
            {
                var john = await context.People.SingleAsync(p => p.Name == "john-changed");
                john.ChangeLogs.Count.ShouldBe(2); //BUT getting 1 item
            }
        }

        private PersonDbContext CreateDbContext(bool lazyLoad = false)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersonDbContext>()
                .UseSqlite(_connection);

            if (lazyLoad)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }

            return new PersonDbContext(optionsBuilder.Options);
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
