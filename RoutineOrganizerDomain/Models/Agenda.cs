using System;
using System.Collections.Generic;

namespace RoutineOrganizerDomain.Models
{
    public class Agenda
    {
        
        public Guid Id {get;set;}
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Period { get; set; }
        public  List<string> Activities {get;set;} 
        public  List<string> Projects {get;set;} 
        public  List<string> Priorities  {get;set;} 
        public  List<string> Prouds {get;set;} 
    }
}