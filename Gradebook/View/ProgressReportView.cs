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
        DataSet ds;
        private int sID;
        private int tcID;

        public ProgressReportView(int studentID, int taughtCourseID)
        {
            InitializeComponent();
            reportService = new ReportService();
            sID = studentID;
            tcID = taughtCourseID;

        }

        private void ProgressReportView_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            dataGridView1.Columns["personID"].Visible = false;
            dataGridView1.Columns["FirstName"].Visible = false;
            dataGridView1.Columns["LastName"].Visible = false;
        }

        // Loads the datagridview .
        private void loadDataGridView()
        {
            ds = reportService.CreateProgressReportDataSet(sID,tcID);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
