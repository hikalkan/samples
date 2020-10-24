using System.Threading.Tasks;
using EventOrganizer.Events;
using Microsoft.AspNetCore.Components;

namespace EventOrganizer.Blazor.Pages
{
    public partial class CreateEvent
    {
        private EventCreationDto Event { get; set; } = new EventCreationDto();

        [Inject]
        private IEventAppService EventAppService { get; set; }

        private async Task Create()
        {
            await EventAppService.CreateAsync(Event);
        }
    }
}
