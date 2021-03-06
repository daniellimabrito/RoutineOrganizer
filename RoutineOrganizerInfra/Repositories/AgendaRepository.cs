using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RoutineOrganizerDomain.Interfaces;
using RoutineOrganizerDomain.Models;
using RoutineOrganizerInfra.Context;

namespace RoutineOrganizerInfra.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly DataContext _context;
        public AgendaRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Agenda obj)
        {
            _context.Add(obj);
        }

        public IEnumerable<Agenda> GetAll()
        {
            return _context.Agendas.ToList();

/*
                .Include(x => x.Activities)
                .Include(x => x.Projects)
                .Include(x => x.Priorities)
                .Include(x => x.Prouds)
                .ToList();
                */
        }

        public Agenda GetById(Guid id)
        {
            return _context.Agendas.FirstOrDefault(x => x.Id == id);
            /*
                .Include(x => x.Activities)
                .Include(x => x.Projects)
                .Include(x => x.Priorities)
                .Include(x => x.Prouds)
            .FirstOrDefault(x => x.Id == id);
            */
        }

        public Agenda GetByPeriod(DateTime period)
        {
            return _context.Agendas.FirstOrDefault(x => x.Period.Year == period.Year && x.Period.Month == period.Month);
        }

        public void Remove(Guid id)
        {
            var obj = new Agenda() { Id = id };

            _context.Agendas.Remove(obj);
        }

        public void Update(Agenda obj)
        {
            _context.Agendas.Update(obj);
           // _context.Entry(obj).State = EntityState.Modified;

        }
    }
}