using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetSearch.Models;

namespace PetSearch.Pages.SearchPetsAdm
{
    public class CreateModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public CreateModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SearchPet SearchPet { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SearchPets.Add(SearchPet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
