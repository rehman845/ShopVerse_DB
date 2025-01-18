using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.MonthCalendar;


namespace DBProject
{
    public partial class CustSignUp : Form
    {
        public CustSignUp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

        private void CustSignUp_Load(object sender, EventArgs e)
        {
          


        }

        private void CustLogIn_Back_Button_Click(object sender, EventArgs e) //mistakenly, it is Sign Up Back
        {
            CustLogIn custLogIn = new CustLogIn();
            custLogIn.Show();
            this.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CusSignUp_Plot_txtfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustSignUp_SignUp_Button_Click(object sender, EventArgs e)
        {

            
            if (string.IsNullOrWhiteSpace(CustSignUp_FName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_LName_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_Mail_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_Password_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_Contact_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_Plot_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_Area_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_City_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_Province_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_Country_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CusSignUp_ZipCode_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_CardNum_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_Bank_txtfield.Text) ||
                string.IsNullOrWhiteSpace(CustSignUp_CVV_txtfield.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         
            if (!System.Text.RegularExpressions.Regex.IsMatch(CustSignUp_Mail_txtfield.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (CustSignUp_Contact_txtfield.Text.Length != 11 || !CustSignUp_Contact_txtfield.Text.StartsWith("03"))
            {
                MessageBox.Show("Contact number must be 11 digits and start with '03'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime dob = CustSignUp_DOB_Datefield.Value;
            if ((DateTime.Now.Year - dob.Year) < 14 || (DateTime.Now.Year - dob.Year == 14 && DateTime.Now.DayOfYear < dob.DayOfYear))
            {
                MessageBox.Show("Minimum age to register is 14 years.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustSignUp_CardNum_txtfield.Text.Length != 16 || !long.TryParse(CustSignUp_CardNum_txtfield.Text, out _))
            {
                MessageBox.Show("Card number must be 16 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustSignUp_CVV_txtfield.Text.Length != 3 || !int.TryParse(CustSignUp_CVV_txtfield.Text, out _))
            {
                MessageBox.Show("CVV must be 3 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CustSignUp_Expiry_Datefield.Value <= DateTime.Now)
            {
                MessageBox.Show("Card expiry date must be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (CusSignUp_ZipCode_txtfield.Text.Length != 5 || !int.TryParse(CusSignUp_ZipCode_txtfield.Text, out _))
            {
                MessageBox.Show("Zip code must be 5 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            con.Open();

            string query1 = @"
INSERT INTO USERS (User_FName, User_LName, User_Mail, User_Password, Discriminator)
VALUES (@fname, @lname, @mail, @password, 'Customer');
SELECT SCOPE_IDENTITY();";

            int userid = 0;

            using (SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                cmd1.Parameters.AddWithValue("@fname", CustSignUp_FName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@lname", CustSignUp_LName_txtfield.Text);
                cmd1.Parameters.AddWithValue("@mail", CustSignUp_Mail_txtfield.Text);
                cmd1.Parameters.AddWithValue("@password", CustSignUp_Password_txtfield.Text);
                userid = Convert.ToInt32(cmd1.ExecuteScalar());
            }

            string query2 = @"
INSERT INTO CUSTOMERS (UserID, Cust_Gender, Cust_Phone, Cust_DOB, Cust_RegDate)
VALUES (@userid, @gender, @phone, @dob, GETDATE());
SELECT SCOPE_IDENTITY();";

            int custid = 0;

            using (SqlCommand cmd2 = new SqlCommand(query2, con))
            {
                cmd2.Parameters.AddWithValue("@userid", userid);
                cmd2.Parameters.AddWithValue("@gender", CustSignUp_Male_Radio.Checked ? "Male" : "Female");
                cmd2.Parameters.AddWithValue("@phone", CustSignUp_Contact_txtfield.Text);
                cmd2.Parameters.AddWithValue("@dob", dob);
                custid = Convert.ToInt32(cmd2.ExecuteScalar());
            }

            string query3 = @"
INSERT INTO ADDRESS (CustID, Plot, Area, City, Province, Country, ZipCode)
VALUES (@custid, @Plot, @Area, @City, @Province, @Country, @ZipCode);";

            using (SqlCommand cmd3 = new SqlCommand(query3, con))
            {
                cmd3.Parameters.AddWithValue("@custid", custid);
                cmd3.Parameters.AddWithValue("@Plot", CusSignUp_Plot_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Area", CusSignUp_Area_txtfield.Text);
                cmd3.Parameters.AddWithValue("@City", CusSignUp_City_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Province", CusSignUp_Province_txtfield.Text);
                cmd3.Parameters.AddWithValue("@Country", CusSignUp_Country_txtfield.Text);
                cmd3.Parameters.AddWithValue("@ZipCode", CusSignUp_ZipCode_txtfield.Text);
                cmd3.ExecuteNonQuery();
            }

            string query4 = @"
INSERT INTO CARDS (CustID, Card_Num, Bank_Name, CVV, Expiry_Date)
VALUES (@custid, @CardNum, @BankName, @CVV, @ExpiryDate);";

            using (SqlCommand cmd4 = new SqlCommand(query4, con))
            {
                cmd4.Parameters.AddWithValue("@custid", custid);
                cmd4.Parameters.AddWithValue("@CardNum", CustSignUp_CardNum_txtfield.Text);
                cmd4.Parameters.AddWithValue("@BankName", CustSignUp_Bank_txtfield.Text);
                cmd4.Parameters.AddWithValue("@CVV", CustSignUp_CVV_txtfield.Text);
                cmd4.Parameters.AddWithValue("@ExpiryDate", CustSignUp_Expiry_Datefield.Value);
                cmd4.ExecuteNonQuery();
            }

            MessageBox.Show("You have been signed up successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();


        }

    }
}
