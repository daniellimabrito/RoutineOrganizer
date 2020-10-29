using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutineOrganizerDomain.Interfaces;
using RoutineOrganizerDomain.Models;

namespace RoutineOrganizerApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _repo.UserExists(user.UserName))
                return BadRequest("User already exists");

            var createdUser = await _repo.Register(user, user.Password);

            return CreatedAtRoute("GetUser", new { controller = "User", id = createdUser.Id }, createdUser);
        }
    }
}