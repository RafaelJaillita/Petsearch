using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetSearch.Models;

namespace PetSearch.Pages.FoundPets
{
    public class IndexModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public IndexModel(PetSearch.Models.dbDorianContext context)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _context = context;
        }

        public IList<FoundPet> FoundPet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FoundPets != null)
            {
                FoundPet = await _context.FoundPets.ToListAsync();
            }
        }
        Uri baseAddress = new Uri("http://localhost:8082/Session.php");
        HttpClient client;

       
 
        public IActionResult Index()
        {
            List<User> users = new List<User>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "users").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(data);
            }
            return Page();
        }

        public IActionResult Create()
        {
            return Page();
        }

        [HttpPost]

        public IActionResult Create(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "users", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "User");
            }
            return Page();
        }
    }
}
