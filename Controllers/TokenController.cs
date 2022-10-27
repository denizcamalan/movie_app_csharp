using movie_api.Models;
using movie_api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using movie_api.Interface;
using System.Text;

namespace movie_api.Controllers
{
    [Route("movie_archive")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;

        private readonly IUser _IUsers;
        public UserController(IConfiguration config, DatabaseContext context, IUser IUsers)
        {
            _configuration = config;
            _context = context;
            _IUsers = IUsers;
        }

        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(Users Users)
        {                               
            _IUsers.AddUser(Users);
            if (Users == null)
                return BadRequest();
            return Created("",await Task.FromResult(Users));
        }

        [AllowAnonymous]
        [Route("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Post(Users Users)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == Users.Name && u.Password == Users.Password);

            if (user != null)
            {
                //create claims details based on the user information
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("user_id", user.Id.ToString()),
                    new Claim("user_name", user.Name),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

    }
}
