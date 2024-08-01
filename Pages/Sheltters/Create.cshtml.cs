using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetSearch.Models;

namespace PetSearch.Pages.Sheltters
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
        public Sheltter Sheltter { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sheltters.Add(Sheltter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
