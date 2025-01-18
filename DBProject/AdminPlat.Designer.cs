namespace DBProject
{
    partial class AdminPlat
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
            this.Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.reportViewer9 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LightCoral;
            this.Back.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.Back.Location = new System.Drawing.Point(328, 582);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(202, 53);
            this.Back.TabIndex = 37;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(259, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 47);
            this.label3.TabIndex = 36;
            this.label3.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(649, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 47);
            this.label1.TabIndex = 35;
            this.label1.Text = "End Date";
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnLoadReport.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.btnLoadReport.Location = new System.Drawing.Point(566, 583);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(202, 53);
            this.btnLoadReport.TabIndex = 33;
            this.btnLoadReport.Text = "Generate";
            this.btnLoadReport.UseVisualStyleBackColor = false;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(228, 73);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(272, 41);
            this.txtStartDate.TabIndex = 31;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(607, 73);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(273, 41);
            this.txtEndDate.TabIndex = 30;
            // 
            // reportViewer9
            // 
            this.reportViewer9.LocalReport.ReportEmbeddedResource = "DBProject.AdminPlat.rdlc";
            this.reportViewer9.LocalReport.ReportPath = "C:\\Users\\M Awab Ur Rehman\\source\\repos\\DBProject\\DBProject\\AdminPlat.rdlc";
            this.reportViewer9.Location = new System.Drawing.Point(12, 125);
            this.reportViewer9.Name = "reportViewer9";
            this.reportViewer9.ServerReport.BearerToken = null;
            this.reportViewer9.Size = new System.Drawing.Size(1076, 446);
            this.reportViewer9.TabIndex = 38;
            // 
            // AdminPlat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.reportViewer9);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminPlat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPlat";
            this.Load += new System.EventHandler(this.AdminPlat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer9;
    }
}