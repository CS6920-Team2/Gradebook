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
        private List<Category> categoriesList;
        private List<TextBox> categoryBoxes;
        private TaughtCourse currentCourse;
        private bool addToggleActive;
        private int totalWeight;
        
        public ClassView()
        {
            InitializeComponent();
            categoryService = new CategoryService();
            InitializeCategoryBoxes();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            if (MainView.role.Equals("Teacher"))
            {
                LoadTeacherView();
            }
            else if (MainView.role.Equals("Administrator"))
            {
                LoadAdminAddView();
                btnAddToggle.CheckState = CheckState.Checked;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// TEACHER VIEW ////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        private void LoadTeacherView()
        {
            currentCourse = MainView.currentCourse;
            txtTeacherName.Text = MainView.currentPerson.fullName;
            txtCourseName.Text = currentCourse.name;
            txtCourseDescription.Text = currentCourse.description;

            cboTeacherName.Visible = false;
            cboCourseName.Visible = false;
            lblCourseID.Visible = false;
            txtCourseID.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            gboxUserOptions.Visible = false;

            FillCategoriesForTaughtCourse();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearMessageFields();
            FillCategoriesForTaughtCourse();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ClearMessageFields();

            if (totalWeight == 100)
            {
                try
                {
                    PullCategoriesInForm();

                    bool updateSuccessful = categoryService.updateAllCategoriesForTaughtCourse(categoriesList);

                    if (updateSuccessful)
                        lblClassViewSuccess.Text = "Update was successful.";
                    else
                        lblClassViewError.Text = "Update not working";
                }
                catch (Exception ex)
                {
                    lblClassViewError.Text = "Error updating weights in database.";
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// ADMIN VIEW //////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        private void LoadAdminAddView()
        {
            ToggleAdminControls(true);

            FillAllCategoriesTo(20);
        }

        private void LoadAdminDeleteView()
        {
            ToggleAdminControls(false);

            // Delete item below later
            FillAllCategoriesTo(20);
        }

        private void BtnAddToggle_Click(object sender, EventArgs e)
        {
            btnAddToggle.CheckState = CheckState.Checked;
            btnDeleteToggle.CheckState = CheckState.Unchecked;

            LoadAdminAddView();
        }

        private void BtnDeleteToggle_Click(object sender, EventArgs e)
        {
            btnAddToggle.CheckState = CheckState.Unchecked;
            btnDeleteToggle.CheckState = CheckState.Checked;

            LoadAdminDeleteView();
        }
        private void ToggleAdminControls(bool activate)
        {
            txtCourseName.Visible = activate;

            txtCourseDescription.ReadOnly = !activate;
            cboCourseName.Visible = !activate;
            lblCourseID.Visible = !activate;
            txtCourseID.Visible = !activate;
            btnDelete.Visible = !activate;

            btnReset.Visible = false;
            btnUpdate.Visible = false;
            txtTeacherName.Visible = false;
            txtCourseName.ReadOnly = false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// CATEGORY WEIGHT HELPERS /////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        public void InitializeCategoryBoxes()
        {
            categoryBoxes = new List<TextBox>();
            categoryBoxes.Add(txtExams);
            categoryBoxes.Add(txtHomework);
            categoryBoxes.Add(txtParticipation);
            categoryBoxes.Add(txtProjects);
            categoryBoxes.Add(txtQuizzes);
        }

        private void FillAllCategoriesTo(int fillAmount)
        {
            foreach (TextBox categoryBox in categoryBoxes)
            {
                categoryBox.Text = fillAmount + "";
            }
        }

        private void FillCategoriesForTaughtCourse()
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

        private void PullCategoriesInForm()
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
            lblTotal.ForeColor = totalWeight != 100 ? Color.Red : Color.Green;
        }

        private void SetCategoryToZero_LeaveText(object sender, EventArgs e)
        {
            if (categoryBoxes != null)
            {
                foreach (TextBox weight in categoryBoxes)
                {
                    if (String.IsNullOrEmpty(weight.Text))
                    {
                        weight.Text = "0";
                    }
                } 
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// CLASS VIEW MANAGERS /////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (categoryBoxes != null)
                TotalCategories(categoryBoxes);
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

        private void ClearMessageFields()
        {
            lblClassViewError.Text = "";
            lblClassViewSuccess.Text = "";
        }
    }
}
