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
    class CourseService : ICourseService
    {
        public List<TaughtCourse> findCoursesByTeacherID(int teacherID)
        {
            List<TaughtCourse> courses;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"SELECT * FROM 
	                            TaughtCourses t JOIN Courses c ON t.courseID = c.courseID
	                            WHERE t.teacherID = @teacherID";
                courses = (List<TaughtCourse>) connection.Query<TaughtCourse>(sql, new {teacherID = teacherID});
            }
            return courses;
        }
    }
}
