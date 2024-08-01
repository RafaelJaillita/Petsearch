using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.Sheltters
{
    public class EditModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public EditModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sheltter Sheltter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sheltters == null)
            {
                return NotFound();
            }

            var sheltter =  await _context.Sheltters.FirstOrDefaultAsync(m => m.Id == id);
            if (sheltter == null)
            {
                return NotFound();
            }
            Sheltter = sheltter;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Sheltter.LastUpdate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sheltter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SheltterExists(Sheltter.Id))
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

        private bool SheltterExists(int id)
        {
          return _context.Sheltters.Any(e => e.Id == id);
        }
    }
}
