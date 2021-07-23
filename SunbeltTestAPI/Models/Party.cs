using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTest.API.Models
{
    public class Party
    {
        public long PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime PartyDate { get; set; }

        public virtual List<Attendee> Attendees { get; set; }
    }
}
