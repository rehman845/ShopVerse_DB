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
    public partial class AdminCustManage : Form
    {
        public AdminCustManage(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public string LoggedInEmail { get; set; }

        private void AdminCustManage_Load(object sender, EventArgs e)
        {

        }

        private void AdminCustomerManage_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminCustomerManage_ViewSeller_Button_Click(object sender, EventArgs e)
        {
            string custID = AdminCustomerManage_CustomerID_txtfield.Text;
            if (string.IsNullOrEmpty(custID))
            {
                MessageBox.Show("Please enter a Customer ID to view information.");
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT User_Mail FROM USERS WHERE UserID = (SELECT UserID FROM CUSTOMERS WHERE CustID = @CustID)", con);
                cmd.Parameters.AddWithValue("@CustID", custID);
                string customerEmail = cmd.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(customerEmail))
                {
                    AdminCustInfo adminCustInfo = new AdminCustInfo(customerEmail);
                    adminCustInfo.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving customer information: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AdminCustomerManage_Approve_Button_Click(object sender, EventArgs e)
        {

        }

        private void AdminCustomerReviewFlows_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminCustomerManage_CustomerID_txtfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_CustomerIDEnter_Click(object sender, EventArgs e)
        {
            string custID = AdminCustomerManage_CustomerID_txtfield.Text;
            if (string.IsNullOrEmpty(custID))
            {
                MessageBox.Show("Please enter a Customer ID.");
                return;
            }

            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT r.ReviewID, r.Comment, c.CustID, u.User_FName " +
                    "FROM REVIEW r " +
                    "JOIN CUSTOMERS c ON r.CustID = c.CustID " +
                    "JOIN USERS u ON c.UserID = u.UserID " +
                    "WHERE r.CustID = @CustID", con);
                cmd.Parameters.AddWithValue("@CustID", custID);

                SqlDataReader reader = cmd.ExecuteReader();

                AdminCustomerReviewFlows.Controls.Clear();

                bool hasReviews = false;

                while (reader.Read())
                {
                    hasReviews = true;

                    int reviewID = Convert.ToInt32(reader["ReviewID"]);
                    string comment = reader["Comment"].ToString();
                    string userName = reader["User_FName"].ToString();
                    string customerId = reader["CustID"].ToString();

                    Panel reviewPanelItem = new Panel
                    {
                        Width = AdminCustomerReviewFlows.Width - 20,
                        Height = 120,
                        BackColor = Color.LightGray,
                        Font = new Font("Century Gothic", 10),
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label lblCustID = new Label { Text = $"Customer ID: {customerId}", AutoSize = true };
                    Label lblCustName = new Label { Text = $"Customer Name: {userName}", AutoSize = true };
                    Label lblComment = new Label { Text = $"Comment: {comment}", AutoSize = true };

                    Button btnDeleteReview = new Button
                    {
                        Text = "Delete Review",
                        BackColor = Color.Red,
                        ForeColor = Color.White,
                        Width = 120,
                        Height = 30
                    };

                    btnDeleteReview.Click += (s, ev) =>
                    {
                        DeleteReview(reviewID);
                        AdminCustomerReviewFlows.Controls.Remove(reviewPanelItem);
                    };

                    reviewPanelItem.Controls.Add(lblCustID);
                    reviewPanelItem.Controls.Add(lblCustName);
                    reviewPanelItem.Controls.Add(lblComment);
                    reviewPanelItem.Controls.Add(btnDeleteReview);

                    lblCustID.Location = new Point(10, 10);
                    lblCustName.Location = new Point(10, 30);
                    lblComment.Location = new Point(10, 50);
                    btnDeleteReview.Location = new Point(400, 40);

                    AdminCustomerReviewFlows.Controls.Add(reviewPanelItem);
                }

                if (!hasReviews)
                {
                    MessageBox.Show("No reviews found for this Customer.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message);
            }
            finally
            {
                con.Close();
            }


        }

        private void DeleteReview(int reviewID)
        {
            try
            {
                con.Open();

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM REVIEW WHERE ReviewID = @ReviewID", con);
                deleteCmd.Parameters.AddWithValue("@ReviewID", reviewID);

                int rowsAffected = deleteCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Review deleted successfully.");
                }
                else
                {
                    MessageBox.Show("No review found for the given ReviewID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting review: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
