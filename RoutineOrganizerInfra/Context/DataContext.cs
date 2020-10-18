using Microsoft.EntityFrameworkCore;
using RoutineOrganizerDomain.Models;

namespace RoutineOrganizerInfra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {}

        public DbSet<Todo> Todos {get;set;}

        public DbSet<Agenda> Agendas {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Activity>()
                .HasKey(a => a.Id);    

            modelBuilder.Entity<Project>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Priority>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Proud>()
                .HasKey(a => a.Id);                                                
 
            modelBuilder.Entity<ActivityDay>()
                .HasKey(a => a.Id); 
        }
        

    }
}