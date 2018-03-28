using EfCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Ef
{
    public class QaDbContext : DbContext
    {
        public DbSet<QaUser> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public QaDbContext(DbContextOptions<QaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureQa();
        }
    }
}
