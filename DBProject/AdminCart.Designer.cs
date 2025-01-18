namespace DBProject
{
    partial class AdminCart
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
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.reportViewer8 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LightCoral;
            this.Back.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.Back.Location = new System.Drawing.Point(328, 586);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(202, 53);
            this.Back.TabIndex = 49;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(320, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(438, 47);
            this.label3.TabIndex = 48;
            this.label3.Text = "Enter Number of Days";
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnLoadReport.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.btnLoadReport.Location = new System.Drawing.Point(566, 587);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(202, 53);
            this.btnLoadReport.TabIndex = 47;
            this.btnLoadReport.Text = "Generate";
            this.btnLoadReport.UseVisualStyleBackColor = false;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(406, 74);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(272, 41);
            this.txtDays.TabIndex = 46;
            // 
            // reportViewer8
            // 
            this.reportViewer8.LocalReport.ReportEmbeddedResource = "DBProject.AdminCart.rdlc";
            this.reportViewer8.LocalReport.ReportPath = "C:\\Users\\M Awab Ur Rehman\\source\\repos\\DBProject\\DBProject\\AdminCart.rdlc";
            this.reportViewer8.Location = new System.Drawing.Point(12, 131);
            this.reportViewer8.Name = "reportViewer8";
            this.reportViewer8.ServerReport.BearerToken = null;
            this.reportViewer8.Size = new System.Drawing.Size(1076, 450);
            this.reportViewer8.TabIndex = 50;
            // 
            // AdminCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.reportViewer8);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.txtDays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminCart";
            this.Load += new System.EventHandler(this.AdminCart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.TextBox txtDays;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer8;
    }
}