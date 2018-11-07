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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int PersonId { get; set; }
        //is unique
        [Display(Name = "Name")]
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
        public virtual ICollection<MatchPerson> MatchPeople { get; set; }


        public Person() : base(new Random())
        {

        }

        public Person(string name, TableTennisRazerContext _context) : base(name)
        {
            PersonName = name;
            var person = _context.Person.SingleOrDefault(x => x.PersonName == PersonName);
            if (person != null)
            {
                Mean = person.Mean;
                StandardDeviation = person.StandardDeviation;
                PersonId = person.PersonId;
            }
            else
            {
                Mean = GameInfo.DefaultGameInfo.InitialMean;
                StandardDeviation = GameInfo.DefaultGameInfo.InitialStandardDeviation;
                _context.Person.Add(this);
            }
        }

        public void GetData(TableTennisRazerContext _context)
        {
            var person = _context.Person.AsNoTracking().SingleOrDefault(x => x.PersonName == PersonName);
            if (person != null)
            {
                Mean = person.Mean;
                StandardDeviation = person.StandardDeviation;
            }
            else
            {
                Mean = GameInfo.DefaultGameInfo.InitialMean;
                StandardDeviation = GameInfo.DefaultGameInfo.InitialStandardDeviation;                
            }
        }        
    }
}
