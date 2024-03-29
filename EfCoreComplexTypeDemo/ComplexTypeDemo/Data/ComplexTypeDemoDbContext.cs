﻿using ComplexTypeDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ComplexTypeDemo.Data;

public class ComplexTypeDemoDbContext : AbpDbContext<ComplexTypeDemoDbContext>
{
    public ComplexTypeDemoDbContext(DbContextOptions<ComplexTypeDemoDbContext> options)
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
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */

        builder.Entity<Customer>(b =>
        {
            b.ToTable("Customers");
            b.ComplexProperty(x => x.HomeAddress, a =>
            {
                a.Property(x => x.City).HasMaxLength(50).IsRequired();
            });
            b.ComplexProperty(x => x.BusinessAddress);
            //... configure other properties
        });
    }
}
