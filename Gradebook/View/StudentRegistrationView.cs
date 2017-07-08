﻿using System;
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

                RemoveRegisteredStudentsFromStudentList();
                AddStudentsToListView(lvUnregistered, unregStudents);

            }
            catch (Exception ex)
            {
                throw new Exception("Unable to load unregistered students"); ;
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

        private void AddStudentsToListView(ListView lv, List<RegisteredStudent> students)
        {
            foreach (RegisteredStudent s in students)
            {
                ListViewItem item = new ListViewItem(s.studentID.ToString());
                item.SubItems.Add(s.fullName);

                lv.Items.Add(item);
            }
        }

        private void RemoveRegisteredStudentsFromStudentList()
        {
            for (int i = 0; i < unregStudents.Count(); i++)
            {
                for (int j = 0; j < regStudents.Count(); j++)
                {
                    if (unregStudents[i].studentID == regStudents[j].studentID)
                    {
                        unregStudents.RemoveAt(i);
                    }
                }
            }
        }
    }
}
