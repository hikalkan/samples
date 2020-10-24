using EventOrganizer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EventOrganizer
{
    [DependsOn(
        typeof(EventOrganizerEntityFrameworkCoreTestModule)
        )]
    public class EventOrganizerDomainTestModule : AbpModule
    {

    }
}