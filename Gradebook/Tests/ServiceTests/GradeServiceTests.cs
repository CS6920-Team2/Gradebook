using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Services.Tests
{
    [TestClass()]
    public class GradeServiceTests
    {
        private GradeService gradeService;
        [TestInitialize]
        public void TestSetUp()
        {
            gradeService = new GradeService();
        }

        [TestMethod()]
        public void findCourseGradesTest()
        {
            //TODO: Kevin
            //need to implement test on static data, our test data isnt good enough as it can easily change
            //may need to bring in Mockito or something more flexible then the basic test suite
            //Assert.Fail();
        }
    }
}