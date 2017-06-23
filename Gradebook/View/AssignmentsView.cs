using System.Windows.Forms;

namespace Gradebook
{
    internal class AssignmentsView : Form
    {
        public MainMDI MdiParent { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AssignmentsView
            // 
            this.ClientSize = new System.Drawing.Size(356, 338);
            this.Name = "AssignmentsView";
            this.Text = "Assignments View";
            this.ResumeLayout(false);

        }
    }
}