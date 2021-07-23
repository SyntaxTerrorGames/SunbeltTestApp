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
    public class AttendeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendee()
        {
            return await _context.Attendee.ToListAsync();
        }

        // GET: api/Attendees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendee>> GetAttendee(long id)
        {
            var attendee = await _context.Attendee.FindAsync(id);

            if (attendee == null)
            {
                return NotFound();
            }

            return attendee;
        }

        // PUT: api/Attendees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendee(long id, Attendee attendee)
        {
            if (id != attendee.AttendeeId)
            {
                return BadRequest();
            }

            _context.Entry(attendee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendeeExists(id))
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

        // POST: api/Attendees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendee>> PostAttendee(Attendee attendee)
        {
            _context.Attendee.Add(attendee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendee", new { id = attendee.AttendeeId }, attendee);
        }

        // DELETE: api/Attendees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(long id)
        {
            var attendee = await _context.Attendee.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }

            _context.Attendee.Remove(attendee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendeeExists(long id)
        {
            return _context.Attendee.Any(e => e.AttendeeId == id);
        }
    }
}
