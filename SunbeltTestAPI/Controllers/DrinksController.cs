using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunbeltTest.API.Models;
using SunbeltTestApp.Data;

namespace SunbeltTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DrinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Drinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drink>>> GetDrink()
        {
            return await _context.Drink.ToListAsync();
        }

        // GET: api/Drinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrink(int id)
        {
            var drink = await _context.Drink.FindAsync(id);

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }

        // PUT: api/Drinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrink(int id, Drink drink)
        {
            if (id != drink.DrinkId)
            {
                return BadRequest();
            }

            _context.Entry(drink).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Drinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drink>> PostDrink(Drink drink)
        {
            _context.Drink.Add(drink);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrink", new { id = drink.DrinkId }, drink);
        }

        // DELETE: api/Drinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            var drink = await _context.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            _context.Drink.Remove(drink);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrinkExists(int id)
        {
            return _context.Drink.Any(e => e.DrinkId == id);
        }
    }
}
