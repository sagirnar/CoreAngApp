using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using DattingApp.API.Data;
using DattingApp.API.DTO;
using DattingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DattingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository repo, IConfiguration configuration)
        {
            _configuration = configuration;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegister)
        {
            
            userForRegister.UserName = userForRegister.UserName.ToLower();

            if (await _repo.UserExists(userForRegister.UserName))
                return BadRequest("User already exists");

            var usertoCreate = new User()
            {
                Username = userForRegister.UserName
            };

            var createdUser = await _repo.Register(usertoCreate, userForRegister.Password);

            return StatusCode(201);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userforLogin)
        {
            throw new Exception("Error Occured while Login");
            var userFromRepo = await _repo.Login(userforLogin.UserName, userforLogin.Password);
            if (userFromRepo == null)
                return Unauthorized();
          
            var claims = new[] {
                       new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                       new Claim(ClaimTypes.Name,userFromRepo.Username)
                   };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                 Subject = new ClaimsIdentity(claims),
                 Expires = DateTime.Now.AddDays(1),
                 SigningCredentials = creds
            };  
            var tokenHandler = new JwtSecurityTokenHandler(); 

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok( new { token = tokenHandler.WriteToken(token) });

        }
    }
}