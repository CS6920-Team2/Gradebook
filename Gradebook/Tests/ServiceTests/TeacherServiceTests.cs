using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Services;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class TeacherServiceTests
    {
        private TeacherService teacherService;
        private SQLiteConnection connection;

        [TestInitialize]
        public void TestSetUp()
        {
            teacherService = new TeacherService();
            connection = ConnectionFactory.GetOpenSQLiteConnection();
        }

        [TestMethod]
        public void getTeacherByUserIDSuccess()
        {
            Teacher teacher = teacherService.getTeacherByUserID(7);

            Assert.IsNotNull(teacher);
            Assert.AreEqual(1, teacher.teacherID);
            Assert.AreEqual(7, teacher.personID);
        }

        [TestMethod]
        public void getTeacherByUserIDReturnsNull()
        {
            Teacher teacher = teacherService.getTeacherByUserID(-1);
            Assert.IsNull(teacher);
        }

        [TestMethod]
        public void getAllTeachersSuccess()
        {
            IEnumerable<dynamic> result = connection.Query("select * from teachers");

            List<Teacher> teachers = teacherService.getAllTeachers();

            Assert.IsNotNull(teachers);
            Assert.AreEqual(result.Count(), teachers.Count);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            connection.Close();
        }
    }
}