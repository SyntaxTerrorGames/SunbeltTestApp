using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunbeltTest.API.Models;

namespace SunbeltTestApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
        public DbSet<SunbeltTest.API.Models.Party> Party { get; set; }
        public DbSet<SunbeltTest.API.Models.Drink> Drink { get; set; }
        public DbSet<SunbeltTest.API.Models.Attendee> Attendee { get; set; }
    }
}
