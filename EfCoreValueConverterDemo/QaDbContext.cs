using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EfCoreValueConverterDemo
{
    public class QaDbContext : DbContext
    {
        public DbSet<QaUser> Users { get; set; }

        public QaDbContext(DbContextOptions<QaDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QaUser>(b =>
            {
                b.Property(u => u.UserName).IsRequired().HasMaxLength(128);

                b.Property(u => u.ExtraProperties)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<string, object>>(s)
                    )
                    .HasMaxLength(4000)
                    .IsRequired();
            });
        }
    }
}
