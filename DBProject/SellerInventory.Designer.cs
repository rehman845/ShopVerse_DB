namespace DBProject
{
    partial class SellerInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellerInventory));
            this.SellerInventory_Back_Button = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SellerInventory_UpdateProd_Button = new System.Windows.Forms.Button();
            this.SellerInventory_RemoveProd_Button = new System.Windows.Forms.Button();
            this.SellerInventory_AddProd_Button = new System.Windows.Forms.Button();
            this.Inventory_Flow = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // SellerInventory_Back_Button
            // 
            this.SellerInventory_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.SellerInventory_Back_Button.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.SellerInventory_Back_Button.Location = new System.Drawing.Point(12, 30);
            this.SellerInventory_Back_Button.Name = "SellerInventory_Back_Button";
            this.SellerInventory_Back_Button.Size = new System.Drawing.Size(118, 65);
            this.SellerInventory_Back_Button.TabIndex = 110;
            this.SellerInventory_Back_Button.Text = "Back";
            this.SellerInventory_Back_Button.UseVisualStyleBackColor = false;
            this.SellerInventory_Back_Button.Click += new System.EventHandler(this.SellerInventory_Back_Button_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(912, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(176, 116);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 109;
            this.pictureBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 44F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(277, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(501, 86);
            this.label1.TabIndex = 108;
            this.label1.Text = "My Inventory";
            // 
            // SellerInventory_UpdateProd_Button
            // 
            this.SellerInventory_UpdateProd_Button.BackColor = System.Drawing.Color.LightCoral;
            this.SellerInventory_UpdateProd_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.SellerInventory_UpdateProd_Button.Location = new System.Drawing.Point(861, 490);
            this.SellerInventory_UpdateProd_Button.Name = "SellerInventory_UpdateProd_Button";
            this.SellerInventory_UpdateProd_Button.Size = new System.Drawing.Size(227, 148);
            this.SellerInventory_UpdateProd_Button.TabIndex = 115;
            this.SellerInventory_UpdateProd_Button.Text = "Update Product";
            this.SellerInventory_UpdateProd_Button.UseVisualStyleBackColor = false;
            this.SellerInventory_UpdateProd_Button.Click += new System.EventHandler(this.SellerInventory_UpdateProd_Button_Click);
            // 
            // SellerInventory_RemoveProd_Button
            // 
            this.SellerInventory_RemoveProd_Button.BackColor = System.Drawing.Color.LightCoral;
            this.SellerInventory_RemoveProd_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.SellerInventory_RemoveProd_Button.Location = new System.Drawing.Point(861, 316);
            this.SellerInventory_RemoveProd_Button.Name = "SellerInventory_RemoveProd_Button";
            this.SellerInventory_RemoveProd_Button.Size = new System.Drawing.Size(227, 148);
            this.SellerInventory_RemoveProd_Button.TabIndex = 112;
            this.SellerInventory_RemoveProd_Button.Text = "Remove Product";
            this.SellerInventory_RemoveProd_Button.UseVisualStyleBackColor = false;
            this.SellerInventory_RemoveProd_Button.Click += new System.EventHandler(this.SellerInventory_RemoveProd_Button_Click);
            // 
            // SellerInventory_AddProd_Button
            // 
            this.SellerInventory_AddProd_Button.BackColor = System.Drawing.Color.LightCoral;
            this.SellerInventory_AddProd_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.SellerInventory_AddProd_Button.Location = new System.Drawing.Point(861, 144);
            this.SellerInventory_AddProd_Button.Name = "SellerInventory_AddProd_Button";
            this.SellerInventory_AddProd_Button.Size = new System.Drawing.Size(227, 148);
            this.SellerInventory_AddProd_Button.TabIndex = 113;
            this.SellerInventory_AddProd_Button.Text = "Add New Product";
            this.SellerInventory_AddProd_Button.UseVisualStyleBackColor = false;
            this.SellerInventory_AddProd_Button.Click += new System.EventHandler(this.SellerInventory_AddProd_Button_Click);
            // 
            // Inventory_Flow
            // 
            this.Inventory_Flow.AutoScroll = true;
            this.Inventory_Flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.Inventory_Flow.Location = new System.Drawing.Point(12, 144);
            this.Inventory_Flow.Name = "Inventory_Flow";
            this.Inventory_Flow.Size = new System.Drawing.Size(834, 494);
            this.Inventory_Flow.TabIndex = 116;
            // 
            // SellerInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.Inventory_Flow);
            this.Controls.Add(this.SellerInventory_UpdateProd_Button);
            this.Controls.Add(this.SellerInventory_AddProd_Button);
            this.Controls.Add(this.SellerInventory_RemoveProd_Button);
            this.Controls.Add(this.SellerInventory_Back_Button);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SellerInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerInventory";
            this.Load += new System.EventHandler(this.SellerInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SellerInventory_Back_Button;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SellerInventory_UpdateProd_Button;
        private System.Windows.Forms.Button SellerInventory_RemoveProd_Button;
        private System.Windows.Forms.Button SellerInventory_AddProd_Button;
        private System.Windows.Forms.FlowLayoutPanel Inventory_Flow;
    }
}