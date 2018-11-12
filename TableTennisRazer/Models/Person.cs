using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Moserware.Skills;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TableTennisRazer.Models
{
    public class Person : Player
    {
        [Key, Display(Name = "Name")]
        public string PersonName { get; set; }
        public double Mean { get; set; }
        public double StandardDeviation { get; set; }
        [NotMapped]
        public Rating Rating
        {
            get
            {
                return new Rating(Mean, StandardDeviation);
            }
            set
            {
                Mean = value.Mean;
                StandardDeviation = value.StandardDeviation;
            }
        }

        //made this its own property for display purposes
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:0.000}")]
        public double ConservativeRating
        {
            get
            {
                return Rating.ConservativeRating;
            }
        }
        public virtual ICollection<MatchPerson> MatchPeople { get; set; }

        //Player class must have unique id, but it need only be consistent for rating calculator
        public Person() : base(new Random().NextDouble())
        {

        }

        //better way to do this plz
        //the settings in the gameinfo object affect match calculations, so if edited in one place must be edited in all 
        public void GetData(TableTennisRazerContext _context)
        {
            _context.Entry(this).Reload();
            if (Mean == 0 && StandardDeviation == 0)
            {
                Mean = GameInfo.DefaultGameInfo.InitialMean;
                StandardDeviation = GameInfo.DefaultGameInfo.InitialStandardDeviation;
                _context.Person.Add(this);
            }
        }        
    }
}
