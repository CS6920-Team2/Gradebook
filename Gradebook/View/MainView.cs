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
    public partial class MainView : BaseForm
    {
        private RoleService roleService;
        private AdminService adminService;
        private TeacherService teacherService;
        private PersonService personService;
        private CourseService courseService;

        private string role;
        private Person currentPerson;
        private int teacherID;
        private int adminID;
        private TaughtCourse currentCourse;

        public MainView()
        {
            InitializeComponent();
            roleService = new RoleService();
            adminService = new AdminService();
            teacherService = new TeacherService();
            personService = new PersonService();
            courseService = new CourseService();
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                // Keep below methods in real application 
                this.AssignPerson();
                this.LoadLeftNav();
                this.AdjustNavForUser();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading navigation bars.";
            }
        }

        ////////////////////////////////////////// Load Helpers //////////////////////////////////////////
        private void AssignPerson()
        {
            try
            {
                role = roleService.findRole(currentUser.RoleID);

                if (role.Equals("Teacher"))
                {
                    Teacher tempTeacher = teacherService.getTeacherByUserID(currentUser.UserID);
                    currentPerson = personService.getPersonByPersonID(tempTeacher.personID);
                    teacherID = tempTeacher.teacherID;
                }
                else if (role.Equals("Administrator"))
                {
                    Admin tempAdmin = adminService.getAdminByUserID(currentUser.UserID);
                    currentPerson = personService.getPersonByPersonID(tempAdmin.personID);
                    adminID = tempAdmin.adminID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLeftNav()
        {
            lblName.Text = currentPerson.fullName;
            lblRole.Text = role;
            lblIDNumber.Text = currentPerson.personID.ToString();
            if (role == "Teacher")
                lblWorkIDNumber.Text = teacherID.ToString();
            else if (role == "Admin")
                lblWorkIDNumber.Text = adminID.ToString();

            if (role == "Teacher")
            {
                try
                {
                    List<TaughtCourse> courseList = courseService.findCoursesByTeacherID(teacherID);
                    cboCourses.DataSource = courseList;
                    cboCourses.DisplayMember = "name";
                    cboCourses.ValueMember = "taughtCourseID";
                    cboCourses.SelectedIndex = 0;
                    currentCourse = (TaughtCourse)cboCourses.SelectedItem;
                    lblTaughtCourseID.Text = cboCourses.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void AdjustNavForUser()
        {
            if (role == "Administrator")
            {
                btnAssignmentsView.Visible = false;
                btnGradebookView.Visible = false;
                btnReportsView.Visible = false;
                cboCourses.Visible = false;
                lblTaughtCourseID.Visible = false;
                lblTaughtCourseID1.Visible = false;
                lblClassInfo.Visible = false;
            }
        }
        ////////////////////////////////////////// Nav Controller Event Triggers  //////////////////////////////////////////

        private void BtnClassView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            ClassView classView = new ClassView(currentPerson, currentCourse, role);
            classView.MdiParent = this;
            classView.Show();
            RemoveChildWindowBorders(classView);
        }

        private void BtnAssignmentsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
            AssignmentsView assignmentsView;
            assignmentsView = new AssignmentsView() { MdiParent = this };
            assignmentsView.Show();
            this.RemoveChildWindowBorders(assignmentsView);
        }

        public T UpdatePanelView<T>() where T : Form, new() {
            var form = FormManager.Current.CreateForm<T>();
            form.MdiParent = this;
            this.contentPanel.Controls.Add(form);
            return null;
        }

        private void BtnGradebookView_Click(object sender, EventArgs e)
        {
            FormManager.Current.UpdateMainViewContent<GradebookView>();
        }

        private void BtnReportsView_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            //_reportsView = new ReportsView() { MdiParent = this };
            //_reportsView.Show();
            //this.RemoveChildWindowBorders(_reportsView);
        }

        public void updateContentPanel(Form form)
        {
            if(form == null)
            {
                throw new ArgumentNullException("Cannot add null form to MainView!");
            }

            while (contentPanel.Controls.Count > 0)
            {
                contentPanel.Controls[0].Dispose();
            }

            contentPanel.Controls.Add(form);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var form = FormManager.Current.CreateForm<LoginView>();
            form.Show();
            this.Close();
        }

        private void CboClasses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCourse = (TaughtCourse)cboCourses.SelectedItem;
            lblTaughtCourseID.Text = currentCourse.taughtCourseID.ToString();

            if (ActiveMdiChild == null)
                return;
            else if (ActiveMdiChild is ClassView)
                this.BtnClassView_Click(null, null);
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
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.Text = "";
            form.Dock = DockStyle.Fill;
        }

    }
}
