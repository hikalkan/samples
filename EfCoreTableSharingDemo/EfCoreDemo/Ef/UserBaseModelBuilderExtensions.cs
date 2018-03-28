using EfCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreDemo.Ef
{
    public static class UserBaseModelBuilderExtensions
    {
        public static void ConfigureDefaultUser<T>(this EntityTypeBuilder<T> b) 
            where T : class, IUser
        {
            b.ToTable("Users");
            b.Property(x => x.UserName).IsRequired().HasMaxLength(128).HasColumnName(nameof(DefaultUser.UserName));
        }

        public static void ConfigureDefaultUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefaultUser>(b =>
            {
                b.ConfigureDefaultUser();

                //b.HasOne<UserBase>()
                //    .WithOne()
                //    .HasForeignKey<UserBase>(u => u.Id);
            });
        }
    }
}