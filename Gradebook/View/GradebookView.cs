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

            MainView.CourseList.SelectedIndexChanged += CourseList_SelectedIndexChanged;

            this.FormClosed += GradebookView_FormClosed;
        }

        private void GradebookView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainView.CourseList.SelectedIndexChanged -= CourseList_SelectedIndexChanged;
        }

        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataSet();
        }

        private void fillDataSet()
        {
            if (MainView.CourseList.SelectedItem != null)
            {
                TaughtCourse selected = (TaughtCourse)MainView.CourseList.SelectedItem;
                dgAssignments.DataSource = gradeService.findCourseGrades(selected.courseID);

                //unable to sort correctly due to multiple header columns
                foreach (DataGridViewColumn column in dgAssignments.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Left:
                    prevClass();
                    return true;
                case Keys.Right:
                    nextClass();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void nextClass()
        {
            int current = MainView.CourseList.SelectedIndex;
            int max = MainView.CourseList.Items.Count;

            if(current + 1 < max)
            {
                MainView.CourseList.SelectedIndex = current + 1;
            }
            else
            {
                MainView.CourseList.SelectedIndex = 0;
            }
        }

        private void prevClass()
        {
            int current = MainView.CourseList.SelectedIndex;
            int max = MainView.CourseList.Items.Count;

            if (current > 0)
            {
                MainView.CourseList.SelectedIndex = current - 1;
            }
            else
            {
                MainView.CourseList.SelectedIndex = max - 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            nextClass();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            prevClass();
        }

        private void GradebookView_Load(object sender, EventArgs e)
        {
            fillDataSet();
        }
    }
}
