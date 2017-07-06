using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class RegisteredStudent : Student
    {
        public int registeredStudentID { get; set; }
        public int taughtCourseID { get; set; }
    }
}
