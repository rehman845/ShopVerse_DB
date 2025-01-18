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
    public partial class CustLogIn : Form
    {
        public CustLogIn()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

        private void CustLogIn_Back_Button_Click(object sender, EventArgs e)
        {
           
            UserType UserType = new UserType();
            UserType.Show();
            this.Hide();
        }

        private void CustLogIn_NewUser_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustSignUp custSignUp = new CustSignUp();
            custSignUp.Show();
            this.Hide();
        }

        public string LoggedInEmail { get; set; }



        private void CustlogIn_Login_Button_Click(object sender, EventArgs e)
        {
            LoggedInEmail = CustLogIn_Mail_txtfield.Text;



                if (string.IsNullOrWhiteSpace(CustLogIn_Mail_txtfield.Text) ||
                    string.IsNullOrWhiteSpace(CustLogIn_Password_txtfield.Text))
                {
                    MessageBox.Show("Please enter both Email and Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (!System.Text.RegularExpressions.Regex.IsMatch(CustLogIn_Mail_txtfield.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                    try
                    {
                        con.Open();

                        string query = @"
            SELECT COUNT(*)
            FROM USERS
            WHERE User_Mail = @mail AND User_Password = @password AND Discriminator = 'Customer'";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@mail", CustLogIn_Mail_txtfield.Text);
                            cmd.Parameters.AddWithValue("@password", CustLogIn_Password_txtfield.Text);

                            int userExists = (int)cmd.ExecuteScalar();

                            if (userExists > 0)
                            {
                        // Update login time and frequency
                        string updateQuery = @"
                UPDATE CUSTOMERS
    SET Cust_LoginTime = @loginTime,
        Cust_FreqLogin = COALESCE(Cust_FreqLogin, 0) + 1
    WHERE UserID = (SELECT UserID FROM USERS WHERE User_Mail = @mail AND Discriminator = 'Customer')";

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@loginTime", DateTime.Now);
                            updateCmd.Parameters.AddWithValue("@mail", CustLogIn_Mail_txtfield.Text);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Continue with the form display and notifications
                        CheckForNotifications(LoggedInEmail);
                        CustForYou custForYou = new CustForYou(LoggedInEmail);
                        custForYou.Show();
                        this.Hide();
                        Console.WriteLine("Form displayed, notification checked.");

                    }
                            else
                            {
                               
                                MessageBox.Show("Invalid Email or Password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            
        }
        private void CheckForNotifications(string customerEmail)
        {
            string selectQuery = @"
    SELECT o.OrderID, o.Shipment_Status
    FROM ORDERS o
    INNER JOIN USERS u ON u.UserID = o.CustID
    WHERE u.User_Mail = @Email
      AND (o.IsNotified IS NULL OR o.IsNotified = 0)"; 

            string updateQuery = @"
    UPDATE o
    SET o.IsNotified = 1
    FROM ORDERS o
    INNER JOIN USERS u ON u.UserID = o.CustID
    WHERE u.User_Mail = @Email
      AND (o.IsNotified IS NULL OR o.IsNotified = 0)";  

            using (SqlConnection localCon = new SqlConnection(con.ConnectionString))
            {
                localCon.Open();

                using (SqlCommand selectCmd = new SqlCommand(selectQuery, localCon))
                {
                    selectCmd.Parameters.AddWithValue("@Email", customerEmail);

                    try
                    {
                        using (SqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int orderId = Convert.ToInt32(reader["OrderID"]);
                                    string currentStatus = reader["Shipment_Status"].ToString();
                                    string statusMessage = GetStatusMessage(orderId, currentStatus);

                                    MessageBox.Show(statusMessage, "Shipment Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while checking notifications: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, localCon))
                    {
                        updateCmd.Parameters.AddWithValue("@Email", customerEmail);

                        try
                        {
                            updateCmd.ExecuteNonQuery(); 
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred while updating the notification status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private string GetStatusMessage(int orderId, string status)
        {
            switch (status)
            {
                case "Pending":
                    return $"Order ID: {orderId} - Your shipment is pending.";
                case "Shipped":
                    return $"Order ID: {orderId} - Your shipment has been shipped.";
                case "In Transit":
                    return $"Order ID: {orderId} - Your shipment is in transit.";
                case "Delivered":
                    return $"Order ID: {orderId} - Your shipment has been delivered!";
                case "Returned":
                    return $"Order ID: {orderId} - Your shipment has been returned.";
                case "Cancelled":
                    return $"Order ID: {orderId} - Your shipment has been cancelled.";
                default:
                    return $"Order ID: {orderId} - Unknown shipment status.";
            }
        }











        private void CustLogIn_Mail_txtfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustLogIn_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
