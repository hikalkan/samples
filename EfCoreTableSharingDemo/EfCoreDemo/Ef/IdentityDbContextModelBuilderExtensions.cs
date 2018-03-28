using EfCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Ef
{
    public static class IdentityDbContextModelBuilderExtensions
    {
        public static void ConfigureIdentity(this ModelBuilder modelBuilder, bool integrateUsers = false)
        {
            if (integrateUsers)
            {
                modelBuilder.ConfigureDefaultUser();
            }

            modelBuilder.Entity<IdentityUser>(b =>
            {
                b.ConfigureDefaultUser();

                b.Property(x => x.Password).HasMaxLength(256);

                if (integrateUsers)
                {
                    b.HasOne<DefaultUser>()
                        .WithOne()
                        .HasForeignKey<DefaultUser>(u => u.Id);
                }
            });
        }
    }
}