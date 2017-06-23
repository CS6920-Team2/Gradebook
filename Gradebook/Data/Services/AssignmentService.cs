using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Services
{
    public class AssignmentService : IAssignmentService
    {

        public DataSet CreateDataSet()
        {
            var connection = ConnectionFactory.GetOpenSQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("Select * FROM Assignments", connection);
            DataSet ds = new System.Data.DataSet();

            dataAdapter.Fill(ds, "Assignments");

            return ds;
        }
    }
}
