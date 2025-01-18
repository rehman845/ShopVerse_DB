namespace DBProject
{
    partial class AdminLogisticsManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogisticsManage));
            this.AdminLogisticsManage_Orders_Datagrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.AdminLogisticsManage_Back_Button = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AdminLogisticsManage_Orders_Datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminLogisticsManage_Orders_Datagrid
            // 
            this.AdminLogisticsManage_Orders_Datagrid.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.AdminLogisticsManage_Orders_Datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AdminLogisticsManage_Orders_Datagrid.ColumnHeadersHeight = 30;
            this.AdminLogisticsManage_Orders_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AdminLogisticsManage_Orders_Datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8});
            this.AdminLogisticsManage_Orders_Datagrid.Location = new System.Drawing.Point(18, 123);
            this.AdminLogisticsManage_Orders_Datagrid.Name = "AdminLogisticsManage_Orders_Datagrid";
            this.AdminLogisticsManage_Orders_Datagrid.RowHeadersWidth = 51;
            this.AdminLogisticsManage_Orders_Datagrid.RowTemplate.Height = 24;
            this.AdminLogisticsManage_Orders_Datagrid.Size = new System.Drawing.Size(1065, 515);
            this.AdminLogisticsManage_Orders_Datagrid.TabIndex = 134;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "OrderID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Product(s)";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quantity";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Grand Total";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "View Details";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Delivery Time";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Delivery Status";
            this.Column7.Items.AddRange(new object[] {
            "Pending",
            "In Transit",
            "Shipped",
            "At Warehouse",
            "Out For Delivery",
            "Delivered",
            "Cancelled",
            "Returned"});
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Seller";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 40.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(155, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(763, 80);
            this.label3.TabIndex = 132;
            this.label3.Text = "Logistics Management";
            // 
            // AdminLogisticsManage_Back_Button
            // 
            this.AdminLogisticsManage_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.AdminLogisticsManage_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminLogisticsManage_Back_Button.Location = new System.Drawing.Point(18, 24);
            this.AdminLogisticsManage_Back_Button.Name = "AdminLogisticsManage_Back_Button";
            this.AdminLogisticsManage_Back_Button.Size = new System.Drawing.Size(92, 48);
            this.AdminLogisticsManage_Back_Button.TabIndex = 135;
            this.AdminLogisticsManage_Back_Button.Text = "Back";
            this.AdminLogisticsManage_Back_Button.UseVisualStyleBackColor = false;
            this.AdminLogisticsManage_Back_Button.Click += new System.EventHandler(this.AdminLogisticsManage_Back_Button_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(941, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(130, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 136;
            this.pictureBox5.TabStop = false;
            // 
            // AdminLogisticsManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.AdminLogisticsManage_Back_Button);
            this.Controls.Add(this.AdminLogisticsManage_Orders_Datagrid);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminLogisticsManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminLogisticsManage";
            this.Load += new System.EventHandler(this.AdminLogisticsManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AdminLogisticsManage_Orders_Datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AdminLogisticsManage_Orders_Datagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button AdminLogisticsManage_Back_Button;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}