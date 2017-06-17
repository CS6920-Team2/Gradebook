using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class Course
    {
        public int courseID { get; set; }
        public int creditID { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        // From TaughtCourses
        public int taughtCourseID { get; set; }
    }
}
