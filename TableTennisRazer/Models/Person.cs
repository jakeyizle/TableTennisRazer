using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Moserware.Skills;
using System.ComponentModel.DataAnnotations;

namespace TableTennisRazer.Models
{
    public class Person
    {
        [Key]
        public string PersonName { get; set; }
        public double Mean { get; set; }
        public double StandardDeviation { get; set; }

        public Person()
        {

        }

        public Person(string name)
        {
            name = PersonName;
        }
    }
}
