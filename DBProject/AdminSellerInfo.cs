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
    public partial class AdminSellerInfo : Form
    {
        public AdminSellerInfo(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }

        public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

        private void AdminSellerInfo_Load(object sender, EventArgs e)
        {
            string userMail = LoggedInEmail;

            string query = @"
SELECT 
    u.User_FName, 
    u.User_LName, 
    u.User_Mail, 
    s.Seller_StoreName, 
    s.Seller_VerStatus, 
    s.Seller_IBAN,
    a.Plot, 
    a.Area, 
    a.City, 
    a.Province, 
    a.Country, 
    a.ZipCode
FROM USERS u
JOIN SELLER s ON u.UserID = s.UserID
LEFT JOIN ADDRESS a ON s.SellerID = a.SellerID
WHERE u.User_Mail = @UserMail";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserMail", userMail);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    SellerSignUp_FName_txtfield.Text = reader["User_FName"].ToString();
                    SellerSignUp_LName_txtfield.Text = reader["User_LName"].ToString();
                    SellerSignUp_Mail_txtfield.Text = reader["User_Mail"].ToString();

                    SellerSignUp_Store_txtfield.Text = reader["Seller_StoreName"].ToString();
                  
                    SellerSignUp_IBAN_txtfield.Text = reader["Seller_IBAN"].ToString();
                    
                    SellerSignUp_Plot_txtfield.Text = reader["Plot"].ToString();
                    SellerSignUp_Area_txtfield.Text = reader["Area"].ToString();
                    SellerSignUp_City_txtfield.Text = reader["City"].ToString();
                    SellerSignUp_Province_txtfield.Text = reader["Province"].ToString();
                    SellerSignUp_Country_txtfield.Text = reader["Country"].ToString();
                    SellerSignUp_ZipCode_txtfield.Text = reader["ZipCode"].ToString();
                }
                else
                {
                    MessageBox.Show("Seller information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void SellerSignUp_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();

        }
    }
}
