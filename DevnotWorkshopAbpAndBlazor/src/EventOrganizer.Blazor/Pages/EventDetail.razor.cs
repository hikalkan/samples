using System;
using System.Threading.Tasks;
using EventOrganizer.Events;
using Microsoft.AspNetCore.Components;

namespace EventOrganizer.Blazor.Pages
{
    public partial class EventDetail
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        private IEventAppService EventAppService { get; set; }

        private EventDetailDto Event { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Event = await EventAppService.GetAsync(Guid.Parse(Id));
        }
    }
}
