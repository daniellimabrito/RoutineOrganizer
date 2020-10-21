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
            return agendaRepository.GetById(id);
        }

        [HttpGet("GetByPeriod/{id}")]
        [Route("GetByPeriod")]
        public Agenda GetByPeriod(string id, [FromServices] IAgendaRepository agendaRepository) {
            var obj = Convert.ToDateTime(id);
            return agendaRepository.GetByPeriod(obj);
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