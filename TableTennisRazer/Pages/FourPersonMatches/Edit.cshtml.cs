using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.FourPersonMatches
{
    public class EditModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public EditModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FourPersonMatch FourPersonMatch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FourPersonMatch = await _context.FourPersonMatch.FirstOrDefaultAsync(m => m.MatchID == id);

            if (FourPersonMatch == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FourPersonMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FourPersonMatchExists(FourPersonMatch.MatchID))
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

        private bool FourPersonMatchExists(int id)
        {
            return _context.FourPersonMatch.Any(e => e.MatchID == id);
        }
    }
}
