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
        private Person _user;
        private string _userName;

        /// <summary>
        /// User name will be stored to help us retrieve user info
        /// 
        /// Login window will be hidden, but hosted here for 
        /// when we want to make it visible (after user logs out)
        /// </summary>
        
        /* 
        public MainMDI(Window loginWindow, string userName)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
            _userName = userName;
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
        /// 2-Show left navigation info for that user: firstName, lastName, role, personID, roleID(teacher or admin)
        /// 3-Show menu items that the person should have access to.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                // Mock user placed below to cover for the AssignPerson method

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
                lblErrorMessage.Text = "Error loading main window.";
            }
        }

        ////////////////////////////////////////// Load Helpers //////////////////////////////////////////

        /// <summary>
        /// This method will pull user information for _user object.
        /// </summary>
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
        /// This method will load all of our user information into the navigation panel
        /// on the left side of the Main UI 
        /// </summary>
        private void LoadLeftNav()
        {
            lblName.Text = _user.lastName + ", " + _user.firstName;
            lblRole.Text = _user.role;
            lblIDNumber.Text = _user.personID.ToString();
            if (_user.role == "Teacher")
                lblRoleIDNumber.Text = _user.teacherID.ToString();
            else if (_user.role == "Admin")
                lblRoleIDNumber.Text = _user.adminID.ToString();
        }

        /// <summary>
        /// This method will laod all of the buttons that our user should be able to 
        /// user in the top navigation panel of the Main UI 
        /// 
        /// Note: All buttons are naturally visible to the user.Thus, only
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
                comboBoxClasses.Visible = false;
            }  
        }

        ////////////////////////////////////////// Button Actions //////////////////////////////////////////

         /// <summary>
         /// Opens the class view form in the MDI while closing
         /// all other windows that may be open
         /// </summary>
        private void btnClassView_Click(object sender, EventArgs e)
        {
            if (_classView == null)
            {
                _classView = new ClassView();
                _classView.MdiParent = this;
                _classView.Show();

                this.removeChildWindowBorders(_classView);
                this.closeUnusedFormsExcept(_classView);
            } 

        }

        /// <summary> Allows user to logout of the system and return to the login screen </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this._loginWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        ////////////////////////////////////////// Form and Window Managers //////////////////////////////////////////

        /// <summary>
        /// When a window is maximized within an MDI the frame usually shows
        /// with an extra navigation bar at the top (min, max, and exit buttons).
        /// 
        /// This method will remove those from the Windows that will appear in each 
        /// of our view
        /// </summary>
        private void removeChildWindowBorders(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox  = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon    = false;
            form.Text        = "";
            form.Dock        = DockStyle.Fill;
        }

        /// <summary>
        /// This method will search through the MDI, close all Forms that aren't being
        /// used and keep the one open that we want open. This way, we won't have 
        /// forms running in the background and slowing down the applicaiton.
        /// </summary>
        private void closeUnusedFormsExcept(Form formToKeep)
        {
            if (_classView != null && _classView != formToKeep)
                _classView.Close();
            else if (_assignmentsView != null && _assignmentsView != formToKeep)
                _assignmentsView.Close();
            else if (_gradebookView != null && _gradebookView != formToKeep)
                _gradebookView.Close();
            else if (_reportsView != null && _reportsView != formToKeep)
                 _reportsView.Close();
        }


        /// <summary> Disposes of the MainMDI window and shows the login window. </summary>
        private void MainMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loginWindow.Visibility = Visibility.Visible;
            this.Dispose();
        }
    }
}
