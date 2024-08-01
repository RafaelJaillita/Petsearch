using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.SearchPetsAdm
{
    public class DetailsModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public DetailsModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

      public SearchPet SearchPet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SearchPets == null)
            {
                return NotFound();
            }

            var searchpet = await _context.SearchPets.FirstOrDefaultAsync(m => m.Id == id);
            if (searchpet == null)
            {
                return NotFound();
            }
            else 
            {
                SearchPet = searchpet;
            }
            return Page();
        }
    }
}
