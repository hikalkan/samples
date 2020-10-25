using System;
using System.Collections.Generic;

namespace EventOrganizer.Events
{
    public class EventDetailDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFree { get; set; }

        public DateTime StartTime { get; set; }

        public List<EventAttendeeDto> Attendees { get; set; }
    }
}
