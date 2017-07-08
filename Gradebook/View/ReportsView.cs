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
    public partial class ReportsView : ContentForm
    {

        private StudentService studentService;
        private TaughtCourse currentCourse = MainView.currentCourse;
        public ReportsView()
        {
            InitializeComponent();
            studentService = new StudentService();
        }


        private void ReportsView_Load(object sender, EventArgs e)
        {
            loadStudentCMB();
        }

        private void BtnFailureReport_Click(object sender, EventArgs e)
        {

        }

        // Loads the combo box with students that have the specific taught course ID
        private void loadStudentCMB()
        {
            try
            {
                List<Student> categoryList = studentService.findStudentsByTaughtCourseID(currentCourse.taughtCourseID);
                studentCB.DataSource = categoryList;
                studentCB.DisplayMember = "fullName";
                studentCB.ValueMember = "studentID";
                studentCB.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void generatePR_Click(object sender, EventArgs e)
        {
            ProgressReportView prv = new ProgressReportView((int)studentCB.SelectedValue, currentCourse.taughtCourseID);
            prv.Show();
        }
    }
}
