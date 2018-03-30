using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreGlobalFilterBugDemo
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            return new MyDbContext();
        }
    }
}