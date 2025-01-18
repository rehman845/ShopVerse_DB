namespace DBProject
{
    partial class SellerInvReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.txtSellerMail = new System.Windows.Forms.TextBox();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(484, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 47);
            this.label2.TabIndex = 34;
            this.label2.Text = "Mail";
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
            // txtSellerMail
            // 
            this.txtSellerMail.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellerMail.Location = new System.Drawing.Point(395, 73);
            this.txtSellerMail.Name = "txtSellerMail";
            this.txtSellerMail.Size = new System.Drawing.Size(287, 41);
            this.txtSellerMail.TabIndex = 32;
            // 
            // reportViewer3
            // 
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "DBProject.SellerInvReport.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(12, 129);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.ServerReport.BearerToken = null;
            this.reportViewer3.Size = new System.Drawing.Size(1076, 447);
            this.reportViewer3.TabIndex = 38;
            // 
            // SellerInvReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.reportViewer3);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.txtSellerMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SellerInvReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerInvReport";
            this.Load += new System.EventHandler(this.SellerInvReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.TextBox txtSellerMail;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
    }
}