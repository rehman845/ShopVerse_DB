namespace DBProject
{
    partial class CustViewCards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustViewCards));
            this.CustAccInfo_AddCard_Button = new System.Windows.Forms.Button();
            this.CustAccInfo_Info_Datagrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.CustAccInfo_Back_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CustAccInfo_RemoveCard_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustAccInfo_Info_Datagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // CustAccInfo_AddCard_Button
            // 
            this.CustAccInfo_AddCard_Button.BackColor = System.Drawing.Color.LightCoral;
            this.CustAccInfo_AddCard_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.CustAccInfo_AddCard_Button.Location = new System.Drawing.Point(858, 407);
            this.CustAccInfo_AddCard_Button.Name = "CustAccInfo_AddCard_Button";
            this.CustAccInfo_AddCard_Button.Size = new System.Drawing.Size(227, 109);
            this.CustAccInfo_AddCard_Button.TabIndex = 139;
            this.CustAccInfo_AddCard_Button.Text = "Add Card";
            this.CustAccInfo_AddCard_Button.UseVisualStyleBackColor = false;
            // 
            // CustAccInfo_Info_Datagrid
            // 
            this.CustAccInfo_Info_Datagrid.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.CustAccInfo_Info_Datagrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustAccInfo_Info_Datagrid.ColumnHeadersHeight = 30;
            this.CustAccInfo_Info_Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CustAccInfo_Info_Datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.CustAccInfo_Info_Datagrid.Location = new System.Drawing.Point(15, 153);
            this.CustAccInfo_Info_Datagrid.Name = "CustAccInfo_Info_Datagrid";
            this.CustAccInfo_Info_Datagrid.RowHeadersWidth = 51;
            this.CustAccInfo_Info_Datagrid.RowTemplate.Height = 24;
            this.CustAccInfo_Info_Datagrid.Size = new System.Drawing.Size(820, 473);
            this.CustAccInfo_Info_Datagrid.TabIndex = 137;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Card Number";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Bank";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CVV";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Expiry Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(950, 24);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(130, 86);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 136;
            this.pictureBox5.TabStop = false;
            // 
            // CustAccInfo_Back_Button
            // 
            this.CustAccInfo_Back_Button.BackColor = System.Drawing.Color.LightCoral;
            this.CustAccInfo_Back_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustAccInfo_Back_Button.Location = new System.Drawing.Point(15, 41);
            this.CustAccInfo_Back_Button.Name = "CustAccInfo_Back_Button";
            this.CustAccInfo_Back_Button.Size = new System.Drawing.Size(122, 57);
            this.CustAccInfo_Back_Button.TabIndex = 135;
            this.CustAccInfo_Back_Button.Text = "Back";
            this.CustAccInfo_Back_Button.UseVisualStyleBackColor = false;
            this.CustAccInfo_Back_Button.Click += new System.EventHandler(this.CustAccInfo_Back_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(285, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 80);
            this.label1.TabIndex = 134;
            this.label1.Text = "My Bank Cards";
            // 
            // CustAccInfo_RemoveCard_Button
            // 
            this.CustAccInfo_RemoveCard_Button.BackColor = System.Drawing.Color.LightCoral;
            this.CustAccInfo_RemoveCard_Button.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.CustAccInfo_RemoveCard_Button.Location = new System.Drawing.Point(858, 249);
            this.CustAccInfo_RemoveCard_Button.Name = "CustAccInfo_RemoveCard_Button";
            this.CustAccInfo_RemoveCard_Button.Size = new System.Drawing.Size(227, 109);
            this.CustAccInfo_RemoveCard_Button.TabIndex = 138;
            this.CustAccInfo_RemoveCard_Button.Text = "Remove Card";
            this.CustAccInfo_RemoveCard_Button.UseVisualStyleBackColor = false;
            // 
            // CustViewCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.CustAccInfo_AddCard_Button);
            this.Controls.Add(this.CustAccInfo_Info_Datagrid);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.CustAccInfo_Back_Button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CustAccInfo_RemoveCard_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustViewCards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustViewCards";
            this.Load += new System.EventHandler(this.CustViewCards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustAccInfo_Info_Datagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CustAccInfo_AddCard_Button;
        private System.Windows.Forms.DataGridView CustAccInfo_Info_Datagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button CustAccInfo_Back_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CustAccInfo_RemoveCard_Button;
    }
}