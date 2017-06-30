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
        private CourseService courseService;

        private List<Category> categoriesList;
        private List<TextBox> categoryBoxes;
        private TaughtCourse currentCourse;
        private bool addCourseToggleIsActive;
        private bool keepCurrentAttributes;
        private int currentTeacherID;
        private int totalWeight;

        public ClassView()
        {
            InitializeComponent();
            InitializeCategoryBoxes();
            keepCurrentAttributes = false;
            categoryService = new CategoryService();
            teacherService = new TeacherService();
            tcService = new TaughtCourseService();
            courseService = new CourseService();
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

            cboTeachers.Visible = false;
            cboCourses.Visible = false;
            lblCourseID.Visible = false;
            txtTaughtCourseID.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            gboxUserOptions.Visible = false;

            FillCategoriesForTaughtCourse();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearMessageFields();

            if (addCourseToggleIsActive)
            {
                ClearCourseAttributes();
                FillTeacherComboBox();
                FillAllCategoryBoxesTo(20);
                keepCurrentAttributes = false;
                btnAdd.Enabled = true;
            }
            else
            {
                FillCategoriesForTaughtCourse();
            }
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
            if (!keepCurrentAttributes)
            {
                ClearCourseAttributes();
                FillTeacherComboBox();
                FillAllCategoryBoxesTo(20);
            }

            ToggleSetForAddNewCourse(true);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearMessageFields();
            bool formIsValid = ValidateAddForm();

            if (formIsValid)
            {
                int teacherID = (int)cboTeachers.SelectedValue;

                Course newCourse = new Course()
                {
                    creditID = 1,
                    name = txtCourseName.Text,
                    description = txtCourseDescription.Text
                };

                categoriesList = InitializeNewCategoryList();
                UpdateCategoryListUsingFormValues(); 

                try
                {
                    bool success = tcService.addTaughtCourseWithCategories(teacherID, newCourse, categoriesList);

                    if (success)
                    {
                        lblClassViewSuccess.Text = "Class added successfully.";
                        keepCurrentAttributes = true;
                        btnAdd.Enabled = false;
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
            btnAddToggle.CheckState = CheckState.Checked;
            btnDeleteToggle.CheckState = CheckState.Unchecked;

            LoadAdminAddView();
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
            FillCourseInformation();
            FillCategoriesForTaughtCourse();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult reuslt = MessageBox.Show(
                            "Are you sure you want to delete this class?\n" +
                            "This change will be irreversible.", "Caution", 
                            MessageBoxButtons.OKCancel, 
                            MessageBoxIcon.Warning);

            if (reuslt == DialogResult.OK)
            {
                // Delete
            }    
        }

        private void BtnDeleteToggle_Click(object sender, EventArgs e)
        {
            btnAddToggle.CheckState = CheckState.Unchecked;
            btnDeleteToggle.CheckState = CheckState.Checked;

            ClearCourseAttributes();
            LoadAdminDeleteView(); 
        }

        private void ToggleSetForAddNewCourse(bool activate)
        {
            addCourseToggleIsActive = activate;
            txtCourseName.Visible = activate;
            btnReset.Visible = activate;
            keepCurrentAttributes = activate;

            txtCourseDescription.ReadOnly = !activate;
            cboCourses.Visible = !activate;
            lblCourseID.Visible = !activate;
            txtTaughtCourseID.Visible = !activate;
            btnDelete.Visible = !activate;
            SetCategoryBoxesToReadOnly(!activate);

            btnUpdate.Visible = false;
            txtTeacherName.Visible = false;
            txtCourseName.ReadOnly = false;
        }

        private void ClearCourseAttributes()
        {
            txtCourseName.Text = "";
            txtCourseDescription.Text = "";
        }

        private void FillTeacherComboBox()
        {
            ClearMessageFields();

            try
            {
                List<Teacher> teachers = teacherService.getAllTeachers();
                cboTeachers.DataSource = teachers;
                cboTeachers.DisplayMember = "fullName";
                cboTeachers.ValueMember = "teacherID";
                cboTeachers.SelectedIndex = 0;

                currentTeacherID = (int)cboTeachers.SelectedValue;
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Unable to find any teachers.";
            }
        }

        private void CboTeachers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentTeacherID = (int)cboTeachers.SelectedValue;
            FillCourseInformation();
        }

        private void FillCourseInformation()
        {
            ClearMessageFields();

            try
            {
                List<TaughtCourse> courseList = courseService.findCoursesByTeacherID(currentTeacherID);
                cboCourses.DataSource = courseList;
                cboCourses.DisplayMember = "name";
                cboCourses.ValueMember = "taughtCourseID";
                cboCourses.SelectedIndex = 0;
                currentCourse = (TaughtCourse)cboCourses.SelectedItem;

                txtTaughtCourseID.Text = currentCourse.taughtCourseID.ToString();
                txtCourseDescription.Text = currentCourse.description;
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Unable to find courses for teacher.";
            }
        }


        private void CboCourses_SelectChangeCommitted(object sender, EventArgs e)
        {
            currentCourse = (TaughtCourse) cboCourses.SelectedItem;
            txtTaughtCourseID.Text = currentCourse.taughtCourseID.ToString();
            txtCourseDescription.Text = currentCourse.description;

            FillCategoriesForTaughtCourse();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////// CATEGORY HELPERS ////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  

        public void InitializeCategoryBoxes()
        {
            categoryBoxes = new List<TextBox>() { txtExams, txtHomework, txtParticipation, txtProjects, txtQuizzes };
        }

        private List<Category> InitializeNewCategoryList()
        {
            List<String> categoryNames = new List<string>()
            {
                "Exams", "Homework", "Participation", "Projects", "Quizzes"
            };
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
                    if (category.name.Equals("Exams", StringComparison.InvariantCultureIgnoreCase))
                        txtExams.Text = category.weight.ToString();
                    else if (category.name.Equals("Homework", StringComparison.InvariantCultureIgnoreCase))
                        txtHomework.Text = category.weight.ToString();
                    else if (category.name.Equals("Participation", StringComparison.InvariantCultureIgnoreCase))
                        txtParticipation.Text = category.weight.ToString();
                    else if (category.name.Equals("Projects", StringComparison.InvariantCultureIgnoreCase))
                        txtProjects.Text = category.weight.ToString();
                    else if (category.name.Equals("Quizzes", StringComparison.InvariantCultureIgnoreCase))
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
                if (category.name.Equals("Exams", StringComparison.InvariantCultureIgnoreCase))
                    category.weight = ConversionUtils.TextBoxToInt(txtExams);
                else if (category.name.Equals("Homework", StringComparison.InvariantCultureIgnoreCase))
                    category.weight = ConversionUtils.TextBoxToInt(txtHomework);
                else if (category.name.Equals("Participation", StringComparison.InvariantCultureIgnoreCase))
                    category.weight = ConversionUtils.TextBoxToInt(txtParticipation);
                else if (category.name.Equals("Projects", StringComparison.InvariantCultureIgnoreCase))
                    category.weight = ConversionUtils.TextBoxToInt(txtProjects);
                else if (category.name.Equals("Quizzes", StringComparison.InvariantCultureIgnoreCase))
                    category.weight = ConversionUtils.TextBoxToInt(txtQuizzes);
            }
        }

        private void TotalCategories(List<TextBox> textBoxes)
        {
            totalWeight = 0;
            foreach (TextBox box in textBoxes)
            {
                try
                {
                    totalWeight += ConversionUtils.TextBoxToInt(box);
                }
                catch (Exception ex)
                {
                    lblClassViewError.Text = "Unable to convert " + box.Tag + " to number.";
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
                foreach (TextBox categoryBox in categoryBoxes)
                {
                    if (String.IsNullOrEmpty(categoryBox.Text))
                    {
                        categoryBox.Text = "0";
                    }
                } 
            }
        }

        private void SetCategoryBoxesToReadOnly(bool isReadOnly)
        {
            foreach (TextBox categoryBox in categoryBoxes)
            {
                categoryBox.ReadOnly = isReadOnly;
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
