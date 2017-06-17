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
        private MainMDI _main;

        public ClassView(MainMDI main)
        {
            InitializeComponent();
            _main = main;
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            textBoxTeacher.Text = _main.user.firstName + " " + _main.user.lastName;
            textBoxCourseName.Text = _main.taughtCoursesID + " << course id for DB pulls";
        }
    }
}
