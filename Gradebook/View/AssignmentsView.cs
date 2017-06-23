using Gradebook.Controls;
using Gradebook.Data.Factories;
using Gradebook.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gradebook.Data.Factories.ConnectionFactory;

namespace Gradebook.View
{
    public partial class AssignmentsView : BaseForm
    {

        private AssignmentService assignmentService;
        public AssignmentsView()
        {
            InitializeComponent();
            assignmentService = new AssignmentService();
        }

        private void AssignmentsView_Load(object sender, EventArgs e)
        {
            DataSet ds = assignmentService.CreateDataSet();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
