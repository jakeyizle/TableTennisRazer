using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moserware.Skills;
namespace TableTennisRazer.Models
{
    public class RatingPoint
    {
        public DateTime Time;
        public double Rating;

        public RatingPoint(DateTime time, Rating rating)
        {
            Time = time;
            Rating = rating.ConservativeRating;
        }
    }
    public class RatingHistory
    {
        public string Name;
        public List<RatingPoint> RatingPoints;

        public RatingHistory(string name, RatingPoint ratingPoint)
        {
            Name = name;
            RatingPoints = new List<RatingPoint>() { ratingPoint };
        }

        public void Add(RatingPoint ratingPoint)
        {
            RatingPoints.Add(ratingPoint);
        }
    }
}
