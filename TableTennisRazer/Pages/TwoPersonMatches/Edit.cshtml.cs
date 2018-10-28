using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.TwoPersonMatches
{
    public class EditModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public EditModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TwoPersonMatch TwoPersonMatch { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TwoPersonMatch = await _context.TwoPersonMatch.FirstOrDefaultAsync(m => m.MatchID == id);

            if (TwoPersonMatch == null)
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

            _context.Attach(TwoPersonMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TwoPersonMatchExists(TwoPersonMatch.MatchID))
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

        private bool TwoPersonMatchExists(int id)
        {
            return _context.TwoPersonMatch.Any(e => e.MatchID == id);
        }
    }
}
