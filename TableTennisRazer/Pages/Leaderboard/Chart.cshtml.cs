using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TableTennisRazer.Models;
using ChartJSCore.Models;
using Moserware.Skills;
namespace TableTennisRazer.Pages.Leaderboard
{
    public class LeaderboardModel : PageModel
    {
        private readonly TableTennisRazer.Models.TableTennisRazerContext _context;

        public LeaderboardModel(TableTennisRazer.Models.TableTennisRazerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Chart chart { get; set; }
        public MatchPerson MatchPerson { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            //todo: abstract this, currently copy and paste from matchcreate
            //Initalize people with defaults
            var Matches = await _context.Match.OrderBy(x => x.Time).ToListAsync();

            var People = _context.Person.ToList();
            People.ForEach(x => x.Rating = GameInfo.DefaultGameInfo.DefaultRating);

            List<LineScatterDataset> datasets = new List<LineScatterDataset>();
            People.ForEach(x => datasets.Add(new LineScatterDataset()
            {
                Label = x.PersonName,
                Data = new List<LineScatterData>(),
                Fill = "false",
                BorderColor = GetColorString(),
            }));

            Dictionary<Person, double> ratingDict = new Dictionary<Person, double>();
            People.ForEach(x => ratingDict.Add(x, x.ConservativeRating));
            foreach (var Match in Matches)
            {
                //Todo 
                var matchPeople = _context.MatchPeople.Where(x => x.MatchId == Match.MatchId).ToList();
                foreach(MatchPerson matchPerson in matchPeople)
                {
                    ratingDict[matchPerson.Person] += matchPerson.RatingChange;
                    var lineScatterData = new LineScatterData()
                    { x = Match.Time.ToLocalTime().ToString(), y = Math.Round(ratingDict[matchPerson.Person], 3).ToString() };

                    datasets.Single(x => x.Label == matchPerson.PersonName).Data.Add(lineScatterData);
                }
            }
            chart = new Chart();
            chart.Type = "line";
            Data data = new Data();
            data.Datasets = new List<Dataset>();
            datasets.ForEach(x => data.Datasets.Add(x));



            Options options = new Options()
            {
                Scales = new Scales()
            };

            Scales scales = new Scales()
            {
                XAxes = new List<Scale>()
                {
                    new CartesianScale()
                },
                YAxes = new List<Scale>()
                {
                    new CartesianScale()
                }
            };


            CartesianScale xAxes = new CartesianScale() { ScaleLabel = new ScaleLabel { LabelString = "Time" }, Ticks = new CartesianLinearTick() { Max = Double.Parse(DateTime.Now.ToLocalTime().AddHours(4).ToString()) } };
            scales.XAxes = new List<Scale>() { xAxes };
            options.Scales = scales;
            chart.Options = options;
            chart.Data = data;

            return Page();
        }

        string GetColorString()
        {
            Random random = new Random();
            int one = random.Next(1, 255);
            int two = random.Next(1, 255);
            int three = random.Next(1, 255);
            return $"rgba({one}, {two}, {three}, 1)";
        }
    }
}
