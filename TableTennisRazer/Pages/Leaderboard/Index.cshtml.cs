using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.Leaderboard
{
    public class IndexModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public IndexModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        public IList<Person> People { get;set; }
        public IList<PersonRanking> PersonRankings { get; set; }

        public async Task OnGetAsync()
        {
            PersonRankings = new List<PersonRanking>();
            People = await _context.Person.OrderByDescending(x=>x.ConservativeRating).ToListAsync();

            for (int i = 0; i < People.Count(); i++)
            {
                var games = await _context.MatchPeople.Where(x => x.PersonName == People[i].PersonName).ToListAsync();
                PersonRankings.Add(new PersonRanking()
                {
                    Name = People[i].PersonName,
                    ConservativeRating = People[i].ConservativeRating,
                    Rank = i + 1,
                    GamesPlayed = games.Count(),
                    WinPercentage = ((double)games.Where(x => x.Result == Result.Win).Count() / games.Count()) * 100
                });

            }
        }
    }
}
