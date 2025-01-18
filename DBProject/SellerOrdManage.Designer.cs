namespace DBProject
{
    partial class SellerOrdManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerOrdManage));
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.SellerOrdManage_Back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SellerOrd_Flow = new System.Windows.Forms.FlowLayoutPanel();
            this.txtOrdID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClearlFilter = new System.Windows.Forms.Button();
            this.txtApplyButton = new System.Windows.Forms.Button();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.Rat = new System.Windows.Forms.Label();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.Customer = new System.Windows.Forms.Label();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(953, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(130, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 130;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // SellerOrdManage_Back_Button
            // 
            this.SellerOrdManage_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.SellerOrdManage_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellerOrdManage_Back_Button.Location = new System.Drawing.Point(18, 20);
            this.SellerOrdManage_Back_Button.Name = "SellerOrdManage_Back_Button";
            this.SellerOrdManage_Back_Button.Size = new System.Drawing.Size(122, 57);
            this.SellerOrdManage_Back_Button.TabIndex = 129;
            this.SellerOrdManage_Back_Button.Text = "Back";
            this.SellerOrdManage_Back_Button.UseVisualStyleBackColor = false;
            this.SellerOrdManage_Back_Button.Click += new System.EventHandler(this.SellerOrdManage_Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(359, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 80);
            this.label1.TabIndex = 128;
            this.label1.Text = "Orders List";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // SellerOrd_Flow
            // 
            this.SellerOrd_Flow.AutoScroll = true;
            this.SellerOrd_Flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.SellerOrd_Flow.Location = new System.Drawing.Point(12, 284);
            this.SellerOrd_Flow.Name = "SellerOrd_Flow";
            this.SellerOrd_Flow.Size = new System.Drawing.Size(1076, 354);
            this.SellerOrd_Flow.TabIndex = 131;
            // 
            // txtOrdID
            // 
            this.txtOrdID.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrdID.Location = new System.Drawing.Point(239, 228);
            this.txtOrdID.Name = "txtOrdID";
            this.txtOrdID.Size = new System.Drawing.Size(199, 48);
            this.txtOrdID.TabIndex = 183;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(64, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 40);
            this.label4.TabIndex = 182;
            this.label4.Text = "Order ID";
            // 
            // txtClearlFilter
            // 
            this.txtClearlFilter.BackColor = System.Drawing.Color.LightCoral;
            this.txtClearlFilter.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.txtClearlFilter.Location = new System.Drawing.Point(769, 230);
            this.txtClearlFilter.Name = "txtClearlFilter";
            this.txtClearlFilter.Size = new System.Drawing.Size(267, 48);
            this.txtClearlFilter.TabIndex = 181;
            this.txtClearlFilter.Text = "Clear Filters";
            this.txtClearlFilter.UseVisualStyleBackColor = false;
            this.txtClearlFilter.Click += new System.EventHandler(this.txtClearlFilter_Click);
            // 
            // txtApplyButton
            // 
            this.txtApplyButton.BackColor = System.Drawing.Color.LightCoral;
            this.txtApplyButton.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.txtApplyButton.Location = new System.Drawing.Point(456, 230);
            this.txtApplyButton.Name = "txtApplyButton";
            this.txtApplyButton.Size = new System.Drawing.Size(267, 48);
            this.txtApplyButton.TabIndex = 180;
            this.txtApplyButton.Text = "Apply Filters";
            this.txtApplyButton.UseVisualStyleBackColor = false;
            this.txtApplyButton.Click += new System.EventHandler(this.txtApplyButton_Click);
            // 
            // txtProd
            // 
            this.txtProd.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProd.Location = new System.Drawing.Point(734, 170);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(301, 48);
            this.txtProd.TabIndex = 179;
            // 
            // Rat
            // 
            this.Rat.AutoSize = true;
            this.Rat.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Rat.Location = new System.Drawing.Point(561, 172);
            this.Rat.Name = "Rat";
            this.Rat.Size = new System.Drawing.Size(143, 40);
            this.Rat.TabIndex = 178;
            this.Rat.Text = "Product";
            // 
            // txtCust
            // 
            this.txtCust.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCust.Location = new System.Drawing.Point(734, 94);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(301, 48);
            this.txtCust.TabIndex = 177;
            // 
            // Customer
            // 
            this.Customer.AutoSize = true;
            this.Customer.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Customer.Location = new System.Drawing.Point(560, 96);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(176, 40);
            this.Customer.TabIndex = 176;
            this.Customer.Text = "Customer";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndDate.Location = new System.Drawing.Point(239, 168);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(282, 48);
            this.txtEndDate.TabIndex = 175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(64, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 40);
            this.label2.TabIndex = 174;
            this.label2.Text = "End Date";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartDate.Location = new System.Drawing.Point(239, 96);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(282, 48);
            this.txtStartDate.TabIndex = 173;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(64, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 40);
            this.label3.TabIndex = 172;
            this.label3.Text = "Start Date";
            // 
            // SellerOrdManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.txtOrdID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClearlFilter);
            this.Controls.Add(this.txtApplyButton);
            this.Controls.Add(this.txtProd);
            this.Controls.Add(this.Rat);
            this.Controls.Add(this.txtCust);
            this.Controls.Add(this.Customer);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SellerOrd_Flow);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.SellerOrdManage_Back_Button);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SellerOrdManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerOrdManage";
            this.Load += new System.EventHandler(this.SellerOrdManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button SellerOrdManage_Back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel SellerOrd_Flow;
        private System.Windows.Forms.TextBox txtOrdID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button txtClearlFilter;
        private System.Windows.Forms.Button txtApplyButton;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label Rat;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Label Customer;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label3;
    }
}