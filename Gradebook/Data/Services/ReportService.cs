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
    public class ReportService :IReportService
    {

        public DataSet CreateProgressReportDataSet(int studentID, int taughtCourseID)
        {
            var connection = ConnectionFactory.GetOpenSQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT p.personID, p.firstName as 'FirstName', p.lastName as 'LastName', " +
            "a.assignedDate as 'Date', a.name as 'Assignment', " +
            "g.actualPoints as 'Actual Points', a.possiblePoints as 'Points Possible', " +
            "cgy.weight as 'Weight %', g.comment as 'Letter Grade' " +
            "FROM " +
            "TaughtCourses t " +
            "JOIN Courses crs ON t.courseID = crs.courseID " +
            "JOIN Categories cgy ON cgy.taughtCourseID = t.taughtCourseID " +
            "JOIN Assignments a ON cgy.categoryID = a.categoryID " +
            "JOIN Credits cre ON crs.creditID = cre.creditID " +
            "JOIN RegisteredStudents rs ON t.taughtCourseID = rs.taughtCourseID " +
            "JOIN Students s ON s.studentID = rs.studentID " +
            "JOIN Persons p ON s.personID = p.personID " +
            "JOIN Grades g ON g.registeredStudentID = rs.registeredStudentID and g.assignmentID = a.assignmentID " +
            "WHERE s.studentID = " + studentID + " AND t.taughtCourseID = " + taughtCourseID + "; ", connection);

            DataSet ds = new System.Data.DataSet();

            dataAdapter.Fill(ds, "ProgressReport");
            return ds;
        }

    }
}
