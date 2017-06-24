using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class TaughtCourse : Course
    {
        public int taughtCourseID { get; set; }
        public int teacherID { get; set; }
        public int courseID { get; set; }
    }
}
