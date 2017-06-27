using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class AdminServiceTests
    {
        private AdminService adminService;

        [TestInitialize]
        public void TestSetUp()
        {
            adminService = new AdminService();
        }

        [TestMethod]
        public void getAdminByUserIDTestSuccess()
        {
            Admin admin = adminService.getAdminByUserID(11);
            Assert.IsNotNull(admin);
            Assert.AreEqual(1, admin.adminID);
            Assert.AreEqual(11, admin.personID);
        }

        [TestMethod]
        public void getAdminByUserIDReturnsNull()
        {
            Admin admin = adminService.getAdminByUserID(-1);
            Assert.IsNull(admin);
        }
    }
}