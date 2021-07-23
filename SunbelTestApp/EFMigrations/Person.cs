using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SunbeltTestApp.EFMigrations
{
    public class Person
    {
        [Key]
        public virtual long PersonId { get; set; }
        public virtual string Name { get; set; }
       
        public virtual List<PartyAttendee> PartyAttendees { get; set; }
    }
}
