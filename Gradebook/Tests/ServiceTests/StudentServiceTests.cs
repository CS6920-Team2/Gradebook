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
    public class StudentServiceTests
    {
        private StudentService studentService;

        [TestInitialize]
        public void TestSetUp()
        {
            studentService = new StudentService();
        }

        [TestMethod]
        public void getStudentByUserIDTestSuccess()
        {
            Student student = studentService.getStudentByUserID(1);
            Assert.IsNotNull(student);
            Assert.AreEqual(1, student.studentID);
            Assert.AreEqual(1, student.personID);
        }

        [TestMethod]
        public void getStudentByUserIDReturnsNull()
        {
            Student student = studentService.getStudentByUserID(-1);
            Assert.IsNull(student);
        }
    }
}
