﻿namespace Gradebook
{
    partial class MainMDI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDI));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnClassView = new System.Windows.Forms.ToolStripButton();
            this.btnAssignmentsView = new System.Windows.Forms.ToolStripButton();
            this.btnGradebookView = new System.Windows.Forms.ToolStripButton();
            this.btnReportsView = new System.Windows.Forms.ToolStripButton();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTaughtCourseID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCourses = new System.Windows.Forms.ComboBox();
            this.lblRoleIDNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserInformation = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClassView,
            this.btnAssignmentsView,
            this.btnGradebookView,
            this.btnReportsView,
            this.btnLogout});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.mainToolStrip.Size = new System.Drawing.Size(1384, 38);
            this.mainToolStrip.TabIndex = 1;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // btnClassView
            // 
            this.btnClassView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassView.Image = global::Gradebook.Properties.Resources.ClassesIcon;
            this.btnClassView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClassView.Name = "btnClassView";
            this.btnClassView.Size = new System.Drawing.Size(81, 25);
            this.btnClassView.Text = "Classes";
            this.btnClassView.Click += new System.EventHandler(this.BtnClassView_Click);
            // 
            // btnAssignmentsView
            // 
            this.btnAssignmentsView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentsView.Image = global::Gradebook.Properties.Resources.AssignmentsIcon;
            this.btnAssignmentsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignmentsView.Name = "btnAssignmentsView";
            this.btnAssignmentsView.Size = new System.Drawing.Size(119, 25);
            this.btnAssignmentsView.Text = "Assignments";
            // 
            // btnGradebookView
            // 
            this.btnGradebookView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGradebookView.Image = global::Gradebook.Properties.Resources.GradesBookIcon;
            this.btnGradebookView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGradebookView.Name = "btnGradebookView";
            this.btnGradebookView.Size = new System.Drawing.Size(107, 25);
            this.btnGradebookView.Text = "Gradebook";
            // 
            // btnReportsView
            // 
            this.btnReportsView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportsView.Image = global::Gradebook.Properties.Resources.ReportIcon;
            this.btnReportsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportsView.Name = "btnReportsView";
            this.btnReportsView.Size = new System.Drawing.Size(84, 25);
            this.btnReportsView.Tag = "";
            this.btnReportsView.Text = "Reports";
            // 
            // btnLogout
            // 
            this.btnLogout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(63, 25);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTaughtCourseID);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboCourses);
            this.panel1.Controls.Add(this.lblRoleIDNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblErrorMessage);
            this.panel1.Controls.Add(this.lblIDNumber);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUserInformation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 723);
            this.panel1.TabIndex = 10;
            // 
            // lblTaughtCourseID
            // 
            this.lblTaughtCourseID.AutoSize = true;
            this.lblTaughtCourseID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaughtCourseID.Location = new System.Drawing.Point(124, 353);
            this.lblTaughtCourseID.Name = "lblTaughtCourseID";
            this.lblTaughtCourseID.Size = new System.Drawing.Size(114, 17);
            this.lblTaughtCourseID.TabIndex = 14;
            this.lblTaughtCourseID.Text = "lblTaughtCourseID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Taught Course ID:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(0, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 73);
            this.label5.TabIndex = 12;
            this.label5.Text = "Class Information";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboCourses
            // 
            this.cboCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourses.FormattingEnabled = true;
            this.cboCourses.Location = new System.Drawing.Point(10, 321);
            this.cboCourses.Name = "cboCourses";
            this.cboCourses.Size = new System.Drawing.Size(184, 21);
            this.cboCourses.TabIndex = 11;
            this.cboCourses.SelectionChangeCommitted += new System.EventHandler(this.CboClasses_SelectionChangeCommitted);
            // 
            // lblRoleIDNumber
            // 
            this.lblRoleIDNumber.AutoSize = true;
            this.lblRoleIDNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleIDNumber.Location = new System.Drawing.Point(86, 144);
            this.lblRoleIDNumber.Name = "lblRoleIDNumber";
            this.lblRoleIDNumber.Size = new System.Drawing.Size(108, 17);
            this.lblRoleIDNumber.TabIndex = 10;
            this.lblRoleIDNumber.Text = "lblRoleIDNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Role ID:";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 202);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 8;
            // 
            // lblIDNumber
            // 
            this.lblIDNumber.AutoSize = true;
            this.lblIDNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDNumber.Location = new System.Drawing.Point(86, 173);
            this.lblIDNumber.Name = "lblIDNumber";
            this.lblIDNumber.Size = new System.Drawing.Size(82, 17);
            this.lblIDNumber.TabIndex = 7;
            this.lblIDNumber.Text = "lblIDNumber";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(86, 115);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(48, 17);
            this.lblRole.TabIndex = 6;
            this.lblRole.Text = "lblRole";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(86, 86);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "lblName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Person ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Roll:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // lblUserInformation
            // 
            this.lblUserInformation.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUserInformation.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserInformation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUserInformation.Location = new System.Drawing.Point(0, 0);
            this.lblUserInformation.Name = "lblUserInformation";
            this.lblUserInformation.Size = new System.Drawing.Size(205, 73);
            this.lblUserInformation.TabIndex = 0;
            this.lblUserInformation.Text = "User Information";
            this.lblUserInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Gradebook.Properties.Resources.GradeBookLogo;
            this.pictureBox1.Location = new System.Drawing.Point(205, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1179, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataSource = typeof(Gradebook.Data.DAO.Course);
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1384, 761);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainToolStrip);
            this.IsMdiContainer = true;
            this.Name = "MainMDI";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gradebook++";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMDI_FormClosed);
            this.Load += new System.EventHandler(this.MainMDI_Load);
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton btnAssignmentsView;
        private System.Windows.Forms.ToolStripButton btnGradebookView;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.ToolStripButton btnClassView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserInformation;
        private System.Windows.Forms.Label lblIDNumber;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ToolStripButton btnReportsView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblRoleIDNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCourses;
        private System.Windows.Forms.Label lblTaughtCourseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource courseBindingSource;
    }
}