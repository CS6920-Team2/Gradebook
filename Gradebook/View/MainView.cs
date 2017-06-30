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
        private StudentService studentService;

        private bool teacherHasNoCourses;
        public static string role;
        public static Person currentPerson;
        public static TaughtCourse currentCourse;
        private int teacherID;
        private int adminID;
        private int studentID;
        private static MainView current;

        public MainView()
        {
            InitializeComponent();
            current = this;
            roleService = new RoleService();
            adminService = new AdminService();
            teacherService = new TeacherService();
            personService = new PersonService();
            courseService = new CourseService();
            studentService = new StudentService();
        }

        public static MainView Current
        {
            get
            {
                return current;
            }
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                this.AssignPerson();
                this.LoadLeftNav();
                this.LoadTopNav();
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
                role = roleService.findRoleByRoleID(MainView.Current.AuthenticatedUser.RoleID);

                if (role.Equals("Teacher"))
                {
                    Teacher tempTeacher = teacherService.getTeacherByUserID(AuthenticatedUser.UserID);
                    currentPerson = personService.getPersonByPersonID(tempTeacher.personID);
                    teacherID = tempTeacher.teacherID;
                }
                else if (role.Equals("Administrator"))
                {
                    Admin tempAdmin = adminService.getAdminByUserID(AuthenticatedUser.UserID);
                    currentPerson = personService.getPersonByPersonID(tempAdmin.personID);
                    adminID = tempAdmin.adminID;
                }
                else if (role.Equals("Student"))
                {
                    Student tempStudent = studentService.getStudentByUserID(MainView.Current.AuthenticatedUser.RoleID);
                    currentPerson = personService.getPersonByPersonID(tempStudent.personID);
                    studentID = tempStudent.studentID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLeftNav()
        {
            currentCourse = null;
            lblName.Text = currentPerson.fullName;
            lblRole.Text = role;
            lblIDNumber.Text = currentPerson.personID.ToString();
            if (role == "Teacher")
                lblWorkIDNumber.Text = teacherID.ToString();
            else if (role == "Administrator")
                lblWorkIDNumber.Text = adminID.ToString();
            else if (role == "Student")
                lblWorkIDNumber.Text = studentID.ToString();

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
                    teacherHasNoCourses = true;
                    lblError.Text = "Please contact your administrator \n to have classes added for you.";
                }
            }
        }

        private void LoadTopNav()
        {
            if (role == "Administrator" || role == "Student" || teacherHasNoCourses)
            {
                btnAssignmentsView.Visible = false;
                btnGradebookView.Visible = false;
                btnReportsView.Visible = false;
                cboCourses.Visible = false;
                lblTaughtCourseID.Visible = false;
                lblTaughtCourseID1.Visible = false;
                lblClassInfo.Visible = false;
            }

            if (role == "Student" || teacherHasNoCourses)
                btnClassView.Visible = false;
        }
        ////////////////////////////////////////// Nav Controller Event Triggers  //////////////////////////////////////////

        private void BtnClassView_Click(object sender, EventArgs e)
        {
            FormManager.Current.UpdateMainViewContent<ClassView>();
        }

        private void BtnAssignmentsView_Click(object sender, EventArgs e)
        {
            FormManager.Current.UpdateMainViewContent<AssignmentsView>();
        }

        private void BtnGradebookView_Click(object sender, EventArgs e)
        {
            FormManager.Current.UpdateMainViewContent<GradebookView>();
        }

        private void BtnReportsView_Click(object sender, EventArgs e)
        {
            //FormManager.Current.UpdateMainViewContent<ReportsView>();
        }

        public T UpdatePanelView<T>() where T : Form, new()
        {
            var form = FormManager.Current.CreateForm<T>();
            form.MdiParent = this;
            this.contentPanel.Controls.Add(form);
            return null;
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
            // Must close content panel so that main view can close
            while (contentPanel.Controls.Count > 0)
                contentPanel.Controls[0].Dispose();

            FormManager.Current.CreateAndShowForm<LoginView>();
        }

        private void CboClasses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCourse = (TaughtCourse)cboCourses.SelectedItem;
            lblTaughtCourseID.Text = currentCourse.taughtCourseID.ToString();

            if (contentPanel.Controls.Count == 0)
                return;
            else if ((string)contentPanel.Controls[0].Tag == "ClassView")
                BtnClassView_Click(null, null);
            else if ((string)contentPanel.Controls[0].Tag == "AssignmentsView")
                BtnAssignmentsView_Click(null, null);
            // This will allow our data to update according to a specific class. 
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Must close content panel so that main view can close
            while (contentPanel.Controls.Count > 0)
                contentPanel.Controls[0].Dispose();
        }
        
    }
}
