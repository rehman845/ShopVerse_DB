﻿namespace DBProject
{
    partial class CustLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustLogIn));
            this.CustLogIn_Back_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustlogIn_Login_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CustLogIn_Password_txtfield = new System.Windows.Forms.TextBox();
            this.CustLogIn_Mail_txtfield = new System.Windows.Forms.TextBox();
            this.CustLogIn_NewUser_LinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustLogIn_Back_Button
            // 
            this.CustLogIn_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.CustLogIn_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustLogIn_Back_Button.Location = new System.Drawing.Point(20, 32);
            this.CustLogIn_Back_Button.Name = "CustLogIn_Back_Button";
            this.CustLogIn_Back_Button.Size = new System.Drawing.Size(92, 48);
            this.CustLogIn_Back_Button.TabIndex = 21;
            this.CustLogIn_Back_Button.Text = "Back";
            this.CustLogIn_Back_Button.UseVisualStyleBackColor = false;
            this.CustLogIn_Back_Button.Click += new System.EventHandler(this.CustLogIn_Back_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(691, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(339, 306);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(254, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(536, 80);
            this.label1.TabIndex = 14;
            this.label1.Text = "Customer Login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.NavajoWhite;
            this.groupBox1.Controls.Add(this.CustlogIn_Login_Button);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CustLogIn_Password_txtfield);
            this.groupBox1.Controls.Add(this.CustLogIn_Mail_txtfield);
            this.groupBox1.Location = new System.Drawing.Point(51, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(598, 378);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // CustlogIn_Login_Button
            // 
            this.CustlogIn_Login_Button.BackColor = System.Drawing.Color.LightCoral;
            this.CustlogIn_Login_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustlogIn_Login_Button.Location = new System.Drawing.Point(247, 315);
            this.CustlogIn_Login_Button.Name = "CustlogIn_Login_Button";
            this.CustlogIn_Login_Button.Size = new System.Drawing.Size(92, 48);
            this.CustlogIn_Login_Button.TabIndex = 23;
            this.CustlogIn_Login_Button.Text = "Login";
            this.CustlogIn_Login_Button.UseVisualStyleBackColor = false;
            this.CustlogIn_Login_Button.Click += new System.EventHandler(this.CustlogIn_Login_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 49);
            this.label3.TabIndex = 25;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 49);
            this.label2.TabIndex = 23;
            this.label2.Text = "E-Mail";
            // 
            // CustLogIn_Password_txtfield
            // 
            this.CustLogIn_Password_txtfield.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustLogIn_Password_txtfield.Location = new System.Drawing.Point(44, 240);
            this.CustLogIn_Password_txtfield.Name = "CustLogIn_Password_txtfield";
            this.CustLogIn_Password_txtfield.Size = new System.Drawing.Size(492, 48);
            this.CustLogIn_Password_txtfield.TabIndex = 24;
            // 
            // CustLogIn_Mail_txtfield
            // 
            this.CustLogIn_Mail_txtfield.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustLogIn_Mail_txtfield.Location = new System.Drawing.Point(42, 101);
            this.CustLogIn_Mail_txtfield.Name = "CustLogIn_Mail_txtfield";
            this.CustLogIn_Mail_txtfield.Size = new System.Drawing.Size(494, 48);
            this.CustLogIn_Mail_txtfield.TabIndex = 23;
            this.CustLogIn_Mail_txtfield.TextChanged += new System.EventHandler(this.CustLogIn_Mail_txtfield_TextChanged);
            // 
            // CustLogIn_NewUser_LinkLabel
            // 
            this.CustLogIn_NewUser_LinkLabel.AutoSize = true;
            this.CustLogIn_NewUser_LinkLabel.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.CustLogIn_NewUser_LinkLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 10);
            this.CustLogIn_NewUser_LinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.CustLogIn_NewUser_LinkLabel.Location = new System.Drawing.Point(502, 602);
            this.CustLogIn_NewUser_LinkLabel.Name = "CustLogIn_NewUser_LinkLabel";
            this.CustLogIn_NewUser_LinkLabel.Size = new System.Drawing.Size(93, 26);
            this.CustLogIn_NewUser_LinkLabel.TabIndex = 23;
            this.CustLogIn_NewUser_LinkLabel.TabStop = true;
            this.CustLogIn_NewUser_LinkLabel.Text = "New User?";
            this.CustLogIn_NewUser_LinkLabel.UseCompatibleTextRendering = true;
            this.CustLogIn_NewUser_LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CustLogIn_NewUser_LinkLabel_LinkClicked);
            // 
            // CustLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.CustLogIn_NewUser_LinkLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CustLogIn_Back_Button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustLogIn";
            this.Load += new System.EventHandler(this.CustLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CustLogIn_Back_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CustLogIn_Password_txtfield;
        private System.Windows.Forms.TextBox CustLogIn_Mail_txtfield;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CustlogIn_Login_Button;
        private System.Windows.Forms.LinkLabel CustLogIn_NewUser_LinkLabel;
    }
}