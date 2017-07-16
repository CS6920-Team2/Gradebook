using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Utils;

namespace Gradebook.Data.Services
{
    public class ReportService : IReportService
    {
        private User AuthenticatedUser { get; set; }
        private Teacher AuthenticatedTeacher { get; set; }

        public ReportService(MainView mainView)
        {
            AuthenticatedUser = mainView.AuthenticatedUser;
            AuthenticatedTeacher = mainView.AuthenticatedTeacher;
        }

        public ReportService()
        {

        }

        public DataSet CreateProgressReportDataSet(int studentID, int taughtCourseID)
        {
            var connection = ConnectionFactory.GetOpenSQLiteConnection();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT p.personID, p.firstName as 'FirstName', p.lastName as 'LastName', " +
            "a.assignedDate as 'Date', a.name as 'Assignment', " +
            "g.actualPoints as 'Actual Points', a.possiblePoints as 'Points Possible', " +
            "cgy.weight as 'Weight %',  cgy.Name as 'Category Name' " +
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
            "WHERE s.studentID = " + studentID + " AND t.taughtCourseID = " + taughtCourseID + 
            " ORDER BY a.assignedDate; ", connection);

            DataSet ds = new System.Data.DataSet();

            dataAdapter.Fill(ds, "ProgressReport");
            return ds;
        }

        public DataTable GetFailureReportDataSet(int teacherID)
        {
            PersonService pService = new PersonService();
            List<GradeInfo> gradeInfo = new List<GradeInfo>(); 

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"SELECT p.personID,
	                            p.firstName as 'FirstName', p.lastName as 'LastName', 
	                            g.actualPoints as 'Grade', a.possiblePoints as 'PointsPossible',
	                            cgy.name AS 'CategoryName', cgy.weight as 'Weight',
	                            crs.name as 'CourseName'
	                            FROM taughtCourses tc 
	                            JOIN courses crs ON crs.courseID = tc.courseID
	                            JOIN registeredStudents rs ON rs.taughtCourseID = tc.taughtCourseID
	                            JOIN students s ON s.studentID = rs.studentID
	                            JOIN persons p ON p.personID = s.studentID
	                            JOIN grades g ON g.registeredStudentID = rs.registeredStudentID
	                            JOIN assignments a ON a.assignmentID = g.assignmentID
	                            JOIN categories cgy ON cgy.categoryID = a.categoryID
                                WHERE tc.teacherID = @teacherID
                                ORDER BY p.lastName";

                gradeInfo = connection.Query<GradeInfo>(sql, new { teacherID = teacherID }).ToList();
            }

            // Create DataTable with column names
            DataTable dt = new DataTable("FailureReportTable");
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Cumulative Average", typeof(string)));
            dt.Columns.Add(new DataColumn("Course Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Student Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Phone Number", typeof(string)));

            // Groups all data by course name
            var courses = gradeInfo.GroupBy(c => c.CourseName);

            if (courses.Count() == 0)
            {
                return dt;
            }

            foreach (var course in courses)
            {
                // Groups all data in a course by student
                var gradesGroupedByStudent = course.GroupBy(s => s.PersonID).ToList();

                // No students forces loop to go to next course
                if (!gradesGroupedByStudent.Any())
                {
                    continue;
                }

                // Sets info for each student in course
                int failureCount = 0;
                foreach (var gradeData in gradesGroupedByStudent)
                {
                    DataRow dr = dt.NewRow();

                    // Set Student Name and Course name
                    if (gradeData.Count() > 0)
                    {
                        var gradeItem = gradeData.First();
                        dr["Name"] = gradeItem.LastName + ", " + gradeItem.FirstName;
                        dr["Course Name"] = gradeItem.CourseName;

                        Person p = pService.getPersonByPersonID(gradeItem.PersonID);
                        dr["Student Email"] = p.email;
                        dr["Phone Number"] = p.phoneNumber;
                    }

                    // Set info used for calculating grades
                    List<WeightedGrade> grades = new List<WeightedGrade>();
                    foreach (var gradeItem in gradeData)
                    {
                        grades.Add(new WeightedGrade(gradeItem.Weight, gradeItem.Grade, gradeItem.PointsPossible, gradeItem.CategoryName));
                    }

                    // Sets the cumulative average for that student
                    double cumulativeGrade = GradeCalculator.CaculateCumulativeGrades(grades);
                    dr["Cumulative Average"] = cumulativeGrade + "%";

                    // If cumulative grade is failing then show student
                    if (cumulativeGrade < 70)
                    {
                        dt.Rows.Add(dr);
                        failureCount += 1;
                    }
                }

                // Totals row added if count of failing students is above zero in a class
                if (failureCount > 0)
                {
                    DataRow totalsRow = dt.NewRow();
                    totalsRow[4] = "Course Total: " + failureCount;
                    dt.Rows.Add(totalsRow); 
                }
            }
            return dt; 
        }

        public DataTable findMissingAssignments(int taughtCourseID)
        {
            List<GradeInfo> gradeInfo = new List<GradeInfo>();
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                //create the sql query, send in an anonymous object which contains the parameters, then select the first result
                gradeInfo = connection.Query<GradeInfo>(
                    "SELECT p.personID, a.assignmentID, p.firstName as 'FirstName', p.lastName as 'LastName'," +
                    "a.name as 'AssignmentName', a.description as 'AssignmentDescription', " +
                    "a.assignedDate as 'AssignedDate', a.dueDate as 'DueDate', " +
                    "a.possiblePoints as 'PointsPossible', crs.name as 'CourseName', " +
                    "crs.description as 'CourseDescription', cre.type as 'CourseDuration', " +
                    "g.actualPoints as 'Grade', g.comment as 'GradeComment', cgy.weight as 'Weight', " +
                    "g.registeredStudentID as 'StudentID', g.assignmentID as 'GradeAssignmentID'," +
                    "cgy.name as 'CategoryName'" +
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
                    "WHERE t.teacherID = @teacherID AND t.taughtCourseID = @taughtCourseID",
                    new { teacherID = MainView.Current.AuthenticatedTeacher.teacherID, taughtCourseID = taughtCourseID }).ToList();
            }

            var gradeInfoData = gradeInfo.Where(s => s.Grade == 0).GroupBy(s => s.PersonID).ToList();


            DataTable dt = new DataTable("Missing Assignments");

            //user names
            DataColumn nameCol = new DataColumn("Student", typeof(string));
            dt.Columns.Add(nameCol);

            var nameInfoGroup = gradeInfo.GroupBy(a => a.AssignmentName);

            //add column for each assignment
            foreach (var assignment in gradeInfo.GroupBy(a => a.GradeAssignmentID))
            {
                if (assignment.Count() > 0)
                {
                    String column = assignment.First().AssignmentName;
                    DataColumn col = new DataColumn(column, typeof(string));
                    col.DefaultValue = "NO DATA";
                    dt.Columns.Add(col);
                }
            }

            //creating two header rows
            DataRow pointsPossibleRow = dt.NewRow();
            dt.Rows.Add(pointsPossibleRow);

            if (gradeInfoData.Count() == 0)
            {
                return new DataTable("Grade");
            }

            foreach (var gradeData in gradeInfoData)
            {
                List<WeightedGrade> grades = new List<WeightedGrade>();

                //create new record for the person
                DataRow dr = dt.NewRow();

                //set student name
                if (gradeData.Count() > 0)
                {
                    var gradeItem = gradeData.First();
                    dr["Student"] = gradeItem.LastName + ", " + gradeItem.FirstName;
                }

                //iterate each assignment and add column
                foreach (var gradeItem in gradeData)
                {
                    dr[gradeItem.AssignmentName] = gradeItem.Grade;
                    pointsPossibleRow[gradeItem.AssignmentName] = gradeItem.PointsPossible;
                    grades.Add(new WeightedGrade(gradeItem.Weight, gradeItem.Grade, gradeItem.PointsPossible, gradeItem.CategoryName));
                }
                dt.Rows.Add(dr);
            }

            nameCol.ReadOnly = true;

            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dt.AcceptChanges();
            return dt;
        }
    }
}
