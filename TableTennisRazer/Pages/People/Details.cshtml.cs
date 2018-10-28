using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.People
{
    public class DetailsModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public DetailsModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.PersonName == name);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
