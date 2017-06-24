using Gradebook.Controls;
using Gradebook.Data.Factories;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gradebook.Data.Factories.ConnectionFactory;

namespace Gradebook.View
{
    public partial class AssignmentsView : BaseForm
    {

        private AssignmentService assignmentService;
        public AssignmentsView()
        {
            InitializeComponent();
            assignmentService = new AssignmentService();
        }

        private void AssignmentsView_Load(object sender, EventArgs e)
        {
            DataSet ds = assignmentService.CreateDataSet();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool updated = assignmentService.updateAssignment(3, 3, nameTB.Text, descriptionTB.Text,
            assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  // ignore header row
                return;
            nameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            descriptionTB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            assignedDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
            dueDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            possiblePointsTB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            categoryCB.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

        }
    }
}
