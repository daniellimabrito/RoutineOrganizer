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

        }
        
        [HttpGet]
        public IEnumerable<Agenda> Get([FromServices] IAgendaRepository agendaRepository)
        {
            return  agendaRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Route("GetAgenda")]
        public Agenda GetAgenda(Guid id, [FromServices] IAgendaRepository agendaRepository) {

            var agenda = agendaRepository.GetById(id);
            if (agenda == null)
                return new Agenda();

            return agenda;
        }

        [HttpGet("GetByPeriod/{id}")]
        [Route("GetByPeriod")]
        public Agenda GetByPeriod(string id, [FromServices] IAgendaRepository agendaRepository) {
            var obj = Convert.ToDateTime(id);
            var agenda = agendaRepository.GetByPeriod(obj);

            if (agenda == null)
                return new Agenda(); // {  Name = null, Notes = null, Period = DateTime.Now, Activities = null, Projects = null, Priorities = null, Prouds = null };

            return agenda;

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

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] Agenda agenda,
            [FromServices] IAgendaRepository agendaRepository,
            [FromServices] IUnitOfWork uow
        ) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

         //   var objAgenda = agendaRepository.GetById(id);

          //  objAgenda.Name = agenda.Name;


            agendaRepository.Update(agenda);
            uow.Commit();

            return Ok(agenda);

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