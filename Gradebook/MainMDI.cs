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
        private Person user;


        /* User will be passed as a parameter in order to keep track of who is using the program
        public MainMDI(Window loginWindow, Person user)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            this.user = user;
        }
        */

        public MainMDI(Window loginWindow)
        {
            InitializeComponent();
            _loginWindow = loginWindow;
        }


        private void MainMDI_Load(object sender, EventArgs e)
        {

        }

        /* Opens the class view form in the MDI while closing
         * all other windows that may be open
         */
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

        /* When a window is maximized within an MDI the frame usually shows
         * with an extra navigation bar at the top (min, max, and exit buttons).
         * 
         * This method will remove those from the Windows that will appear in each 
         * of our view
         */
        private void removeChildWindowBorders(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.Text = "";
            form.Dock = DockStyle.Fill;
        }

        /* This method will search through the MDI, close all Forms that aren't being
         * used and keep the one open that we want open. This way, we won't have 
         * forms running in the background and slowing down the applicaiton.
         */
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

        // Allows user to logout of the system and return to the login screen
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this._loginWindow.Visibility = Visibility.Visible;
            this.Close();
        }


    }
}
