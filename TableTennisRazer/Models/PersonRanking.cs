using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TableTennisRazer.Models
{
    public class PersonRanking
    {
        public int Rank { get; set; }

        [Display(Name = "Rating")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double ConservativeRating { get; set; }

        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public double WinPercentage { get; set; }
    }
}
