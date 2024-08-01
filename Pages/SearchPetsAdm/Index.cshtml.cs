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
    public class IndexModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public IndexModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        public IList<SearchPet> SearchPet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SearchPets != null)
            {
                SearchPet = await _context.SearchPets.ToListAsync();
            }
        }
    }
}
