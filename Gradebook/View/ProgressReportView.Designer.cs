namespace Gradebook.View
{
    partial class ProgressReportView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gradeAvgLBL = new System.Windows.Forms.Label();
            this.letterGradeLBL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.studentNameLBL = new System.Windows.Forms.Label();
            this.studentEmailLBL = new System.Windows.Forms.Label();
            this.studentNumberLBL = new System.Windows.Forms.Label();
            this.teacherNameLBL = new System.Windows.Forms.Label();
            this.teacherEmailLBL = new System.Windows.Forms.Label();
            this.teacherNumberLBL = new System.Windows.Forms.Label();
            this.studentHeader = new System.Windows.Forms.Label();
            this.teacherHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.Location = new System.Drawing.Point(115, 273);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(604, 354);
            this.dataGridView1.TabIndex = 0;
            // 
            // gradeAvgLBL
            // 
            this.gradeAvgLBL.AutoSize = true;
            this.gradeAvgLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeAvgLBL.Location = new System.Drawing.Point(110, 245);
            this.gradeAvgLBL.Name = "gradeAvgLBL";
            this.gradeAvgLBL.Size = new System.Drawing.Size(145, 25);
            this.gradeAvgLBL.TabIndex = 1;
            this.gradeAvgLBL.Text = "Grade Average";
            // 
            // letterGradeLBL
            // 
            this.letterGradeLBL.AutoSize = true;
            this.letterGradeLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterGradeLBL.Location = new System.Drawing.Point(545, 245);
            this.letterGradeLBL.Name = "letterGradeLBL";
            this.letterGradeLBL.Size = new System.Drawing.Size(120, 25);
            this.letterGradeLBL.TabIndex = 2;
            this.letterGradeLBL.Text = "Letter Grade";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Progress Report";
            // 
            // studentNameLBL
            // 
            this.studentNameLBL.AutoSize = true;
            this.studentNameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNameLBL.Location = new System.Drawing.Point(112, 72);
            this.studentNameLBL.Name = "studentNameLBL";
            this.studentNameLBL.Size = new System.Drawing.Size(98, 17);
            this.studentNameLBL.TabIndex = 4;
            this.studentNameLBL.Text = "Student Name";
            // 
            // studentEmailLBL
            // 
            this.studentEmailLBL.AutoSize = true;
            this.studentEmailLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentEmailLBL.Location = new System.Drawing.Point(112, 97);
            this.studentEmailLBL.Name = "studentEmailLBL";
            this.studentEmailLBL.Size = new System.Drawing.Size(95, 17);
            this.studentEmailLBL.TabIndex = 5;
            this.studentEmailLBL.Text = "Student Email";
            // 
            // studentNumberLBL
            // 
            this.studentNumberLBL.AutoSize = true;
            this.studentNumberLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNumberLBL.Location = new System.Drawing.Point(112, 122);
            this.studentNumberLBL.Name = "studentNumberLBL";
            this.studentNumberLBL.Size = new System.Drawing.Size(111, 17);
            this.studentNumberLBL.TabIndex = 6;
            this.studentNumberLBL.Text = "Student Number";
            // 
            // teacherNameLBL
            // 
            this.teacherNameLBL.AutoSize = true;
            this.teacherNameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherNameLBL.Location = new System.Drawing.Point(112, 170);
            this.teacherNameLBL.Name = "teacherNameLBL";
            this.teacherNameLBL.Size = new System.Drawing.Size(102, 17);
            this.teacherNameLBL.TabIndex = 7;
            this.teacherNameLBL.Text = "Teacher Name";
            // 
            // teacherEmailLBL
            // 
            this.teacherEmailLBL.AutoSize = true;
            this.teacherEmailLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherEmailLBL.Location = new System.Drawing.Point(112, 195);
            this.teacherEmailLBL.Name = "teacherEmailLBL";
            this.teacherEmailLBL.Size = new System.Drawing.Size(99, 17);
            this.teacherEmailLBL.TabIndex = 8;
            this.teacherEmailLBL.Text = "Teacher Email";
            // 
            // teacherNumberLBL
            // 
            this.teacherNumberLBL.AutoSize = true;
            this.teacherNumberLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherNumberLBL.Location = new System.Drawing.Point(112, 220);
            this.teacherNumberLBL.Name = "teacherNumberLBL";
            this.teacherNumberLBL.Size = new System.Drawing.Size(115, 17);
            this.teacherNumberLBL.TabIndex = 9;
            this.teacherNumberLBL.Text = "Teacher Number";
            // 
            // studentHeader
            // 
            this.studentHeader.AutoSize = true;
            this.studentHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentHeader.Location = new System.Drawing.Point(112, 55);
            this.studentHeader.Name = "studentHeader";
            this.studentHeader.Size = new System.Drawing.Size(64, 17);
            this.studentHeader.TabIndex = 10;
            this.studentHeader.Text = "Student";
            // 
            // teacherHeader
            // 
            this.teacherHeader.AutoSize = true;
            this.teacherHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherHeader.Location = new System.Drawing.Point(112, 153);
            this.teacherHeader.Name = "teacherHeader";
            this.teacherHeader.Size = new System.Drawing.Size(68, 17);
            this.teacherHeader.TabIndex = 11;
            this.teacherHeader.Text = "Teacher";
            // 
            // ProgressReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(836, 639);
            this.Controls.Add(this.teacherHeader);
            this.Controls.Add(this.studentHeader);
            this.Controls.Add(this.teacherNumberLBL);
            this.Controls.Add(this.teacherEmailLBL);
            this.Controls.Add(this.teacherNameLBL);
            this.Controls.Add(this.studentNumberLBL);
            this.Controls.Add(this.studentEmailLBL);
            this.Controls.Add(this.studentNameLBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.letterGradeLBL);
            this.Controls.Add(this.gradeAvgLBL);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProgressReportView";
            this.Text = "Progress Report View";
            this.Load += new System.EventHandler(this.ProgressReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label gradeAvgLBL;
        private System.Windows.Forms.Label letterGradeLBL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label studentNameLBL;
        private System.Windows.Forms.Label studentEmailLBL;
        private System.Windows.Forms.Label studentNumberLBL;
        private System.Windows.Forms.Label teacherNameLBL;
        private System.Windows.Forms.Label teacherEmailLBL;
        private System.Windows.Forms.Label teacherNumberLBL;
        private System.Windows.Forms.Label studentHeader;
        private System.Windows.Forms.Label teacherHeader;
    }
}