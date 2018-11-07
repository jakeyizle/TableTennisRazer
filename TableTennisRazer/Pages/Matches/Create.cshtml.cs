using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moserware.Skills;
using Newtonsoft.Json;
using TableTennisRazer.Models;
namespace TableTennisRazer.Pages.Matches
{
    public class CreateModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;
        public List<SelectListItem> MatchTypes = new List<SelectListItem>
        {
            new SelectListItem {Value = "1", Text = "1v1"},
            new SelectListItem {Value = "2", Text = "2v2"}
        };
        public int? SelectedMatchType { get; set; }

        public CreateModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; }
        [BindProperty]
        public List<MatchPerson> MatchPeople { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Match.Add(Match);
            MatchPeople = MatchPeople.Where(x => x.Person.PersonName != null).ToList();
            MatchPeople.ForEach(x => _context.MatchPeople.Add(x));
            MatchPeople.ForEach(x => x.Person.GetData(_context));
            var newSkills = TrueSkillCalculator.CalculateNewRatings(GameInfo.DefaultGameInfo, GetTeams(MatchPeople), (int)Result.Win, (int)Result.Loss);
            for (int i = 0; i < MatchPeople.Count(); i++)
            {
                MatchPeople[i].Person.Rating = newSkills[MatchPeople[i].Person];
                MatchPeople[i].Match = Match;
                MatchPeople[i].MatchResult = (i % 2 == 0) ? (int)Result.Loss : (int)Result.Win;
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        IEnumerable<IDictionary<Player, Rating>> GetTeams(List<MatchPerson> matchPeople)
        {
            var people = matchPeople.Select(x => x.Person).ToList();
            if (people.Count() == 2)
            {
                var winTeam = new Team(people[0], people[0].Rating);
                var loseTeam = new Team(people[1], people[1].Rating);
                return Teams.Concat(winTeam, loseTeam);
            }
            else
            {
                var winTeam = new Team();
                var loseTeam = new Team();
                winTeam.AddPlayer(people[0], people[0].Rating);
                winTeam.AddPlayer(people[1], people[1].Rating);
                loseTeam.AddPlayer(people[3], people[0].Rating);
                loseTeam.AddPlayer(people[4], people[0].Rating);
                return Teams.Concat(winTeam, loseTeam);
            }
        }
    }
}