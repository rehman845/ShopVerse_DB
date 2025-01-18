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
    public partial class AdminLogIn : Form
    {
        public AdminLogIn()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");


        private void AdminLogIn_Load(object sender, EventArgs e)
        {

        }

        private void AdminLogIn_Back_Button_Click(object sender, EventArgs e)
        {
            UserType UserType = new UserType();
            UserType.Show();
            this.Hide();
        }

        private void AdminLogIn_NewUser_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminSignUp adminSignUp = new AdminSignUp();
            adminSignUp.Show();
            this.Hide();
        }

        public string LoggedInEmail { get; set; }


        private void AdminlogIn_Login_Button_Click(object sender, EventArgs e)
        {
            LoggedInEmail = AdminLogIn_Mail_txtfield.Text;

            if (string.IsNullOrWhiteSpace(AdminLogIn_Mail_txtfield.Text) ||
                string.IsNullOrWhiteSpace(AdminLogIn_Password_txtfield.Text))
            {
                MessageBox.Show("Please enter both Email and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(AdminLogIn_Mail_txtfield.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                con.Open();

                string query = @"
            SELECT COUNT(*)
            FROM USERS
            WHERE User_Mail = @mail AND User_Password = @password AND Discriminator = 'Admin'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@mail", AdminLogIn_Mail_txtfield.Text);
                    cmd.Parameters.AddWithValue("@password", AdminLogIn_Password_txtfield.Text);

                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {

                        AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
                        adminDashboard.Show();
                        this.Hide();
                    }
                    else
                    {

                        MessageBox.Show("Invalid Email or Password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
