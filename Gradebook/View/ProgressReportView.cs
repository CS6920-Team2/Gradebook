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
using Gradebook.Data.Utils;

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

        public ProgressReportView()
        {
            InitializeComponent();
            reportService = new ReportService();
            personService = new PersonService();
            courseService = new CourseService();
            sID = ReportsView.curStudentID;
            tcID = MainView.currentCourse.taughtCourseID;

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
            loadLetterGradeColumn();
        }

        private void loadLetterGradeColumn()
        {
            dataGridView1.Columns.Add("lgCol", "Letter Grade");
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int actualPoints = Int32.Parse(row.Cells[5].Value.ToString());
                int possiblePoints = Int32.Parse(row.Cells[6].Value.ToString());
                double grade = ((double) actualPoints / possiblePoints) * 100;
                row.Cells[9].Value = getLetterGrade(grade);
            }

        }

        private double getFinalGrade()
        {
            return GradeCalculator.CalculateCumulativeGrades(dataGridView1);
        }

        private string getLetterGrade(double gradeAvg)
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
                "Course Information" + Environment.NewLine +
                "Course Name: " + course.name.ToString() + Environment.NewLine +
                "Course Descripition " + course.description.ToString() + Environment.NewLine +
                "Teacher Name: " + teacher.fullName.ToString() + Environment.NewLine +
                "Teacher Email: " + teacher.email.ToString() + Environment.NewLine +
                "Teacher Number: " + teacher.phoneNumber.ToString();


        }
        private void printBtn_Click_1(object sender, EventArgs e)
        {

        }
        

       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;

        private void printBtn_Click_(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}
