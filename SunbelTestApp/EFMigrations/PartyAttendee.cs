using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.EFMigrations
{
    public class PartyAttendee
    {
        [Key]
        public long PartyAttendeeId { get; set; }
        public long PartyId { get; set; }
        public long PersonId { get; set; }
        public int DrinkId { get; set; }

        public virtual Party Party { get; set; }
        public virtual Person Person { get; set; }
        public virtual Drink Drink { get; set; }
    }
}
