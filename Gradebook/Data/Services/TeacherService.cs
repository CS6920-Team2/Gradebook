using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;

namespace Gradebook.Data.Services
{
    class TeacherService : ITeacherService
    {
        public Teacher getTeacherByUserID(int userID)
        {
            Teacher teacher;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                teacher = connection.Query<Teacher>("select * from Teachers where userID = @userID",new {userID = userID}).FirstOrDefault();
            }

            return teacher;
        }

        public List<Teacher> getAllTeachers()
        {
            List<Teacher> teacherList;
            var sql = @"SELECT t.teacherID, p.firstName, p.lastName
                        FROM teachers t JOIN persons p ON t.personID = p.personID";

            using (var connetion = ConnectionFactory.GetOpenSQLiteConnection())
            {
                teacherList = (List<Teacher>) connetion.Query<Teacher>(sql);
            }

            return teacherList;
        }
    }
}
