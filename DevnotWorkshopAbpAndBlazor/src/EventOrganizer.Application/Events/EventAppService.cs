using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Repositories;

namespace EventOrganizer.Events
{
    public class EventAppService : EventOrganizerAppService, IEventAppService
    {
        private readonly IRepository<Event, Guid> _eventRepository;

        public EventAppService(IRepository<Event, Guid> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [Authorize]
        public async Task<Guid> CreateAsync(EventCreationDto input)
        {
            var eventEntity = ObjectMapper.Map<EventCreationDto, Event>(input);
            await _eventRepository.InsertAsync(eventEntity);
            return eventEntity.Id;
        }
    }
}
