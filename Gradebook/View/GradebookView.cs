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
using System.Windows.Forms.VisualStyles;

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
                currentCourse = new ComboBoxItem(MainView.currentCourse.name + ", " + MainView.currentCourse.description, MainView.currentCourse.taughtCourseID);
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
            if (dgAssignments.Rows.Count > 0)
            {
                dgAssignments.Rows[0].Visible = false;
            }
            currencyManager.ResumeBinding();
        }

        private void GradebookView_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainView.CourseList.SelectedIndexChanged -= CourseList_SelectedIndexChanged;
        }

        private void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
           GradebookView_Load(null, null);
        }

        private void fillDataSet()
        {
            if (MainView.CourseList.SelectedItem != null)
            {
                TaughtCourse selected = (TaughtCourse)MainView.CourseList.SelectedItem;
                dgAssignments.DataSource = gradeService.findCourseGrades(selected.taughtCourseID);

                //unable to sort correctly due to multiple header columns
                foreach (DataGridViewColumn column in dgAssignments.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;

                    if (dgAssignments.Columns.Count > 0)
                    {
                        dgAssignments.Columns[0].Visible = false;

                        //set the first two columns and rows to read only
                        dgAssignments.Columns[0].ReadOnly = true;
                        dgAssignments.Columns[1].ReadOnly = true;
                        dgAssignments.Columns[2].ReadOnly = true;
                    }
                }
            }

            btnUpdate.Enabled = dgAssignments.Rows.Count > 0;
        }

        private void DgAssignments_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex <= 2)
            {
                e.Cancel = true;
            } else
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Yellow;

                dgAssignments.Rows[e.RowIndex].Cells[e.ColumnIndex].Style = style;
            }
        }

        private void dgAssignments_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(CheckKey);
        }

        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
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
            if (dgAssignments.RowCount == 0)
            {
                lblMessage.Text = "No grades to show. Make sure assignments and students have been added to your course.";
            }
            else
            {
                lblMessage.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var dirtyRows = ((DataTable)dgAssignments.DataSource).GetChanges();
                bool success = gradeService.Update(dirtyRows, ((DataTable)dgAssignments.DataSource).Rows[0]);

                if (success)
                {
                    fillDataSet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to update grade book. Please check all input.", "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            fillDataSet();
        }
    }
}
