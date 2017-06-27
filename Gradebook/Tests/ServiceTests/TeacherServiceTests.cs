using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;
using Gradebook.Data.Services;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class TeacherServiceTests
    {
        private TeacherService teacherService;

        [TestInitialize]
        public void TestSetUp()
        {
            teacherService = new TeacherService();
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
        public void getAdminByUserIDReturnsNull()
        {
            Teacher teacher = teacherService.getTeacherByUserID(-1);
            Assert.IsNull(teacher);
        }
    }
}