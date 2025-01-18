namespace DBProject
{
    partial class CustCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustCart));
            this.Cart_Back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Cart_CheckOut_Button = new System.Windows.Forms.Button();
            this.Cart_TotalValue_Label = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Cart_CartItems_FlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.Product = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CustCart_DeleteProd_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.Cart_CartItems_FlowLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cart_Back_Button
            // 
            this.Cart_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Cart_Back_Button.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.Cart_Back_Button.Location = new System.Drawing.Point(12, 26);
            this.Cart_Back_Button.Name = "Cart_Back_Button";
            this.Cart_Back_Button.Size = new System.Drawing.Size(107, 63);
            this.Cart_Back_Button.TabIndex = 31;
            this.Cart_Back_Button.Text = "Back";
            this.Cart_Back_Button.UseVisualStyleBackColor = false;
            this.Cart_Back_Button.Click += new System.EventHandler(this.Cart_Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(291, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 80);
            this.label1.TabIndex = 30;
            this.label1.Text = "My Cart Details";
            // 
            // Cart_CheckOut_Button
            // 
            this.Cart_CheckOut_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Cart_CheckOut_Button.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.Cart_CheckOut_Button.Location = new System.Drawing.Point(761, 531);
            this.Cart_CheckOut_Button.Name = "Cart_CheckOut_Button";
            this.Cart_CheckOut_Button.Size = new System.Drawing.Size(298, 107);
            this.Cart_CheckOut_Button.TabIndex = 36;
            this.Cart_CheckOut_Button.Text = "Proceed To\r\nCheck Out";
            this.Cart_CheckOut_Button.UseVisualStyleBackColor = false;
            this.Cart_CheckOut_Button.Click += new System.EventHandler(this.Cart_CheckOut_Button_Click);
            // 
            // Cart_TotalValue_Label
            // 
            this.Cart_TotalValue_Label.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.Cart_TotalValue_Label.Location = new System.Drawing.Point(765, 467);
            this.Cart_TotalValue_Label.Name = "Cart_TotalValue_Label";
            this.Cart_TotalValue_Label.Size = new System.Drawing.Size(294, 47);
            this.Cart_TotalValue_Label.TabIndex = 38;
            this.Cart_TotalValue_Label.Text = "TBE";
            this.Cart_TotalValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(761, 113);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(298, 341);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(951, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(126, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 95;
            this.pictureBox5.TabStop = false;
            // 
            // Cart_CartItems_FlowLayout
            // 
            this.Cart_CartItems_FlowLayout.AutoScroll = true;
            this.Cart_CartItems_FlowLayout.BackColor = System.Drawing.Color.NavajoWhite;
            this.Cart_CartItems_FlowLayout.Controls.Add(this.Product);
            this.Cart_CartItems_FlowLayout.Controls.Add(this.label3);
            this.Cart_CartItems_FlowLayout.Controls.Add(this.label4);
            this.Cart_CartItems_FlowLayout.Location = new System.Drawing.Point(12, 113);
            this.Cart_CartItems_FlowLayout.Name = "Cart_CartItems_FlowLayout";
            this.Cart_CartItems_FlowLayout.Size = new System.Drawing.Size(726, 525);
            this.Cart_CartItems_FlowLayout.TabIndex = 96;
            // 
            // Product
            // 
            this.Product.AutoSize = true;
            this.Product.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Product.Location = new System.Drawing.Point(3, 0);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(143, 40);
            this.Product.TabIndex = 97;
            this.Product.Text = "Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(152, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 40);
            this.label3.TabIndex = 98;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(257, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 40);
            this.label4.TabIndex = 99;
            this.label4.Text = "Quantity";
            // 
            // CustCart_DeleteProd_button
            // 
            this.CustCart_DeleteProd_button.BackColor = System.Drawing.Color.LightCoral;
            this.CustCart_DeleteProd_button.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.CustCart_DeleteProd_button.Location = new System.Drawing.Point(1033, 545);
            this.CustCart_DeleteProd_button.Name = "CustCart_DeleteProd_button";
            this.CustCart_DeleteProd_button.Size = new System.Drawing.Size(10, 14);
            this.CustCart_DeleteProd_button.TabIndex = 97;
            this.CustCart_DeleteProd_button.Text = "Delete";
            this.CustCart_DeleteProd_button.UseVisualStyleBackColor = false;
            this.CustCart_DeleteProd_button.Click += new System.EventHandler(this.CustCart_DeleteProd_button_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(765, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 47);
            this.label2.TabIndex = 98;
            this.label2.Text = "Subtotal";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cart_CartItems_FlowLayout);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.Cart_TotalValue_Label);
            this.Controls.Add(this.Cart_CheckOut_Button);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Cart_Back_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustCart_DeleteProd_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustCart";
            this.Load += new System.EventHandler(this.CustCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.Cart_CartItems_FlowLayout.ResumeLayout(false);
            this.Cart_CartItems_FlowLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cart_Back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cart_CheckOut_Button;
        private System.Windows.Forms.Label Cart_TotalValue_Label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.FlowLayoutPanel Cart_CartItems_FlowLayout;
        private System.Windows.Forms.Label Product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CustCart_DeleteProd_button;
        private System.Windows.Forms.Label label2;
    }
}