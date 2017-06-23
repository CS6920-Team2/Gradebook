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
    }
}
