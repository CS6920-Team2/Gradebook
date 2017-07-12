using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            return Math.Round(cumulativeGrade, 2);
        }
        
        public static double CalculateCumulativeGrades(DataGridView dgView)
        {
            // Convert items in grid view to weighted grades
            List<WeightedGrade> grades = new List<WeightedGrade>();
            foreach (DataGridViewRow row in dgView.Rows)
            {
                int weight = Int32.Parse(row.Cells[7].Value.ToString());
                int actualPoints = Int32.Parse(row.Cells[5].Value.ToString());
                int possiblePoints = Int32.Parse(row.Cells[6].Value.ToString());
                string categoryName = row.Cells[8].Value.ToString();
                grades.Add(new WeightedGrade(weight, actualPoints, possiblePoints, categoryName));
            }

            // Sent these grades to the other method override above
            return CaculateCumulativeGrades(grades);

        }
        
    }
}
