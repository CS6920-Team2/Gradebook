using Gradebook.Controls;
using Gradebook.Data.Factories;
using Gradebook.Data.Services;
using Gradebook.Data.Utils;
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
            DataSet ds = assignmentService.CreateAssignmentDataSet();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Category ID"].Visible = false;
            dataGridView1.Columns["assignmentID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Enabled = false;
            submitBtn.Visible = false;
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
        }


        // Clicking the submit button will complete the transaction of deleting, inserting or updating.
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (isValidData() == true)
            {

                // updated = assignmentService.updateAssignment(Int32.Parse(assignmentIDTB.Text), 3, nameTB.Text, descriptionTB.Text,
               // assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
               assignmentService.addAssignment(3, nameTB.Text, descriptionTB.Text, 
                   assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
                dataGridView1.Update();
            }
        }

        // Clicking the datagrid selects a row and assigns the values to the textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            controlsEnabled();
            if (e.RowIndex == -1)  // ignore header row
                return;
            assignmentIDTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            nameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            descriptionTB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            assignedDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
            dueDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
            possiblePointsTB.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            categoryCB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();

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
            controlsEnabled();
            addBtn.Enabled = false;
            addBtn.ForeColor = Color.Black;
            modifyBtn.Enabled = true;
            modifyBtn.ForeColor = Color.Red;
            dataGridView1.Enabled = false;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.ForeColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
            dataGridView1.EnableHeadersVisualStyles = false;
            submitBtn.Visible = true;
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            resetControls();
        }

        private void clickModify()
        {
            controlsDisabled();
            addBtn.Enabled = true;
            addBtn.ForeColor = Color.Red;
            modifyBtn.Enabled = false;
            modifyBtn.ForeColor = Color.Black;
            dataGridView1.Enabled = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = true;

            submitBtn.Visible = false;
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
        }

        // Checks that all data is valid before a transaction.
        private bool isValidData()
        {
            if (Validator.IsPresent(nameTB) &&
                Validator.IsPresent(descriptionTB) &&
                //Validator.IsPresent(categoryCB) &&
                Validator.IsPresent(possiblePointsTB))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        // Sets combo and text box controls to Disabled.
        private void controlsDisabled()
        {
            nameTB.Enabled = false;
            descriptionTB.Enabled = false;
            assignedDatedtp.Enabled = false;
            dueDatedtp.Enabled = false;
            categoryCB.Enabled = false;
            possiblePointsTB.Enabled = false;
        }

        // Sets combo and text box controls to Enabled.
        private void controlsEnabled()
        {
            nameTB.Enabled = true;
            descriptionTB.Enabled = true;
            assignedDatedtp.Enabled = true;
            dueDatedtp.Enabled = true;
            categoryCB.Enabled = true;
            possiblePointsTB.Enabled = true;
        }

        private void resetControls()
        {
            assignmentIDTB.Text = "";
            nameTB.Text = "";
            descriptionTB.Text = "";
            assignedDatedtp.Value = DateTime.Today;
            dueDatedtp.Value = DateTime.Today;
            possiblePointsTB.Text = "";
            categoryCB.Text = "";
        }
    }
}
