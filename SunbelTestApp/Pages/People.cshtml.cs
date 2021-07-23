using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SunbeltTestApp.Data;
using SunbeltTestApp.EFMigrations;
using SunbeltTestApp.Interfaces;

namespace SunbeltTestApp.Pages
{
    public class AttendeesModel : PageModel
    {
        private readonly IRepository<Person> _repository;

        public AttendeesModel(IRepository<Person> repository)
        {
            _repository = repository;
            //PopulateDrinksList();
        }

        public SelectList DrinksList { get; set; }
        public SelectList PartyList { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Name { get; set; }
        }

        public List<Person> People { get; set; }

        public async Task OnGet()
        {
            People = await _repository.ReadAllAsync();
        }

        //public void PopulateDrinksList()
        //{
        //    var drinks = from drink in _context.Drinks
        //                 orderby drink.Name
        //                 select drink;

        //    DrinksList = new SelectList(drinks, "DrinkId", "Name");
        //}

        //public void PopulatePartyList()
        //{
        //    var parties = from party in _context.Parties
        //                  select party;

        //    PartyList = new SelectList(parties, "PartyId", "PartyName");
        //}


        public async Task<IActionResult> OnPostAsync()
        {
            Person newPerson = new Person
            {
                Name = Input.Name
            };

            if (ModelState.IsValid)
                await _repository.CreateAsync(newPerson);

            return RedirectToPage();
        }
    }
}
