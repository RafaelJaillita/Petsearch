using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetSearch.Models;

namespace PetSearch.Pages.Users
{
    public class LogInModel : PageModel
    {
        private readonly PetSearch.Models.dbDorianContext _context;

        public LogInModel(PetSearch.Models.dbDorianContext context)
        {
            _context = context;
        }

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        [BindProperty]
        public User User { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? userString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? passwordString { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            var log = from x in _context.Users select x;
            
            int y = 0;
            if (!String.IsNullOrEmpty(userString) && !String.IsNullOrEmpty(passwordString))
            {
                var logi = log.Where(s => s.EmailAddress.Equals(userString) && s.Password.Equals(passwordString));
                User.Id = logi.Select(s => s.Id).FirstOrDefault();
                foreach (var item in logi)
                {
                    y++;
                    if (y > 0)
                    {
                        HttpContext.Session.SetInt32("user_id", item.Id);
                        HttpContext.Session.SetString("user_role", item.Rol);
                        HttpContext.Session.SetInt32("user_status", item.Status);
                    }
                }
            }
            //User = await log.ToListAsync();
            if (y > 0)
            {
                User = _context.Users.Find(User.Id);
                User.Status = 2; //log = 2; no log=1

                _context.Users.Update(User);

                HttpContext.Session.SetInt32("user_status", User.Status);

                await _context.SaveChangesAsync();

                return RedirectToPage("../Index");
            }
            else
            {
                return RedirectToPage("../Users/Login");
            }
        }
    }
}
