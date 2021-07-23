using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.EFMigrations
{
    public class Party
    {
        [Key]
        public long PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime PartyDate { get; set; }

        // Notes: System could be upgraded by including a relational table that allows
        // user to choose which drinks are available at the current party.
        
        public virtual List<Person> People { get; set; }
    }
}
