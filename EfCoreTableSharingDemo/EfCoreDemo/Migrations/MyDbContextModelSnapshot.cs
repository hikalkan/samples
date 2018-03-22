﻿// <auto-generated />
using EfCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfCoreDemo.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreDemo.DetailedUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasColumnName("Email");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("MyUsers");
                });

            modelBuilder.Entity("EfCoreDemo.User", b =>
                {
                    b.Property<Guid>("Id");

                    b.Property<string>("UserName")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("MyUsers");
                });

            modelBuilder.Entity("EfCoreDemo.User", b =>
                {
                    b.HasOne("EfCoreDemo.DetailedUser")
                        .WithOne("User")
                        .HasForeignKey("EfCoreDemo.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
