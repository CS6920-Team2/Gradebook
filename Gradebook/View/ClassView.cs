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

            if (MainView.role.Equals("Teacher"))
            {
                cboTeacherName.Hide();
                txtTeacherName.Text = currentPerson.fullName;
            }
            else if (MainView.role.Equals("Admin"))
            {
                txtTeacherName.Hide();
                // Get list of teachers and add to comboBox
            }
            txtCourseName.Text = currentCourse.name;
            txtCourseDescription.Text = currentCourse.description;
            FillCategories();

        }

        private void FillCategories()
        {
            
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
            totalWeight = 0;
            foreach (TextBox weight in weightBoxes)
            {
                totalWeight += TextBoxToInt(weight);
            }

            lblTotal.Text = totalWeight + "%";
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

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (weightBoxes != null)
                this.TotalCategories(weightBoxes);
        }

        private void AllowOnlyNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowOnlyNumber(e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FillCategories();
            lblClassViewError.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
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
                        category.weight = TextBoxToInt(txtExams);
                    else if (category.name == "Homework")
                        category.weight = TextBoxToInt(txtHomework);
                    else if (category.name == "Participation")
                        category.weight = TextBoxToInt(txtParticipation);
                    else if (category.name == "Projects")
                        category.weight = TextBoxToInt(txtProjects);
                    else if (category.name == "Quizzes")
                        category.weight = TextBoxToInt(txtQuizzes);

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
