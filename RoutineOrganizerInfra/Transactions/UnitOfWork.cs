using RoutineOrganizerDomain.Interfaces;
using RoutineOrganizerInfra.Context;

namespace RoutineOrganizerInfra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}