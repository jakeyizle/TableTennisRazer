using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;

namespace TableTennisRazer.Pages.Matches
{
    public class ResultModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public ResultModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }

        public List<MatchPerson> MatchPeople {get;set;}
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public List<Game> GameList { get; set; }

        //yeah this is dirty as fuck.
        //gets the latest match, then gets the match history between the 2 teams
        public async Task<IActionResult> OnGetAsync()
        {
            var match = await _context.Match.OrderBy(x=>x.MatchId).LastOrDefaultAsync();
            MatchPeople = await _context.MatchPeople.Where(x => x.MatchId == match.MatchId).OrderBy(y=>y.MatchResult).ToListAsync();
            MatchPeople.ForEach(x => x.Person =  _context.Person.FirstOrDefault(p => p.PersonName == x.PersonName));

            var names = MatchPeople.Select(x => x.PersonName);
            var matchIds = await _context.Match.Select(x=>x.MatchId).ToListAsync();
            List<MatchPerson> AllMatches = new List<MatchPerson>();
            GameList = new List<Game>();

            if (MatchPeople.Count() == 4)
            {
                foreach (int matchId in matchIds)
                {
                    var matchPeople = await _context.MatchPeople.Where(x => x.MatchId == matchId).ToListAsync();
                    if (Enumerable.SequenceEqual(matchPeople.OrderBy(t => t.MatchResult).Select(x => x.PersonName), 
                                                 MatchPeople.OrderBy(t => t.MatchResult).Select(x => x.PersonName)))
                    {
                        var foo = 3;
                    }

                    if (Enumerable.SequenceEqual(matchPeople.Select(x => x.PersonName).OrderBy(t => t), names.OrderBy(t => t)))
                    {
                        if (matchPeople.First(x => x.PersonName == MatchPeople[0].PersonName).Result
                            == matchPeople.First(x => x.PersonName == MatchPeople[1].PersonName).Result
                            && (matchPeople.First(x => x.PersonName == MatchPeople[2].PersonName).Result
                            == matchPeople.First(x => x.PersonName == MatchPeople[3].PersonName).Result))
                        {
                            matchPeople.ForEach(x => AllMatches.Add(x));
                            var Match = await _context.Match.FirstAsync(x => x.MatchId == matchId);
                            GameList.Add(new Game(Match.WinningScore, Match.LosingScore, matchPeople, Match.Time));
                        }
                    }
                }
            }
            else
            {
                foreach (int matchId in matchIds)
                {
                    var matchPeople = await _context.MatchPeople.Where(x => x.MatchId == matchId).ToListAsync();
                    if (Enumerable.SequenceEqual(matchPeople.Select(x => x.PersonName).OrderBy(t => t), names.OrderBy(t => t)))
                    {
                        matchPeople.ForEach(x => AllMatches.Add(x));
                        var Match = await _context.Match.FirstAsync(x => x.MatchId == matchId);
                        GameList.Add(new Game(Match.WinningScore, Match.LosingScore, matchPeople, Match.Time));
                    }
                }
            }

            WinCount = AllMatches.Count(x => x.PersonName == MatchPeople[0].PersonName && x.Result == Result.Win);
            LossCount = AllMatches.Count(x => x.PersonName == MatchPeople[0].PersonName && x.Result == Result.Loss);

            if (match == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
