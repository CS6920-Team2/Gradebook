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

namespace Gradebook
{
    public partial class MainMDI : Form
    {
        private Form _classView;
        private Form _assignmentsView;
        private Form _gradebookView;
        private Form _reportsView;
        private Window _loginWindow;
        private string _userName;
        private Person _user;
        private int _taughtCourseID;

        /// <summary>
        /// User name will be stored to help us retrieve _user info
        /// 
        /// Login window will be hidden, but hosted here for 
        /// when we want to make it visible (after _user logs out)
        /// </summary>
        
        /* 
        public MainMDI(Window loginWindow, string userName)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
            _user = new Person();
            _user.userName = userName;
        }
        */

        // Planning to use the contructor above
        public MainMDI(Window loginWindow)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
        }

        /// <summary>
        /// Upon loading we should: 
        /// 
        /// 1-Assign the person who is using the application
        /// 2-Show left navigation info for that _user: firstName, lastName, role, personID, roleID(teacher or admin)
        /// 3-Show menu items that the person should have access to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                // Mock _user placed below to cover for the AssignPerson method

                // Keep below methods in real application 
                // this.AssignPerson();
                // this.LoadLeftNav();
                // this.LoadTopNav();

                // Delete mock draft below after login form is added to app
                _user = new Person()
                {
                    firstName = "Jacob",
                    lastName = "Radcliffe",
                    role = "Teacher",
                    personID = 1,
                    teacherID = 1
                };
                this.LoadLeftNav();
                this.LoadTopNav();
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
                // _user = new Person();
                // _user = UsersController.GetUserByUserName(_user.userName);

                if (_user.role == "Teacher")
                {
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
                else if (_user.role == "Admin")
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

        /// <summary>
        /// This method will load all of our _user information into the navigation panel
        /// on the left side of the Main UI 
        /// </summary>
        private void LoadLeftNav()
        {
            // Loads in teacher information
            lblName.Text = _user.lastName + ", " + _user.firstName;
            lblRole.Text = _user.role;
            lblIDNumber.Text = _user.personID.ToString();
            if (_user.role == "Teacher")
                lblRoleIDNumber.Text = _user.teacherID.ToString();
            else if (_user.role == "Admin")
                lblRoleIDNumber.Text = _user.adminID.ToString();

            // Loads in classes for teacher
            if (_user.role == "Teacher")
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
                        name = "Math",
                        taughtCourseID = 1
                    };
                    Course course2 = new Course()
                    {
                        name = "English",
                        taughtCourseID = 4
                    };
                    courseList.Add(course1);
                    courseList.Add(course2);

                    // Keep items below
                    cboCourses.DataSource = courseList;
                    cboCourses.DisplayMember = "name";
                    cboCourses.ValueMember = "taughtCourseID";
                    cboCourses.SelectedIndex = 0;
                    _taughtCourseID = (int)cboCourses.SelectedValue;
                    lblTaughtCourseID.Text = cboCourses.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// This method will laod all of the buttons that our _user should be able to 
        /// _user in the top navigation panel of the Main UI 
        /// 
        /// Note: All buttons are naturally visible to the _user.Thus, only
        /// restrictions that need to be applied are to the admin since
        /// we are only allowing them to use a few features right now.
        /// </summary>
        private void LoadTopNav()
        {
            if (_user.role == "Admin")
            {
                btnAssignmentsView.Visible = false;
                btnGradebookView.Visible = false;
                btnReportsView.Visible = false;
                cboCourses.Visible = false;
            }  
        }
        ////////////////////////////////////////// Nav Controller Even Triggers  //////////////////////////////////////////

        /// <summary> Opens the class view form in the MDI while closing all other forms </summary>
        private void BtnClassView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
               ActiveMdiChild.Close();

            _classView = new ClassView(_user, _taughtCourseID) {MdiParent = this};
            _classView.Show();
            this.RemoveChildWindowBorders(_classView);
        }

        /// <summary> Opens the assigments view form in the MDI while closing all other forms </summary>
        private void BtnAssignmentsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_assignmentsView = new AssignmentsView() { MdiParent = this };
            //_assignmentsView.Show();
            //this.RemoveChildWindowBorders(_assignmentsView);
        }

        /// <summary> Opens the gradebook view form in the MDI while closing all other forms </summary>
        private void BtnGradebookView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_gradebookView = new GradebookView { MdiParent = this };
            //_gradebookView.Show();
            //this.RemoveChildWindowBorders(_gradebookView);
        }

        /// <summary> Opens the reports view form in the MDI while closing all other forms </summary>
        private void BtnReportsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_reportsView = new ReportsView() { MdiParent = this };
            //_reportsView.Show();
            //this.RemoveChildWindowBorders(_reportsView);
        }

        /// <summary> Allows _user to logout of the system and return to the login screen </summary>
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this._loginWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        /// <summary>
        /// This method is used purely to help the development process.
        /// 
        /// When the cboClasses in the top nav is selected, the label to the right of
        /// it will change and show the taught courseID. This will be removed (or hidden) 
        /// in the final release of the application.
        /// </summary>
        private void CboClasses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _taughtCourseID = (int)cboCourses.SelectedValue;
            lblTaughtCourseID.Text = cboCourses.SelectedValue.ToString();

            if (_classView != null)
                this.BtnClassView_Click(null, null);
            else if (_assignmentsView != null)
                this.BtnAssignmentsView_Click(null, null);
            else if (_gradebookView != null)
                this.BtnGradebookView_Click(null, null);
            else if (_reportsView != null)
                this.BtnReportsView_Click(null, null);
        }

        ////////////////////////////////////////// Form and Window Managers //////////////////////////////////////////

        /// <summary>
        /// When a window is maximized within an MDI the frame usually shows
        /// with an extra navigation bar at the top (min, max, and exit buttons).
        /// 
        /// This method will remove those from the Windows that will appear in each 
        /// of our view
        /// </summary>
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

        /// <summary> Disposes of the MainMDI window and shows the login window. </summary>
        private void MainMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginWindow.Visibility = Visibility.Visible;
            this.Dispose();
        }

    }
}
