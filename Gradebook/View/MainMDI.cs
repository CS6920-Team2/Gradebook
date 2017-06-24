using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Gradebook;
using Gradebook.Data.DAO;
using Gradebook.Controls;
using Gradebook.Data.Services;
using Gradebook.Data.Utils;
using Gradebook.View;

namespace Gradebook
{
    public partial class MainMDI : BaseForm
    {
        private RoleService roleService;
        private TeacherService teacherService;
        private PersonService personService;

        private string role;
        private Teacher currentTeacher;
        private Admin currentAdmin;
        private Course currentCourse;

        public MainMDI()
        {
            InitializeComponent();
            roleService = new RoleService();
            teacherService = new TeacherService();
            personService = new PersonService();
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                // Keep below methods in real application 
                this.AssignPerson();
                // this.LoadLeftNav();
                // this.LoadTopNav();
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error loading navigation bars.";
            }
        }

        ////////////////////////////////////////// Load Helpers //////////////////////////////////////////

        /// <summary> This method will pull and assign _user information. </summary>
        private void AssignPerson()
        {

            try
            {
                // Returns from Users joined with Roles: userID, userName, role
                role = roleService.findRole(currentUser.RoleID);

                if (role.Equals("Teacher"))
                {
                    Teacher tempTeacher = teacherService.getTeacherByUserID(currentUser.UserID);
                    currentTeacher = (Teacher)personService.getPersonByPersonID(tempTeacher.personID);
                    currentTeacher.teacherID = tempTeacher.teacherID;
                    /* Returns from Teachers table: teacherID, PersonID
                     * 
                     * Person tempUser = TeacherController.GetTeacherByUserID(userID);
                     * _user.teacherID = tempUser.teacherID;
                     * _user.personID = tempUser.personID;
                     * 
                     * Returns from Persons table: firstName, lastName (can add more as we see needed)
                     * 
                     * tempUser = PersonsController.GetPersonByPersonID(personID);
                     * _user.firstName = tempUser.firstName;
                     * _user.lastName = tempUser.lastName;
                     */
                }
                else if (role.Equals("Administrator"))
                {
                    /* Returns from Administrators table: adminID, PersonID
                     * 
                     * Person tempUser = AdminController.GetAdminByUserID(userID);
                     * _user.adminID = tempUser.adminID;
                     * _user.personID = tempUser.personID;
                     * 
                     * Returns from Persons table: firstName, lastName (can add more as we see needed)
                     * tempUser = PersonsController.GetPersonByPersonID(personID);
                     * _user.firstName = tempUser.firstName;
                     * _user.lastName = tempUser.lastName;
                     */

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLeftNav()
        {
            /* Loads in person information
            lblName.Text = currentPerson.lastName + ", " + currentPerson.firstName;
            lblRole.Text = currentPerson.role;
            lblIDNumber.Text = currentPerson.personID.ToString();
            if (currentPerson.role == "Teacher")
                lblRoleIDNumber.Text = currentPerson.teacherID.ToString();
            else if (currentPerson.role == "Admin")
                lblRoleIDNumber.Text = currentPerson.adminID.ToString();
            */
            // Loads in classes for teacher
            if (role == "Teacher")
            {
                try
                {
                    /* Keep code below
                    * 1-Retrieve list of courses from Courses join Taught Courses: taughtCourseID, Courses.name 
                    * 2-Set values to comboBox
                    * 
                    * Commented items below will replace the fake model objects
                    */

                    // List<Courses> = CoursesController.GetCoursesByTeacherID(teacherID);
                    List<Course> courseList = new List<Course>();
                    Course course1 = new Course()
                    {
                        name = "Algebra",
                        courseID = 1,
                        description = "Exploring equations and their relation to the coordinate plane.",
                        taughtCourseID = 1,

                    };
                    Course course2 = new Course()
                    {
                        name = "Geometry",
                        courseID = 2,
                        description = "Deals with measurement, points, lines, angles, along with two and three dimensional sufaces.",
                        taughtCourseID = 4
                    };
                    courseList.Add(course1);
                    courseList.Add(course2);

                    // Keep items below
                    cboCourses.DataSource = courseList;
                    cboCourses.DisplayMember = "name";
                    cboCourses.ValueMember = "taughtCourseID";
                    cboCourses.SelectedIndex = 0;
                    currentCourse = (Course) cboCourses.SelectedItem;
                    lblTaughtCourseID.Text = cboCourses.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void LoadTopNav()
        {
            if (role == "Admin")
            {
                btnAssignmentsView.Visible = false;
                btnGradebookView.Visible = false;
                btnReportsView.Visible = false;
                cboCourses.Visible = false;
            }  
        }
        ////////////////////////////////////////// Nav Controller Event Triggers  //////////////////////////////////////////
        
        /// <summary> Opens the class view form in the MDI while closing all other forms </summary>
        private void BtnClassView_Click(object sender, EventArgs e)
        {
            //var form = FormManager.Current.CreateForm<ClassView>();
            var form = this;
            if (ActiveMdiChild != null)
               ActiveMdiChild.Close();

            form.MdiParent = this;
            form.Show();
            this.RemoveChildWindowBorders(form);
        }

        /// <summary> Opens the assigments view form in the MDI while closing all other forms </summary>
        private void BtnAssignmentsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            AssignmentsView _assignmentsView;
            _assignmentsView = new AssignmentsView() { MdiParent = this };
            _assignmentsView.Show();
            this.RemoveChildWindowBorders(_assignmentsView);
        }

        private void BtnGradebookView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_gradebookView = new GradebookView { MdiParent = this };
            //_gradebookView.Show();
            //this.RemoveChildWindowBorders(_gradebookView);
        }

        private void BtnReportsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_reportsView = new ReportsView() { MdiParent = this };
            //_reportsView.Show();
            //this.RemoveChildWindowBorders(_reportsView);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            //if(_loginWindow != null)
            //{
             //   this._loginWindow.Visibility = Visibility.Visible;
            //}
            
            //this.Close();
        }

        private void CboClasses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCourse = (Course)cboCourses.SelectedItem;
            lblTaughtCourseID.Text = cboCourses.SelectedValue.ToString();

            //if (_classView != null)
            //    this.BtnClassView_Click(null, null);
            //else if (_assignmentsView != null)
            //    this.BtnAssignmentsView_Click(null, null);
            //else if (_gradebookView != null)
            //    this.BtnGradebookView_Click(null, null);
            //else if (_reportsView != null)
            //    this.BtnReportsView_Click(null, null);
        }
        

        ////////////////////////////////////////// Form and Window Managers //////////////////////////////////////////

        private void RemoveChildWindowBorders(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox  = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon    = false;
            form.Text        = "";
            form.Dock        = DockStyle.Fill;
        }
        
    }
}
