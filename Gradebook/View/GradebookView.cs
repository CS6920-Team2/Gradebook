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
            dgAssignments.CellBeginEdit += DgAssignments_CellBeginEdit;
            dgAssignments.DataBindingComplete += DgAssignments_DataBindingComplete;
            this.FormClosed += GradebookView_FormClosed;
        }

        private void DgAssignments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //have to disable the currency manager in order to hide the first row..
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgAssignments.DataSource];
            currencyManager.SuspendBinding();
            dgAssignments.Rows[0].Visible = false;
            currencyManager.ResumeBinding();
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
                dgAssignments.Columns[0].Visible = false;

                //set the first two columns and rows to read only
                dgAssignments.Columns[0].ReadOnly = true;
                dgAssignments.Columns[1].ReadOnly = true;
                dgAssignments.Columns[2].ReadOnly = true;
            }
        }

        private void DgAssignments_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 2)
            {
                e.Cancel = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dirtyRows = ((DataTable)dgAssignments.DataSource).GetChanges();
            bool success = gradeService.Update(dirtyRows, ((DataTable)dgAssignments.DataSource).Rows[0]);

            if(success)
            {
                fillDataSet();
            }
        }
    }
}
