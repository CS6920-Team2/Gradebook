using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class WeightedGrade
    {
        public String CategoryName { get; set; }
        public int Weight { get; set; }
        public int TotalEarned{ get; set; }
        public int TotalPoints { get; set; }

        public WeightedGrade(int weight, int totalEarned, int totalPoints, String categoryName)
        {
            this.Weight = weight;
            this.TotalEarned = totalEarned;
            this.TotalPoints = totalPoints;
            this.CategoryName = categoryName;
        }
    }
}
