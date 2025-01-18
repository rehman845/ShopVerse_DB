using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace DBProject
{
    public partial class LogisticsSignUp : Form
    {
        public LogisticsSignUp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");


        private void LogisticsSignUp_Back_Button_Click(object sender, EventArgs e)
        {
            LogisticsLogIn logisticsLogIn = new LogisticsLogIn();
            logisticsLogIn.Show();
            this.Hide();
        }

        private void LogisticsSignUp_SignUp_Button_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(LogisticsSignUp_FName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(LogisticsSignUp_LName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(LogisticsSignUp_Mail_txtfield.Text) ||
                string.IsNullOrWhiteSpace(LogisticsSignUp_Password_txtfield.Text) ||
                string.IsNullOrWhiteSpace(LogisticsSignUp_Company_txtfield.Text))


            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(LogisticsSignUp_Mail_txtfield.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            con.Open();

            string query1 = @"
INSERT INTO USERS (User_FName, User_LName, User_Mail, User_Password, Discriminator)
VALUES (@fname, @lname, @mail, @password, 'Logistics');
SELECT SCOPE_IDENTITY();";

            int userid = 0;

            using (SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                cmd1.Parameters.AddWithValue("@fname", LogisticsSignUp_FName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@lname", LogisticsSignUp_LName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@mail", LogisticsSignUp_Mail_txtfield.Text);
                cmd1.Parameters.AddWithValue("@password", LogisticsSignUp_Password_txtfield.Text);
                userid = Convert.ToInt32(cmd1.ExecuteScalar());
            }

            string query2 = @"
INSERT INTO LOGISTICS (UserID, Company_Name)
VALUES (@userid, @company);
SELECT SCOPE_IDENTITY();";

            int logisticsid = 0;

            using (SqlCommand cmd2 = new SqlCommand(query2, con))
            {
                cmd2.Parameters.AddWithValue("@userid", userid);
                cmd2.Parameters.AddWithValue("@company", LogisticsSignUp_Company_txtfield.Text);
                logisticsid = Convert.ToInt32(cmd2.ExecuteScalar());
            }

            MessageBox.Show("You have been signed up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }

        private void LogisticsSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
