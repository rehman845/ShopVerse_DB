namespace DBProject
{
    partial class ProductInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfo));
            this.ProductInfo_SearchBar_txtfield = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ProductInfo_ProdPic_image = new System.Windows.Forms.PictureBox();
            this.ProdInfo_ProdName_label = new System.Windows.Forms.Label();
            this.ProdInfo_Price_label = new System.Windows.Forms.Label();
            this.ProdInfo_ProdDesc_label = new System.Windows.Forms.Label();
            this.ProdInfo_AddToCart_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProdInfo_StoreName_labellink = new System.Windows.Forms.LinkLabel();
            this.ProdInfo_Back_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProdInfo_Review_flowpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.ProdInfo_WriteReview_Textbox = new System.Windows.Forms.TextBox();
            this.ProdInfo_PostReviewButton = new System.Windows.Forms.Button();
            this.ProdInfo_RatingComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductInfo_ProdPic_image)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductInfo_SearchBar_txtfield
            // 
            this.ProductInfo_SearchBar_txtfield.BackColor = System.Drawing.Color.Azure;
            this.ProductInfo_SearchBar_txtfield.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.ProductInfo_SearchBar_txtfield.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ProductInfo_SearchBar_txtfield.Location = new System.Drawing.Point(205, 12);
            this.ProductInfo_SearchBar_txtfield.Name = "ProductInfo_SearchBar_txtfield";
            this.ProductInfo_SearchBar_txtfield.Size = new System.Drawing.Size(448, 36);
            this.ProductInfo_SearchBar_txtfield.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(126, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // ProductInfo_ProdPic_image
            // 
            this.ProductInfo_ProdPic_image.BackColor = System.Drawing.Color.White;
            this.ProductInfo_ProdPic_image.Location = new System.Drawing.Point(22, 68);
            this.ProductInfo_ProdPic_image.Name = "ProductInfo_ProdPic_image";
            this.ProductInfo_ProdPic_image.Size = new System.Drawing.Size(631, 327);
            this.ProductInfo_ProdPic_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductInfo_ProdPic_image.TabIndex = 31;
            this.ProductInfo_ProdPic_image.TabStop = false;
            this.ProductInfo_ProdPic_image.Click += new System.EventHandler(this.ProductInfo_ProdPic_image_Click);
            // 
            // ProdInfo_ProdName_label
            // 
            this.ProdInfo_ProdName_label.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_ProdName_label.Location = new System.Drawing.Point(12, 398);
            this.ProdInfo_ProdName_label.Name = "ProdInfo_ProdName_label";
            this.ProdInfo_ProdName_label.Size = new System.Drawing.Size(522, 40);
            this.ProdInfo_ProdName_label.TabIndex = 32;
            this.ProdInfo_ProdName_label.Text = "Product Name(to be extracted)";
            // 
            // ProdInfo_Price_label
            // 
            this.ProdInfo_Price_label.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_Price_label.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.ProdInfo_Price_label.Location = new System.Drawing.Point(12, 452);
            this.ProdInfo_Price_label.Name = "ProdInfo_Price_label";
            this.ProdInfo_Price_label.Size = new System.Drawing.Size(517, 40);
            this.ProdInfo_Price_label.TabIndex = 33;
            this.ProdInfo_Price_label.Text = "Product Price(to be extracted)";
            // 
            // ProdInfo_ProdDesc_label
            // 
            this.ProdInfo_ProdDesc_label.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_ProdDesc_label.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.ProdInfo_ProdDesc_label.Location = new System.Drawing.Point(17, 555);
            this.ProdInfo_ProdDesc_label.Name = "ProdInfo_ProdDesc_label";
            this.ProdInfo_ProdDesc_label.Size = new System.Drawing.Size(636, 97);
            this.ProdInfo_ProdDesc_label.TabIndex = 34;
            this.ProdInfo_ProdDesc_label.Text = "Product Description(to be extracted)";
            // 
            // ProdInfo_AddToCart_Button
            // 
            this.ProdInfo_AddToCart_Button.BackColor = System.Drawing.Color.LightCoral;
            this.ProdInfo_AddToCart_Button.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.ProdInfo_AddToCart_Button.Location = new System.Drawing.Point(677, 6);
            this.ProdInfo_AddToCart_Button.Name = "ProdInfo_AddToCart_Button";
            this.ProdInfo_AddToCart_Button.Size = new System.Drawing.Size(392, 48);
            this.ProdInfo_AddToCart_Button.TabIndex = 35;
            this.ProdInfo_AddToCart_Button.Text = "Add to Cart";
            this.ProdInfo_AddToCart_Button.UseVisualStyleBackColor = false;
            this.ProdInfo_AddToCart_Button.Click += new System.EventHandler(this.ProdInfo_AddToCart_Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Khaki;
            this.groupBox1.Controls.Add(this.ProdInfo_StoreName_labellink);
            this.groupBox1.Location = new System.Drawing.Point(677, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 93);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // ProdInfo_StoreName_labellink
            // 
            this.ProdInfo_StoreName_labellink.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_StoreName_labellink.LinkColor = System.Drawing.Color.Black;
            this.ProdInfo_StoreName_labellink.Location = new System.Drawing.Point(6, 3);
            this.ProdInfo_StoreName_labellink.Name = "ProdInfo_StoreName_labellink";
            this.ProdInfo_StoreName_labellink.Size = new System.Drawing.Size(386, 90);
            this.ProdInfo_StoreName_labellink.TabIndex = 38;
            this.ProdInfo_StoreName_labellink.TabStop = true;
            this.ProdInfo_StoreName_labellink.Text = "Store name (extract)";
            this.ProdInfo_StoreName_labellink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProdInfo_Back_Button
            // 
            this.ProdInfo_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.ProdInfo_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_Back_Button.Location = new System.Drawing.Point(19, 6);
            this.ProdInfo_Back_Button.Name = "ProdInfo_Back_Button";
            this.ProdInfo_Back_Button.Size = new System.Drawing.Size(92, 48);
            this.ProdInfo_Back_Button.TabIndex = 39;
            this.ProdInfo_Back_Button.Text = "Back";
            this.ProdInfo_Back_Button.UseVisualStyleBackColor = false;
            this.ProdInfo_Back_Button.Click += new System.EventHandler(this.ProdInfo_Back_Button_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18.00001F, System.Drawing.FontStyle.Bold);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Location = new System.Drawing.Point(15, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(517, 40);
            this.label2.TabIndex = 40;
            this.label2.Text = "Product Description";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(670, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 40);
            this.label1.TabIndex = 39;
            this.label1.Text = "Reviews";
            // 
            // ProdInfo_Review_flowpanel
            // 
            this.ProdInfo_Review_flowpanel.AutoScroll = true;
            this.ProdInfo_Review_flowpanel.BackColor = System.Drawing.Color.MistyRose;
            this.ProdInfo_Review_flowpanel.Location = new System.Drawing.Point(677, 204);
            this.ProdInfo_Review_flowpanel.Name = "ProdInfo_Review_flowpanel";
            this.ProdInfo_Review_flowpanel.Size = new System.Drawing.Size(398, 162);
            this.ProdInfo_Review_flowpanel.TabIndex = 41;
            this.ProdInfo_Review_flowpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ProdInfo_Review_flowpanel_Paint);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label3.Location = new System.Drawing.Point(670, 381);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 40);
            this.label3.TabIndex = 42;
            this.label3.Text = "Write Review";
            // 
            // ProdInfo_WriteReview_Textbox
            // 
            this.ProdInfo_WriteReview_Textbox.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_WriteReview_Textbox.Location = new System.Drawing.Point(677, 435);
            this.ProdInfo_WriteReview_Textbox.Name = "ProdInfo_WriteReview_Textbox";
            this.ProdInfo_WriteReview_Textbox.Size = new System.Drawing.Size(398, 48);
            this.ProdInfo_WriteReview_Textbox.TabIndex = 43;
            this.ProdInfo_WriteReview_Textbox.TextChanged += new System.EventHandler(this.ProdInfo_WriteReview_Textbox_TextChanged);
            // 
            // ProdInfo_PostReviewButton
            // 
            this.ProdInfo_PostReviewButton.BackColor = System.Drawing.Color.LightCoral;
            this.ProdInfo_PostReviewButton.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.ProdInfo_PostReviewButton.Location = new System.Drawing.Point(677, 590);
            this.ProdInfo_PostReviewButton.Name = "ProdInfo_PostReviewButton";
            this.ProdInfo_PostReviewButton.Size = new System.Drawing.Size(398, 48);
            this.ProdInfo_PostReviewButton.TabIndex = 44;
            this.ProdInfo_PostReviewButton.Text = "Post Review";
            this.ProdInfo_PostReviewButton.UseVisualStyleBackColor = false;
            this.ProdInfo_PostReviewButton.Click += new System.EventHandler(this.ProdInfo_PostReviewButton_Click);
            // 
            // ProdInfo_RatingComboBox
            // 
            this.ProdInfo_RatingComboBox.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProdInfo_RatingComboBox.FormattingEnabled = true;
            this.ProdInfo_RatingComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ProdInfo_RatingComboBox.Location = new System.Drawing.Point(677, 533);
            this.ProdInfo_RatingComboBox.Name = "ProdInfo_RatingComboBox";
            this.ProdInfo_RatingComboBox.Size = new System.Drawing.Size(398, 41);
            this.ProdInfo_RatingComboBox.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.Location = new System.Drawing.Point(670, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 40);
            this.label4.TabIndex = 46;
            this.label4.Text = "Rating";
            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProdInfo_RatingComboBox);
            this.Controls.Add(this.ProdInfo_PostReviewButton);
            this.Controls.Add(this.ProdInfo_WriteReview_Textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProdInfo_Review_flowpanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProdInfo_Back_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ProdInfo_AddToCart_Button);
            this.Controls.Add(this.ProdInfo_ProdDesc_label);
            this.Controls.Add(this.ProdInfo_Price_label);
            this.Controls.Add(this.ProdInfo_ProdName_label);
            this.Controls.Add(this.ProductInfo_ProdPic_image);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ProductInfo_SearchBar_txtfield);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductInfo";
            this.Load += new System.EventHandler(this.ProductInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductInfo_ProdPic_image)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProductInfo_SearchBar_txtfield;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox ProductInfo_ProdPic_image;
        private System.Windows.Forms.Label ProdInfo_ProdName_label;
        private System.Windows.Forms.Label ProdInfo_Price_label;
        private System.Windows.Forms.Label ProdInfo_ProdDesc_label;
        private System.Windows.Forms.Button ProdInfo_AddToCart_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel ProdInfo_StoreName_labellink;
        private System.Windows.Forms.Button ProdInfo_Back_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel ProdInfo_Review_flowpanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProdInfo_WriteReview_Textbox;
        private System.Windows.Forms.Button ProdInfo_PostReviewButton;
        private System.Windows.Forms.ComboBox ProdInfo_RatingComboBox;
        private System.Windows.Forms.Label label4;
    }
}