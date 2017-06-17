using Gradebook.Data.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradebook
{
    public partial class ClassView : Form
    {
        private Person _user;
        private int _taughtCourseID;
        private Course _currentCourse;

        public ClassView(Person user, int taughtCourseID)
        {
            InitializeComponent();
            _user = user;
            _taughtCourseID = taughtCourseID;
        }

        /// <summary>
        /// On load the following should happen: 
        /// 1- Teacher name should be placed in: textBoxTeacher
        /// 
        /// 
        /// 2- Course name should be placed in: textBoxCoureName
        /// 
        /// 
        /// 3- Course description should be placed in: textCourseDescription
        /// 
        /// 4- Category weights should be placed in for each category: 
        /// Will hardcode name based on which category is being filled in
        /// None exist? set to defaults
        /// 
        /// 5- Totals of categories should be added up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassView_Load(object sender, EventArgs e)
        {
            
            textBoxTeacher.Text = _user.firstName + " " + _user.lastName;
            textBoxCourseName.Text = _taughtCourseID + " << course id for DB pulls";
        }
    }
}
