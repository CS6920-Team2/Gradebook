namespace Gradebook.View
{
    partial class MissingAssignmentReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgAssignments = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAssignments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Missing Assignment Report";
            // 
            // dgAssignments
            // 
            this.dgAssignments.AllowUserToAddRows = false;
            this.dgAssignments.AllowUserToDeleteRows = false;
            this.dgAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAssignments.Location = new System.Drawing.Point(18, 119);
            this.dgAssignments.Name = "dgAssignments";
            this.dgAssignments.ReadOnly = true;
            this.dgAssignments.Size = new System.Drawing.Size(806, 456);
            this.dgAssignments.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Gradebook.Properties.Resources.GradeBookLogo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(836, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Green;
            this.lblMessage.Location = new System.Drawing.Point(18, 100);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 13);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "lblMessage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 582);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "* Check mark means that the work has been turned in\r\n* 0\'s show work that is miss" +
    "ing";
            // 
            // MissingAssignmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 639);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgAssignments);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MissingAssignmentReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MissingAssignmentReport";
            this.Load += new System.EventHandler(this.MissingAssignmentReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAssignments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgAssignments;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label2;
    }
}