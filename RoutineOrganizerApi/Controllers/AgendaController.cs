using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RoutineOrganizerDomain.Models;
using RoutineOrganizerInfra.Context;
using System;
using RoutineOrganizerDomain.Interfaces;


namespace RoutineOrganizerApi.Controllers
{
    [ApiController]
    [Route("v1/agenda")]
    public class AgendaController : ControllerBase
    {
     //   private readonly DataContext _dataContext;

        private List<Agenda> objAgenda = new List<Agenda>();

        public AgendaController()
        {
           // _dataContext = new DataContext();

          

            objAgenda.Add( new Agenda() { 
                Id = Guid.NewGuid(), Name = "Test", Period = DateTime.Now, 
                Notes = DateTime.Now.ToString("MMMM dd, yyyy"),
                Projects = new List<string>() {"Find a new job", "Buy a car", "Travel"}, 
                Activities = new List<string>(){"YOGA", "BJJ", "Office"},
                Priorities = new List<string>(){"Go to the grocery"},
                Prouds = new List<string>(){"Diet still good"}
                
                });

            objAgenda.Add( new Agenda() { 
                Id = Guid.NewGuid(), Name = "Test 2", Period = DateTime.Now, 
                Notes = DateTime.Now.ToString("yyyy MMMM"),
                Projects = new List<string>() {"Paint the wall", "Fix the oven", "Clean the house"}, 
                Activities = new List<string>(){"Bar", "School", "Pool"},
                Priorities = new List<string>(){"Pick-up Tomas"},
                Prouds = new List<string>(){"Ran 5km"}
                
                });               
        }

     //   public AgendaController(DataContext context)
     //   {
      //      _dataContext = context;
      //  }

        [HttpGet]
        public IEnumerable<Agenda> Get()
        {
            return  objAgenda;//_dataContext.Agendas;
        }
    }
}