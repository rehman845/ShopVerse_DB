namespace DBProject
{
    partial class CatProds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatProds));
            this.CatProd_FlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.CatProd_Back_button = new System.Windows.Forms.Button();
            this.CatProd_CatNameTop_label = new System.Windows.Forms.Label();
            this.CustCart_DeleteProd_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // CatProd_FlowLayout
            // 
            this.CatProd_FlowLayout.AutoScroll = true;
            this.CatProd_FlowLayout.BackColor = System.Drawing.Color.NavajoWhite;
            this.CatProd_FlowLayout.Location = new System.Drawing.Point(18, 115);
            this.CatProd_FlowLayout.Name = "CatProd_FlowLayout";
            this.CatProd_FlowLayout.Size = new System.Drawing.Size(1065, 525);
            this.CatProd_FlowLayout.TabIndex = 105;
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
            this.pictureBox5.TabIndex = 104;
            this.pictureBox5.TabStop = false;
            // 
            // CatProd_Back_button
            // 
            this.CatProd_Back_button.BackColor = System.Drawing.Color.LightCoral;
            this.CatProd_Back_button.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.CatProd_Back_button.Location = new System.Drawing.Point(18, 28);
            this.CatProd_Back_button.Name = "CatProd_Back_button";
            this.CatProd_Back_button.Size = new System.Drawing.Size(107, 63);
            this.CatProd_Back_button.TabIndex = 100;
            this.CatProd_Back_button.Text = "Back";
            this.CatProd_Back_button.UseVisualStyleBackColor = false;
            this.CatProd_Back_button.Click += new System.EventHandler(this.CatProd_Back_button_Click);
            // 
            // CatProd_CatNameTop_label
            // 
            this.CatProd_CatNameTop_label.AutoSize = true;
            this.CatProd_CatNameTop_label.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.CatProd_CatNameTop_label.Location = new System.Drawing.Point(297, 11);
            this.CatProd_CatNameTop_label.Name = "CatProd_CatNameTop_label";
            this.CatProd_CatNameTop_label.Size = new System.Drawing.Size(471, 80);
            this.CatProd_CatNameTop_label.TabIndex = 99;
            this.CatProd_CatNameTop_label.Text = "CatName TBE";
            // 
            // CustCart_DeleteProd_button
            // 
            this.CustCart_DeleteProd_button.BackColor = System.Drawing.Color.LightCoral;
            this.CustCart_DeleteProd_button.Font = new System.Drawing.Font("Century Gothic", 22F, System.Drawing.FontStyle.Bold);
            this.CustCart_DeleteProd_button.Location = new System.Drawing.Point(1039, 547);
            this.CustCart_DeleteProd_button.Name = "CustCart_DeleteProd_button";
            this.CustCart_DeleteProd_button.Size = new System.Drawing.Size(10, 14);
            this.CustCart_DeleteProd_button.TabIndex = 106;
            this.CustCart_DeleteProd_button.Text = "Delete";
            this.CustCart_DeleteProd_button.UseVisualStyleBackColor = false;
            // 
            // CatProds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.CatProd_FlowLayout);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.CatProd_Back_button);
            this.Controls.Add(this.CatProd_CatNameTop_label);
            this.Controls.Add(this.CustCart_DeleteProd_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CatProds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CatProds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel CatProd_FlowLayout;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button CatProd_Back_button;
        private System.Windows.Forms.Label CatProd_CatNameTop_label;
        private System.Windows.Forms.Button CustCart_DeleteProd_button;
    }
}