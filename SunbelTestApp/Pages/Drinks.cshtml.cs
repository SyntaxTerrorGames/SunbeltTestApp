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
    public class DrinksModel : PageModel
    {
        private readonly IRepository<Drink> _repository;

        public DrinksModel(IRepository<Drink> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }
        }

        public List<Drink> Drinks { get; set; }

        public async Task OnGet()
        {
            Drinks = await _repository.ReadAllAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Drink newDrink = new Drink
            {
                Name = Input.Name
            };

            await _repository.CreateAsync(newDrink);

            return RedirectToPage();
        }
    }
}
