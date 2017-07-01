using Gradebook.Controls;
using Gradebook.Data.DAO;
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
        private CategoryService categoryService;
        private TaughtCourse currentCourse = MainView.currentCourse;
        private bool canModify;

        DataSet ds;
        public AssignmentsView()
        {
            InitializeComponent();
            assignmentService = new AssignmentService();
            categoryService = new CategoryService();
            canModify = false;
        }

        private void AssignmentsView_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            dataGridView1.Columns["Category ID"].Visible = false;
            dataGridView1.Columns["assignmentID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            clickAdd();
            loadCategoryCMB();
        }


        // Clicking the submit button will complete the transaction of a insertion
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (isValidData() == true)
            {
               assignmentService.addAssignment((int)categoryCB.SelectedValue, nameTB.Text, descriptionTB.Text, 
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
                bool updated = assignmentService.updateAssignment(Int32.Parse(assignmentIDTB.Text), (int)categoryCB.SelectedValue, nameTB.Text, descriptionTB.Text,
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
            if (canModify)
            {
                assignmentIDTB.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                nameTB.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                descriptionTB.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                assignedDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                dueDatedtp.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                possiblePointsTB.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                categoryCB.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            }
            else
            {
                resetControls();
            }
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
        
        // Toggles to Add View
        private void clickAdd()
        {
            headerLBL.Text = "Add Assignment";
            canModify = false;
            controlsEnabled();
            addBtn.Enabled = false;
            modifyBtn.Enabled = true;
            submitBtn.Visible = true;
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            resetControls();
        }

        // Toggles to the Modify View
        private void clickModify()
        {
            headerLBL.Text = "Modify Assignment";
            canModify = true;
            controlsEnabled();
            addBtn.Enabled = true;
            modifyBtn.Enabled = false;
            submitBtn.Visible = false;
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
        }

        // Checks that all data is valid before a transaction.
        private bool isValidData()
        {

            if (!Validator.IsPresent(nameTB) ||
                !Validator.IsPresent(descriptionTB) ||
                !Validator.IsPresent(categoryCB) ||
                !Validator.IsPresent(possiblePointsTB) ||
                !Validator.IsInt32(possiblePointsTB))

            {
                return false;
            }
            if (Int32.Parse(possiblePointsTB.Text) < 1 || Int32.Parse(possiblePointsTB.Text) > 100)
            {
                MessageBox.Show("Possible points should be between 1 and 100", "Points Error");
                return false;
            }
            if (assignedDatedtp.Value > dueDatedtp.Value)
            {
                MessageBox.Show("Due Date must be greater than or equal to Assigned Date", "Date Error");
                return false;
            }
            else
            {
                return true;
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
            ds = assignmentService.CreateAssignmentDataSet(currentCourse.taughtCourseID);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void loadCategoryCMB()
        {
            try
            {
                List<Category> categoryList = categoryService.findCategoriesByTaughtCourseID(currentCourse.taughtCourseID);
                categoryCB.DataSource = categoryList;
                categoryCB.DisplayMember = "name";
                categoryCB.ValueMember = "categoryID";
                categoryCB.SelectedIndex = -1;
                //currentCourse = (TaughtCourse)categoryCB.SelectedItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
