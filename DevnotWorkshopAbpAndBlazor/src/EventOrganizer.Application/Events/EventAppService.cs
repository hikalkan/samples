using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EventOrganizer.Users;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Domain.Repositories;

namespace EventOrganizer.Events
{
    public class EventAppService : EventOrganizerAppService, IEventAppService
    {
        private readonly IRepository<Event, Guid> _eventRepository;
        private readonly IRepository<AppUser, Guid> _userRepository;

        public EventAppService(
            IRepository<Event, Guid> eventRepository,
            IRepository<AppUser, Guid> userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        [Authorize]
        public async Task<Guid> CreateAsync(EventCreationDto input)
        {
            var eventEntity = ObjectMapper.Map<EventCreationDto, Event>(input);
            await _eventRepository.InsertAsync(eventEntity);
            return eventEntity.Id;
        }

        public async Task<EventDetailDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            var attendeeIds = @event.Attendees.Select(a => a.UserId).ToList();
            var attendees = (await AsyncExecuter.ToListAsync(_userRepository.Where(u => attendeeIds.Contains(u.Id))))
                .ToDictionary(x => x.Id);

            var result = ObjectMapper.Map<Event, EventDetailDto>(@event);
            foreach (var attendeeDto in result.Attendees)
            {
                attendeeDto.UserName = attendees[attendeeDto.UserId].UserName;
            }

            return result;
        }
    }
}
