using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreValueConverterDemo
{
    public class QaDbContextFactory : IDesignTimeDbContextFactory<QaDbContext>
    {
        public QaDbContext CreateDbContext(string[] args)
        {
            return new QaDbContext(Program.CreateDbContextOptions<QaDbContext>());
        }
    }
}