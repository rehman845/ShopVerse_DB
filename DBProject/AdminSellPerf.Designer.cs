namespace DBProject
{
    partial class AdminSellPerf
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
            this.txtSellerID = new System.Windows.Forms.TextBox();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.reportViewer6 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // txtSellerID
            // 
            this.txtSellerID.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellerID.Location = new System.Drawing.Point(395, 62);
            this.txtSellerID.Name = "txtSellerID";
            this.txtSellerID.Size = new System.Drawing.Size(287, 41);
            this.txtSellerID.TabIndex = 44;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnLoadReport.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.btnLoadReport.Location = new System.Drawing.Point(566, 586);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(202, 53);
            this.btnLoadReport.TabIndex = 45;
            this.btnLoadReport.Text = "Generate";
            this.btnLoadReport.UseVisualStyleBackColor = false;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(449, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 47);
            this.label2.TabIndex = 46;
            this.label2.Text = "Seller ID";
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LightCoral;
            this.Back.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.Back.Location = new System.Drawing.Point(328, 585);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(202, 53);
            this.Back.TabIndex = 47;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // reportViewer6
            // 
            this.reportViewer6.LocalReport.ReportEmbeddedResource = "DBProject.AdminSellPerf.rdlc";
            this.reportViewer6.LocalReport.ReportPath = "C:\\Users\\M Awab Ur Rehman\\source\\repos\\DBProject\\DBProject\\AdminSellPerf.rdlc";
            this.reportViewer6.Location = new System.Drawing.Point(12, 128);
            this.reportViewer6.Name = "reportViewer6";
            this.reportViewer6.ServerReport.BearerToken = null;
            this.reportViewer6.Size = new System.Drawing.Size(1076, 451);
            this.reportViewer6.TabIndex = 48;
            // 
            // AdminSellPerf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.reportViewer6);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.txtSellerID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminSellPerf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSellPerf";
            this.Load += new System.EventHandler(this.AdminSellPerf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSellerID;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Back;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer6;
    }
}