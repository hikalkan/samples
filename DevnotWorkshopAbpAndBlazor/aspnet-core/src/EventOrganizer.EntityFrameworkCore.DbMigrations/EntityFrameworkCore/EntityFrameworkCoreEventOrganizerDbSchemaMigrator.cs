using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventOrganizer.Data;
using Volo.Abp.DependencyInjection;

namespace EventOrganizer.EntityFrameworkCore
{
    public class EntityFrameworkCoreEventOrganizerDbSchemaMigrator
        : IEventOrganizerDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreEventOrganizerDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the EventOrganizerMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<EventOrganizerMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}