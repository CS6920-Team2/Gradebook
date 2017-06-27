using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.Services;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class RoleServiceTests
    {
        private RoleService roleService;

        [TestInitialize]
        public void SetUp()
        {
            roleService = new RoleService(); 
        }

        [TestMethod]
        public void findRoleByRoleIDStudent()
        {
            string studentRole = roleService.findRoleByRoleID(1);
            Assert.AreEqual("Student", studentRole);
        }

        [TestMethod]
        public void findRoleByRoleIDTeacher()
        {
            string teacherRole = roleService.findRoleByRoleID(2);
            Assert.AreEqual("Teacher", teacherRole);
        }

        [TestMethod]
        public void findRoleByRoleIDAdmin()
        {
            string adminRole = roleService.findRoleByRoleID(3);
            Assert.AreEqual("Administrator", adminRole);
        }

        [TestMethod]
        public void findRoleByRoleIDFails()
        {
            string nullRole = roleService.findRoleByRoleID(-1);
            Assert.IsNull(nullRole);
        }
    }
}
