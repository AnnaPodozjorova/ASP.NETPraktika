using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASP.NET_React.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASP.NET_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TodoContext _context;

        public AuthController(TodoContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<City>> PostPerson(Person pers)
        {
            _context.person.Add(pers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(pers.Login))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return new ObjectResult(pers) { StatusCode = 200 };
        }

        [HttpPost("token")]
        public ActionResult GetToken(Person pers)
        {
            //symmetric security key
            var symmetricSecurityKey = AuthOptions.GetSymmetricSecurityKey();

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //add claims
            var claims = new List<Claim>();
            var person = _context.person.Where(a => a.Login == pers.Login && a.Password == pers.Password).Single();
            if (person.Login == null)
            {
                return new NotFoundObjectResult(null);
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, person.Role));
                claims.Add(new Claim(ClaimTypes.Name, person.Login));
            }
            
            //create token
            var token = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                    , claims: claims
                );

            //return token
            
            return Content (new JwtSecurityTokenHandler().WriteToken(token));
        }

        private bool PersonExists(string login)
        {
            return _context.person.Any(e => e.Login == login);
        }
    }
}