using Microsoft.EntityFrameworkCore;
using SunbeltTestApp.EFMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyAttendee> PartyAttendees { get; set; }
    }
}
