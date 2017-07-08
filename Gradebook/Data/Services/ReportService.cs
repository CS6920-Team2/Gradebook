using Gradebook.Data.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Services
{
    public class ReportService
    {

        public DataSet CreateProgressReportDataSet(int taughtCourseID, int studentID)
        {
            var connection = ConnectionFactory.GetOpenSQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT p.personID, p.firstName as 'FirstName', p.lastName as 'LastName', " +
            "a.name as 'AssignmentName', a.assignedDate as 'AssignedDate', " +
            "g.actualPoints as 'Grade', a.possiblePoints as 'PointsPossible' " +
            "cgy.weight as 'Weight', g.comment as 'GradeComment' " +
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
            "WHERE s.studentID = 1 AND t.taughtCourseID = 1; ", connection);

            DataSet ds = new System.Data.DataSet();

            dataAdapter.Fill(ds, "ProgressReport");
            return ds;
        }

    }
}
