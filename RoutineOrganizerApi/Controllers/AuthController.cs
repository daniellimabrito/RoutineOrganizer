using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoutineOrganizerDomain.Dtos;
using RoutineOrganizerDomain.Interfaces;
using RoutineOrganizerDomain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.JWT;
using System.IdentityModel.Tokens.Jwt;

namespace RoutineOrganizerApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            if (await _repo.UserExists(userForRegisterDto.Email))
                return BadRequest("E-mail already exists");

                var userToCreate = new User {
                    UserName = userForRegisterDto.UserName,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    Email = userForRegisterDto.Email,
                    Created = DateTime.Now                  
                };
                
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return CreatedAtRoute("GetUser", new { controller = "User", id = createdUser.Id }, createdUser);
        } 

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto) 
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Email.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
                return Unauthorized(new UserForRegisterDto(){ Email = userForLoginDto.Email, Password = userForLoginDto.Password });

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Email)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

              //  var user = _mapper.Map<UserForListDto>(userFromRepo);

                var user = new User() {
                    Id = userFromRepo.Id,
                    LastName = userFromRepo.LastName,
                    FirstName = userFromRepo.FirstName,
                    Email = userFromRepo.Email
                };

                return Ok(new {
                    token = tokenHandler.WriteToken(token),
                    user 
                });    

        }
    }
}