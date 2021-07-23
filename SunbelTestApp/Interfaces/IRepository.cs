using SunbeltTestApp.EFMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task CreateAsync(T entity);
        Task<List<T>> ReadAllAsync();

        Task<List<PartyAttendee>> ReadAllPartiesByPerson(long personId);
        Task<List<PartyAttendee>> ReadSingleParty(long partyId);
        Task<List<PartyAttendee>> ReadAllPartyAttendeesAsync();
    }
}
