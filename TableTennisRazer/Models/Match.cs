using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableTennisRazer.Models
{
    public class Match
    {
        public int MatchID { get; set; }
        public int WinningScore { get; set; }
        public int LosingScore { get; set; }
        public string WinningPersonOne { get; set; }
        public string LosingPersonOne { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
