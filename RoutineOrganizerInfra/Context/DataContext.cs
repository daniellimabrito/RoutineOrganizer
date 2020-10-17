using Microsoft.EntityFrameworkCore;
using RoutineOrganizerDomain.Models;

namespace RoutineOrganizerInfra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}

        //public DbSet<ActivityDay> Activities {get;set;}

        public DbSet<Todo> Todos {get;set;}

        public DbSet<Agenda> Agendas {get;set;}
        

    }
}