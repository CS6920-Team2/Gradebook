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

namespace Gradebook
{
    public partial class MainMDI : Form
    {
        private ClassView classView;
        private Window loginWindow;

        public MainMDI(Window loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
        }


        private void btnClassView_Click(object sender, EventArgs e)
        {
            if (classView == null)
            {
                classView = new ClassView();
                classView.MdiParent = this;
                classView.Show();

                this.removeChildWindowBorders(classView);

            }
        }

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.loginWindow.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
