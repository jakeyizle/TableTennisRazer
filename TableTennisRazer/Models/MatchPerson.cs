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
        Win = 1,
        Loss = 2
    }
    public class MatchPerson
    {
        public int MatchId { get; set; }

        [Display(Name = "Name")]
        public string PersonName { get; set; }

        [Display(Name = "Match Result")]
        public int MatchResult { get; set; }

        [Display(Name = "Rating Change")]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double RatingChange { get; set; }

        [NotMapped]
        public Result Result
        {
            get
            {
                return (Result)MatchResult;
            }
        }


        public virtual Match Match { get; set; }
        public virtual Person Person { get; set; }

        public MatchPerson()
        {

        }       
    }
}
