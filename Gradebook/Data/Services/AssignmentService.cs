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

        public DataSet CreateAssignmentDataSet()
        {
            var connection = ConnectionFactory.GetOpenSQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT a.assignmentID, " +
                "a.categoryID AS 'Category ID', a.assignedDate AS 'Assigned'," +
                " a.dueDate AS 'Due', a.name AS 'Assignment', c.name AS 'Category'," +
                " a.description AS 'Description', a.possiblePoints AS 'Value' " +
                "FROM TaughtCourses tc " +
                "JOIN Categories c " +
                "ON c.taughtCourseID = tc.taughtCourseID " +
                "JOIN Assignments a " +
                "ON c.categoryID = a.categoryID " +
                "ORDER BY a.assignedDate ASC; ", connection);
            DataSet ds = new System.Data.DataSet();

            dataAdapter.Fill(ds, "Assignments");

            return ds;
        }

        public DataSet GetAssignments(int classId, DataSet dataSet)
        {
            //TODO: Kevin -- finish writing method
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("Select * FROM Assignments", ConnectionFactory.GetOpenSQLiteConnection());

            dataAdapter.Fill(dataSet, "Assignments");

            return dataSet;
        }

        public bool updateAssignment(int newAssignmentID, int newCategoryID, string newName, string newDescription,
            DateTime newAssignedDate, DateTime newDueDate, int newPossiblePoints)
        {
            int rowsAffected = 0;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                rowsAffected = connection.Execute("update Assignments set categoryID = @categoryID, name = @name," +
                    "description = @description, assignedDate = @assignedDate, dueDate = @dueDate, possiblePoints = @possiblePoints" +
                    " where assignmentID=@assignmentID",
                    new { categoryID = newCategoryID, name = newName, description = newDescription,
                    assignedDate = newAssignedDate, dueDate = newDueDate, possiblePoints = newPossiblePoints,
                    assignmentID = newAssignmentID});
            }
            return rowsAffected > 0;
        }

        public void addAssignment(int newCategoryID, string newName, string newDescription,
            DateTime newAssignedDate, DateTime newDueDate, int newPossiblePoints)
        {
            int rowsAffected = 0;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                rowsAffected = connection.Execute("insert into Assignments (categoryID, name, " +
                    "description, assignedDate, dueDate, possiblePoints)" +
                    " VALUES (@categoryID, @name, @description, " +
                    "@assignedDate, @dueDate, @possiblePoints)",
                    new
                    {
                        categoryID = newCategoryID,
                        name = newName,
                        description = newDescription,
                        assignedDate = newAssignedDate,
                        dueDate = newDueDate,
                        possiblePoints = newPossiblePoints
                    });
            }
        }

        public void deleteAssignment(int newAssignmentID)
        {
            int rowsAffected = 0;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                rowsAffected = connection.Execute("delete from Assignments where assignmentID = @assignmentID",
                    new
                    {
                        assignmentID = newAssignmentID
                    });
            }
        }
    }
}
