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
            this.SuspendLayout();
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(125, 12);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(173, 20);
            this.nameTB.TabIndex = 3;
            // 
            // assignmentName
            // 
            this.assignmentName.AutoSize = true;
            this.assignmentName.Location = new System.Drawing.Point(14, 20);
            this.assignmentName.Name = "assignmentName";
            this.assignmentName.Size = new System.Drawing.Size(95, 13);
            this.assignmentName.TabIndex = 2;
            this.assignmentName.Text = "Assignment Name:";
            // 
            // descriptionTB
            // 
            this.descriptionTB.Location = new System.Drawing.Point(125, 59);
            this.descriptionTB.Multiline = true;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.Size = new System.Drawing.Size(173, 76);
            this.descriptionTB.TabIndex = 5;
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(46, 62);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(63, 13);
            this.description.TabIndex = 4;
            this.description.Text = "Description:";
            // 
            // assignedDate
            // 
            this.assignedDate.AutoSize = true;
            this.assignedDate.Location = new System.Drawing.Point(30, 172);
            this.assignedDate.Name = "assignedDate";
            this.assignedDate.Size = new System.Drawing.Size(79, 13);
            this.assignedDate.TabIndex = 6;
            this.assignedDate.Text = "Assigned Date:";
            // 
            // assignedDatedtp
            // 
            this.assignedDatedtp.Location = new System.Drawing.Point(125, 166);
            this.assignedDatedtp.Name = "assignedDatedtp";
            this.assignedDatedtp.Size = new System.Drawing.Size(200, 20);
            this.assignedDatedtp.TabIndex = 8;
            // 
            // dueDatedtp
            // 
            this.dueDatedtp.Location = new System.Drawing.Point(125, 204);
            this.dueDatedtp.Name = "dueDatedtp";
            this.dueDatedtp.Size = new System.Drawing.Size(200, 20);
            this.dueDatedtp.TabIndex = 10;
            // 
            // dueDate
            // 
            this.dueDate.AutoSize = true;
            this.dueDate.Location = new System.Drawing.Point(53, 211);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(56, 13);
            this.dueDate.TabIndex = 9;
            this.dueDate.Text = "Due Date:";
            // 
            // possiblePointsTB
            // 
            this.possiblePointsTB.Location = new System.Drawing.Point(125, 252);
            this.possiblePointsTB.Name = "possiblePointsTB";
            this.possiblePointsTB.Size = new System.Drawing.Size(173, 20);
            this.possiblePointsTB.TabIndex = 12;
            // 
            // possiblePoints
            // 
            this.possiblePoints.AutoSize = true;
            this.possiblePoints.Location = new System.Drawing.Point(14, 260);
            this.possiblePoints.Name = "possiblePoints";
            this.possiblePoints.Size = new System.Drawing.Size(81, 13);
            this.possiblePoints.TabIndex = 11;
            this.possiblePoints.Text = "Points Possible:";
            // 
            // AssignmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 474);
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
            this.Name = "AssignmentsView";
            this.Text = "Assignments View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
    }
}