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
    public partial class AdminCustInfo : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public AdminCustInfo(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void AdminCustInfo_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminCustInfo_Load(object sender, EventArgs e)
        {


            string userMail = LoggedInEmail;


            string query = @"SELECT
                u.User_FName, 
                u.User_LName, 
                u.User_Mail, 
                c.Cust_Gender, 
                c.Cust_Phone, 
                c.Cust_DOB, 
                c.Cust_RegDate, 
                c.Cust_LoginTime, 
                cr.Card_Num, 
                cr.Bank_Name, 
                cr.CVV, 
                cr.Expiry_Date, 
                a.Plot, 
                a.Area, 
                a.City, 
                a.Province, 
                a.Country, 
                a.ZipCode
            FROM USERS u
            JOIN CUSTOMERS c ON u.UserID = c.UserID
            LEFT JOIN CARDS cr ON c.CustID = cr.CustID
            LEFT JOIN ADDRESS a ON c.CustID = a.CustID
            WHERE u.User_Mail = @UserMail";


            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserMail", userMail);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    CustAccInfo_FName_txtfield.Text = reader["User_FName"].ToString();
                    CustAccInfo_LName_txtfield.Text = reader["User_LName"].ToString();
                    CustAccInfo_Mail_txtfield.Text = reader["User_Mail"].ToString();

                    CustAccInfo_Contact_txtfield.Text = reader["Cust_Phone"].ToString();
                    CustAccInfo_DOB_Datefield.Text = reader["Cust_DOB"].ToString();
                    if (reader["Cust_Gender"].ToString().Equals("Male", StringComparison.OrdinalIgnoreCase))
                    {
                        CustAccInfo_Male_Radio.Checked = true;
                    }
                    else if (reader["Cust_Gender"].ToString().Equals("Female", StringComparison.OrdinalIgnoreCase))
                    {
                        CustAccInfo_Female_Radio.Checked = true;
                    }

                    CustAccInfo_CardNum_txtfield.Text = reader["Card_Num"].ToString();
                    CustAccInfo_Bank_txtfield.Text = reader["Bank_Name"].ToString();
                    CustAccInfo_CVV_txtfield.Text = reader["CVV"].ToString();
                    CustAccInfo_Expiry_Datefield.Text = reader["Expiry_Date"].ToString();
                    CustAccInfo_Plot_txtfield.Text = reader["Plot"].ToString();
                    CustAccInfo_Area_txtfield.Text = reader["Area"].ToString();
                    CustAccInfo_City_txtfield.Text = reader["City"].ToString();
                    CustAccInfo_Province_txtfield.Text = reader["Province"].ToString();
                    CustAccInfo_Country_txtfield.Text = reader["Country"].ToString();
                    CustAccInfo_ZipCode_txtfield.Text = reader["ZipCode"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
