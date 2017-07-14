using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradebook;
using Gradebook.Data.Services;
using Gradebook.Data.Utils;

namespace Gradebook.View
{
    public partial class FailureReportView : Form
    {
        private ReportService reportService;

        public FailureReportView()
        {
            InitializeComponent();
            reportService = new ReportService();
        }

        private void FailureReportView_Load(object sender, EventArgs e)
        {
            try
            {
                loadDataGridView();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void loadDataGridView()
        {
            try
            {
                if (MainView.Current.AuthenticatedTeacher != null)
                {
                    dgView.DataSource = reportService.GetFailureReportDataSet(MainView.Current.AuthenticatedTeacher.teacherID);
                    dgView.AutoResizeColumns();
                    dgView.ClearSelection();

                    removeColumnSortAbility();
                    modifyTotalsRow(Color.White, Color.MediumAquamarine);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Unable to load failure reports table");
                throw ex;
            }
        }

        private void modifyTotalsRow(Color textColor, Color backColor)
        {
            foreach (DataGridViewRow row in dgView.Rows)
            {
                if (string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                {
                    row.DefaultCellStyle.ForeColor = textColor;
                    row.DefaultCellStyle.BackColor = backColor;
                }
            }
        }

        private void removeColumnSortAbility()
        {
            foreach (DataGridViewColumn column in dgView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
