using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.EFMigrations
{
    public class Drink
    {
        [Key]
        public int DrinkId { get; set; }
        public string Name { get; set; }

        public virtual List<PartyAttendee> PartyAttendees { get; set; }
    }
}
