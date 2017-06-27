using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;
using Gradebook.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    class CourseServiceTests
    {
        private CourseService courseService;

        [TestInitialize]
        public void TestSetUp()
        {
            courseService = new CourseService();
        }

        [TestMethod]
        public void findCoursesByTeacherIDSuccess()
        {
            // TeacherID 1: Bob Monroe who teaches three math classes
            List<TaughtCourse> courses = courseService.findCoursesByTeacherID(1);
            Assert.IsNotNull(courses);
            Assert.AreEqual(3, courses.Count);
        }

        [TestMethod]
        public void findCoursesByTeacherIDFails()
        {
            List<TaughtCourse> courses = courseService.findCoursesByTeacherID(-1);
            Assert.IsNull(courses);
        }
    }
}
