using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace EventOrganizer.EntityFrameworkCore
{
    public static class EventOrganizerDbContextModelCreatingExtensions
    {
        public static void ConfigureEventOrganizer(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(EventOrganizerConsts.DbTablePrefix + "YourEntities", EventOrganizerConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}