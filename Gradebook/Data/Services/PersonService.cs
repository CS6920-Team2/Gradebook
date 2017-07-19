using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;
using Gradebook.Data.Interfaces;
using Gradebook.Data.Factories;
using Dapper;

namespace Gradebook.Data.Services
{
    class PersonService : IPersonService
    {
        public Person getPersonByPersonID(int personID)
        {
            Person person;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                person = connection.Query<Teacher>("select * from Persons where personID = @personID", new { personID = personID }).FirstOrDefault();
            }
            return person;
        }

        public Person getPersonByStudentID(int studentID)
        {
            Person person;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                person = connection.Query<Student>("SELECT * " +
                "FROM Persons p " +
                "JOIN Students s " +
                "ON p.personID = s.personID " +
                "WHERE s.studentID = @studentID; ", new { studentID = studentID }).FirstOrDefault();
            }
            return person;
        }

        public Person getPersonByTaughtCourseID(int taughtCourseID)
        {
            Person person;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                person = connection.Query<Teacher>("SELECT * " +
                "FROM Persons p " +
                "JOIN Teachers t " +
                "ON p.personID = t.personID " +
                "JOIN TaughtCourses tc " +
                "ON t.teacherID = tc.teacherID " +
                "WHERE tc.taughtCourseID = @taughtCourseID; ", new { taughtCourseID = taughtCourseID }).FirstOrDefault();
            }
            return person;
        }

    }
}
