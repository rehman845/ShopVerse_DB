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
    public partial class UserType : Form
    {
        public UserType()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");


        private void UserType_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UserType_Back_Button_Click(object sender, EventArgs e)
        {
            Welcome Welcome = new Welcome();
            Welcome.Show(); 
            this.Close();     
        }

        private void UserType_Seller_Button_Click(object sender, EventArgs e)
        {
            SellerLogIn sellerLogIn = new SellerLogIn();
            sellerLogIn.Show();
            this.Hide();
        }

        private void UserType_Customer_Button_Click(object sender, EventArgs e)
        {
            CustLogIn custLogIn = new CustLogIn();
            custLogIn.Show();
            this.Hide();
        }

        private void UserType_Admin_Button_Click(object sender, EventArgs e)
        {
            AdminLogIn adminLogIn = new AdminLogIn();
            adminLogIn.Show();
            this.Hide();
        }

        private void UserType_Logistics_Button_Click(object sender, EventArgs e)
        {
            LogisticsLogIn logisticsLogIn = new LogisticsLogIn();
            logisticsLogIn.Show();
            this.Hide();
        }
    }
}
