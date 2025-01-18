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
    public partial class AdminSellerManage : Form
    {
        public AdminSellerManage(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public string LoggedInEmail { get; set; }
        private void AdminSellerManage_Load(object sender, EventArgs e)
        {

        }

        private void AdminSellerManage_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminSellerManage_ViewSeller_Button_Click(object sender, EventArgs e)
        {
            string sellerID = AdminSellerManage_SellerID_txtfield.Text;
            if (string.IsNullOrEmpty(sellerID))
            {
                MessageBox.Show("Please enter a Seller ID to view information.");
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT User_Mail FROM USERS WHERE UserID = (SELECT UserID FROM SELLER WHERE SellerID = @SellerID)", con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);
                string sellerEmail = cmd.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(sellerEmail))
                {
                    AdminSellerInfo adminSellerInfo = new AdminSellerInfo(sellerEmail);
                    adminSellerInfo.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Seller not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving seller information: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            
        }

        private void AdminSellerManage_Approve_Button_Click(object sender, EventArgs e)
        {
            string sellerID = AdminSellerManage_SellerID_txtfield.Text;

            if (string.IsNullOrEmpty(sellerID))
            {
                MessageBox.Show("Please enter a Seller ID to approve.");
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE SELLER SET Seller_VerStatus = 1 WHERE SellerID = @SellerID", con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Seller approved successfully.");
                }
                else
                {
                    MessageBox.Show("Seller not found or already approved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving seller: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void Admin_SellerIDEnter_Click(object sender, EventArgs e)
        {
            string sellerID = AdminSellerManage_SellerID_txtfield.Text;
            if (string.IsNullOrEmpty(sellerID))
            {
                MessageBox.Show("Please enter a Seller ID.");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                o.OrderID, 
                o.CustID, 
                p.Prod_Name AS Product, 
                od.Item_Quant AS Quantity, 
                o.Order_Amount AS Grand_Total, 
                o.LogisticsID, 
                o.Shipment_Status, 
                o.Order_Date, 
                o.Delivery_Date, 
                o.Order_Return, 
                o.Return_Approve,
                o.Tracking_Number
              FROM ORDERS o
              JOIN ORDER_ITEM od ON o.OrderID = od.OrderID
              JOIN PRODUCTS p ON od.ProdID = p.ProdID
              WHERE p.SellerID = @SellerID
              ORDER BY o.OrderID, p.Prod_Name", con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                SqlDataReader reader = cmd.ExecuteReader();
                AdminSellerOrderFlow.Controls.Clear();

                while (reader.Read())
                {
                    Panel orderPanel = new Panel
                    {
                        Width = 800,
                        Height = 150,
                        BackColor = Color.MistyRose,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle
                    };



                    Label lblOrderID = new Label
                    {
                        Text = "Order ID: " + reader["OrderID"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(10, 10)
                    };

                    Label lblCustID = new Label
                    {
                        Text = "Customer ID: " + reader["CustID"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(10, 30)
                    };

                    Label lblProduct = new Label
                    {
                        Text = "Product: " + reader["Product"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(10, 50)
                    };

                    Label lblQuantity = new Label
                    {
                        Text = "Quantity: " + reader["Quantity"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(10, 70)
                    };

                    Label lblGrandTotal = new Label
                    {
                        Text = "Grand Total: $" + reader["Grand_Total"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(10, 90)
                    };

                    Label lblLogisticsID = new Label
                    {
                        Text = "Logistics ID: " + reader["LogisticsID"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(400, 10)
                    };

                    Label lblShipmentStatus = new Label
                    {
                        Text = "Shipment Status: " + reader["Shipment_Status"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(400, 30)
                    };

                    Label lblOrderDate = new Label
                    {
                        Text = "Order Date: " + Convert.ToDateTime(reader["Order_Date"]).ToString("yyyy-MM-dd"),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(400, 50)
                    };

                    Label lblDeliveryDate = new Label
                    {
                        Text = "Delivery Date: " + Convert.ToDateTime(reader["Delivery_Date"]).ToString("yyyy-MM-dd"),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(400, 70)
                    };

                    Label lblTrackingNumber = new Label
                    {
                        Text = "Tracking Number: " + reader["Tracking_Number"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Bold),
                        Location = new Point(400, 90)
                    };

                    //// Order Return Label
                    //Label lblOrderReturn = new Label
                    //{
                    //    Text = Convert.ToBoolean(reader["Order_Return"]) ? "Return Requested" : "No Return Request",
                    //    ForeColor = Convert.ToBoolean(reader["Order_Return"]) ? Color.Red : Color.Green,
                    //    AutoSize = true,
                    //    Location = new Point(600, 10)
                    //};

                    //// ComboBox for Return Approval
                    //Label lblApproveReturn = new Label { Text = "Approve Return", Location = new Point(600, 40), AutoSize = true };
                    //ComboBox cmbReturnApprove = new ComboBox
                    //{
                    //    Width = 120,
                    //    Location = new Point(600, 60)
                    //};
                    //cmbReturnApprove.Items.Add("Yes");
                    //cmbReturnApprove.Items.Add("No");
                    //cmbReturnApprove.SelectedItem = reader["Return_Approve"] != DBNull.Value && Convert.ToBoolean(reader["Return_Approve"]) ? "Yes" : "No";

                    ////ComboBox Event Handler
                    //cmbReturnApprove.SelectedIndexChanged += (s, ev) =>
                    //{
                    //    try
                    //    {
                    //        using (SqlCommand updateCmd = new SqlCommand("UPDATE ORDERS SET Return_Approve = @ReturnApprove WHERE OrderID = @OrderID", con))
                    //        {
                    //            updateCmd.Parameters.AddWithValue("@ReturnApprove", cmbReturnApprove.SelectedItem.ToString() == "Yes" ? 1 : 0);
                    //            updateCmd.Parameters.AddWithValue("@OrderID", reader["OrderID"]);
                    //            updateCmd.ExecuteNonQuery();
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show("Error updating return approval: " + ex.Message);
                    //    }
                    //};


                    orderPanel.Controls.Add(lblOrderID);
                    orderPanel.Controls.Add(lblCustID);
                    orderPanel.Controls.Add(lblProduct);
                    orderPanel.Controls.Add(lblQuantity);
                    orderPanel.Controls.Add(lblGrandTotal);
                    orderPanel.Controls.Add(lblLogisticsID);
                    orderPanel.Controls.Add(lblShipmentStatus);
                    orderPanel.Controls.Add(lblOrderDate);
                    orderPanel.Controls.Add(lblDeliveryDate);
                    orderPanel.Controls.Add(lblTrackingNumber);
                    //orderPanel.Controls.Add(lblOrderReturn);
                    //orderPanel.Controls.Add(lblApproveReturn);
                    //orderPanel.Controls.Add(cmbReturnApprove);

                    AdminSellerOrderFlow.Controls.Add(orderPanel);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
