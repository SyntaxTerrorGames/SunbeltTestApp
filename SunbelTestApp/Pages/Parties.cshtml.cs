using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SunbeltTestApp.Data;
using SunbeltTestApp.EFMigrations;
using SunbeltTestApp.Interfaces;

namespace SunbeltTestApp.Pages
{
    public class PartiesModel : PageModel
    {
        private readonly IRepository<Party> _repository;

        public PartiesModel(IRepository<Party> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string PartyName { get; set; }
            public DateTime PartyDate { get; set; }
        }

        public List<Party> Parties { get; set; }

        public async Task OnGet()
        {
            Parties = await _repository.ReadAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Party newParty = new Party
            {
                PartyName = Input.PartyName,
                PartyDate = Input.PartyDate
            };

            await _repository.CreateAsync(newParty);

            return RedirectToPage();
        }
    }
}
