namespace DBProject
{
    partial class OrderPlaced
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPlaced));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.OrderPlace_TrackOrder_button = new System.Windows.Forms.Button();
            this.OrderPlace_ContShop_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(972, 80);
            this.label1.TabIndex = 53;
            this.label1.Text = "Your Order Has Been Placed!";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(346, 92);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(421, 358);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 97;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // OrderPlace_TrackOrder_button
            // 
            this.OrderPlace_TrackOrder_button.BackColor = System.Drawing.Color.ForestGreen;
            this.OrderPlace_TrackOrder_button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.OrderPlace_TrackOrder_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OrderPlace_TrackOrder_button.Location = new System.Drawing.Point(302, 456);
            this.OrderPlace_TrackOrder_button.Name = "OrderPlace_TrackOrder_button";
            this.OrderPlace_TrackOrder_button.Size = new System.Drawing.Size(504, 83);
            this.OrderPlace_TrackOrder_button.TabIndex = 98;
            this.OrderPlace_TrackOrder_button.Text = "Track Order";
            this.OrderPlace_TrackOrder_button.UseVisualStyleBackColor = false;
            this.OrderPlace_TrackOrder_button.Click += new System.EventHandler(this.OrderPlace_TrackOrder_button_Click);
            // 
            // OrderPlace_ContShop_button
            // 
            this.OrderPlace_ContShop_button.BackColor = System.Drawing.Color.ForestGreen;
            this.OrderPlace_ContShop_button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.OrderPlace_ContShop_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OrderPlace_ContShop_button.Location = new System.Drawing.Point(302, 555);
            this.OrderPlace_ContShop_button.Name = "OrderPlace_ContShop_button";
            this.OrderPlace_ContShop_button.Size = new System.Drawing.Size(504, 83);
            this.OrderPlace_ContShop_button.TabIndex = 99;
            this.OrderPlace_ContShop_button.Text = "Continue Shopping";
            this.OrderPlace_ContShop_button.UseVisualStyleBackColor = false;
            this.OrderPlace_ContShop_button.Click += new System.EventHandler(this.OrderPlace_ContShop_button_Click);
            // 
            // OrderPlaced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.OrderPlace_ContShop_button);
            this.Controls.Add(this.OrderPlace_TrackOrder_button);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderPlaced";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderPlaced";
            this.Load += new System.EventHandler(this.OrderPlaced_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button OrderPlace_TrackOrder_button;
        private System.Windows.Forms.Button OrderPlace_ContShop_button;
    }
}