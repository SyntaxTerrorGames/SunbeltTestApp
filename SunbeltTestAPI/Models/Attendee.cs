using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTest.API.Models
{
    public class Attendee
    {
        public virtual long AttendeeId { get; set; }
        public virtual string AttendeeName { get; set; }

        public virtual int DrinkId { get; set; }

        public virtual Drink Drink { get; set; }
    }
}
