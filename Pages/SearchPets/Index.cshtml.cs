using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetSearch.Models;

namespace PetSearch.Pages.SearchPets
{
    public class IndexModel : PageModel
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); // <- This service

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
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
