namespace Gradebook.View
{
    partial class AssignmentsView
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
            this.nameTB = new System.Windows.Forms.TextBox();
            this.assignmentName = new System.Windows.Forms.Label();
            this.descriptionTB = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.Label();
            this.assignedDate = new System.Windows.Forms.Label();
            this.assignedDatedtp = new System.Windows.Forms.DateTimePicker();
            this.dueDatedtp = new System.Windows.Forms.DateTimePicker();
            this.dueDate = new System.Windows.Forms.Label();
            this.possiblePointsTB = new System.Windows.Forms.TextBox();
            this.possiblePoints = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.Label();
            this.categoryCB = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.assignmentIDTB = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(293, 62);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(186, 20);
            this.nameTB.TabIndex = 3;
            this.nameTB.Tag = "Name";
            // 
            // assignmentName
            // 
            this.assignmentName.AutoSize = true;
            this.assignmentName.Location = new System.Drawing.Point(249, 65);
            this.assignmentName.Name = "assignmentName";
            this.assignmentName.Size = new System.Drawing.Size(38, 13);
            this.assignmentName.TabIndex = 2;
            this.assignmentName.Text = "Name:";
            // 
            // descriptionTB
            // 
            this.descriptionTB.Location = new System.Drawing.Point(293, 96);
            this.descriptionTB.Multiline = true;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.Size = new System.Drawing.Size(186, 76);
            this.descriptionTB.TabIndex = 5;
            this.descriptionTB.Tag = "Description";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(224, 96);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(63, 13);
            this.description.TabIndex = 4;
            this.description.Text = "Description:";
            // 
            // assignedDate
            // 
            this.assignedDate.AutoSize = true;
            this.assignedDate.Location = new System.Drawing.Point(503, 64);
            this.assignedDate.Name = "assignedDate";
            this.assignedDate.Size = new System.Drawing.Size(79, 13);
            this.assignedDate.TabIndex = 6;
            this.assignedDate.Text = "Assigned Date:";
            // 
            // assignedDatedtp
            // 
            this.assignedDatedtp.Location = new System.Drawing.Point(588, 64);
            this.assignedDatedtp.Name = "assignedDatedtp";
            this.assignedDatedtp.Size = new System.Drawing.Size(202, 20);
            this.assignedDatedtp.TabIndex = 8;
            // 
            // dueDatedtp
            // 
            this.dueDatedtp.Location = new System.Drawing.Point(588, 93);
            this.dueDatedtp.Name = "dueDatedtp";
            this.dueDatedtp.Size = new System.Drawing.Size(202, 20);
            this.dueDatedtp.TabIndex = 10;
            // 
            // dueDate
            // 
            this.dueDate.AutoSize = true;
            this.dueDate.Location = new System.Drawing.Point(526, 93);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(56, 13);
            this.dueDate.TabIndex = 9;
            this.dueDate.Text = "Due Date:";
            // 
            // possiblePointsTB
            // 
            this.possiblePointsTB.Location = new System.Drawing.Point(588, 149);
            this.possiblePointsTB.Name = "possiblePointsTB";
            this.possiblePointsTB.Size = new System.Drawing.Size(202, 20);
            this.possiblePointsTB.TabIndex = 12;
            this.possiblePointsTB.Tag = "Points Possible";
            // 
            // possiblePoints
            // 
            this.possiblePoints.AutoSize = true;
            this.possiblePoints.Location = new System.Drawing.Point(501, 149);
            this.possiblePoints.Name = "possiblePoints";
            this.possiblePoints.Size = new System.Drawing.Size(81, 13);
            this.possiblePoints.TabIndex = 11;
            this.possiblePoints.Text = "Points Possible:";
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Location = new System.Drawing.Point(530, 122);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(52, 13);
            this.category.TabIndex = 13;
            this.category.Text = "Category:";
            // 
            // categoryCB
            // 
            this.categoryCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCB.FormattingEnabled = true;
            this.categoryCB.Location = new System.Drawing.Point(588, 122);
            this.categoryCB.Name = "categoryCB";
            this.categoryCB.Size = new System.Drawing.Size(202, 21);
            this.categoryCB.TabIndex = 14;
            this.categoryCB.Tag = "Category";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(824, 180);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Assignment Details";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(693, 375);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(97, 40);
            this.submitBtn.TabIndex = 17;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // assignmentIDTB
            // 
            this.assignmentIDTB.Location = new System.Drawing.Point(455, 20);
            this.assignmentIDTB.Name = "assignmentIDTB";
            this.assignmentIDTB.Size = new System.Drawing.Size(173, 20);
            this.assignmentIDTB.TabIndex = 19;
            this.assignmentIDTB.Visible = false;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(99, 56);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(97, 40);
            this.addBtn.TabIndex = 20;
            this.addBtn.Text = "Add ";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // modifyBtn
            // 
            this.modifyBtn.Location = new System.Drawing.Point(99, 122);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(97, 40);
            this.modifyBtn.TabIndex = 21;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = true;
            this.modifyBtn.Click += new System.EventHandler(this.modifyBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(693, 375);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(97, 40);
            this.updateBtn.TabIndex = 22;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(588, 375);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(97, 40);
            this.deleteBtn.TabIndex = 23;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // AssignmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(895, 474);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.modifyBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.assignmentIDTB);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.categoryCB);
            this.Controls.Add(this.category);
            this.Controls.Add(this.possiblePointsTB);
            this.Controls.Add(this.possiblePoints);
            this.Controls.Add(this.dueDatedtp);
            this.Controls.Add(this.dueDate);
            this.Controls.Add(this.assignedDatedtp);
            this.Controls.Add(this.assignedDate);
            this.Controls.Add(this.descriptionTB);
            this.Controls.Add(this.description);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.assignmentName);
            this.MinimizeBox = false;
            this.Name = "AssignmentsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assignments View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AssignmentsView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label assignmentName;
        private System.Windows.Forms.TextBox descriptionTB;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label assignedDate;
        private System.Windows.Forms.DateTimePicker assignedDatedtp;
        private System.Windows.Forms.DateTimePicker dueDatedtp;
        private System.Windows.Forms.Label dueDate;
        private System.Windows.Forms.TextBox possiblePointsTB;
        private System.Windows.Forms.Label possiblePoints;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.ComboBox categoryCB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox assignmentIDTB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
    }
}