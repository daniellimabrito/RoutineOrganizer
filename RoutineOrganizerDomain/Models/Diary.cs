using System;
using System.Collections.Generic;

namespace RoutineOrganizerDomain.Models
{
    public class Diary
    {
         public Guid Id {get;set;}
        public string Name { get; set; }
        public int Period { get; private set; }

        public  IEnumerable<Activity> Activities {get;set;} 
        public  IEnumerable<Project> Projects {get;set;} 
        public  IEnumerable<Priority> Priorities  {get;set;} 
        public  IEnumerable<Grateful> Gratefuls {get;set;} 

    }
}