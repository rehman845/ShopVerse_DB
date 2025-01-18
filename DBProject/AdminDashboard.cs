using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.Data.SqlClient;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;




namespace DBProject
{
    public partial class AdminDashboard : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public AdminDashboard(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;


        }
        public string LoggedInEmail { get; set; }
        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            string userMail = LoggedInEmail;

            string query = @"SELECT
                u.User_FName
                
            FROM USERS u
            WHERE u.User_Mail = @UserMail";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserMail", userMail);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    AdminDashboard_Name_label.Text = reader["User_FName"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void SellerDashboard_Inventory_button_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_CustManage_button_Click(object sender, EventArgs e)
        {
            AdminCustManage adminCustManage = new AdminCustManage(LoggedInEmail);
            adminCustManage.Show();
            this.Hide();
        }

        private void AdminDashboard_SellerManage_button_Click(object sender, EventArgs e)
        {
            AdminSellerManage adminSellerManage = new AdminSellerManage(LoggedInEmail);
            adminSellerManage.Show();
            this.Hide();
        }

        private void AdminDashboard_OrderManage_button_Click(object sender, EventArgs e)
        {
            AdminOrdManage adminOrdManage = new AdminOrdManage(LoggedInEmail);
            adminOrdManage.Show();
            this.Hide();
        }

        private void AdminDashboard_LogisticManage_button_Click(object sender, EventArgs e)
        {
            AdminLogisticsManage adminLogisticsManage = new AdminLogisticsManage(LoggedInEmail);
            adminLogisticsManage.Show();
            this.Hide();
        }

        private void AdminDashboard_CategoryManage_button_Click(object sender, EventArgs e)
        {
            AdminCategoryManage adminCategoryManage = new AdminCategoryManage(LoggedInEmail);
            adminCategoryManage.Show();
            this.Hide();
        }

        private void AdminDashboard_SignOut_button_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Reports
        {
            AdminReports adminReports = new AdminReports(LoggedInEmail);
            adminReports.Show();
            this.Hide();
        }

        private void AdminDashboard_ProdManage_button_Click(object sender, EventArgs e)
        {
            AdminProdManage adminProdManage = new AdminProdManage(LoggedInEmail);
            adminProdManage.Show();
            this.Hide();
        }
    }
}
