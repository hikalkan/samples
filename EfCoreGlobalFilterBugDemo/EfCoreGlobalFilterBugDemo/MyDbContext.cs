using Microsoft.EntityFrameworkCore;

namespace EfCoreGlobalFilterBugDemo
{
    public class MyDbContext : MyDbContextBase<MyDbContext>
    {
        public DbSet<User> Users { get; set; }

        public MyDbContext()
            : base(CreateDbContextOptions())
        {

        }

        public static DbContextOptions<MyDbContext> CreateDbContextOptions()
        {
            return new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=localhost;Database=EfCoreGlobalFilterBugDemo;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;
        }
    }
}
