namespace DBProject
{
    partial class CustCheckout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustCheckout));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Checkout_Back_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Checkout_PlaceOrder_Button = new System.Windows.Forms.Button();
            this.Checkout_Total_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Checkout_PayViaCOD_Button = new System.Windows.Forms.Button();
            this.Checkout_PayViaCard_Button = new System.Windows.Forms.Button();
            this.Checkout_Items_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.Checkout_PaymentMethod_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.Checkout_Address_flow = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(350, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 80);
            this.label1.TabIndex = 52;
            this.label1.Text = "Check Out";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(962, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(126, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 96;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // Checkout_Back_Button
            // 
            this.Checkout_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Checkout_Back_Button.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold);
            this.Checkout_Back_Button.Location = new System.Drawing.Point(12, 12);
            this.Checkout_Back_Button.Name = "Checkout_Back_Button";
            this.Checkout_Back_Button.Size = new System.Drawing.Size(107, 63);
            this.Checkout_Back_Button.TabIndex = 97;
            this.Checkout_Back_Button.Text = "Back";
            this.Checkout_Back_Button.UseVisualStyleBackColor = false;
            this.Checkout_Back_Button.Click += new System.EventHandler(this.Checkout_Back_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 40);
            this.label2.TabIndex = 100;
            this.label2.Text = "Order Summary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(437, 40);
            this.label4.TabIndex = 103;
            this.label4.Text = "Choose Payment Method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 587);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(598, 40);
            this.label5.TabIndex = 104;
            this.label5.Text = "Order Shall Be Delivered in 7-10 Days";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 15.8F);
            this.label6.Location = new System.Drawing.Point(744, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(327, 33);
            this.label6.TabIndex = 105;
            this.label6.Text = "Delivery Fee (Standard)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(744, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 34);
            this.label7.TabIndex = 106;
            this.label7.Text = "Rs 150";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 20.2F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(742, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 40);
            this.label8.TabIndex = 107;
            this.label8.Text = "Grand Total";
            // 
            // Checkout_PlaceOrder_Button
            // 
            this.Checkout_PlaceOrder_Button.BackColor = System.Drawing.Color.LightCoral;
            this.Checkout_PlaceOrder_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.Checkout_PlaceOrder_Button.Location = new System.Drawing.Point(762, 531);
            this.Checkout_PlaceOrder_Button.Name = "Checkout_PlaceOrder_Button";
            this.Checkout_PlaceOrder_Button.Size = new System.Drawing.Size(298, 107);
            this.Checkout_PlaceOrder_Button.TabIndex = 108;
            this.Checkout_PlaceOrder_Button.Text = "Place Order";
            this.Checkout_PlaceOrder_Button.UseVisualStyleBackColor = false;
            this.Checkout_PlaceOrder_Button.Click += new System.EventHandler(this.Checkout_PlaceOrder_Button_Click);
            // 
            // Checkout_Total_label
            // 
            this.Checkout_Total_label.AutoSize = true;
            this.Checkout_Total_label.Font = new System.Drawing.Font("Century Gothic", 20.2F, System.Drawing.FontStyle.Bold);
            this.Checkout_Total_label.Location = new System.Drawing.Point(946, 216);
            this.Checkout_Total_label.Name = "Checkout_Total_label";
            this.Checkout_Total_label.Size = new System.Drawing.Size(95, 40);
            this.Checkout_Total_label.TabIndex = 109;
            this.Checkout_Total_label.Text = "(TBE)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 40);
            this.label3.TabIndex = 101;
            this.label3.Text = "Address";
            // 
            // Checkout_PayViaCOD_Button
            // 
            this.Checkout_PayViaCOD_Button.BackColor = System.Drawing.Color.Peru;
            this.Checkout_PayViaCOD_Button.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Checkout_PayViaCOD_Button.Location = new System.Drawing.Point(775, 407);
            this.Checkout_PayViaCOD_Button.Name = "Checkout_PayViaCOD_Button";
            this.Checkout_PayViaCOD_Button.Size = new System.Drawing.Size(275, 92);
            this.Checkout_PayViaCOD_Button.TabIndex = 110;
            this.Checkout_PayViaCOD_Button.Text = "Choose COD";
            this.Checkout_PayViaCOD_Button.UseVisualStyleBackColor = false;
            this.Checkout_PayViaCOD_Button.Click += new System.EventHandler(this.Checkout_PayViaCOD_Button_Click);
            // 
            // Checkout_PayViaCard_Button
            // 
            this.Checkout_PayViaCard_Button.BackColor = System.Drawing.Color.Peru;
            this.Checkout_PayViaCard_Button.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold);
            this.Checkout_PayViaCard_Button.Location = new System.Drawing.Point(775, 291);
            this.Checkout_PayViaCard_Button.Name = "Checkout_PayViaCard_Button";
            this.Checkout_PayViaCard_Button.Size = new System.Drawing.Size(275, 92);
            this.Checkout_PayViaCard_Button.TabIndex = 111;
            this.Checkout_PayViaCard_Button.Text = "Pay Via Card";
            this.Checkout_PayViaCard_Button.UseVisualStyleBackColor = false;
            this.Checkout_PayViaCard_Button.Click += new System.EventHandler(this.Checkout_PayViaCard_Button_Click);
            // 
            // Checkout_Items_flow
            // 
            this.Checkout_Items_flow.AutoScroll = true;
            this.Checkout_Items_flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.Checkout_Items_flow.Location = new System.Drawing.Point(19, 137);
            this.Checkout_Items_flow.Name = "Checkout_Items_flow";
            this.Checkout_Items_flow.Size = new System.Drawing.Size(717, 128);
            this.Checkout_Items_flow.TabIndex = 112;
            // 
            // Checkout_PaymentMethod_flow
            // 
            this.Checkout_PaymentMethod_flow.AutoScroll = true;
            this.Checkout_PaymentMethod_flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.Checkout_PaymentMethod_flow.Location = new System.Drawing.Point(19, 473);
            this.Checkout_PaymentMethod_flow.Name = "Checkout_PaymentMethod_flow";
            this.Checkout_PaymentMethod_flow.Size = new System.Drawing.Size(717, 100);
            this.Checkout_PaymentMethod_flow.TabIndex = 113;
            // 
            // Checkout_Address_flow
            // 
            this.Checkout_Address_flow.AutoScroll = true;
            this.Checkout_Address_flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.Checkout_Address_flow.Location = new System.Drawing.Point(19, 327);
            this.Checkout_Address_flow.Name = "Checkout_Address_flow";
            this.Checkout_Address_flow.Size = new System.Drawing.Size(717, 100);
            this.Checkout_Address_flow.TabIndex = 113;
            // 
            // CustCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.Checkout_PaymentMethod_flow);
            this.Controls.Add(this.Checkout_Address_flow);
            this.Controls.Add(this.Checkout_Items_flow);
            this.Controls.Add(this.Checkout_PayViaCard_Button);
            this.Controls.Add(this.Checkout_PayViaCOD_Button);
            this.Controls.Add(this.Checkout_Total_label);
            this.Controls.Add(this.Checkout_PlaceOrder_Button);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Checkout_Back_Button);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustCheckout";
            this.Load += new System.EventHandler(this.CustCheckout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Checkout_Back_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Checkout_PlaceOrder_Button;
        private System.Windows.Forms.Label Checkout_Total_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Checkout_PayViaCOD_Button;
        private System.Windows.Forms.Button Checkout_PayViaCard_Button;
        private System.Windows.Forms.FlowLayoutPanel Checkout_Items_flow;
        private System.Windows.Forms.FlowLayoutPanel Checkout_PaymentMethod_flow;
        private System.Windows.Forms.FlowLayoutPanel Checkout_Address_flow;
    }
}