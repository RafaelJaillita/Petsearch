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
    public class IndexModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public IndexModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        public IList<Sheltter> Sheltter { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Sheltters != null)
            {
                Sheltter = await _context.Sheltters.ToListAsync();
            }
        }
    }
}
