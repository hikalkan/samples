using Microsoft.EntityFrameworkCore;
using UserRelationsDemo.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace UserRelationsDemo.Data;

public class UserRelationsDemoDbContext : AbpDbContext<UserRelationsDemoDbContext>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<UserBook> UserBooks { get; set; }

    public UserRelationsDemoDbContext(DbContextOptions<UserRelationsDemoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
/*
        builder.Entity<IdentityUser>(b =>
        {
            b.HasMany<Book>("Readings").WithMany(x => x.Readers);
        });
*/
        builder.Entity<Book>(b =>
        {
            b.ToTable("Books");
            b.ConfigureByConvention();
            b.Property(x => x.Name).HasMaxLength(100);
            b.HasIndex(x => x.Name).IsUnique();
        });
        
        builder.Entity<UserBook>(b =>
        {
            b.ToTable("UserBooks");
            b.ConfigureByConvention();

            b.HasOne(x => x.User).WithMany().HasForeignKey("UserId");
            b.HasOne(x => x.Book).WithMany().HasForeignKey("BookId");
        });
    }
}
