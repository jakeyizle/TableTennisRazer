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
            //todo: fix the goddamn chart
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

            var baseTime = Matches[0].Time;
            var endTime = Matches.Last().Time - baseTime;


            Dictionary<Person, double> ratingDict = new Dictionary<Person, double>();
            People.ForEach(x => ratingDict.Add(x, x.ConservativeRating));
            foreach (var Match in Matches)
            {
                //Todo 
                var matchPeople = _context.MatchPeople.Where(x => x.MatchId == Match.MatchId).ToList();
                foreach(MatchPerson matchPerson in matchPeople)
                {
                    TimeSpan interval = matchPerson.Match.Time - baseTime;
                    ratingDict[matchPerson.Person] += matchPerson.RatingChange;
                    var lineScatterData = new LineScatterData()
                    { x = Match.Time.ToString(), y = Math.Round(ratingDict[matchPerson.Person], 3).ToString() };

                    datasets.Single(x => x.Label == matchPerson.PersonName).Data.Add(lineScatterData);
                }
            }
            chart = new Chart();
            chart.Type = "line";
            Data data = new Data();
            data.Datasets = new List<Dataset>();
            data.Datasets.Add(datasets[1]);
            //datasets.ForEach(x => data.Datasets.Add(x));
            chart.Data = data;

            Options options = new Options()
            {                
                Responsive = true,
                MaintainAspectRatio = false,
                Scales = new Scales()
                {                    
                    XAxes = new List<Scale>()
                    {
                        new CartesianScale()
                        {
                            Display = true,
                            Ticks = new TimeTick()
                            {
                                Display = true,
                                Source = "auto"
                                //Max = 1,
                            },
                            ScaleLabel = new ScaleLabel()
                            {
                                Display = true,
                                LabelString = "X AXIS",
                                FontSize = 20
                            }
                        }
                    },
                    YAxes = new List<Scale>()
                    {
                        new CartesianScale()
                        {
                            Display = true,
                            Ticks = new CartesianLinearTick()
                            {
                                Display = true,
                            },
                            ScaleLabel = new ScaleLabel()
                            {
                                Display = true,
                                LabelString = "Y AXIS",
                                FontSize = 20

                            }
                        }
                    }
                }
            };

            chart.Options = options;
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
