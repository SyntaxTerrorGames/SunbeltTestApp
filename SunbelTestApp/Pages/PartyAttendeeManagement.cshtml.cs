using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SunbeltTestApp.EFMigrations;
using SunbeltTestApp.Interfaces;

namespace SunbeltTestApp.Pages
{
    public class PartyAttendeeManagementModel : PageModel
    {
        private readonly IRepository<PartyAttendee> _partyAttendeeRepository;
        private readonly IRepository<Party> _partyRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Drink> _drinkRepository;

        public PartyAttendeeManagementModel(IRepository<PartyAttendee> partyAttendeeRepository,
            IRepository<Party> partyRepository, IRepository<Person> personRepository,
            IRepository<Drink> drinkRepository)
        {
            _partyAttendeeRepository = partyAttendeeRepository;
            _partyRepository = partyRepository;
            _drinkRepository = drinkRepository;
            _personRepository = personRepository;
        }

        public SelectList PartyList { get; set; }
        public SelectList PersonList { get; set; }
        public SelectList DrinkList { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public long PartyId { get; set; }
            public int DrinkId { get; set; }
            public long PersonId {get;set;}

            public long PersonFilterId { get; set; }
            public long PartyFilterId { get; set; }
        }

        public List<PartyAttendee> PartyAttendees { get; set; }

        private async Task PopulatePartyListAsync()
        {
            var parties = await _partyRepository.ReadAllAsync();

            Party emptyParty = new Party();
            parties.Insert(0, emptyParty);

            PartyList = new SelectList(parties, "PartyId", "PartyName");
        }

        private async Task PopulatePersonList()
        {
            var people = await _personRepository.ReadAllAsync();

            Person emptyPerson = new Person();
            people.Insert(0, emptyPerson);

            PersonList = new SelectList(people, "PersonId", "Name");
        }

        private async Task PopulateDrinkList()
        {
            var drinks = await _drinkRepository.ReadAllAsync();

            Drink emptyDrink = new Drink();
            drinks.Insert(0, emptyDrink);

            DrinkList = new SelectList(drinks, "DrinkId", "Name");
        }

        public async Task OnGet()
        {
            await PopulatePartyListAsync();
            await PopulatePersonList();
            await PopulateDrinkList ();
            PartyAttendees = await _partyAttendeeRepository.ReadAllPartyAttendeesAsync();
        }

        /// <summary>
        /// Changes to filter select lists redirect here
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // Check person filter
            if (Input.PersonFilterId != 0)
                PartyAttendees = await _partyAttendeeRepository.ReadAllPartiesByPerson(Input.PersonFilterId);
            else if (Input.PartyFilterId != 0)
                PartyAttendees = await _partyAttendeeRepository.ReadSingleParty(Input.PartyFilterId);
            else
                PartyAttendees = await _partyAttendeeRepository.ReadAllAsync();

            await PopulatePartyListAsync();
            await PopulatePersonList();
            await PopulateDrinkList();

            return Page();
        }

        /// <summary>
        /// Form post redirects here
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostSubmitAsync()
        {
            PartyAttendee newPartyAttendee = new PartyAttendee
            {
                DrinkId = Input.DrinkId,
                PartyId = Input.PartyId,
                PersonId = Input.PersonId
            };

            await _partyAttendeeRepository.CreateAsync(newPartyAttendee);

            return RedirectToPage();
        }

    }
}
