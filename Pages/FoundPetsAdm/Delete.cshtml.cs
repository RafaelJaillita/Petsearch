using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.FoundPetsAdm
{
    public class DeleteModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public DeleteModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FoundPet FoundPet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoundPets == null)
            {
                return NotFound();
            }

            var foundpet = await _context.FoundPets.FirstOrDefaultAsync(m => m.Id == id);

            if (foundpet == null)
            {
                return NotFound();
            }
            else 
            {
                FoundPet = foundpet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FoundPets == null)
            {
                return NotFound();
            }
            var foundpet = await _context.FoundPets.FindAsync(id);

            if (foundpet != null)
            {
                FoundPet = foundpet;
                _context.FoundPets.Remove(FoundPet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
