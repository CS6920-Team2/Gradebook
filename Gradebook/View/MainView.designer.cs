namespace Gradebook
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.topNav = new System.Windows.Forms.ToolStrip();
            this.btnClassView = new System.Windows.Forms.ToolStripButton();
            this.btnAssignmentsView = new System.Windows.Forms.ToolStripButton();
            this.btnGradebookView = new System.Windows.Forms.ToolStripButton();
            this.btnReportsView = new System.Windows.Forms.ToolStripButton();
            this.btnLogout = new System.Windows.Forms.ToolStripButton();
            this.leftNav = new System.Windows.Forms.Panel();
            this.lblTaughtCourseID = new System.Windows.Forms.Label();
            this.lblTaughtCourseID1 = new System.Windows.Forms.Label();
            this.lblClassInfo = new System.Windows.Forms.Label();
            this.cboCourses = new System.Windows.Forms.ComboBox();
            this.lblWorkIDNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblIDNumber = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserInformation = new System.Windows.Forms.Label();
            this.gradebookLogo = new System.Windows.Forms.PictureBox();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.topNav.SuspendLayout();
            this.leftNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradebookLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // topNav
            // 
            this.topNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClassView,
            this.btnAssignmentsView,
            this.btnGradebookView,
            this.btnReportsView,
            this.btnLogout});
            this.topNav.Location = new System.Drawing.Point(0, 0);
            this.topNav.Name = "topNav";
            this.topNav.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.topNav.Size = new System.Drawing.Size(1362, 38);
            this.topNav.TabIndex = 1;
            this.topNav.Text = "toolStrip1";
            // 
            // btnClassView
            // 
            this.btnClassView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassView.Image = ((System.Drawing.Image)(resources.GetObject("btnClassView.Image")));
            this.btnClassView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClassView.Name = "btnClassView";
            this.btnClassView.Size = new System.Drawing.Size(81, 25);
            this.btnClassView.Text = "Classes";
            this.btnClassView.Click += new System.EventHandler(this.BtnClassView_Click);
            // 
            // btnAssignmentsView
            // 
            this.btnAssignmentsView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignmentsView.Image = ((System.Drawing.Image)(resources.GetObject("btnAssignmentsView.Image")));
            this.btnAssignmentsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAssignmentsView.Name = "btnAssignmentsView";
            this.btnAssignmentsView.Size = new System.Drawing.Size(119, 25);
            this.btnAssignmentsView.Text = "Assignments";
            this.btnAssignmentsView.Click += new System.EventHandler(this.BtnAssignmentsView_Click);
            // 
            // btnGradebookView
            // 
            this.btnGradebookView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGradebookView.Image = ((System.Drawing.Image)(resources.GetObject("btnGradebookView.Image")));
            this.btnGradebookView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGradebookView.Name = "btnGradebookView";
            this.btnGradebookView.Size = new System.Drawing.Size(107, 25);
            this.btnGradebookView.Text = "Gradebook";
            this.btnGradebookView.Click += new System.EventHandler(this.BtnGradebookView_Click);
            // 
            // btnReportsView
            // 
            this.btnReportsView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportsView.Image = ((System.Drawing.Image)(resources.GetObject("btnReportsView.Image")));
            this.btnReportsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportsView.Name = "btnReportsView";
            this.btnReportsView.Size = new System.Drawing.Size(84, 25);
            this.btnReportsView.Tag = "";
            this.btnReportsView.Text = "Reports";
            this.btnReportsView.Click += new System.EventHandler(this.BtnReportsView_Click);
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
            // leftNav
            // 
            this.leftNav.Controls.Add(this.lblTaughtCourseID);
            this.leftNav.Controls.Add(this.lblTaughtCourseID1);
            this.leftNav.Controls.Add(this.lblClassInfo);
            this.leftNav.Controls.Add(this.cboCourses);
            this.leftNav.Controls.Add(this.lblWorkIDNumber);
            this.leftNav.Controls.Add(this.label4);
            this.leftNav.Controls.Add(this.lblError);
            this.leftNav.Controls.Add(this.lblIDNumber);
            this.leftNav.Controls.Add(this.lblRole);
            this.leftNav.Controls.Add(this.lblName);
            this.leftNav.Controls.Add(this.label3);
            this.leftNav.Controls.Add(this.label2);
            this.leftNav.Controls.Add(this.label1);
            this.leftNav.Controls.Add(this.lblUserInformation);
            this.leftNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftNav.Location = new System.Drawing.Point(0, 38);
            this.leftNav.Name = "leftNav";
            this.leftNav.Size = new System.Drawing.Size(205, 703);
            this.leftNav.TabIndex = 10;
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
            // lblTaughtCourseID1
            // 
            this.lblTaughtCourseID1.AutoSize = true;
            this.lblTaughtCourseID1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaughtCourseID1.Location = new System.Drawing.Point(7, 353);
            this.lblTaughtCourseID1.Name = "lblTaughtCourseID1";
            this.lblTaughtCourseID1.Size = new System.Drawing.Size(111, 17);
            this.lblTaughtCourseID1.TabIndex = 13;
            this.lblTaughtCourseID1.Text = "Taught Course ID:";
            // 
            // lblClassInfo
            // 
            this.lblClassInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClassInfo.Font = new System.Drawing.Font("Rockwell", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassInfo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblClassInfo.Location = new System.Drawing.Point(0, 235);
            this.lblClassInfo.Name = "lblClassInfo";
            this.lblClassInfo.Size = new System.Drawing.Size(205, 73);
            this.lblClassInfo.TabIndex = 12;
            this.lblClassInfo.Text = "Class Information";
            this.lblClassInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // lblWorkIDNumber
            // 
            this.lblWorkIDNumber.AutoSize = true;
            this.lblWorkIDNumber.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkIDNumber.Location = new System.Drawing.Point(86, 144);
            this.lblWorkIDNumber.Name = "lblWorkIDNumber";
            this.lblWorkIDNumber.Size = new System.Drawing.Size(112, 17);
            this.lblWorkIDNumber.TabIndex = 10;
            this.lblWorkIDNumber.Text = "lblWorkIDNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Work ID:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(7, 202);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 8;
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
            // gradebookLogo
            // 
            this.gradebookLogo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gradebookLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradebookLogo.Image = ((System.Drawing.Image)(resources.GetObject("gradebookLogo.Image")));
            this.gradebookLogo.Location = new System.Drawing.Point(205, 38);
            this.gradebookLogo.Name = "gradebookLogo";
            this.gradebookLogo.Size = new System.Drawing.Size(1157, 73);
            this.gradebookLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gradebookLogo.TabIndex = 11;
            this.gradebookLogo.TabStop = false;
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(204, 111);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1180, 650);
            this.contentPanel.TabIndex = 13;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.gradebookLogo);
            this.Controls.Add(this.leftNav);
            this.Controls.Add(this.topNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gradebook++";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainMDI_Load);
            this.topNav.ResumeLayout(false);
            this.topNav.PerformLayout();
            this.leftNav.ResumeLayout(false);
            this.leftNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradebookLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip topNav;
        private System.Windows.Forms.ToolStripButton btnAssignmentsView;
        private System.Windows.Forms.ToolStripButton btnGradebookView;
        private System.Windows.Forms.ToolStripButton btnLogout;
        private System.Windows.Forms.ToolStripButton btnClassView;
        private System.Windows.Forms.Panel leftNav;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserInformation;
        private System.Windows.Forms.Label lblIDNumber;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ToolStripButton btnReportsView;
        private System.Windows.Forms.PictureBox gradebookLogo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblWorkIDNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblClassInfo;
        private System.Windows.Forms.ComboBox cboCourses;
        private System.Windows.Forms.Label lblTaughtCourseID;
        private System.Windows.Forms.Label lblTaughtCourseID1;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}