using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET.Controllers
{
    [Route("api/v1/world/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly TodoContext _context;

        public CountriesController(TodoContext context)
        {
            _context = context;
        }

        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        [Authorize(Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }

        // GET: api/v1/world/Countries/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Country>>> Getcountry()
        {
            return await _context.country.ToListAsync();
        }

        // GET: api/v1/world/Countries/AUT
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(string id)
        {
            var country = await _context.country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // GET: api/v1/world/Countries/continent/{name} (Europe)
        [HttpGet("continent/{name}")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesByContinent(string name)
        {
            var country = await _context.country.Where(a => a.continent == name).ToListAsync();

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // GET: api/v1/world/Countries/Indep/{year} (1997)
        [HttpGet("Indep/{name}")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountriesByIndependenceYear(string name)
        {
            var country = await _context.country.Where(a => a.indepyear == name).ToListAsync();

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // GET: api/v1/world/Countries/Estonia/city/all
        [HttpGet("{name}/city/all")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(string name)
        {
            var country = await _context.country.Where(a => a.name == name).ToListAsync();

            if (country == null)
            {
                return NotFound();
            }
            try
            {
                var cities = await _context.city.Where(a => a.countrycode == country[0].code).ToListAsync();
                return cities;
            }
            catch { }
            return NotFound();
        }

        private bool CountryExists(string id)
        {
            return _context.country.Any(e => e.code == id);
        }
    }
}
