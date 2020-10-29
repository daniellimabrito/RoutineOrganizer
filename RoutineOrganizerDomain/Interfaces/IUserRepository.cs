using System;
using System.Threading.Tasks;
using RoutineOrganizerDomain.Models;
using System.Collections.Generic;

namespace RoutineOrganizerDomain.Interfaces
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(Guid id);
    }
}