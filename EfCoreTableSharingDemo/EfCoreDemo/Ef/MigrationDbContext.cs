using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Ef
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureIdentity(true);
            modelBuilder.ConfigureQa(true);
        }
    }
}