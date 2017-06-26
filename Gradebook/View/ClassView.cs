using Gradebook.Data.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Gradebook.Controls;
using Gradebook.Data.Services;
using Gradebook.Data.Utils;

namespace Gradebook
{
    public partial class ClassView : ContentForm
    {
        private CategoryService categoryService;
        private string currentRole = MainView.role;
        private Person currentPerson = MainView.currentPerson;
        private TaughtCourse currentCourse = MainView.currentCourse;
        private List<Category> categoriesList;
        private int totalWeight;
        private List<TextBox> weightBoxes;

        public ClassView()
        {
            InitializeComponent();
            categoryService = new CategoryService();

            weightBoxes = new List<TextBox>();
            weightBoxes.Add(txtExams);
            weightBoxes.Add(txtHomework);
            weightBoxes.Add(txtParticipation);
            weightBoxes.Add(txtProjects);
            weightBoxes.Add(txtQuizzes);
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            if (currentRole == null || currentPerson == null || currentCourse == null)
            {
                lblClassViewError.Text = "Error loading form.";
                return;
            }

            if (currentRole.Equals("Teacher"))
            {
                cboTeacherName.Hide();
                txtTeacherName.Text = currentPerson.fullName;
            }
            else if (currentRole.Equals("Admin"))
            {
                txtTeacherName.Hide();
                // Get list of teachers and add to comboBox
                // Possibly move admin to their own form to clean things up
            }
            txtCourseName.Text = currentCourse.name;
            txtCourseDescription.Text = currentCourse.description;
            FillCategories();

        }

        private void FillCategories()
        {
            ClearMessageFields();
            try
            {
                categoriesList = categoryService.findCategoriesByTaughtCourseID(currentCourse.taughtCourseID);
                
                foreach (Category category in categoriesList)
                {
                    if (category.name == "Exams")
                        txtExams.Text = category.weight.ToString();
                    else if (category.name == "Homework")
                        txtHomework.Text = category.weight.ToString();
                    else if (category.name == "Participation")
                        txtParticipation.Text = category.weight.ToString();
                    else if (category.name == "Projects")
                        txtProjects.Text = category.weight.ToString();
                    else if (category.name == "Quizzes")
                        txtQuizzes.Text = category.weight.ToString();
                }
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Error loading categories.";
            }
        }

        private void TotalCategories(List<TextBox> weightBoxes)
        {
            ClearMessageFields();
            totalWeight = 0;
            foreach (TextBox weight in weightBoxes)
            {
                try
                {
                    totalWeight += ConversionUtils.TextBoxToInt(weight);
                }
                catch (Exception ex)
                {
                    lblClassViewError.Text = "Unable to convert " + weight.Tag + " to number.";
                    break;
                }
            }

            lblTotal.Text = totalWeight + "%";

            if (totalWeight != 100)
                lblTotal.ForeColor = Color.Red;
            else
                lblTotal.ForeColor = Color.Green;
        }

        ////////////////////////////////////////// Event Handlers  //////////////////////////////////////////

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (weightBoxes != null)
                TotalCategories(weightBoxes);            
        }

        private void AllowOnlyNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumber(e);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearMessageFields();
            FillCategories();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ClearMessageFields();
            if (totalWeight != 100)
            {
                lblClassViewError.Text = "Totals must be equal 100%";
                return;
            }

            // Updates DB with new categories
            try
            {
                foreach (Category category in categoriesList)
                {
                    if (category.name == "Exams")
                        category.weight = ConversionUtils.TextBoxToInt(txtExams);
                    else if (category.name == "Homework")
                        category.weight = ConversionUtils.TextBoxToInt(txtHomework);
                    else if (category.name == "Participation")
                        category.weight = ConversionUtils.TextBoxToInt(txtParticipation);
                    else if (category.name == "Projects")
                        category.weight = ConversionUtils.TextBoxToInt(txtProjects);
                    else if (category.name == "Quizzes")
                        category.weight = ConversionUtils.TextBoxToInt(txtQuizzes);
                }

                bool successful = categoryService.updateAllCategoriesForTaughtCourse(categoriesList);
                if (successful)
                    lblClassViewSuccess.Text = "Update was successful.";
                else
                    lblClassViewError.Text = "Update not working";
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Failed to update categories.";
            }
        }

        private void SetWeightToZero_LeaveText(object sender, EventArgs e)
        {
            if (weightBoxes != null)
            {
                foreach (TextBox weight in weightBoxes)
                {
                    if (String.IsNullOrEmpty(weight.Text))
                    {
                        weight.Text = "0";
                    }
                } 
            }
        }

        private void ClearMessageFields()
        {
            lblClassViewError.Text = "";
            lblClassViewSuccess.Text = "";
        }
    }
}
