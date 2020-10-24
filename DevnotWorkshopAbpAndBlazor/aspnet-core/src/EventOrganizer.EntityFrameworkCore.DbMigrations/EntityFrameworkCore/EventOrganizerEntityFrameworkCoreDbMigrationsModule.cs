using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace EventOrganizer.EntityFrameworkCore
{
    [DependsOn(
        typeof(EventOrganizerEntityFrameworkCoreModule)
        )]
    public class EventOrganizerEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EventOrganizerMigrationsDbContext>();
        }
    }
}
