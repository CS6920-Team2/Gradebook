using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class CourseServiceTests
    {
        private CourseService courseService;
        private SQLiteConnection connection;

        [TestInitialize]
        public void TestSetUp()
        {
            courseService = new CourseService();
            connection = ConnectionFactory.GetOpenSQLiteConnection();
        }

        [TestMethod]
        public void findCoursesByTeacherIDSuccess()
        {
            // TeacherID 1: Bob Monroe
            var sql = @"SELECT * FROM TaughtCourses t 
                          JOIN Courses c ON t.courseID = c.courseID
	                      WHERE t.teacherID = 1";
            IEnumerable<dynamic> result = connection.Query(sql);

            List<TaughtCourse> courses = courseService.findCoursesByTeacherID(1);

            Assert.IsNotNull(courses);
            Assert.AreEqual(result.Count(), courses.Count);
        }

        [TestMethod]
        public void findCoursesByTeacherIDFails()
        {
            List<TaughtCourse> courses = courseService.findCoursesByTeacherID(-1);

            Assert.IsNotNull(courses);
            Assert.AreEqual(0, courses.Count);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            connection.Close();
        }
    }
}
