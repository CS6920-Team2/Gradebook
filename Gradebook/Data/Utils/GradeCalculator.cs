using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Utils
{
    class GradeCalculator
    {
        public static double CaculateCumulativeGrades(List<WeightedGrade> grades)
        {
            double cumulativeEarned = 0;
            double totalWeightUsed = 0;
            foreach (var gradesFromCategory in grades.GroupBy(g => g.CategoryName))
            {
                // Weight for particular category
                double weight = gradesFromCategory.First().Weight;

                // Weights we want to keep track of 
                // (in case we don't have assignments in each category yet)
                totalWeightUsed += weight;

                // Total earned and possible for all assignments in that category (no weight considered)
                double totalEarnedForCategory = gradesFromCategory.Sum(g => g.TotalEarned);
                double totalPossibleForCategory = gradesFromCategory.Sum(g => g.TotalPoints);

                // Total points for the category earned 
                cumulativeEarned += totalEarnedForCategory / totalPossibleForCategory * weight;
            }
            double cumulativeGrade = cumulativeEarned / totalWeightUsed * 100.0;
            return cumulativeGrade;
        }
    }
}
