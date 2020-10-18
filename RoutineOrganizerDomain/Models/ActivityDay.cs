using System;

namespace RoutineOrganizerDomain.Models
{
    public class ActivityDay
    {
        public Guid Id {get;set;}
        public DateTime Day { get; set; }
        public string Interval { get; set; }

    }
}