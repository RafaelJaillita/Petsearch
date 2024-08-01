using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.Sheltters
{
    public class DetailsModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public DetailsModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

      public Sheltter Sheltter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sheltters == null)
            {
                return NotFound();
            }

            var sheltter = await _context.Sheltters.FirstOrDefaultAsync(m => m.Id == id);
            if (sheltter == null)
            {
                return NotFound();
            }
            else 
            {
                Sheltter = sheltter;
            }
            return Page();
        }
    }
}
