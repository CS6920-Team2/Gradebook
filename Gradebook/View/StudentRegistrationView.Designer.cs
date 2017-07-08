namespace Gradebook.View
{
    partial class StudentRegistrationView
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
            this.cboTaughtCourses = new System.Windows.Forms.ComboBox();
            this.txtTeacher = new System.Windows.Forms.TextBox();
            this.txtTCID = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gBoxUnregistered = new System.Windows.Forms.GroupBox();
            this.lvUnregistered = new System.Windows.Forms.ListView();
            this.unRegStudentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unRegFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gBoxRegistered = new System.Windows.Forms.GroupBox();
            this.lvRegistered = new System.Windows.Forms.ListView();
            this.regStudentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.regFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.gBoxUnregistered.SuspendLayout();
            this.gBoxRegistered.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTaughtCourses
            // 
            this.cboTaughtCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaughtCourses.FormattingEnabled = true;
            this.cboTaughtCourses.Location = new System.Drawing.Point(97, 41);
            this.cboTaughtCourses.MaxDropDownItems = 50;
            this.cboTaughtCourses.Name = "cboTaughtCourses";
            this.cboTaughtCourses.Size = new System.Drawing.Size(182, 21);
            this.cboTaughtCourses.TabIndex = 0;
            this.cboTaughtCourses.SelectionChangeCommitted += new System.EventHandler(this.CboTaughtCourses_SelectionChangeCommitted);
            // 
            // txtTeacher
            // 
            this.txtTeacher.Location = new System.Drawing.Point(97, 149);
            this.txtTeacher.Name = "txtTeacher";
            this.txtTeacher.ReadOnly = true;
            this.txtTeacher.Size = new System.Drawing.Size(286, 20);
            this.txtTeacher.TabIndex = 1;
            // 
            // txtTCID
            // 
            this.txtTCID.Location = new System.Drawing.Point(326, 42);
            this.txtTCID.Name = "txtTCID";
            this.txtTCID.ReadOnly = true;
            this.txtTCID.Size = new System.Drawing.Size(57, 20);
            this.txtTCID.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(97, 68);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(286, 75);
            this.txtDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Course:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "TCID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Teacher:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(389, 305);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add >";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(389, 392);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(88, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "< Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(389, 441);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(88, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(389, 470);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // gBoxUnregistered
            // 
            this.gBoxUnregistered.Controls.Add(this.lvUnregistered);
            this.gBoxUnregistered.Location = new System.Drawing.Point(78, 209);
            this.gBoxUnregistered.Name = "gBoxUnregistered";
            this.gBoxUnregistered.Size = new System.Drawing.Size(305, 399);
            this.gBoxUnregistered.TabIndex = 16;
            this.gBoxUnregistered.TabStop = false;
            this.gBoxUnregistered.Text = "Unregistered Students";
            // 
            // lvUnregistered
            // 
            this.lvUnregistered.CheckBoxes = true;
            this.lvUnregistered.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.unRegStudentID,
            this.unRegFullName});
            this.lvUnregistered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUnregistered.Location = new System.Drawing.Point(3, 16);
            this.lvUnregistered.Name = "lvUnregistered";
            this.lvUnregistered.Size = new System.Drawing.Size(299, 380);
            this.lvUnregistered.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvUnregistered.TabIndex = 8;
            this.lvUnregistered.UseCompatibleStateImageBehavior = false;
            this.lvUnregistered.View = System.Windows.Forms.View.Details;
            // 
            // unRegStudentID
            // 
            this.unRegStudentID.Text = "ID";
            // 
            // unRegFullName
            // 
            this.unRegFullName.Text = "Student Name";
            this.unRegFullName.Width = 235;
            // 
            // gBoxRegistered
            // 
            this.gBoxRegistered.Controls.Add(this.lvRegistered);
            this.gBoxRegistered.Location = new System.Drawing.Point(483, 209);
            this.gBoxRegistered.Name = "gBoxRegistered";
            this.gBoxRegistered.Size = new System.Drawing.Size(305, 399);
            this.gBoxRegistered.TabIndex = 17;
            this.gBoxRegistered.TabStop = false;
            this.gBoxRegistered.Text = "Registered Students";
            // 
            // lvRegistered
            // 
            this.lvRegistered.CheckBoxes = true;
            this.lvRegistered.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.regStudentID,
            this.regFullName});
            this.lvRegistered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRegistered.Location = new System.Drawing.Point(3, 16);
            this.lvRegistered.Name = "lvRegistered";
            this.lvRegistered.Size = new System.Drawing.Size(299, 380);
            this.lvRegistered.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvRegistered.TabIndex = 8;
            this.lvRegistered.UseCompatibleStateImageBehavior = false;
            this.lvRegistered.View = System.Windows.Forms.View.Details;
            // 
            // regStudentID
            // 
            this.regStudentID.Text = "ID";
            // 
            // regFullName
            // 
            this.regFullName.Text = "Student Name";
            this.regFullName.Width = 234;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(389, 363);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(88, 23);
            this.btnRemoveAll.TabIndex = 18;
            this.btnRemoveAll.Text = "<< Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(389, 334);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(88, 23);
            this.btnAddAll.TabIndex = 19;
            this.btnAddAll.Text = "Add All >>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.BtnAddAll_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(97, 176);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 20;
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.ForeColor = System.Drawing.Color.Green;
            this.lblSuccess.Location = new System.Drawing.Point(97, 176);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(0, 13);
            this.lblSuccess.TabIndex = 21;
            // 
            // StudentRegistrationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 650);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.gBoxRegistered);
            this.Controls.Add(this.gBoxUnregistered);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTCID);
            this.Controls.Add(this.txtTeacher);
            this.Controls.Add(this.cboTaughtCourses);
            this.Name = "StudentRegistrationView";
            this.Text = "StudentRegistrationView";
            this.Load += new System.EventHandler(this.StudentRegistrationView_Load);
            this.gBoxUnregistered.ResumeLayout(false);
            this.gBoxRegistered.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTaughtCourses;
        private System.Windows.Forms.TextBox txtTeacher;
        private System.Windows.Forms.TextBox txtTCID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gBoxUnregistered;
        private System.Windows.Forms.GroupBox gBoxRegistered;
        private System.Windows.Forms.ListView lvUnregistered;
        private System.Windows.Forms.ListView lvRegistered;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.ColumnHeader unRegStudentID;
        private System.Windows.Forms.ColumnHeader unRegFullName;
        private System.Windows.Forms.ColumnHeader regStudentID;
        private System.Windows.Forms.ColumnHeader regFullName;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblSuccess;
    }
}