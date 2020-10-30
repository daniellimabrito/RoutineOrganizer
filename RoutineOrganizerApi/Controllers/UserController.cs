using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutineOrganizerDomain.Interfaces;

namespace RoutineOrganizerApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}", Name="GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _repo.GetUser(id);

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repo.GetUsers();

            return Ok(users);
        }
    }
}