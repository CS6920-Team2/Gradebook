using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class GradeInfo
    {
        [Browsable(false)]
        public int PersonID { get; set; }
        [Browsable(false)]
        public int AssignmentID { get; set; }
        [DisplayName("Assignment Name")]
        public String AssignmentName { get; set; }
        [DisplayName("Assignment Description")]
        public String AssignmentDescription { get; set; }
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
        [DisplayName("Points Possible")]
        public int PointsPossible { get; set; }
        [DisplayName("Course Name")]
        public String CourseName { get; set; }
        [DisplayName("Course Description")]
        public String CourseDescription { get; set; }
        [DisplayName("Course Duration")]
        public String CourseDuration { get; set; }
        [DisplayName("First Namee")]
        public String FirstName { get; set; }
        [DisplayName("Last Name")]
        public String LastName { get; set; }
        [DisplayName("Grade")]
        public int Grade { get; set; }
        [DisplayName("Comment")]
        public String GradeComment { get; set; }
        [DisplayName("Weight")]
        public int Weight { get; set; }
        [DisplayName("Category Name")]
        public String CategoryName { get; set; }
    }
}
