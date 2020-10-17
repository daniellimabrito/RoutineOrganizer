using System;
using System.Collections.Generic;
using RoutineOrganizerDomain.Models;

namespace RoutineOrganizerDomain.Interfaces
{
    public interface IAgendaRepository
    {
         void Add(Agenda obj);
         void Remove(Guid id);
         void Update(Agenda obj);
         IEnumerable<Agenda> GetAll();
         Agenda GetById(Guid id);

    }
}