using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTest.API.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }

        public virtual List<Attendee> Attendees { get; set; }
    }
}
