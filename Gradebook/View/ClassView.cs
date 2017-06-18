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

namespace Gradebook
{
    public partial class ClassView : Form
    {
        private Person _user;
        private Course _currentCourse;
        private List<Category> _categoriesList;
        private int _totalWeight;

        public ClassView(Person user, Course currentCourse)
        {
            InitializeComponent();
            _user = user;
            _currentCourse = currentCourse;
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
        /// 5- Totals of categories should be added up
        /// </summary>
        private void ClassView_Load(object sender, EventArgs e)
        {
            // 1 
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
            
            // 2
            textBoxCourseName.Text = _currentCourse.name;

            // 3
            textBoxCourseDescription.Text = _currentCourse.description;

            // 4
            this.FillCategories(_currentCourse.taughtCourseID);

            //
            this.TotalCategories(_categoriesList);
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
        private void TotalCategories(List<Category> categoriesList)
        {
            foreach (Category category in categoriesList)
            {
                _totalWeight += category.weight;
            }

            lblTotal.Text = _totalWeight + "%";
        }

    }
}
