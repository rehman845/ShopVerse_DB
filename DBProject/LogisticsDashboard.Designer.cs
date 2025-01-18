namespace DBProject
{
    partial class LogisticsDashboard
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
            this.LogisticsDashboard_SignOut_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.LogisticsDashboard_Name_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LogisticsDashboard_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // LogisticsDashboard_SignOut_button
            // 
            this.LogisticsDashboard_SignOut_button.BackColor = System.Drawing.Color.Crimson;
            this.LogisticsDashboard_SignOut_button.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.LogisticsDashboard_SignOut_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LogisticsDashboard_SignOut_button.Location = new System.Drawing.Point(389, 581);
            this.LogisticsDashboard_SignOut_button.Name = "LogisticsDashboard_SignOut_button";
            this.LogisticsDashboard_SignOut_button.Size = new System.Drawing.Size(331, 54);
            this.LogisticsDashboard_SignOut_button.TabIndex = 82;
            this.LogisticsDashboard_SignOut_button.Text = "Sign Out";
            this.LogisticsDashboard_SignOut_button.UseVisualStyleBackColor = false;
            this.LogisticsDashboard_SignOut_button.Click += new System.EventHandler(this.LogisticsDashboard_SignOut_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(610, 74);
            this.label3.TabIndex = 80;
            this.label3.Text = "Logistics Dashboard";
            // 
            // LogisticsDashboard_Name_label
            // 
            this.LogisticsDashboard_Name_label.AutoSize = true;
            this.LogisticsDashboard_Name_label.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.LogisticsDashboard_Name_label.Location = new System.Drawing.Point(577, 9);
            this.LogisticsDashboard_Name_label.Name = "LogisticsDashboard_Name_label";
            this.LogisticsDashboard_Name_label.Size = new System.Drawing.Size(969, 80);
            this.LogisticsDashboard_Name_label.TabIndex = 79;
            this.LogisticsDashboard_Name_label.Text = "(Add Name extraction logic)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 80);
            this.label1.TabIndex = 78;
            this.label1.Text = "Welcome!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LogisticsDashboard_flow
            // 
            this.LogisticsDashboard_flow.AutoScroll = true;
            this.LogisticsDashboard_flow.BackColor = System.Drawing.Color.NavajoWhite;
            this.LogisticsDashboard_flow.Location = new System.Drawing.Point(12, 179);
            this.LogisticsDashboard_flow.Name = "LogisticsDashboard_flow";
            this.LogisticsDashboard_flow.Size = new System.Drawing.Size(1076, 385);
            this.LogisticsDashboard_flow.TabIndex = 83;
            // 
            // LogisticsDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.LogisticsDashboard_flow);
            this.Controls.Add(this.LogisticsDashboard_SignOut_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LogisticsDashboard_Name_label);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogisticsDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogisticsDashboard";
            this.Load += new System.EventHandler(this.LogisticsDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LogisticsDashboard_SignOut_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LogisticsDashboard_Name_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel LogisticsDashboard_flow;
    }
}