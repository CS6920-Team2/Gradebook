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

        public ProgressReportView()
        {
            InitializeComponent();
            reportService = new ReportService();
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
            ds = reportService.CreateProgressReportDataSet(1,1);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
