using System;

namespace RoutineOrganizerDomain.Models
{
    public class Activity
    {
        public Guid Id {get;set;}
        public DateTime Day { get; set; }
        public string Interval { get; set; }
    }
}