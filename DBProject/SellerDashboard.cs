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
    public partial class SellerDashboard : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerDashboard(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }

        private void SellerDashboard_Load(object sender, EventArgs e)
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

                    SellerDashboard_Name_label.Text = reader["User_FName"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SellerDashboard_SignOut_button_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void SellerDashboard_UpdAcc_button_Click(object sender, EventArgs e)
        {
            SellerUpdAcc sellerUpdAcc = new SellerUpdAcc(LoggedInEmail);
            sellerUpdAcc.Show();
            this.Hide();
        }

        private void SellerDashboard_ProductAddRem_button_Click(object sender, EventArgs e)
        {
            SellerProdEdit sellerProdEdit = new SellerProdEdit(LoggedInEmail);
            sellerProdEdit.Show();
            this.Hide();
        }

        private void SellerDashboard_Back_button_Click(object sender, EventArgs e)
        {

        }

        private void SellerDashboard_Inventory_button_Click(object sender, EventArgs e)
        {
            SellerInventory sellerInventory = new SellerInventory(LoggedInEmail);
            sellerInventory.Show();
            this.Hide();
        }

        private void SellerDashboard_OrdManagement_button_Click(object sender, EventArgs e)
        {

            SellerOrdManage sellerOrdManage = new SellerOrdManage(LoggedInEmail);
            sellerOrdManage.Show();
            this.Hide();
        }

        private void SellerDashboard_SalesReport_button_Click(object sender, EventArgs e)
        {
            SellerReports sellerReports = new SellerReports(LoggedInEmail);
            sellerReports.Show();
            this.Hide();
        }

        private void SellerDashboard_StoreSettings_button_Click(object sender, EventArgs e)
        {
            SellerUpdAcc sellerUpdAcc = new SellerUpdAcc(LoggedInEmail);
            sellerUpdAcc.Show();
            this.Hide();
        }

        private void SellerDashboard_Name_label_Click(object sender, EventArgs e)
        {

        }
    }
}
