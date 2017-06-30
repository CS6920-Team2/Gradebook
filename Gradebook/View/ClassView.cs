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
        private TeacherService teacherService;
        private TaughtCourseService tcService;
        private List<Category> categoriesList;
        private List<TextBox> categoryBoxes;
        private TaughtCourse currentCourse;
        private bool addCourseToggleIsActive;
        private int totalWeight;

        public ClassView()
        {
            InitializeComponent();
            InitializeCategoryBoxes();
            categoryService = new CategoryService();
            teacherService = new TeacherService();
            tcService = new TaughtCourseService();

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

            if (IsWeightTotal100())
            {
                try
                {
                    UpdateCategoryListUsingFormValues();

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
        ///////////////////////////////////////////////// ADD ADMIN VIEW //////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        private void LoadAdminAddView()
        {
            ToggleSetForAddNewCourse(true);
            
            FillTeacherComboBox();
            FillAllCategoryBoxesTo(20);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearMessageFields();
            bool formIsValid = ValidateAddForm();

            if (formIsValid)
            {
                // Teacher ID
                int teacherID = (int)cboTeacherName.SelectedValue;

                // Course info
                Course newCourse = new Course()
                {
                    creditID = 1,
                    name = txtCourseName.Text,
                    description = txtCourseDescription.Text
                };

                // Categories
                categoriesList = InitializeNewCategoryList();
                UpdateCategoryListUsingFormValues(); 

                // Add to DB
                try
                {
                    bool success = tcService.addTaughtCourseWithCategories(teacherID, newCourse, categoriesList);

                    if (success)
                    {
                        lblClassViewSuccess.Text = "Class added successfully.";
                        LoadAdminAddView();
                    }
                    else
                        lblClassViewError.Text = "Unable to add class successfully.";
                }
                catch (Exception ex)
                {
                    lblClassViewError.Text = "Error adding class to database.";
                }
            }
        }

        private void BtnAddToggle_Click(object sender, EventArgs e)
        {
            if (!addCourseToggleIsActive)
            {
                btnAddToggle.CheckState = CheckState.Checked;
                btnDeleteToggle.CheckState = CheckState.Unchecked;

                LoadAdminAddView(); 
            }
        }

        private bool ValidateAddForm()
        {
            return (Validator.IsPresent(txtCourseName, lblClassViewError) &&
                    Validator.IsPresent(txtCourseDescription, lblClassViewError) &&
                    IsWeightTotal100());
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// DELETE ADMIN VIEW ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        private void LoadAdminDeleteView()
        {
            ToggleSetForAddNewCourse(false);

            FillTeacherComboBox();

            // Delete item below later
            FillAllCategoryBoxesTo(20);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteToggle_Click(object sender, EventArgs e)
        {
            if (addCourseToggleIsActive)
            {
                btnAddToggle.CheckState = CheckState.Unchecked;
                btnDeleteToggle.CheckState = CheckState.Checked;

                LoadAdminDeleteView(); 
            }
        }

        private void ToggleSetForAddNewCourse(bool activate)
        {
            addCourseToggleIsActive = activate;
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

            txtCourseName.Text = "";
            txtCourseDescription.Text = "";
        }

        private void FillTeacherComboBox()
        {
            try
            {
                List<Teacher> teachers = teacherService.getAllTeachers();
                cboTeacherName.DataSource = teachers;
                cboTeacherName.DisplayMember = "fullName";
                cboTeacherName.ValueMember = "teacherID";
                cboTeacherName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Unable to find any teachers.";
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// CATEGORY WEIGHT HELPERS /////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        public void InitializeCategoryBoxes()
        {
            categoryBoxes = new List<TextBox>() { txtExams, txtHomework, txtParticipation, txtProjects, txtQuizzes };
        }

        private List<Category> InitializeNewCategoryList()
        {
            List<String> categoryNames = new List<string>() { "Exams", "Homework", "Participation", "Projects", "Quizzes" };
            List<Category> newCategories = new List<Category>();

            foreach (String categoryName in categoryNames)
            {
                Category category = new Category() { name = categoryName };
                newCategories.Add(category);
            }

            return newCategories;
        }

        private void FillAllCategoryBoxesTo(int fillAmount)
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

        private void UpdateCategoryListUsingFormValues()
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

        private bool IsWeightTotal100()
        {
            if (totalWeight != 100)
            {
                lblClassViewError.Text = "Total weight must equal 100.";
                return false;
            }
            return true;
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
