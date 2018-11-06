using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisRazer.Models
{
    public enum Result : int
    {
        Loss = 1,
        Win = 2
    }
    public class MatchPerson
    {
        public int MatchId { get; set; }
        public int PersonId { get; set; }
        public int MatchResult { get; set; }

        public virtual Match Match { get; set; }
        public virtual Person Person { get; set; }

        public MatchPerson()
        {

        }       
        public MatchPerson(int matchId, int personId, int result)
        {
            MatchId = matchId;
            PersonId = personId;
            MatchResult = result;
        }
    }
}
