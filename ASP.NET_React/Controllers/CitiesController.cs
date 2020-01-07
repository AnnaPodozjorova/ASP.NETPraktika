using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.NET_React.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_React.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly TodoContext _context;

        public CitiesController(TodoContext context)
        {
            _context = context;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(long id, City city)
        {
            if (id != city.id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new ObjectResult(city) { StatusCode = 200 };
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _context.city.Add(city);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CityExists(city.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return new ObjectResult(city) { StatusCode = 200 };
        }

        // POST: api/Cities/all
        [HttpPost("all")]
        public async Task<ActionResult<City>> PostCities()
        {
            var cities = new List<City> {
            new City() { id = 9009, name = "Kohtla-Järve", countrycode = "EST", district = "Ida-Virumaa", population = 35187 },
            new City() { id = 9010, name = "Jõhvi", countrycode = "EST", district = "Ida-Virumaa", population = 10051 },
            new City() { id = 9011, name = "Narva", countrycode = "EST", district = "Ida-Virumaa", population = 57842 }
            };
            _context.city.AddRange(cities);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                foreach(City city in cities)
                if (CityExists(city.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return new ObjectResult(cities) { StatusCode = 200 };
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<City>> DeleteCity(long id)
        {
            var city = await _context.city.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.city.Remove(city);
            await _context.SaveChangesAsync();

            return city;
        }

        private bool CityExists(long id)
        {
            return _context.city.Any(e => e.id == id);
        }
    }
}
