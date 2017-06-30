using Gradebook.Controls;
using Gradebook.Data;
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
    public partial class GradebookView : ContentForm
    {
        private GradeService gradeService;
        private CourseService courseService;
        public GradebookView()
        {
            InitializeComponent();
            courseService = new CourseService();
            gradeService = new GradeService(MainView.Current);
            LoadView();
        }

        public void LoadView()
        {
            List<TaughtCourse> courses = courseService.findCourses();

            ComboBoxItem currentCourse = null;
            if(MainView.currentCourse != null)
            {
                currentCourse = new ComboBoxItem(MainView.currentCourse.name + ", " + MainView.currentCourse.description, MainView.currentCourse.courseID);
            }

            foreach (TaughtCourse course in courses)
            {
                if(currentCourse != null && course.courseID == (int)currentCourse.Value)
                {
                    ddlCourses.Items.Add(currentCourse);
                } else
                {
                    ddlCourses.Items.Add(new ComboBoxItem(course.name + ", " + course.description, course.courseID));
                }
            }

            if(MainView.currentCourse != null)
            {
                ddlCourses.SelectedItem = currentCourse;
            }
        }

        private void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
        }

        private void fillDataSet()
        {
            if (ddlCourses.SelectedItem != null)
            {
                ComboBoxItem selected = (ComboBoxItem) ddlCourses.SelectedItem;
                dgAssignments.DataSource = gradeService.findCourseGrades((int)selected.Value);

                //unable to sort correctly due to multiple header columns
                foreach (DataGridViewColumn column in dgAssignments.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
    }
}
