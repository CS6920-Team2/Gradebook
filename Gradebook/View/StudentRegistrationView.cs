using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradebook.Controls;
using Gradebook.Data.DAO;
using Gradebook.Data.Services;

namespace Gradebook.View
{
    public partial class StudentRegistrationView : ContentForm
    {
        private TaughtCourse currentCourse;
        private List<RegisteredStudent> regStudents;
        private List<RegisteredStudent> unregStudents;
        private TeacherService teacherService;
        private TaughtCourseService tcService;
        private RegisteredStudentService rsService;

        public StudentRegistrationView()
        {
            InitializeComponent();
            teacherService = new TeacherService();
            tcService = new TaughtCourseService();
            rsService = new RegisteredStudentService();
        }

        private void StudentRegistrationView_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCourses();
                LoadCourseInfo();
                LoadRegisteredStudents();
                LoadUnregisteredStudents();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void LoadCourses()
        {
            try
            {
                List<TaughtCourse> courses = tcService.getTaughtCourses();
                cboTaughtCourses.DataSource = courses;
                cboTaughtCourses.DisplayMember = "name";
                cboTaughtCourses.ValueMember = "taughtCourseID";
                cboTaughtCourses.SelectedIndex = 0;

                currentCourse = (TaughtCourse)cboTaughtCourses.SelectedItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load courses");
            }
        }

        private void CboTaughtCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentCourse = (TaughtCourse)cboTaughtCourses.SelectedItem;

            try
            {
                ClearMessages();

                LoadCourseInfo();
                LoadRegisteredStudents();
                LoadUnregisteredStudents();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void LoadCourseInfo()
        {
            try
            {
                txtTCID.Text = currentCourse.taughtCourseID.ToString();
                txtDescription.Text = currentCourse.description;
                txtTeacher.Text = teacherService.getTeacherByTaughtCourseID(currentCourse.taughtCourseID).fullName;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load course information");
            }
        }

        private void LoadRegisteredStudents()
        {
            lvRegistered.Items.Clear();

            try
            {
                regStudents = rsService.getRegisteredStudentsInTaughtCourse(currentCourse.taughtCourseID);

                AddStudentsToListView(lvRegistered, regStudents);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load registered students");
            }

            ResizeListViewColumns(lvUnregistered);
        }

        private void LoadUnregisteredStudents()
        {
            lvUnregistered.Items.Clear();

            try
            {
                unregStudents = rsService.getAllStudentsAsRegisteredStudents();

                RemoveRegisteredStudentsFromUnregisteredStudentList();
                AddStudentsToListView(lvUnregistered, unregStudents);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load unregistered students");
            }

            ResizeListViewColumns(lvUnregistered);
        }

        private void ClearMessages()
        {
            lblSuccess.Text = "";
            lblError.Text = "";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // List View Buttons ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ClearMessages();

            MoveSelectedItems(lvUnregistered, lvRegistered);
            ResizeListViewColumns(lvRegistered);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            ClearMessages();

            MoveSelectedItems(lvRegistered, lvUnregistered);
            ResizeListViewColumns(lvUnregistered);
        }

        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            ClearMessages();

            MoveAllItems(lvUnregistered, lvRegistered);
            ResizeListViewColumns(lvRegistered);
            RemoveAllChecks();
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            ClearMessages();

            MoveAllItems(lvRegistered, lvUnregistered);
            ResizeListViewColumns(lvUnregistered);
            RemoveAllChecks();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ClearMessages();

            LoadRegisteredStudents();
            LoadUnregisteredStudents();
            RemoveAllChecks();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ClearMessages();

            try
            {
                List<int> addStudentIDs = new List<int>();
                List<int> removeStudentIDs = new List<int>();

                addStudentIDs = FindStudentsAddedForRegistration(addStudentIDs);
                removeStudentIDs = FindStudentsRemovedFromRegistration(removeStudentIDs);

                if (addStudentIDs.Count == 0 && removeStudentIDs.Count == 0)
                {
                    lblError.Text = "Unable to update. No changes have been made to roster.";
                    return;
                }

                DialogResult result = ShowUpdateConfirmationMessage();

                if (result == DialogResult.OK)
                {
                    bool success = rsService.updateRegisteredStudentsInTaughtCourse(currentCourse.taughtCourseID, addStudentIDs, removeStudentIDs);

                    if (success)
                    {
                        BtnReset_Click(null, null);
                        lblSuccess.Text = "Class roster updated successfully.";
                    }
                    else
                        throw new Exception("Unable to update class roster.");
                }

                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private DialogResult ShowUpdateConfirmationMessage()
        {
            DialogResult result = 
                MessageBox.Show("Are you should you want to update your roster? \n\n" +
                "If you have removed any students, they may lose any recorded grades for this class.",
                "Caution",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            return result;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // List View Helpers ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void MoveSelectedItems(ListView source, ListView target)
        {
            while (source.CheckedItems.Count > 0)
            {
                ListViewItem temp = source.CheckedItems[0];
                source.Items.Remove(temp);
                target.Items.Add(temp);
                temp.Checked = false;
            }
        }

        private static void MoveAllItems(ListView source, ListView target)
        {
            while (source.Items.Count > 0)
            {
                ListViewItem temp = source.Items[0];
                source.Items.Remove(temp);
                target.Items.Add(temp);
            }
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void RemoveAllChecks()
        {
            while (lvRegistered.CheckedItems.Count > 0)
            {
                lvRegistered.CheckedItems[0].Checked = false;
            }

            while (lvUnregistered.CheckedItems.Count > 0)
            {
                lvUnregistered.CheckedItems[0].Checked = false;
            }
        }

        private void AddStudentsToListView(ListView lv, List<RegisteredStudent> students)
        {
            foreach (RegisteredStudent s in students)
            {
                ListViewItem item = new ListViewItem(s.studentID.ToString());
                item.SubItems.Add(s.fullName);
                item.Tag = s.studentID;

                lv.Items.Add(item);
            } 
        }

        private void RemoveRegisteredStudentsFromUnregisteredStudentList()
        {
            unregStudents.RemoveAll(unRegStu => regStudents.Any(regStu => regStu.studentID == unRegStu.studentID));
        }

        private List<int> FindStudentsAddedForRegistration(List<int> addStudentIDs)
        {
            foreach (ListViewItem item in lvRegistered.Items)
            {
                if (!ListContainsStudent(regStudents, (int)item.Tag))
                {
                    addStudentIDs.Add((int)item.Tag);
                }
            }

            return addStudentIDs;
        }

        private List<int> FindStudentsRemovedFromRegistration(List<int> removeStudentIDs)
        {
            foreach (ListViewItem item in lvUnregistered.Items)
            {
                if (ListContainsStudent(regStudents, (int)item.Tag))
                {
                    removeStudentIDs.Add((int)item.Tag);
                }
            }

            return removeStudentIDs;
        }

        private bool ListContainsStudent(List<RegisteredStudent> students, int sID)
        {
            foreach (RegisteredStudent rs in students)
            {
                if (rs.studentID == sID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
