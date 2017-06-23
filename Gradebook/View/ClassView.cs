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

namespace Gradebook
{
    public partial class ClassView : Form
    {
        private Person _user;
        private Course _currentCourse;
        private List<Category> _categoriesList;
        private int _totalWeight;
        private List<TextBox> _weightBoxes;

        public ClassView(Person user, Course currentCourse)
        {
            InitializeComponent();
            _user = user;
            _currentCourse = currentCourse;

            _weightBoxes = new List<TextBox>();
            _weightBoxes.Add(textBoxExams);
            _weightBoxes.Add(textBoxHomework);
            _weightBoxes.Add(textBoxParticipation);
            _weightBoxes.Add(textBoxProjects);
            _weightBoxes.Add(textBoxQuizzes);
        }

        /// <summary>
        /// On load the following should happen: 
        /// 1- Teacher name should be placed in: textBoxTeacher
        /// Gather from user
        /// 
        /// 2- Course name should be placed in: textBoxCoureName
        /// Gather from courses combo box in left nav
        /// 
        /// 3- Course description should be placed in: textCourseDescription
        /// 
        /// 4- Category weights should be placed in for each category: 
        /// Will hardcode name based on which category is being filled in
        /// None exist? set to defaults
        /// 
        /// 5- Totals of categories should be added up (event handlers)
        /// </summary>
        private void ClassView_Load(object sender, EventArgs e)
        {
            /*
            if (_user.role == "Teacher")
            {
                cboTeacherName.Hide();
                textBoxTeacherName.Text = _user.fullName;
            }
            else if (_user.role == "Admin")
            {
                textBoxTeacherName.Hide();
                // Get list of teachers and add to comboBox
            }
            textBoxCourseName.Text = _currentCourse.name;
            textBoxCourseDescription.Text = _currentCourse.description;
            this.FillCategories(_currentCourse.taughtCourseID);
            */
        }

        /// <summary> 
        /// Returns from TaughtCourses join Categories: categoryID, name, weight 
        /// Fills in text boxes accordingly. 
        /// </summary>
        private void FillCategories(int taughtCourseID)
        {
            try
            {
                // _categoryList = CoursesController.GetCategoriesByTaughtCourseID(_currentCourse.courseID)
                _categoriesList = new List<Category>();
                Category exams = new Category()
                {
                    categoryID = 1,
                    name = "Exams",
                    weight = 20
                };
                Category homework = new Category()
                {
                    categoryID = 2,
                    name = "Homework",
                    weight = 20
                };
                Category participation = new Category()
                {
                    categoryID = 3,
                    name = "Participation",
                    weight = 20
                };
                Category projects = new Category()
                {
                    categoryID = 4,
                    name = "Projects",
                    weight = 20
                };
                Category quizzes = new Category()
                {
                    categoryID = 5,
                    name = "Quizzes",
                    weight = 20
                };
                _categoriesList.Add(exams);
                _categoriesList.Add(homework);
                _categoriesList.Add(participation);
                _categoriesList.Add(projects);
                _categoriesList.Add(quizzes);

                // Keep the code below 
                foreach (Category category in _categoriesList)
                {
                    if (category.name == "Exams")
                        textBoxExams.Text = category.weight.ToString();
                    else if (category.name == "Homework")
                        textBoxHomework.Text = category.weight.ToString();
                    else if (category.name == "Participation")
                        textBoxParticipation.Text = category.weight.ToString();
                    else if (category.name == "Projects")
                        textBoxProjects.Text = category.weight.ToString();
                    else if (category.name == "Quizzes")
                        textBoxQuizzes.Text = category.weight.ToString();
                }
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Error loading categories.";
            }
        }

        /// <summary> Adds all the category weights together </summary>
        private void TotalCategories(List<TextBox> weightBoxes)
        {
            _totalWeight = 0;
            foreach (TextBox weight in weightBoxes)
            {
                _totalWeight += TextBoxToInt(weight);
            }

            lblTotal.Text = _totalWeight + "%";
        }

        private int TextBoxToInt(TextBox textBox)
        {
            try
            {
                if (textBox.Text != "")
                {
                    int number;
                    number = Convert.ToInt32(textBox.Text);
                    number = int.Parse(textBox.Text);
                    return number;
                }
                return 0;
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Error converting text to string" + textBox.Name.ToString();
                return 0;
            }
        }

        ////////////////////////////////////////// Event Handlers  //////////////////////////////////////////

        /// <summary> Changes totals when weight text boxes are changed. </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (_weightBoxes != null)
                this.TotalCategories(_weightBoxes);
        }


        /// <summary> 
        /// The event below and its helper make it so only integers
        /// are allowed to be entered into the category weights. 
        /// </summary>
        private void AllowOnlyNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.AllowOnlyNumber(e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.FillCategories(_currentCourse.taughtCourseID);
            lblClassViewError.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_totalWeight != 100)
            {
                lblClassViewError.Text = "Totals must be equal 100%";
                return;
            }
            
            // Updates DB with new categories
            try
            {

                foreach (Category category in _categoriesList)
                {
                    if (category.name == "Exams")
                        category.weight = TextBoxToInt(textBoxExams);
                    else if (category.name == "Homework")
                        category.weight = TextBoxToInt(textBoxHomework);
                    else if (category.name == "Participation")
                        category.weight = TextBoxToInt(textBoxParticipation);
                    else if (category.name == "Projects")
                        category.weight = TextBoxToInt(textBoxProjects);
                    else if (category.name == "Quizzes")
                        category.weight = TextBoxToInt(textBoxQuizzes);

                    //bool updated = CategoriesController.CategoriesDB.UpdateCategory(category);
                    bool updated = false;
                    if (!updated)
                    {
                        lblClassViewError.Text = "Failed to update category " + category.name;
                        return;
                    }
                        
                }
            }
            catch (Exception ex)
            {
                lblClassViewError.Text = "Unable to update categories in DB.";
            }
        }
    }
}
