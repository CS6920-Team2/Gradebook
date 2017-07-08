namespace Gradebook.View
{
    partial class ProgressReportView
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gradeAvgLBL = new System.Windows.Forms.Label();
            this.letterGradeLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(104, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(611, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // gradeAvgLBL
            // 
            this.gradeAvgLBL.AutoSize = true;
            this.gradeAvgLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gradeAvgLBL.Location = new System.Drawing.Point(107, 149);
            this.gradeAvgLBL.Name = "gradeAvgLBL";
            this.gradeAvgLBL.Size = new System.Drawing.Size(197, 31);
            this.gradeAvgLBL.TabIndex = 1;
            this.gradeAvgLBL.Text = "Grade Average";
            // 
            // letterGradeLBL
            // 
            this.letterGradeLBL.AutoSize = true;
            this.letterGradeLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letterGradeLBL.Location = new System.Drawing.Point(476, 149);
            this.letterGradeLBL.Name = "letterGradeLBL";
            this.letterGradeLBL.Size = new System.Drawing.Size(166, 31);
            this.letterGradeLBL.TabIndex = 2;
            this.letterGradeLBL.Text = "Letter Grade";
            // 
            // ProgressReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 488);
            this.Controls.Add(this.letterGradeLBL);
            this.Controls.Add(this.gradeAvgLBL);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProgressReportView";
            this.Text = "Progress Report View";
            this.Load += new System.EventHandler(this.ProgressReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label gradeAvgLBL;
        private System.Windows.Forms.Label letterGradeLBL;
    }
}