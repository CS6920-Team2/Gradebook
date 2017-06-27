using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.DAO;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class PersonServiceTests
    {
        private PersonService personService;

        [TestInitialize]
        public void SetUp()
        {
            personService = new PersonService();
        }

        [TestMethod]
        public void getPersonByPersonIDSuccess()
        {
            Person amyStewart = personService.getPersonByPersonID(1);
            Assert.IsNotNull(amyStewart);
            Assert.AreEqual("Amy", amyStewart.firstName);
            Assert.AreEqual("Stewart", amyStewart.lastName);
        }

        [TestMethod]
        public void getPersonByPersonIDFails()
        {
            Person nullPerson = personService.getPersonByPersonID(-1);
            Assert.IsNull(nullPerson);
        }
    }
}
