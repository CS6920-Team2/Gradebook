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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnMissingAssignment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFailureReport
            // 
            this.btnFailureReport.Location = new System.Drawing.Point(93, 65);
            this.btnFailureReport.Name = "btnFailureReport";
            this.btnFailureReport.Size = new System.Drawing.Size(249, 25);
            this.btnFailureReport.TabIndex = 2;
            this.btnFailureReport.Text = "Generate Failure Report";
            this.btnFailureReport.UseVisualStyleBackColor = true;
            this.btnFailureReport.Click += new System.EventHandler(this.BtnFailureReport_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(93, 96);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(249, 44);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "This report will pull any kids who have a cumulative grade below a 70% in  any of" +
    " your classes.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(12, 9);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(128, 37);
            this.lblReports.TabIndex = 17;
            this.lblReports.Text = "Reports";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(93, 204);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(249, 44);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "This report will show you the  cumulative averages for a student in your class.";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // generatePR
            // 
            this.generatePR.Location = new System.Drawing.Point(93, 146);
            this.generatePR.Name = "generatePR";
            this.generatePR.Size = new System.Drawing.Size(249, 25);
            this.generatePR.TabIndex = 20;
            this.generatePR.Text = "Generate Progress Report";
            this.generatePR.UseVisualStyleBackColor = true;
            this.generatePR.Click += new System.EventHandler(this.generatePR_Click);
            // 
            // studentCB
            // 
            this.studentCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentCB.FormattingEnabled = true;
            this.studentCB.Location = new System.Drawing.Point(93, 177);
            this.studentCB.Name = "studentCB";
            this.studentCB.Size = new System.Drawing.Size(249, 21);
            this.studentCB.TabIndex = 22;
            this.studentCB.SelectionChangeCommitted += new System.EventHandler(this.studentCB_SelectionChangeCommitted);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::Gradebook.Properties.Resources.Trophy;
            this.pictureBox2.Location = new System.Drawing.Point(12, 146);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::Gradebook.Properties.Resources.Error;
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = global::Gradebook.Properties.Resources.Report_Card;
            this.pictureBox4.Location = new System.Drawing.Point(11, 246);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(75, 75);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(92, 293);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(249, 44);
            this.textBox4.TabIndex = 27;
            this.textBox4.Text = "This report will show a list of assignments and Students who have a missing assig" +
    "nment.";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnMissingAssignment
            // 
            this.btnMissingAssignment.Location = new System.Drawing.Point(92, 262);
            this.btnMissingAssignment.Name = "btnMissingAssignment";
            this.btnMissingAssignment.Size = new System.Drawing.Size(249, 25);
            this.btnMissingAssignment.TabIndex = 26;
            this.btnMissingAssignment.Text = "Generate Missing Assignment Report";
            this.btnMissingAssignment.UseVisualStyleBackColor = true;
            this.btnMissingAssignment.Click += new System.EventHandler(this.btnMissingAssignment_Click);
            // 
            // ReportsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 650);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnMissingAssignment);
            this.Controls.Add(this.studentCB);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.generatePR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnFailureReport);
            this.Name = "ReportsView";
            this.Tag = "ReportsView";
            this.Text = "ReportsView";
            this.Load += new System.EventHandler(this.ReportsView_Load);
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
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnMissingAssignment;
    }
}