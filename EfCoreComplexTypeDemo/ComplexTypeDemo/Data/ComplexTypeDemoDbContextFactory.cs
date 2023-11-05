using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ComplexTypeDemo.Data;

public class ComplexTypeDemoDbContextFactory : IDesignTimeDbContextFactory<ComplexTypeDemoDbContext>
{
    public ComplexTypeDemoDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ComplexTypeDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ComplexTypeDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
