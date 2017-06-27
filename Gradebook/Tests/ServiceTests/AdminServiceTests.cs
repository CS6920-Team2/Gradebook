using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.GradebookTests.ServiceTests
{
    [TestClass]
    public class AdminServiceTests
    {
        private AdminService adminService;
        private Admin admin;

        [TestInitialize]
        public void TestSetUp()
        {
            adminService = new AdminService();
        }

        [TestMethod]
        public void getAdminByUserIDTestSuccess()
        {
            admin = adminService.getAdminByUserID(11);
            Assert.IsNotNull(admin);
            Assert.AreEqual(1, admin.adminID);
            Assert.AreEqual(11, admin.personID);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void getAdminByUserIDReturnNull()
        {
            admin = adminService.getAdminByUserID(1);
        }
    }
}