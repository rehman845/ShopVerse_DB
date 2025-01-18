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
    public partial class SellerUpdAcc : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerUpdAcc(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }

        private void SellerUpdAcc_Back_Button_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void SellerUpdAcc_Load(object sender, EventArgs e)
        {
            
        }

        private void SellerUpdAcc_Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string getUserIDQuery = "SELECT UserID FROM USERS WHERE User_Mail = @Email";
                SqlCommand cmd1 = new SqlCommand(getUserIDQuery, con);
                cmd1.Parameters.AddWithValue("@Email", LoggedInEmail);
                object userIDResult = cmd1.ExecuteScalar();

                if (userIDResult == null)
                {
                    MessageBox.Show("No user found for the logged-in email.");
                    return;
                }

                int userID = (int)userIDResult;

                string getSellerIDQuery = "SELECT SellerID FROM SELLER WHERE UserID = @UserID";
                SqlCommand cmd2 = new SqlCommand(getSellerIDQuery, con);
                cmd2.Parameters.AddWithValue("@UserID", userID);
                object sellerIDResult = cmd2.ExecuteScalar();

                if (sellerIDResult == null)
                {
                    MessageBox.Show("No seller profile found for this user.");
                    return;
                }

                int sellerID = (int)sellerIDResult;

                string updateUserQuery = @"
                    UPDATE USERS 
                    SET User_FName = @FName, User_LName = @LName, User_Password = @Password
                    WHERE UserID = @UserID";

                SqlCommand updateUserCmd = new SqlCommand(updateUserQuery, con);
                updateUserCmd.Parameters.AddWithValue("@FName", SellerUpdAcc_FName_txtfield.Text);
                updateUserCmd.Parameters.AddWithValue("@LName", SellerUpdAcc_LName_txtfield.Text);
                updateUserCmd.Parameters.AddWithValue("@Password", SellerUpdAcc_Password_txtfield.Text);
                updateUserCmd.Parameters.AddWithValue("@UserID", userID);
                updateUserCmd.ExecuteNonQuery();

                string updateSellerQuery = @"
                    UPDATE SELLER 
                    SET Seller_StoreName = @StoreName, Seller_IBAN = @IBAN
                    WHERE SellerID = @SellerID";

                SqlCommand updateSellerCmd = new SqlCommand(updateSellerQuery, con);
                updateSellerCmd.Parameters.AddWithValue("@StoreName", SellerUpdAcc_StoreName_txtfield.Text);
                updateSellerCmd.Parameters.AddWithValue("@IBAN", SellerUpdAcc_IBAN_txtfield.Text);
                updateSellerCmd.Parameters.AddWithValue("@SellerID", sellerID);
                updateSellerCmd.ExecuteNonQuery();

                string updateAddressQuery = @"
                    UPDATE ADDRESS 
                    SET Plot = @Plot, Area = @Area, City = @City, Province = @Province, Country = @Country, ZipCode = @ZipCode
                    WHERE SellerID = @SellerID";

                SqlCommand updateAddressCmd = new SqlCommand(updateAddressQuery, con);
                updateAddressCmd.Parameters.AddWithValue("@Plot", SellerUpdAcc_Plot_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@Area", SellerUpdAcc_Area_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@City", SellerUpdAcc_City_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@Province", SellerUpdAcc_Province_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@Country", SellerUpdAcc_Country_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@ZipCode", SellerUpdAcc_ZipCode_txtfield.Text);
                updateAddressCmd.Parameters.AddWithValue("@SellerID", sellerID);
                updateAddressCmd.ExecuteNonQuery();

                MessageBox.Show("Seller information updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating seller information: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
