using Gradebook.Data.DAO;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradebook.View
{
    public partial class ProgressReportView : Form
    {
        private ReportService reportService;
        private PersonService personService;
        private CourseService courseService;
        private Person student;
        private Person teacher;
        private Course course;
        DataSet ds;
        private int sID;
        private int tcID;

        public ProgressReportView(int studentID, int taughtCourseID)
        {
            InitializeComponent();
            reportService = new ReportService();
            personService = new PersonService();
            courseService = new CourseService();
            sID = studentID;
            tcID = taughtCourseID;

        }

        private void ProgressReportView_Load(object sender, EventArgs e)
        {
            setReportTB();
            loadDataGridView();

            dataGridView1.Columns["personID"].Visible = false;
            dataGridView1.Columns["FirstName"].Visible = false;
            dataGridView1.Columns["LastName"].Visible = false;
            gradeAvgLBL.Text = "Grade Average: " + getFinalGrade() +"%";
            letterGradeLBL.Text = "Letter Grade: " + getLetterGrade(getFinalGrade());
        }

        // Loads the datagridview .
        private void loadDataGridView()
        {
            ds = reportService.CreateProgressReportDataSet(sID,tcID);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private decimal getFinalGrade()
        {
            decimal actualPoints = 0;
            decimal possiblePoints = 0;
            int weight = 0;
            decimal pointAvg = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                weight = Int32.Parse(row.Cells[7].Value.ToString());
                decimal weightPercentage = (decimal)weight / 100;
                actualPoints += (decimal)Int32.Parse(row.Cells[5].Value.ToString()) * weightPercentage;
                possiblePoints += (decimal)Int32.Parse(row.Cells[6].Value.ToString()) * weightPercentage;
                
            }
            pointAvg = (actualPoints / possiblePoints) * 100;
            pointAvg = Math.Round(pointAvg, 2);
            return pointAvg;
        }

        private string getLetterGrade(decimal gradeAvg)
        {
            string letterGrade = "";
            if(gradeAvg >=97)
            {
                letterGrade = "A+";
            }
            else if (gradeAvg >= 93 && gradeAvg < 97)
            {
                letterGrade = "A";
            }
            else if (gradeAvg >= 90 && gradeAvg < 93)
            {
                letterGrade = "A-";
            }
            else if (gradeAvg >= 87 && gradeAvg < 90)
            {
                letterGrade = "B+";
            }
            else if (gradeAvg >= 83 && gradeAvg < 87)
            {
                letterGrade = "B";
            }
            else if (gradeAvg >= 80 && gradeAvg < 83)
            {
                letterGrade = "B-";
            }
            else if (gradeAvg >= 77 && gradeAvg < 80)
            {
                letterGrade = "C+";
            }
            else if (gradeAvg >= 73 && gradeAvg < 77)
            {
                letterGrade = "C";
            }
            else if (gradeAvg >= 70 && gradeAvg < 73)
            {
                letterGrade = "C-";
            }
            else if (gradeAvg >= 67 && gradeAvg < 70)
            {
                letterGrade = "D+";
            }
            else if (gradeAvg >= 63 && gradeAvg < 67)
            {
                letterGrade = "D";
            }
            else if (gradeAvg >= 60 && gradeAvg < 63)
            {
                letterGrade = "D-";
            }
            else
            {
                letterGrade = "F";
            }
            return letterGrade;
        }
        

        private void setReportTB()
        {
            student = personService.getPersonByStudentID(sID);
            teacher = personService.getPersonByTaughtCourseID(tcID);
            course = courseService.getCourseByTaughtCourseID(tcID);
            reportDescriptionTB.Text = "Student Information" + Environment.NewLine +
                "Student Name: " + student.fullName.ToString() + Environment.NewLine +
                "Student Email: " + student.email.ToString() + Environment.NewLine + Environment.NewLine +
                "Course Description" + Environment.NewLine +
                "Teacher Name: " + teacher.fullName.ToString() + Environment.NewLine +
                "Teacher Email: " + teacher.email.ToString() + Environment.NewLine +
                "Teacher Number: " + teacher.phoneNumber.ToString() + Environment.NewLine +
                "Course Name: " + course.name.ToString() + Environment.NewLine +
                "Course Descripition " + course.description.ToString();


        }
    }
}
