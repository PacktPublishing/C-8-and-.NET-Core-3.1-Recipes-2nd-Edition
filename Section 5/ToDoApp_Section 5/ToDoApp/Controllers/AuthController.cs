using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.DTO;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ToDoApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<User> _userManager;
        private AppDbContext _context;
        private SignInManager<User> _signInManager;
        private string _secret = "APP_SECRET";

        public AuthController(UserManager<User> userManager, AppDbContext context, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            await _userManager.CreateAsync(user);
            var created = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            SecurityToken token = GetToken(created);
            return Ok(token);
        }

        private SecurityToken GetToken(User created)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, created.Id.ToString())
                }),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
            if (result.Succeeded)
            {
                var loggedIn = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                return Ok(GetToken(loggedIn));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}