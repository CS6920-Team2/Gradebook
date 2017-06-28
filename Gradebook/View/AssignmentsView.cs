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
    public partial class AssignmentsView : ContentForm
    {

        private AssignmentService assignmentService;

        DataSet ds;
        public AssignmentsView()
        {
            InitializeComponent();
            assignmentService = new AssignmentService();
        }

        private void AssignmentsView_Load(object sender, EventArgs e)
        {
            ds = assignmentService.CreateAssignmentDataSet();
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["Category ID"].Visible = false;
            dataGridView1.Columns["assignmentID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            clickView();
            DataGridViewRow row = this.dataGridView1.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.Black;
            row.DefaultCellStyle.ForeColor = Color.White;
            row.Height = 35;
            row.MinimumHeight = 20;
        }


        // Clicking the submit button will complete the transaction of a insertion
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (isValidData() == true)
            {
               assignmentService.addAssignment(3, nameTB.Text, descriptionTB.Text, 
                   assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
                MessageBox.Show("You have succesfully added the Assignment", "Successful Addition");
                resetControls();
                loadDataGridView();
            }
        }


        // Clicking the update button will complete the transaction of a update
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (isValidData() == true)
            {
                bool updated = assignmentService.updateAssignment(Int32.Parse(assignmentIDTB.Text), 3, nameTB.Text, descriptionTB.Text,
                assignedDatedtp.Value, dueDatedtp.Value, Int32.Parse(possiblePointsTB.Text));
                MessageBox.Show("You have succesfully updated the Assignment", "Successful Update");
                resetControls();
                loadDataGridView();
            }

        }

        // Clicking the delete button will complete the transaction of a deletion
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            assignmentService.deleteAssignment(Int32.Parse(assignmentIDTB.Text));
            MessageBox.Show("You have succesfully deleted the Assignment", "Successful Deletion");
            resetControls();
            loadDataGridView();
        }

        // Clicking the datagrid selects a row and assigns the values to the textboxes.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

        // Clicking event shows the Add View
        private void addBtn_Click(object sender, EventArgs e)
        {
            clickAdd();
        }

        // Clicking event shows the Modify View
        private void modifyBtn_Click(object sender, EventArgs e)
        {
            clickModify();
        }

        // Clicking event shows the View only
        private void viewBtn_Click(object sender, EventArgs e)
        {
            clickView();
        }

        // Toggles to Add View
        private void clickAdd()
        {
            controlsEnabled();
            viewBtn.Enabled = true;
            viewBtn.ForeColor = Color.Red;
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

        // Toggles to the Modify View
        private void clickModify()
        {
            controlsEnabled();
            viewBtn.Enabled = true;
            viewBtn.ForeColor = Color.Red;
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

        // Toggles to the View only
        private void clickView()
        {
            controlsDisabled();
            viewBtn.Enabled = false;
            addBtn.Enabled = true;
            modifyBtn.Enabled = true;
            submitBtn.Visible = false;
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            viewBtn.ForeColor = Color.Black;
            modifyBtn.ForeColor = Color.Red;
            addBtn.ForeColor = Color.Red;
            dataGridView1.Enabled = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = true;
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

        // Resets the controls to default values.
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

        // Loads the datagridview .
        private void loadDataGridView()
        {
            ds = assignmentService.CreateAssignmentDataSet();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }


}
