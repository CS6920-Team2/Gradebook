using Gradebook.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;

namespace Gradebook.Data.Services
{
    public class RegisteredStudentService : IRegisteredStudentService
    {
        public List<RegisteredStudent> getAllStudentsAsRegisteredStudents()
        {
            List<RegisteredStudent> registeredStudents;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"select * from students s join persons p on s.personID = p.personID";

                registeredStudents = (List<RegisteredStudent>)connection.Query<RegisteredStudent>(sql);
            }

            return registeredStudents;
        }

        public List<RegisteredStudent> getRegisteredStudentsInTaughtCourse(int taughtCourseID)
        {
            List<RegisteredStudent> registeredStudents;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"select rs.*, p.firstName, p.lastName from students s 
	                            join persons p on s.studentID = p.personID
	                            join registeredStudents rs on s.studentID = rs.studentID
	                            join taughtCourses tc on rs.taughtCourseID = tc.taughtCourseID
	                            where tc.taughtCourseID = @taughtCourseID";

                registeredStudents = (List<RegisteredStudent>)connection.Query<RegisteredStudent>(sql, new { taughtCourseID = taughtCourseID });
            }

            return registeredStudents;
        }
    }
}
