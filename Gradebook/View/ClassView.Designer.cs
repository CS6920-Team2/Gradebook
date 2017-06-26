namespace Gradebook
{
    partial class ClassView
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
            this.groupBoxClassDescription = new System.Windows.Forms.GroupBox();
            this.txtCourseDescription = new System.Windows.Forms.TextBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.groupBoxCategoryWeights = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProjects = new System.Windows.Forms.TextBox();
            this.txtQuizzes = new System.Windows.Forms.TextBox();
            this.txtExams = new System.Windows.Forms.TextBox();
            this.txtParticipation = new System.Windows.Forms.TextBox();
            this.txtHomework = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblClassViewError = new System.Windows.Forms.Label();
            this.cboTeacherName = new System.Windows.Forms.ComboBox();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.groupBoxClassDescription.SuspendLayout();
            this.groupBoxCategoryWeights.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClassDescription
            // 
            this.groupBoxClassDescription.Controls.Add(this.txtCourseDescription);
            this.groupBoxClassDescription.Location = new System.Drawing.Point(15, 78);
            this.groupBoxClassDescription.Name = "groupBoxClassDescription";
            this.groupBoxClassDescription.Size = new System.Drawing.Size(332, 116);
            this.groupBoxClassDescription.TabIndex = 0;
            this.groupBoxClassDescription.TabStop = false;
            this.groupBoxClassDescription.Text = "Class Description";
            // 
            // txtCourseDescription
            // 
            this.txtCourseDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCourseDescription.Location = new System.Drawing.Point(3, 16);
            this.txtCourseDescription.Multiline = true;
            this.txtCourseDescription.Name = "txtCourseDescription";
            this.txtCourseDescription.ReadOnly = true;
            this.txtCourseDescription.Size = new System.Drawing.Size(326, 97);
            this.txtCourseDescription.TabIndex = 0;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(15, 48);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(74, 13);
            this.lblCourse.TabIndex = 2;
            this.lblCourse.Text = "Course Name:";
            // 
            // groupBoxCategoryWeights
            // 
            this.groupBoxCategoryWeights.Controls.Add(this.lblTotal);
            this.groupBoxCategoryWeights.Controls.Add(this.label7);
            this.groupBoxCategoryWeights.Controls.Add(this.txtProjects);
            this.groupBoxCategoryWeights.Controls.Add(this.txtQuizzes);
            this.groupBoxCategoryWeights.Controls.Add(this.txtExams);
            this.groupBoxCategoryWeights.Controls.Add(this.txtParticipation);
            this.groupBoxCategoryWeights.Controls.Add(this.txtHomework);
            this.groupBoxCategoryWeights.Controls.Add(this.label5);
            this.groupBoxCategoryWeights.Controls.Add(this.label4);
            this.groupBoxCategoryWeights.Controls.Add(this.label3);
            this.groupBoxCategoryWeights.Controls.Add(this.label2);
            this.groupBoxCategoryWeights.Controls.Add(this.label1);
            this.groupBoxCategoryWeights.Location = new System.Drawing.Point(18, 210);
            this.groupBoxCategoryWeights.Name = "groupBoxCategoryWeights";
            this.groupBoxCategoryWeights.Size = new System.Drawing.Size(326, 187);
            this.groupBoxCategoryWeights.TabIndex = 3;
            this.groupBoxCategoryWeights.TabStop = false;
            this.groupBoxCategoryWeights.Text = "Category Weights";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(285, 156);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(41, 13);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "lblTotal";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Total: ";
            // 
            // txtProjects
            // 
            this.txtProjects.Location = new System.Drawing.Point(111, 107);
            this.txtProjects.MaxLength = 3;
            this.txtProjects.Name = "txtProjects";
            this.txtProjects.Size = new System.Drawing.Size(209, 20);
            this.txtProjects.TabIndex = 5;
            this.txtProjects.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProjects.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtProjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // txtQuizzes
            // 
            this.txtQuizzes.Location = new System.Drawing.Point(111, 133);
            this.txtQuizzes.MaxLength = 3;
            this.txtQuizzes.Name = "txtQuizzes";
            this.txtQuizzes.Size = new System.Drawing.Size(209, 20);
            this.txtQuizzes.TabIndex = 4;
            this.txtQuizzes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuizzes.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtQuizzes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // txtExams
            // 
            this.txtExams.Location = new System.Drawing.Point(111, 29);
            this.txtExams.MaxLength = 3;
            this.txtExams.Name = "txtExams";
            this.txtExams.Size = new System.Drawing.Size(209, 20);
            this.txtExams.TabIndex = 3;
            this.txtExams.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExams.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtExams.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // txtParticipation
            // 
            this.txtParticipation.Location = new System.Drawing.Point(111, 81);
            this.txtParticipation.MaxLength = 3;
            this.txtParticipation.Name = "txtParticipation";
            this.txtParticipation.Size = new System.Drawing.Size(209, 20);
            this.txtParticipation.TabIndex = 2;
            this.txtParticipation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtParticipation.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtParticipation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // txtHomework
            // 
            this.txtHomework.Location = new System.Drawing.Point(111, 55);
            this.txtHomework.MaxLength = 3;
            this.txtHomework.Name = "txtHomework";
            this.txtHomework.Size = new System.Drawing.Size(209, 20);
            this.txtHomework.TabIndex = 1;
            this.txtHomework.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHomework.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.txtHomework.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Projects:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quizzes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exams:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Participation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Homework:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(188, 403);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(269, 403);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(92, 45);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.ReadOnly = true;
            this.txtCourseName.Size = new System.Drawing.Size(252, 20);
            this.txtCourseName.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Teacher:";
            // 
            // lblClassViewError
            // 
            this.lblClassViewError.AutoSize = true;
            this.lblClassViewError.ForeColor = System.Drawing.Color.Red;
            this.lblClassViewError.Location = new System.Drawing.Point(15, 408);
            this.lblClassViewError.Name = "lblClassViewError";
            this.lblClassViewError.Size = new System.Drawing.Size(0, 13);
            this.lblClassViewError.TabIndex = 9;
            // 
            // cboTeacherName
            // 
            this.cboTeacherName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeacherName.FormattingEnabled = true;
            this.cboTeacherName.Location = new System.Drawing.Point(92, 19);
            this.cboTeacherName.Name = "cboTeacherName";
            this.cboTeacherName.Size = new System.Drawing.Size(252, 21);
            this.cboTeacherName.TabIndex = 10;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.Location = new System.Drawing.Point(92, 19);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.ReadOnly = true;
            this.txtTeacherName.Size = new System.Drawing.Size(252, 20);
            this.txtTeacherName.TabIndex = 11;
            // 
            // ClassView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 474);
            this.Controls.Add(this.txtTeacherName);
            this.Controls.Add(this.cboTeacherName);
            this.Controls.Add(this.lblClassViewError);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCourseName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBoxCategoryWeights);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.groupBoxClassDescription);
            this.Name = "ClassView";
            this.Tag = "ClassView";
            this.Text = "Class View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClassView_Load);
            this.groupBoxClassDescription.ResumeLayout(false);
            this.groupBoxClassDescription.PerformLayout();
            this.groupBoxCategoryWeights.ResumeLayout(false);
            this.groupBoxCategoryWeights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClassDescription;
        private System.Windows.Forms.TextBox txtCourseDescription;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.GroupBox groupBoxCategoryWeights;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtProjects;
        private System.Windows.Forms.TextBox txtQuizzes;
        private System.Windows.Forms.TextBox txtExams;
        private System.Windows.Forms.TextBox txtParticipation;
        private System.Windows.Forms.TextBox txtHomework;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblClassViewError;
        private System.Windows.Forms.ComboBox cboTeacherName;
        private System.Windows.Forms.TextBox txtTeacherName;
    }
}