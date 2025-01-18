namespace DBProject
{
    partial class CustWishlist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustWishlist));
            this.Wishlist_Items_Datagrid = new System.Windows.Forms.DataGridView();
            this.Cart_ProdName_DatagridCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cart_ProdPrice_DatagridCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cart_Quantity_DatagridCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cart_Remove_DatagridCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Wishlist_AddToCart_button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Cart_ProdPic_DatagridImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.Wishlist_Back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Wishlist_AddAll_Button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wishlist_Items_Datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Wishlist_Items_Datagrid
            // 
            this.Wishlist_Items_Datagrid.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.Wishlist_Items_Datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Wishlist_Items_Datagrid.ColumnHeadersHeight = 30;
            this.Wishlist_Items_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Wishlist_Items_Datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cart_ProdName_DatagridCol,
            this.Cart_ProdPrice_DatagridCol,
            this.Cart_Quantity_DatagridCol,
            this.Cart_Remove_DatagridCol,
            this.Wishlist_AddToCart_button,
            this.Cart_ProdPic_DatagridImage});
            this.Wishlist_Items_Datagrid.Location = new System.Drawing.Point(18, 115);
            this.Wishlist_Items_Datagrid.Name = "Wishlist_Items_Datagrid";
            this.Wishlist_Items_Datagrid.RowHeadersWidth = 51;
            this.Wishlist_Items_Datagrid.RowTemplate.Height = 24;
            this.Wishlist_Items_Datagrid.Size = new System.Drawing.Size(726, 525);
            this.Wishlist_Items_Datagrid.TabIndex = 99;
            // 
            // Cart_ProdName_DatagridCol
            // 
            this.Cart_ProdName_DatagridCol.HeaderText = "Product";
            this.Cart_ProdName_DatagridCol.MinimumWidth = 6;
            this.Cart_ProdName_DatagridCol.Name = "Cart_ProdName_DatagridCol";
            this.Cart_ProdName_DatagridCol.Width = 112;
            // 
            // Cart_ProdPrice_DatagridCol
            // 
            this.Cart_ProdPrice_DatagridCol.HeaderText = "Price";
            this.Cart_ProdPrice_DatagridCol.MinimumWidth = 6;
            this.Cart_ProdPrice_DatagridCol.Name = "Cart_ProdPrice_DatagridCol";
            this.Cart_ProdPrice_DatagridCol.Width = 112;
            // 
            // Cart_Quantity_DatagridCol
            // 
            this.Cart_Quantity_DatagridCol.HeaderText = "Quantity";
            this.Cart_Quantity_DatagridCol.MinimumWidth = 6;
            this.Cart_Quantity_DatagridCol.Name = "Cart_Quantity_DatagridCol";
            this.Cart_Quantity_DatagridCol.Width = 112;
            // 
            // Cart_Remove_DatagridCol
            // 
            this.Cart_Remove_DatagridCol.HeaderText = "Remove";
            this.Cart_Remove_DatagridCol.MinimumWidth = 6;
            this.Cart_Remove_DatagridCol.Name = "Cart_Remove_DatagridCol";
            this.Cart_Remove_DatagridCol.Text = "Remove";
            this.Cart_Remove_DatagridCol.ToolTipText = "Remove";
            this.Cart_Remove_DatagridCol.UseColumnTextForButtonValue = true;
            this.Cart_Remove_DatagridCol.Width = 112;
            // 
            // Wishlist_AddToCart_button
            // 
            this.Wishlist_AddToCart_button.HeaderText = "Add To Cart";
            this.Wishlist_AddToCart_button.MinimumWidth = 6;
            this.Wishlist_AddToCart_button.Name = "Wishlist_AddToCart_button";
            this.Wishlist_AddToCart_button.Width = 125;
            // 
            // Cart_ProdPic_DatagridImage
            // 
            this.Cart_ProdPic_DatagridImage.HeaderText = "Picture";
            this.Cart_ProdPic_DatagridImage.MinimumWidth = 6;
            this.Cart_ProdPic_DatagridImage.Name = "Cart_ProdPic_DatagridImage";
            this.Cart_ProdPic_DatagridImage.Width = 112;
            // 
            // Wishlist_Back_Button
            // 
            this.Wishlist_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Wishlist_Back_Button.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.Wishlist_Back_Button.Location = new System.Drawing.Point(18, 28);
            this.Wishlist_Back_Button.Name = "Wishlist_Back_Button";
            this.Wishlist_Back_Button.Size = new System.Drawing.Size(107, 63);
            this.Wishlist_Back_Button.TabIndex = 97;
            this.Wishlist_Back_Button.Text = "Back";
            this.Wishlist_Back_Button.UseVisualStyleBackColor = false;
            this.Wishlist_Back_Button.Click += new System.EventHandler(this.Wishlist_Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(349, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 80);
            this.label1.TabIndex = 96;
            this.label1.Text = "My Wishlist";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(957, 14);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(126, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 103;
            this.pictureBox5.TabStop = false;
            // 
            // Wishlist_AddAll_Button
            // 
            this.Wishlist_AddAll_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Wishlist_AddAll_Button.Font = new System.Drawing.Font("Century Gothic", 26F, System.Drawing.FontStyle.Bold);
            this.Wishlist_AddAll_Button.Location = new System.Drawing.Point(767, 486);
            this.Wishlist_AddAll_Button.Name = "Wishlist_AddAll_Button";
            this.Wishlist_AddAll_Button.Size = new System.Drawing.Size(298, 154);
            this.Wishlist_AddAll_Button.TabIndex = 100;
            this.Wishlist_AddAll_Button.Text = "Add All\r\nTo Cart";
            this.Wishlist_AddAll_Button.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(718, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(396, 397);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 98;
            this.pictureBox2.TabStop = false;
            // 
            // CustWishlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.Wishlist_Items_Datagrid);
            this.Controls.Add(this.Wishlist_Back_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Wishlist_AddAll_Button);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustWishlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustWishlist";
            this.Load += new System.EventHandler(this.CustWishlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Wishlist_Items_Datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Wishlist_Items_Datagrid;
        private System.Windows.Forms.Button Wishlist_Back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Wishlist_AddAll_Button;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cart_ProdName_DatagridCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cart_ProdPrice_DatagridCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cart_Quantity_DatagridCol;
        private System.Windows.Forms.DataGridViewButtonColumn Cart_Remove_DatagridCol;
        private System.Windows.Forms.DataGridViewButtonColumn Wishlist_AddToCart_button;
        private System.Windows.Forms.DataGridViewImageColumn Cart_ProdPic_DatagridImage;
    }
}