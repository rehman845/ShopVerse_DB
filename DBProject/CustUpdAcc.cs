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
    public partial class CustUpdAcc : Form
    {

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustUpdAcc(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }

        private void CustUpdAcc_Back_Button_Click(object sender, EventArgs e)
        {
            CustDashboard custDashboard = new CustDashboard(LoggedInEmail);
            custDashboard.Show();
            this.Hide();
        }

        private void CustUpdAcc_Load(object sender, EventArgs e)
        {
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            try
            {
                con.Open();

                string query = @"
                    SELECT U.User_FName, U.User_LName, U.User_Mail, U.User_Password, C.Cust_Gender, C.Cust_Phone, 
                   C.Cust_DOB, A.Plot, A.Area, A.City, A.Province, A.Country, A.ZipCode,
                   CA.Card_Num, CA.Bank_Name, CA.CVV, CA.Expiry_Date
            FROM USERS U
            INNER JOIN CUSTOMERS C ON U.UserID = C.UserID
            LEFT JOIN ADDRESS A ON C.CustID = A.CustID
            LEFT JOIN CARDS CA ON C.CustID = CA.CustID
                    WHERE U.User_Mail = @mail";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@mail", LoggedInEmail);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CustUpdAcc_FName_txtfield.Text = reader["User_FName"].ToString();
                            CustUpdAcc_LName_txtfield.Text = reader["User_LName"].ToString();
                            CustUpdAcc_Password_txtfield.Text = reader["User_Password"].ToString();
                            CustUpdAcc_Plot_txtfield.Text = reader["Plot"].ToString();
                            CustUpdAcc_Area_txtfield.Text = reader["Area"].ToString();
                            CustUpdAcc_City_txtfield.Text = reader["City"].ToString();
                            CustUpdAcc_Province_txtfield.Text = reader["Province"].ToString();
                            CustUpdAcc_Country_txtfield.Text = reader["Country"].ToString();
                            CustUpdAcc_ZipCode_txtfield.Text = reader["ZipCode"].ToString();
                            CustUpdAcc_CardNum_txtfield.Text = reader["Card_Num"].ToString();
                            CustUpdAcc_Bank_txtfield.Text = reader["Bank_Name"].ToString();
                            CustUpdAcc_CVV_txtfield.Text = reader["CVV"].ToString();
                            CustUpdAcc_Expiry_Datefield.Value = Convert.ToDateTime(reader["Expiry_Date"]);

                            if (reader["Cust_Gender"].ToString() == "Male")
                                CustUpdAcc_Male_Radio.Checked = true;
                            else
                                CustUpdAcc_Female_Radio.Checked = true;

                            CustUpdAcc_DOB_Datefield.Value = Convert.ToDateTime(reader["Cust_DOB"]);
                        }
                        else
                        {
                            MessageBox.Show("No customer details found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        private void CustUpdAcc_Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string updateUserQuery = @"
                    UPDATE USERS
                    SET User_FName = @fname, User_LName = @lname
                    WHERE UserID = (SELECT UserID FROM USERS WHERE User_Mail = @loggedInMail)";

                using (SqlCommand cmd = new SqlCommand(updateUserQuery, con))
                {
                    cmd.Parameters.AddWithValue("@fname", CustUpdAcc_FName_txtfield.Text);
                    cmd.Parameters.AddWithValue("@lname", CustUpdAcc_LName_txtfield.Text);
                    cmd.Parameters.AddWithValue("@loggedInMail", LoggedInEmail);
                    cmd.ExecuteNonQuery();
                }

                string updateCustomerQuery = @"
                    UPDATE CUSTOMERS
                    SET Cust_Gender = @gender,  Cust_DOB = @dob
                    WHERE CustID = (SELECT C.CustID FROM CUSTOMERS C
                                    INNER JOIN USERS U ON C.UserID = U.UserID
                                    WHERE U.User_Mail = @loggedInMail)";

                using (SqlCommand cmd = new SqlCommand(updateCustomerQuery, con))
                {
                    cmd.Parameters.AddWithValue("@gender", CustUpdAcc_Male_Radio.Checked ? "Male" : "Female");
               
                    cmd.Parameters.AddWithValue("@dob", CustUpdAcc_DOB_Datefield.Value);
                    cmd.Parameters.AddWithValue("@loggedInMail", LoggedInEmail);
                    cmd.ExecuteNonQuery();
                }

                string updateAddressQuery = @"
                    UPDATE ADDRESS
                    SET Plot = @plot, Area = @area, City = @city, Province = @province, Country = @country, ZipCode = @zipCode
                    WHERE CustID = (SELECT C.CustID FROM CUSTOMERS C
                                    INNER JOIN USERS U ON C.UserID = U.UserID
                                    WHERE U.User_Mail = @loggedInMail)";

                using (SqlCommand cmd = new SqlCommand(updateAddressQuery, con))
                {
                    cmd.Parameters.AddWithValue("@plot", CustUpdAcc_Plot_txtfield.Text);
                    cmd.Parameters.AddWithValue("@area", CustUpdAcc_Area_txtfield.Text);
                    cmd.Parameters.AddWithValue("@city", CustUpdAcc_City_txtfield.Text);
                    cmd.Parameters.AddWithValue("@province", CustUpdAcc_Province_txtfield.Text);
                    cmd.Parameters.AddWithValue("@country", CustUpdAcc_Country_txtfield.Text);
                    cmd.Parameters.AddWithValue("@zipCode", CustUpdAcc_ZipCode_txtfield.Text);
                    cmd.Parameters.AddWithValue("@loggedInMail", LoggedInEmail);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Customer details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
