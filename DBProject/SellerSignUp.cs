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
    public partial class SellerSignUp : Form
    {
        public SellerSignUp()
        {
            
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
      
        private void SellerSignUp_Back_Button_Click(object sender, EventArgs e)
        {
            SellerLogIn sellerLogIn = new SellerLogIn();
            sellerLogIn.Show();
            this.Hide();
        }

        private void SellerSignUp_SignUp_Button_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SellerSignUp_FName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_LName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Mail_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Password_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Plot_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Area_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_City_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Province_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_Country_txtfield.Text) ||
                string.IsNullOrWhiteSpace(SellerSignUp_ZipCode_txtfield.Text))
                
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!System.Text.RegularExpressions.Regex.IsMatch(SellerSignUp_Mail_txtfield.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (SellerSignUp_IBAN_txtfield.Text.Length != 5 || !int.TryParse(SellerSignUp_IBAN_txtfield.Text, out _))
            {
                MessageBox.Show("IBAN must be 34 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            


            if (SellerSignUp_ZipCode_txtfield.Text.Length != 5 || !int.TryParse(SellerSignUp_ZipCode_txtfield.Text, out _))
            {
                MessageBox.Show("Zip code must be 5 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();

            string query1 = @"
INSERT INTO USERS (User_FName, User_LName, User_Mail, User_Password, Discriminator)
VALUES (@fname, @lname, @mail, @password, 'Seller');
SELECT SCOPE_IDENTITY();";

            int userid = 0;

            using (SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                cmd1.Parameters.AddWithValue("@fname", SellerSignUp_FName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@lname", SellerSignUp_LName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@mail", SellerSignUp_Mail_txtfield.Text);
                cmd1.Parameters.AddWithValue("@password", SellerSignUp_Password_txtfield.Text);
                userid = Convert.ToInt32(cmd1.ExecuteScalar());
            }

            string query2 = @"
INSERT INTO SELLER (UserID, Seller_StoreName, Seller_VerStatus, Seller_IBAN)
VALUES (@userid, @storename, 0, @selleriban);
SELECT SCOPE_IDENTITY();";

            int sellerid = 0;

            using (SqlCommand cmd2 = new SqlCommand(query2, con))
            {
                cmd2.Parameters.AddWithValue("@userid", userid);
                cmd2.Parameters.AddWithValue("@storename", SellerSignUp_Store_txtfield.Text);
                cmd2.Parameters.AddWithValue("@selleriban", SellerSignUp_IBAN_txtfield.Text);
                sellerid = Convert.ToInt32(cmd2.ExecuteScalar());
            }

            string query3 = @"
INSERT INTO ADDRESS (SellerID, Plot, Area, City, Province, Country, ZipCode)
VALUES (@sellerid, @Plot, @Area, @City, @Province, @Country, @ZipCode);";

            using (SqlCommand cmd3 = new SqlCommand(query3, con))
            {
                cmd3.Parameters.AddWithValue("@sellerid", sellerid);
                cmd3.Parameters.AddWithValue("@Plot", SellerSignUp_Plot_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Area", SellerSignUp_Area_txtfield.Text);
                cmd3.Parameters.AddWithValue("@City", SellerSignUp_City_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Province", SellerSignUp_Province_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Country", SellerSignUp_Country_txtfield.Text);
                cmd3.Parameters.AddWithValue("@ZipCode", SellerSignUp_ZipCode_txtfield.Text);
                cmd3.ExecuteNonQuery();
            }

            

            MessageBox.Show("You have been signed up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();

        }

        private void SellerSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
