using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gradebook.Data.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Gradebook.Tests.ConnectionFactoryTests
{
    [TestClass]
    public class ConnectionFactoryTests
    {
        [TestMethod]
        public void GetOpenConnectionTest()
        {
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                Assert.IsNotNull(connection);
                Assert.AreEqual(connection.State, ConnectionState.Open);
            }
        }

        [TestMethod]
        public void GetOpenSQLiteConnectionTest()
        {
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                Assert.IsNotNull(connection);
                Assert.AreEqual(connection.State, ConnectionState.Open);
            }
        }
    }
}
