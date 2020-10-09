using System;

namespace RoutineOrganizerDomain.Models
{
    public class Todo
    {
         public Guid Id {get;set;}
        public string Description { get; set; }
        public TodoTypes  Type { get; set; }
    }
}