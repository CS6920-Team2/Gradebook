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
        private List<Student> regStudents;
        private List<Student> unregStudents;
        private StudentService studentService;

        public StudentRegistrationView()
        {
            InitializeComponent();
            studentService = new StudentService();
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

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load courses");
            }
        }

        private void LoadCourseInfo()
        {
            try
            {

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
                unregStudents = studentService.getAllStudents();

                foreach (Student s in unregStudents)
                {
                    ListViewItem item = new ListViewItem(s.studentID.ToString());
                    item.SubItems.Add(s.fullName);

                    lvUnregistered.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load unregistered students");
            }

            ResizeListViewColumns(lvUnregistered);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // List View Buttons ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lvUnregistered, lvRegistered);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            MoveSelectedItems(lvRegistered, lvUnregistered);
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

        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(lvUnregistered, lvRegistered);
            RemoveAllChecks();
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            MoveAllItems(lvRegistered, lvUnregistered);
            RemoveAllChecks();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            RemoveAllChecks();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            RemoveAllChecks();
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // List View Formatting /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
    }
}
