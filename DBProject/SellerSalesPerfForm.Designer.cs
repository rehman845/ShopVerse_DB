namespace DBProject
{
    partial class SellerSalesPerfForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtSellerMail = new System.Windows.Forms.TextBox();
            this.btnLoadReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportPath = "C:\\Users\\M Awab Ur Rehman\\source\\repos\\DBProject\\DBProject\\SalesPerfReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(37, 135);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1029, 445);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(416, 81);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(273, 41);
            this.txtEndDate.TabIndex = 1;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(37, 81);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(272, 41);
            this.txtStartDate.TabIndex = 2;
            // 
            // txtSellerMail
            // 
            this.txtSellerMail.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSellerMail.Location = new System.Drawing.Point(779, 81);
            this.txtSellerMail.Name = "txtSellerMail";
            this.txtSellerMail.Size = new System.Drawing.Size(287, 41);
            this.txtSellerMail.TabIndex = 3;
            // 
            // btnLoadReport
            // 
            this.btnLoadReport.BackColor = System.Drawing.Color.LightCoral;
            this.btnLoadReport.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.btnLoadReport.Location = new System.Drawing.Point(567, 586);
            this.btnLoadReport.Name = "btnLoadReport";
            this.btnLoadReport.Size = new System.Drawing.Size(202, 53);
            this.btnLoadReport.TabIndex = 4;
            this.btnLoadReport.Text = "Generate";
            this.btnLoadReport.UseVisualStyleBackColor = false;
            this.btnLoadReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(852, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 47);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(458, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 47);
            this.label1.TabIndex = 26;
            this.label1.Text = "End Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(80, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 47);
            this.label3.TabIndex = 27;
            this.label3.Text = "Start Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LightCoral;
            this.Back.Font = new System.Drawing.Font("Century Gothic", 18.2F, System.Drawing.FontStyle.Bold);
            this.Back.Location = new System.Drawing.Point(329, 585);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(202, 53);
            this.Back.TabIndex = 28;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // SellerSalesPerfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoadReport);
            this.Controls.Add(this.txtSellerMail);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SellerSalesPerfForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerSalesPerfForm";
            this.Load += new System.EventHandler(this.SellerSalesPerfForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtSellerMail;
        private System.Windows.Forms.Button btnLoadReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Back;
    }
}