using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventOrganizer.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class EventOrganizerMigrationsDbContextFactory : IDesignTimeDbContextFactory<EventOrganizerMigrationsDbContext>
    {
        public EventOrganizerMigrationsDbContext CreateDbContext(string[] args)
        {
            EventOrganizerEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<EventOrganizerMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new EventOrganizerMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EventOrganizer.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
