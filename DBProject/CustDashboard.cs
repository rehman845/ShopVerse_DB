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
    public partial class CustDashboard : Form
    {
        public CustDashboard(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }



        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void CustDashboard_SignOut_button_Click(object sender, EventArgs e)
        {
            Welcome Welcome = new Welcome();
            Welcome.Show(); 
            this.Close();     
        }

        private void CustDashboard_Back_button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void CustDashboard_ReviewsPosted_button_Click(object sender, EventArgs e)
        {
            CustReviews custReviews = new CustReviews(LoggedInEmail);
            custReviews.Show();
            this.Hide();
        }

        private void CustDashboard_ViewCards_button_Click(object sender, EventArgs e)
        {
            CustViewCards custViewCards = new CustViewCards(LoggedInEmail);
            custViewCards.Show();
            this.Hide();
        }

        private void CustDashboard_OrdInfo_button_Click(object sender, EventArgs e)
        {
            CustMyOrders custMyOrders = new CustMyOrders(LoggedInEmail);
            custMyOrders.Show();
            this.Hide();
        }

        private void CustDashboard_UpdAcc_button_Click(object sender, EventArgs e)
        {
            CustUpdAcc custUpdAcc = new CustUpdAcc(LoggedInEmail);
            custUpdAcc.Show();
            this.Hide();
        }

        public string LoggedInEmail { get; set; }



        private void CustDashboard_AccInfo_button_Click(object sender, EventArgs e)
        {       
                

                CustAccInfo custAccInfo = new CustAccInfo(LoggedInEmail);
                custAccInfo.Show();
                this.Hide();
        }


           
        private void CustDashboard_UpdateCards_button_Click(object sender, EventArgs e)
        {

        }

        private void CustDashboard_RequestDeletion_button_Click(object sender, EventArgs e)
        {

        }

        private void CustDashboard_Wishlist_Button_Click(object sender, EventArgs e)
        {
            CustCart custCart = new CustCart(LoggedInEmail);
            custCart.Show();
            this.Hide();
        }

        private void CustDashboard_Load(object sender, EventArgs e)
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

                    CustDashboard_Name_label.Text = reader["User_FName"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CustDashboard_Name_label_Click(object sender, EventArgs e)
        {

            

        }
    }
}
