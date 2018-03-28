using EfCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Ef
{
    public static class QaDbContextModelBuilderExtensions
    {
        public static void ConfigureQa(this ModelBuilder modelBuilder, bool integrateUsers = false)
        {
            if (integrateUsers)
            {
                modelBuilder.ConfigureDefaultUser();
            }

            modelBuilder.Entity<QaUser>(b =>
            {
                b.ConfigureDefaultUser();

                b.Property(x => x.Reputation).HasDefaultValue(0);

                if (integrateUsers)
                {
                    b.HasOne<DefaultUser>()
                    .WithOne()
                    .HasForeignKey<DefaultUser>(u => u.Id);
                }
            });

            modelBuilder.Entity<Question>(b =>
            {
                b.ToTable("Question");

                b.Property(x => x.Text).HasMaxLength(1024).IsRequired();
                b.HasOne<QaUser>().WithMany().HasForeignKey(x => x.CreatorUserId).IsRequired();
            });
        }
    }
}