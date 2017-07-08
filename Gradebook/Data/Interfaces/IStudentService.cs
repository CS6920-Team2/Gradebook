using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Interfaces
{
    public interface IStudentService
    {
        Student getStudentByUserID(int userID);
        List<Student> getAllStudents();
        List<Student> findStudentsByTaughtCourseID(int taughtCourseID);
    }
}
