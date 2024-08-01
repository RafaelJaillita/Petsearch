using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.FoundPets
{
    public class EditModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public EditModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoundPet FoundPet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FoundPets == null)
            {
                return NotFound();
            }

            var foundpet =  await _context.FoundPets.FirstOrDefaultAsync(m => m.Id == id);
            if (foundpet == null)
            {
                return NotFound();
            }
            FoundPet = foundpet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            FoundPet.LastUpdate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoundPet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoundPetExists(FoundPet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoundPetExists(int id)
        {
          return _context.FoundPets.Any(e => e.Id == id);
        }
    }
}
