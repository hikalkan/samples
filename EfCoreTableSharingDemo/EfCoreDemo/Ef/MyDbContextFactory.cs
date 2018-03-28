using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreDemo.Ef
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            return new MigrationDbContext(Program.CreateDbContextOptions<MigrationDbContext>());
        }
    }
}