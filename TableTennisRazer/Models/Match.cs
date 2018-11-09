using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisRazer.Models
{
    public class Match
    {
        public int MatchId { get; set; }
        public int? WinningScore { get; set; }
        public int? LosingScore { get; set; }
        public DateTime Time { get; set; }
        public virtual ICollection<MatchPerson> MatchPeople { get; set; }
    }
}
