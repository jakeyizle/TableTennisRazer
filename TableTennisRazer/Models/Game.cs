using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableTennisRazer.Models
{
    public class Game
    {
        public string Score;
        public string WinningTeam;
        public string LosingTeam;
        DateTime time;
        public DateTime Time
        {
            get
            {
                return time.ToLocalTime();
            }
        }

        public Game(int? winningScore, int? losingScore, List<MatchPerson> matchPeople, DateTime _time)
        {
            time = _time;
            Score = winningScore.ToString() + " - " + losingScore.ToString();
            if (matchPeople.Count() == 4)
            {
                var winList = matchPeople.Where(x => x.Result == Result.Win).OrderBy(y=>y.PersonName).ToList();
                WinningTeam = winList[0].PersonName + " and " + winList[1].PersonName;

                var lossList = matchPeople.Where(x => x.Result == Result.Loss).OrderBy(y => y.PersonName).ToList();
                LosingTeam = lossList[0].PersonName + " and " + lossList[1].PersonName;
            }
            else
            {
                WinningTeam = matchPeople.First(x => x.Result == Result.Win).PersonName;
                LosingTeam = matchPeople.First(x => x.Result == Result.Loss).PersonName;
            }
        }
    }
}
