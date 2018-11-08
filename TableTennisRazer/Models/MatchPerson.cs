﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableTennisRazer.Models
{
    public enum Result : int
    {
        Win = 1,
        Loss = 2
    }
    public class MatchPerson
    {
        public int MatchId { get; set; }
        public string PersonName { get; set; }
        public int MatchResult { get; set; }
        public double RatingChange { get; set; }

        public virtual Match Match { get; set; }
        public virtual Person Person { get; set; }

        public MatchPerson()
        {

        }       
        public MatchPerson(int matchId, string name, int result)
        {
            MatchId = matchId;
            PersonName = name;
            MatchResult = result;
        }
    }
}
