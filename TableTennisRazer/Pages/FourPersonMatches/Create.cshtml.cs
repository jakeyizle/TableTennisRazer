using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.FourPersonMatches
{
    public class CreateModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public CreateModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FourPersonMatch FourPersonMatch { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FourPersonMatch.Add(FourPersonMatch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}