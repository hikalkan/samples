using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Add some users using "DetailedUsers" DbSet
            using (var dbContext = new MyDbContext(CreateDbContextOptions()))
            {
                dbContext.DetailedUsers.Add(new DetailedUser("john", "john@aspnetboilerplate.com"));
                dbContext.DetailedUsers.Add(new DetailedUser("neo", "neo@aspnetboilerplate.com"));
                dbContext.SaveChanges();
            }

            //Query users from "Users" DbSet
            using (var dbContext = new MyDbContext(CreateDbContextOptions()))
            {
                foreach (var user in dbContext.Users.ToList())
                {
                    Console.WriteLine(user);
                }
            }

            Console.ReadLine();
        }

        public static DbContextOptions<MyDbContext> CreateDbContextOptions()
        {
            return new DbContextOptionsBuilder<MyDbContext>()
                   .UseSqlServer("Server=localhost;Database=MyDbContextDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                   .Options;
        }
    }

    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(string userName)
        {
            Id = Guid.NewGuid();
            UserName = userName;
        }

        public override string ToString()
        {
            return $"# User => Id = {Id}, UserName = {UserName}";
        }
    }

    public class DetailedUser
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DetailedUser()
        {
            
        }

        public DetailedUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        public override string ToString()
        {
            return $"# DetailedUser => Id = {Id}, UserName = {UserName}, Email = {Email}";
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<DetailedUser> DetailedUsers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("MyUsers");
                b.Property(x => x.UserName).HasColumnName(nameof(User.UserName));
                //b.HasOne<DetailedUser>()
                //    .WithOne()
                //    .HasForeignKey<DetailedUser>(u => u.Id);
            });

            modelBuilder.Entity<DetailedUser>(b =>
            {
                b.ToTable("MyUsers");
                b.Property(x => x.UserName).HasColumnName(nameof(DetailedUser.UserName));
                b.Property(x => x.Email).HasColumnName(nameof(DetailedUser.UserName));
                b.HasOne<User>()
                    .WithOne()
                    .HasForeignKey<User>(u => u.Id);
            });
        }
    }

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            return new MyDbContext(Program.CreateDbContextOptions());
        }
    }
}
