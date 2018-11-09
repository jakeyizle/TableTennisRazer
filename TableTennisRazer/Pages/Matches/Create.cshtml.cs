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

            MatchPeople = MatchPeople.Where(x => x.Person.PersonName != null).ToList();
            _context.MatchPeople.AttachRange(MatchPeople);            
            MatchPeople.ForEach(x => x.Person.GetData(_context));

            var newSkills = TrueSkillCalculator.CalculateNewRatings(GameInfo.DefaultGameInfo, GetTeams(MatchPeople), (int)Result.Win, (int)Result.Loss);
            for (int i = 0; i < MatchPeople.Count(); i++)
            {
                double oldRating = MatchPeople[i].Person.Rating.ConservativeRating;
                MatchPeople[i].Person.Rating = newSkills[MatchPeople[i].Person];
                MatchPeople[i].RatingChange = MatchPeople[i].Person.Rating.ConservativeRating - oldRating;
                MatchPeople[i].Match = Match;
                MatchPeople[i].MatchResult = (i % 2) + 1;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Result");
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
                winTeam.AddPlayer(people[0], people[0].Rating);
                winTeam.AddPlayer(people[2], people[2].Rating);
                winTeam.AsDictionary().Where(x => x.Key == people[0]);
                var loseTeam = new Team();
                loseTeam.AddPlayer(people[1], people[1].Rating);
                loseTeam.AddPlayer(people[3], people[3].Rating);
                return Teams.Concat(winTeam, loseTeam);
            }
        }
    }
}