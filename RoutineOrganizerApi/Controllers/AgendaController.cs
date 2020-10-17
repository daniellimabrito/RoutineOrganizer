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
        private readonly IAgendaRepository _repo;

        private List<Agenda> objAgenda = new List<Agenda>();

        public AgendaController(IAgendaRepository repo)
        {
           _repo = repo;

          

       /*      objAgenda.Add( new Agenda() { 
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
                
                });                */
        }

     //   public AgendaController(DataContext context)
     //   {
      //      _dataContext = context;
      //  }

        [HttpGet]
        public IEnumerable<Agenda> Get([FromServices] IAgendaRepository agendaRepository)
        {
            return  agendaRepository.GetAll();
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] Agenda objAgenda,
            [FromServices] IAgendaRepository agendaRepository, 
            [FromServices]IUnitOfWork uow)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            agendaRepository.Add(objAgenda);
            uow.Commit();

            return Ok(objAgenda);
        }

        [HttpPut("{id}")]
        [Route("")]
        public IActionResult Put(Guid id, [FromBody] Agenda agenda,
            [FromServices] IAgendaRepository agendaRepository,
            [FromServices] IUnitOfWork uow
        ) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var objAgenda = agendaRepository.GetById(id);

            objAgenda.Name = agenda.Name;

            agendaRepository.Update(objAgenda);
            uow.Commit();

            return Ok(objAgenda);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id,
            [FromServices] IAgendaRepository agendaRepository,
            [FromServices] IUnitOfWork uow
        )
        {
            try
            {
                agendaRepository.Remove(id);
                uow.Commit();

                return Ok($"Agenda number {id} removed.");
            }
                catch (System.Exception)
            {
                return NoContent();
            }

        }
    }
}