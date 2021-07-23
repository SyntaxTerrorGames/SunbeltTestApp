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
    public class PartiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PartiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Party>>> GetParty()
        {
            return await _context.Party.ToListAsync();
        }

        // GET: api/Parties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Party>> GetParty(long id)
        {
            var party = await _context.Party.FindAsync(id);

            if (party == null)
            {
                return NotFound();
            }

            return party;
        }

        // PUT: api/Parties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParty(long id, Party party)
        {
            if (id != party.PartyId)
            {
                return BadRequest();
            }

            _context.Entry(party).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(id))
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

        // POST: api/Parties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Party>> PostParty(Party party)
        {
            _context.Party.Add(party);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParty", new { id = party.PartyId }, party);
        }

        // DELETE: api/Parties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParty(long id)
        {
            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }

            _context.Party.Remove(party);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartyExists(long id)
        {
            return _context.Party.Any(e => e.PartyId == id);
        }
    }
}
