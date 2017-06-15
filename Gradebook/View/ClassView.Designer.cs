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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.lblCourse = new System.Windows.Forms.Label();
            this.groupBoxCategoryWeights = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHomework = new System.Windows.Forms.TextBox();
            this.textBoxParticipation = new System.Windows.Forms.TextBox();
            this.textBoxExams = new System.Windows.Forms.TextBox();
            this.textBoxQuizzes = new System.Windows.Forms.TextBox();
            this.textBoxProjects = new System.Windows.Forms.TextBox();
            this.groupBoxClassDescription.SuspendLayout();
            this.groupBoxCategoryWeights.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxClassDescription
            // 
            this.groupBoxClassDescription.Controls.Add(this.textBox1);
            this.groupBoxClassDescription.Location = new System.Drawing.Point(16, 56);
            this.groupBoxClassDescription.Name = "groupBoxClassDescription";
            this.groupBoxClassDescription.Size = new System.Drawing.Size(332, 116);
            this.groupBoxClassDescription.TabIndex = 0;
            this.groupBoxClassDescription.TabStop = false;
            this.groupBoxClassDescription.Text = "Class Description";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(326, 97);
            this.textBox1.TabIndex = 0;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.AllowDrop = true;
            this.comboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(62, 27);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(286, 21);
            this.comboBoxClass.TabIndex = 1;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(13, 30);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(43, 13);
            this.lblCourse.TabIndex = 2;
            this.lblCourse.Text = "Course:";
            // 
            // groupBoxCategoryWeights
            // 
            this.groupBoxCategoryWeights.Controls.Add(this.textBoxProjects);
            this.groupBoxCategoryWeights.Controls.Add(this.textBoxQuizzes);
            this.groupBoxCategoryWeights.Controls.Add(this.textBoxExams);
            this.groupBoxCategoryWeights.Controls.Add(this.textBoxParticipation);
            this.groupBoxCategoryWeights.Controls.Add(this.textBoxHomework);
            this.groupBoxCategoryWeights.Controls.Add(this.label5);
            this.groupBoxCategoryWeights.Controls.Add(this.label4);
            this.groupBoxCategoryWeights.Controls.Add(this.label3);
            this.groupBoxCategoryWeights.Controls.Add(this.label2);
            this.groupBoxCategoryWeights.Controls.Add(this.label1);
            this.groupBoxCategoryWeights.Location = new System.Drawing.Point(19, 188);
            this.groupBoxCategoryWeights.Name = "groupBoxCategoryWeights";
            this.groupBoxCategoryWeights.Size = new System.Drawing.Size(326, 166);
            this.groupBoxCategoryWeights.TabIndex = 3;
            this.groupBoxCategoryWeights.TabStop = false;
            this.groupBoxCategoryWeights.Text = "Category Weights";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(192, 360);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(273, 360);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Homework:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Participation:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exams:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quizzes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Projects:";
            // 
            // textBoxHomework
            // 
            this.textBoxHomework.Location = new System.Drawing.Point(111, 29);
            this.textBoxHomework.Name = "textBoxHomework";
            this.textBoxHomework.Size = new System.Drawing.Size(209, 20);
            this.textBoxHomework.TabIndex = 5;
            // 
            // textBoxParticipation
            // 
            this.textBoxParticipation.Location = new System.Drawing.Point(111, 55);
            this.textBoxParticipation.Name = "textBoxParticipation";
            this.textBoxParticipation.Size = new System.Drawing.Size(209, 20);
            this.textBoxParticipation.TabIndex = 6;
            // 
            // textBoxExams
            // 
            this.textBoxExams.Location = new System.Drawing.Point(111, 81);
            this.textBoxExams.Name = "textBoxExams";
            this.textBoxExams.Size = new System.Drawing.Size(209, 20);
            this.textBoxExams.TabIndex = 7;
            // 
            // textBoxQuizzes
            // 
            this.textBoxQuizzes.Location = new System.Drawing.Point(111, 107);
            this.textBoxQuizzes.Name = "textBoxQuizzes";
            this.textBoxQuizzes.Size = new System.Drawing.Size(209, 20);
            this.textBoxQuizzes.TabIndex = 8;
            // 
            // textBoxProjects
            // 
            this.textBoxProjects.Location = new System.Drawing.Point(111, 133);
            this.textBoxProjects.Name = "textBoxProjects";
            this.textBoxProjects.Size = new System.Drawing.Size(209, 20);
            this.textBoxProjects.TabIndex = 9;
            // 
            // ClassView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 409);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBoxCategoryWeights);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.groupBoxClassDescription);
            this.Name = "ClassView";
            this.Text = "Class View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxClassDescription.ResumeLayout(false);
            this.groupBoxClassDescription.PerformLayout();
            this.groupBoxCategoryWeights.ResumeLayout(false);
            this.groupBoxCategoryWeights.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxClassDescription;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.GroupBox groupBoxCategoryWeights;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox textBoxProjects;
        private System.Windows.Forms.TextBox textBoxQuizzes;
        private System.Windows.Forms.TextBox textBoxExams;
        private System.Windows.Forms.TextBox textBoxParticipation;
        private System.Windows.Forms.TextBox textBoxHomework;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}