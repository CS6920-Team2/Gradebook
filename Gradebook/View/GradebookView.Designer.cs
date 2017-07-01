namespace Gradebook.View
{
    partial class GradebookView
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
            this.lblGradebook = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgAssignments = new System.Windows.Forms.DataGridView();
            this.ddlCourses = new System.Windows.Forms.ComboBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGradebook
            // 
            this.lblGradebook.AutoSize = true;
            this.lblGradebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradebook.Location = new System.Drawing.Point(13, 13);
            this.lblGradebook.Name = "lblGradebook";
            this.lblGradebook.Size = new System.Drawing.Size(200, 37);
            this.lblGradebook.TabIndex = 0;
            this.lblGradebook.Text = "View Grades";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 54);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgAssignments
            // 
            this.dgAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAssignments.Location = new System.Drawing.Point(12, 84);
            this.dgAssignments.Name = "dgAssignments";
            this.dgAssignments.Size = new System.Drawing.Size(1140, 515);
            this.dgAssignments.TabIndex = 3;
            // 
            // ddlCourses
            // 
            this.ddlCourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCourses.FormattingEnabled = true;
            this.ddlCourses.Location = new System.Drawing.Point(174, 55);
            this.ddlCourses.Name = "ddlCourses";
            this.ddlCourses.Size = new System.Drawing.Size(892, 21);
            this.ddlCourses.TabIndex = 4;
            this.ddlCourses.SelectedIndexChanged += new System.EventHandler(this.ddlCourses_SelectedIndexChanged);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(1072, 54);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(37, 23);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1115, 54);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(37, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // GradebookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 611);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.ddlCourses);
            this.Controls.Add(this.dgAssignments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblGradebook);
            this.Name = "GradebookView";
            this.Text = "GradebookView";
            ((System.ComponentModel.ISupportInitialize)(this.dgAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGradebook;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgAssignments;
        private System.Windows.Forms.ComboBox ddlCourses;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}