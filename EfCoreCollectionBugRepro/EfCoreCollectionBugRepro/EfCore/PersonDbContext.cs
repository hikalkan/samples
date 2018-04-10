using EfCoreCollectionBugRepro.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreCollectionBugRepro.EfCore
{
    public class PersonDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(b =>
            {
                b.HasMany(x => x.ChangeLogs).WithOne().HasForeignKey(x => x.PersonId);
            });
        }

        public static DbContextOptions<PersonDbContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<PersonDbContext>()
                .UseSqlServer("Server=localhost;Database=EfCoreCollectionBugRepro;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
        }
    }
}
