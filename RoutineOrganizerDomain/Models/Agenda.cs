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
        public virtual ICollection<ActivityDay> Activities {get;set;} 
        public  virtual ICollection<Project> Projects {get;set;} 
        public  virtual ICollection<Priority> Priorities  {get;set;} 
        public  virtual ICollection<Proud> Prouds {get;set;} 

    }
}