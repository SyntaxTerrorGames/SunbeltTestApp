using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SunbeltTestApp.Data;
using SunbeltTestApp.EFMigrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunbelTestApp.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context { get; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Person> People { get; set; }

        public void OnGet()
        {
            People = (from attendee in _context.People.Take(10)
                         select attendee).ToList();
        }
    }
}
