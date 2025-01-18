namespace DBProject
{
    partial class AdminCustManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCustManage));
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AdminCustomerManage_CustomerID_txtfield = new System.Windows.Forms.TextBox();
            this.AdminCustomerManage_Back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdminCustomerManage_ViewSeller_Button = new System.Windows.Forms.Button();
            this.Admin_CustomerIDEnter = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.DataGridView();
            this.AdminCustomerManage_Approve_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AdminCustomerReviewFlows = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(947, 11);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(130, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 136;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 47);
            this.label2.TabIndex = 24;
            this.label2.Text = "Customer ID";
            // 
            // AdminCustomerManage_CustomerID_txtfield
            // 
            this.AdminCustomerManage_CustomerID_txtfield.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.AdminCustomerManage_CustomerID_txtfield.Location = new System.Drawing.Point(15, 94);
            this.AdminCustomerManage_CustomerID_txtfield.Name = "AdminCustomerManage_CustomerID_txtfield";
            this.AdminCustomerManage_CustomerID_txtfield.Size = new System.Drawing.Size(123, 52);
            this.AdminCustomerManage_CustomerID_txtfield.TabIndex = 25;
            this.AdminCustomerManage_CustomerID_txtfield.TextChanged += new System.EventHandler(this.AdminCustomerManage_CustomerID_txtfield_TextChanged);
            // 
            // AdminCustomerManage_Back_Button
            // 
            this.AdminCustomerManage_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.AdminCustomerManage_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminCustomerManage_Back_Button.Location = new System.Drawing.Point(12, 28);
            this.AdminCustomerManage_Back_Button.Name = "AdminCustomerManage_Back_Button";
            this.AdminCustomerManage_Back_Button.Size = new System.Drawing.Size(122, 57);
            this.AdminCustomerManage_Back_Button.TabIndex = 134;
            this.AdminCustomerManage_Back_Button.Text = "Back";
            this.AdminCustomerManage_Back_Button.UseVisualStyleBackColor = false;
            this.AdminCustomerManage_Back_Button.Click += new System.EventHandler(this.AdminCustomerManage_Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(142, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(805, 80);
            this.label1.TabIndex = 133;
            this.label1.Text = "Customer Management";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.Controls.Add(this.AdminCustomerManage_ViewSeller_Button);
            this.groupBox1.Controls.Add(this.Admin_CustomerIDEnter);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AdminCustomerManage_CustomerID_txtfield);
            this.groupBox1.Controls.Add(this.Admin);
            this.groupBox1.Controls.Add(this.AdminCustomerManage_Approve_Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1076, 177);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            // 
            // AdminCustomerManage_ViewSeller_Button
            // 
            this.AdminCustomerManage_ViewSeller_Button.BackColor = System.Drawing.Color.LightCoral;
            this.AdminCustomerManage_ViewSeller_Button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.AdminCustomerManage_ViewSeller_Button.Location = new System.Drawing.Point(331, 22);
            this.AdminCustomerManage_ViewSeller_Button.Name = "AdminCustomerManage_ViewSeller_Button";
            this.AdminCustomerManage_ViewSeller_Button.Size = new System.Drawing.Size(722, 127);
            this.AdminCustomerManage_ViewSeller_Button.TabIndex = 128;
            this.AdminCustomerManage_ViewSeller_Button.Text = "View Customer Information";
            this.AdminCustomerManage_ViewSeller_Button.UseVisualStyleBackColor = false;
            this.AdminCustomerManage_ViewSeller_Button.Click += new System.EventHandler(this.AdminCustomerManage_ViewSeller_Button_Click);
            // 
            // Admin_CustomerIDEnter
            // 
            this.Admin_CustomerIDEnter.BackColor = System.Drawing.Color.LightCoral;
            this.Admin_CustomerIDEnter.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.Admin_CustomerIDEnter.Location = new System.Drawing.Point(144, 91);
            this.Admin_CustomerIDEnter.Name = "Admin_CustomerIDEnter";
            this.Admin_CustomerIDEnter.Size = new System.Drawing.Size(133, 57);
            this.Admin_CustomerIDEnter.TabIndex = 131;
            this.Admin_CustomerIDEnter.Text = "Enter";
            this.Admin_CustomerIDEnter.UseVisualStyleBackColor = false;
            this.Admin_CustomerIDEnter.Click += new System.EventHandler(this.Admin_CustomerIDEnter_Click);
            // 
            // Admin
            // 
            this.Admin.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.Admin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Admin.ColumnHeadersHeight = 30;
            this.Admin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Admin.Location = new System.Drawing.Point(754, 155);
            this.Admin.Name = "Admin";
            this.Admin.RowHeadersWidth = 51;
            this.Admin.RowTemplate.Height = 24;
            this.Admin.Size = new System.Drawing.Size(10, 10);
            this.Admin.TabIndex = 130;
            // 
            // AdminCustomerManage_Approve_Button
            // 
            this.AdminCustomerManage_Approve_Button.BackColor = System.Drawing.Color.LightCoral;
            this.AdminCustomerManage_Approve_Button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.AdminCustomerManage_Approve_Button.Location = new System.Drawing.Point(775, 22);
            this.AdminCustomerManage_Approve_Button.Name = "AdminCustomerManage_Approve_Button";
            this.AdminCustomerManage_Approve_Button.Size = new System.Drawing.Size(278, 127);
            this.AdminCustomerManage_Approve_Button.TabIndex = 129;
            this.AdminCustomerManage_Approve_Button.Text = "Approve Customer Account";
            this.AdminCustomerManage_Approve_Button.UseVisualStyleBackColor = false;
            this.AdminCustomerManage_Approve_Button.Click += new System.EventHandler(this.AdminCustomerManage_Approve_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(312, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(476, 51);
            this.label3.TabIndex = 137;
            this.label3.Text = "All Customer Reviews";
            // 
            // AdminCustomerReviewFlows
            // 
            this.AdminCustomerReviewFlows.AutoScroll = true;
            this.AdminCustomerReviewFlows.BackColor = System.Drawing.Color.NavajoWhite;
            this.AdminCustomerReviewFlows.Location = new System.Drawing.Point(12, 361);
            this.AdminCustomerReviewFlows.Name = "AdminCustomerReviewFlows";
            this.AdminCustomerReviewFlows.Size = new System.Drawing.Size(1076, 278);
            this.AdminCustomerReviewFlows.TabIndex = 138;
            this.AdminCustomerReviewFlows.Paint += new System.Windows.Forms.PaintEventHandler(this.AdminCustomerReviewFlows_Paint);
            // 
            // AdminCustManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.AdminCustomerManage_Back_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AdminCustomerReviewFlows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminCustManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminCustManage";
            this.Load += new System.EventHandler(this.AdminCustManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Admin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AdminCustomerManage_CustomerID_txtfield;
        private System.Windows.Forms.Button AdminCustomerManage_Back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AdminCustomerManage_ViewSeller_Button;
        private System.Windows.Forms.Button Admin_CustomerIDEnter;
        private System.Windows.Forms.Button AdminCustomerManage_Approve_Button;
        private System.Windows.Forms.DataGridView Admin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel AdminCustomerReviewFlows;
    }
}