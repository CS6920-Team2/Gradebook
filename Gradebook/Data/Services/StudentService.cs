using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Interfaces;
using Gradebook.Data.Factories;

namespace Gradebook.Data.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> getAllStudents()
        {
            List<Student> students;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"select * from students s join persons p on s.personID = p.personID";

                students = (List<Student>) connection.Query<Student>(sql);
            }

            return students;
        }

        public Student getStudentByUserID(int userID)
        {
            Student student;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                student = connection.Query<Student>("select * from Students where userID = @userID", new { userID = userID }).FirstOrDefault();
            }
            return student;
        }

        public List<Student> findStudentsByTaughtCourseID(int taughtCourseID)
        {
            List<Student> students;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"SELECT s.studentID, p.firstName, p.lastName
                            FROM Persons p
                            JOIN Students s
                            ON p.personID = s.personID
                            JOIN RegisteredStudents rs 
                            ON s.studentID = rs.studentID
                            JOIN TaughtCourses tc
                            ON rs.taughtCourseID = tc.taughtCourseID
                            WHERE tc.taughtCourseID = @taughtCourseID;";
                students = (List<Student>)connection.Query<Student>(sql, new { taughtCourseID = taughtCourseID });
            }
            return students;
        }
    }
}
