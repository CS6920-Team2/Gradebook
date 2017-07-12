using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Gradebook.Data.Utils;

namespace Gradebook.Data.Services
{
    public class GradeService : IGradeService
    {
        private static class GradeColumns
        {
            public static String Student = "Student";
            public static String Grades = "Grades";
            public static String Average = "Average";
            public static String PointsPossible = "Points Possible";
            public static String DueDate = "Due";
            public static String AssignmentID = "AssignmentID";
            public static String StudentID = "StudentID";
        }

        private User AuthenticatedUser { get; set; }
        private Teacher AuthenticatedTeacher { get; set; }

        public GradeService(MainView mainView)
        {
            AuthenticatedUser = mainView.AuthenticatedUser;
            AuthenticatedTeacher = mainView.AuthenticatedTeacher;
        }

        public GradeService()
        {

        }

        public DataTable findCourseGrades(int taughtCourseID)
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
                    new { teacherID = AuthenticatedTeacher.teacherID, taughtCourseID = taughtCourseID }).ToList();
            }

            var gradeInfoData = gradeInfo.GroupBy(s => s.PersonID).ToList();

            DataTable dt = new DataTable(GradeColumns.Grades);
            //gradeId for updating
            DataColumn gradeCol = new DataColumn(GradeColumns.StudentID, typeof(int));
            dt.Columns.Add(gradeCol);
            //user names
            DataColumn nameCol = new DataColumn(GradeColumns.Student, typeof(string));
            dt.Columns.Add(nameCol);
            //averages
            DataColumn avgCol = new DataColumn(GradeColumns.Average, typeof(string));
            dt.Columns.Add(avgCol);

            var nameInfoGroup = gradeInfo.GroupBy(a => a.AssignmentName);

            //add column for each assignment
            foreach (var assignment in gradeInfo.GroupBy(a => a.GradeAssignmentID))
            {
                if (assignment.Count() > 0)
                {
                    String column = assignment.First().AssignmentName;
                    DataColumn col = new DataColumn(column, typeof(string));
                    dt.Columns.Add(col);
                }
            }

            DataRow assignmentIDRow = dt.NewRow();

            //creating two header rows
            DataRow dueDateRow = dt.NewRow();
            dueDateRow[GradeColumns.Average] = GradeColumns.DueDate;
            DataRow pointsPossibleRow = dt.NewRow();
            //pointsPossibleRow.Table.Columns.
            pointsPossibleRow[GradeColumns.Average] = GradeColumns.PointsPossible;

            dt.Rows.Add(assignmentIDRow);
            dt.Rows.Add(dueDateRow);
            dt.Rows.Add(pointsPossibleRow);

            if (gradeInfoData.Count() == 0)
            {
                return new DataTable(GradeColumns.Grades);
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
                    dr[GradeColumns.Student] = gradeItem.LastName + ", " + gradeItem.FirstName;
                }

                //iterate each assignment and add column
                foreach (var gradeItem in gradeData)
                {
                    dr[GradeColumns.StudentID] = gradeItem.StudentID;
                    dr[gradeItem.AssignmentName] = gradeItem.Grade;
                    pointsPossibleRow[gradeItem.AssignmentName] = gradeItem.PointsPossible;
                    dueDateRow[gradeItem.AssignmentName] = gradeItem.DueDate.ToShortDateString();
                    assignmentIDRow[gradeItem.AssignmentName] = gradeItem.GradeAssignmentID;
                    grades.Add(new WeightedGrade(gradeItem.Weight, gradeItem.Grade, gradeItem.PointsPossible, gradeItem.CategoryName));
                }

                //calculate weighted grade
                double cumulativeGrade = GradeCalculator.CaculateCumulativeGrades(grades);
                dr[GradeColumns.Average] = cumulativeGrade + "%";
                dt.Rows.Add(dr);
            }

            nameCol.ReadOnly = true;
            avgCol.ReadOnly = true;

            dt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dt.AcceptChanges();
            return dt;
        }

        public bool Update(DataTable grades, DataRow mappedAssignmentIds)
        {
            int rowsChanged = 0;
            if (grades != null && grades.Rows.Count > 0 && mappedAssignmentIds != null)
            {
                using (var connection = ConnectionFactory.GetOpenConnection())
                {
                    foreach (DataRow rowData in grades.Rows)
                    {
                        DataTable row = rowData.Table;
                        for (int i = 3; i < row.Columns.Count; i++)
                        {
                            int studentID = rowData.Field<int>(rowData.Table.Columns[0]);
                            int assignmentID = int.Parse(mappedAssignmentIds.Field<string>(mappedAssignmentIds.Table.Columns[i]));
                            int actualPoints = int.Parse(rowData.Field<string>(rowData.Table.Columns[i]));

                            try
                            {
                                rowsChanged += connection.Execute("UPDATE Grades set actualPoints = @actualPoints " +
                                "WHERE registeredStudentID=@registeredStudentID " +
                                "AND assignmentID=@assignmentID", new
                                {
                                    actualPoints = actualPoints,
                                    assignmentID = assignmentID,
                                    registeredStudentID = studentID
                                });
                            }
                            catch (Exception)
                            {

                            }
                        }

                    }
                }
            }
            return rowsChanged > 0;
        }
    }
}
