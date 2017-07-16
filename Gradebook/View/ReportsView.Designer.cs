namespace Gradebook.View
{
    partial class ReportsView
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
            this.btnFailureReport = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblReports = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.generatePR = new System.Windows.Forms.Button();
            this.studentCB = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnMissingAssignment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFailureReport
            // 
            this.btnFailureReport.Location = new System.Drawing.Point(124, 80);
            this.btnFailureReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFailureReport.Name = "btnFailureReport";
            this.btnFailureReport.Size = new System.Drawing.Size(332, 31);
            this.btnFailureReport.TabIndex = 2;
            this.btnFailureReport.Text = "Generate Failure Report";
            this.btnFailureReport.UseVisualStyleBackColor = true;
            this.btnFailureReport.Click += new System.EventHandler(this.BtnFailureReport_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(124, 118);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(332, 54);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "This report will pull any kids who have a cumulative grade below a 70% in  any of" +
    " your classes.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(16, 11);
            this.lblReports.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(160, 46);
            this.lblReports.TabIndex = 17;
            this.lblReports.Text = "Reports";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(124, 390);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(332, 54);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "This report will show you the  cumulative averages for a student in your class.";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // generatePR
            // 
            this.generatePR.Location = new System.Drawing.Point(124, 319);
            this.generatePR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.generatePR.Name = "generatePR";
            this.generatePR.Size = new System.Drawing.Size(332, 31);
            this.generatePR.TabIndex = 20;
            this.generatePR.Text = "Generate Progress Report";
            this.generatePR.UseVisualStyleBackColor = true;
            this.generatePR.Click += new System.EventHandler(this.generatePR_Click);
            // 
            // studentCB
            // 
            this.studentCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentCB.FormattingEnabled = true;
            this.studentCB.Location = new System.Drawing.Point(124, 357);
            this.studentCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.studentCB.Name = "studentCB";
            this.studentCB.Size = new System.Drawing.Size(331, 24);
            this.studentCB.TabIndex = 22;
            this.studentCB.SelectionChangeCommitted += new System.EventHandler(this.studentCB_SelectionChangeCommitted);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(124, 241);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(332, 54);
            this.textBox3.TabIndex = 25;
            this.textBox3.Text = "This report display all the students who are missing an assignment in  the select" +
    "ed class.";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(124, 203);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(332, 31);
            this.button2.TabIndex = 24;
            this.button2.Text = "Generate Missing Work Report";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::Gradebook.Properties.Resources.Missing_Work;
            this.pictureBox3.Location = new System.Drawing.Point(16, 190);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 92);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::Gradebook.Properties.Resources.Trophy;
            this.pictureBox2.Location = new System.Drawing.Point(16, 319);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Gradebook.Properties.Resources.Error;
            this.pictureBox1.Location = new System.Drawing.Point(16, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = global::Gradebook.Properties.Resources.Report_Card;
            this.pictureBox4.Location = new System.Drawing.Point(15, 442);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 92);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(123, 500);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(332, 54);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "This report will show a list of assignments and Students who have a missing assig" +
    "nment.";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMissingAssignment
            // 
            this.btnMissingAssignment.Location = new System.Drawing.Point(123, 462);
            this.btnMissingAssignment.Margin = new System.Windows.Forms.Padding(4);
            this.btnMissingAssignment.Name = "btnMissingAssignment";
            this.btnMissingAssignment.Size = new System.Drawing.Size(332, 31);
            this.btnMissingAssignment.TabIndex = 26;
            this.btnMissingAssignment.Text = "Generate Missing Assignment Report";
            this.btnMissingAssignment.UseVisualStyleBackColor = true;
            this.btnMissingAssignment.Click += new System.EventHandler(this.btnMissingAssignment_Click);
            // 
            // ReportsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 800);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnMissingAssignment);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.studentCB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.generatePR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFailureReport);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReportsView";
            this.Tag = "ReportsView";
            this.Text = "ReportsView";
            this.Load += new System.EventHandler(this.ReportsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFailureReport;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button generatePR;
        private System.Windows.Forms.ComboBox studentCB;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnMissingAssignment;
    }
}