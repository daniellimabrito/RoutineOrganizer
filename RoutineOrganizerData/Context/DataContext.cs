using Microsoft.EntityFrameworkCore;
using RoutineOrganizerDomain.Models;

namespace RoutineOrganizerData.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}

        public DbSet<ActivityDay> Activities {get;set;}

        public DbSet<Todo> Todos {get;set;}
        
    }
}