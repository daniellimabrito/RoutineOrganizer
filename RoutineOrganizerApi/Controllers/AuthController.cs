using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutineOrganizerDomain.Dtos;
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
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            if (await _repo.UserExists(userForRegisterDto.UserName))
                return BadRequest("User already exists");

                var userToCreate = new User {
                    UserName = userForRegisterDto.UserName,
                    Created = DateTime.Now                  
                };
                
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return CreatedAtRoute("GetUser", new { controller = "User", id = createdUser.Id }, createdUser);
        } 
    }
}