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

            dataGridView1.Enabled = false;
        }


        // Clicking the submit button will complete the transaction of deleting, inserting or updating.
        private void submitBtn_Click(object sender, EventArgs e)
        {
            bool updated = assignmentService.updateAssignment(Int32.Parse(assignmentIDTB.Text), 3, nameTB.Text, descriptionTB.Text,
            assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
            dataGridView1.Update();
        }

        // Clicking the datagrid selects a row and assigns the values to the textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  // ignore header row
                return;
            assignmentIDTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            nameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            descriptionTB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            assignedDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            dueDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            possiblePointsTB.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            categoryCB.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            clickAdd();
        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            clickModify();
        }

        private void clickAdd()
        {
            addBtn.Enabled = false;
            addBtn.ForeColor = Color.Black;
            modifyBtn.Enabled = true;
            modifyBtn.ForeColor = Color.Red;
            dataGridView1.Enabled = false;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;

            assignmentIDTB.Text = "";
            nameTB.Text = "";
            descriptionTB.Text = "";
            assignedDatedtp.Value = DateTime.Today;
            dueDatedtp.Value = DateTime.Today;
            possiblePointsTB.Text = "";
            categoryCB.Text = "";
        }

        private void clickModify()
        {
            addBtn.Enabled = true;
            addBtn.ForeColor = Color.Red;
            modifyBtn.Enabled = false;
            modifyBtn.ForeColor = Color.Black;
            dataGridView1.Enabled = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = true;
            dataGridView1.ReadOnly = false;
        }
    }
}
