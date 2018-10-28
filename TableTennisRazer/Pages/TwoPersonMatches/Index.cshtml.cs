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
    public class IndexModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public IndexModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        public IList<TwoPersonMatch> TwoPersonMatch { get;set; }

        public async Task OnGetAsync()
        {
            TwoPersonMatch = await _context.TwoPersonMatch.ToListAsync();
        }
    }
}
