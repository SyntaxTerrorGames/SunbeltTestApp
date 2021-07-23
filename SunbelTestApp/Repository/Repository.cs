using Microsoft.EntityFrameworkCore;
using SunbeltTestApp.Data;
using SunbeltTestApp.EFMigrations;
using SunbeltTestApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.Repository
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> ReadAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<PartyAttendee>> ReadAllPartiesByPerson(long personId)
        {
            return await _context.PartyAttendees.Include(i => i.Party)
                .Include(i => i.Drink).Include(i => i.Person).Where(p=>p.PersonId == personId).ToListAsync();
        }

        public async Task<List<PartyAttendee>> ReadSingleParty(long partyId)
        {
            return await _context.PartyAttendees.Include(i => i.Party)
                .Include(i => i.Drink).Include(i => i.Person).Where(p => p.PartyId == partyId).ToListAsync();
        }

        public async Task<List<PartyAttendee>> ReadAllPartyAttendeesAsync()
        {
            return await _context.PartyAttendees.Include(i => i.Party)
                .Include(i => i.Drink).Include(i => i.Person).ToListAsync();
        }
    }
}
