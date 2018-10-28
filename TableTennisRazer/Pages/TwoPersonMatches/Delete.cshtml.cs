using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.TwoPersonMatches
{
    public class DeleteModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public DeleteModel(TableTennisRazer.Models.TableTennisRazerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TwoPersonMatch = await _context.TwoPersonMatch.FindAsync(id);

            if (TwoPersonMatch != null)
            {
                _context.TwoPersonMatch.Remove(TwoPersonMatch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
