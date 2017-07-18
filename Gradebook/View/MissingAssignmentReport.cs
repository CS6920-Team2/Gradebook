using Gradebook.Controls;
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
    public partial class MissingAssignmentReport : Form
    {
        private ReportService reportService;

        public MissingAssignmentReport()
        {
            InitializeComponent();
            //this.Size = new Size(1180, 650);
            reportService = new ReportService();
        }

        private void MissingAssignmentReport_Load(object sender, EventArgs e)
        {
            fillDataView();
        }

        private void fillDataView()
        {
            lblMessage.Text = "";

            TaughtCourse selected = (TaughtCourse)MainView.CourseList.SelectedItem;
            dgAssignments.DataSource = reportService.findMissingAssignments(selected.taughtCourseID);

            if (dgAssignments.Columns.Count == 0)
            {
                lblMessage.Text = @"No missing assignments for this class.";
                return;
            }

            //unable to sort correctly due to multiple header columns
            foreach (DataGridViewColumn column in dgAssignments.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dgAssignments.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in dgAssignments.Columns)
                    {
                        col.ReadOnly = true;
                    }
                }
            }
        }
    }
}
