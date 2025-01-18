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
    public partial class SellerOrdManage : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerOrdManage(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void SellerOrdManage_Back_Button_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void SellerOrdManage_Load(object sender, EventArgs e)
        {
            

            LoadOrders();
          //  this.reportViewer1.RefreshReport();
          //  this.reportViewer1.RefreshReport();
        }

        private Panel CreateOrderPanel(int orderID, int custID, string product, int quantity, decimal grandTotal, string logisticsID, string shipmentStatus, DateTime? orderDate, DateTime? deliveryDate, bool orderReturn, int returnApprove, string trackingNumber, bool sellerAccept)
        {
            Panel orderPanel = new Panel
            {
                Width = 800,
                Height = 200, 
                BackColor = Color.MistyRose,
                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            orderPanel.Controls.Add(new Label
            {
                Text = "Order ID: " + orderID.ToString(),
                Location = new Point(10, 10),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Customer ID: " + custID.ToString(),
                Location = new Point(10, 30),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Product: " + product,
                Location = new Point(10, 50),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Quantity: " + quantity.ToString(),
                Location = new Point(10, 70),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Grand Total: $" + grandTotal.ToString(),
                Location = new Point(10, 90),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Logistics ID: " + (string.IsNullOrEmpty(logisticsID) ? "N/A" : logisticsID),
                Location = new Point(400, 10),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Shipment Status: " + (string.IsNullOrEmpty(shipmentStatus) ? "Pending" : shipmentStatus),
                Location = new Point(400, 30),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Order Date: " + (orderDate.HasValue ? orderDate.Value.ToString("yyyy-MM-dd") : "N/A"),
                Location = new Point(400, 50),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Delivery Date: " + (deliveryDate.HasValue ? deliveryDate.Value.ToString("yyyy-MM-dd") : "N/A"),
                Location = new Point(400, 70),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = "Tracking Number: " + (string.IsNullOrEmpty(trackingNumber) ? "N/A" : trackingNumber),
                Location = new Point(400, 90),
                AutoSize = true
            });

            orderPanel.Controls.Add(new Label
            {
                Text = orderReturn ? "Return Requested" : "No Return Request",
                ForeColor = orderReturn ? Color.Red : Color.Green,
                Location = new Point(600, 10),
                AutoSize = true
            });

            ComboBox cmbReturnStatus = new ComboBox
            {
                Location = new Point(600, 40),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbReturnStatus.Items.Add("Pending");
            cmbReturnStatus.Items.Add("Approved");
            cmbReturnStatus.Items.Add("Rejected");

            cmbReturnStatus.SelectedItem = returnApprove == 1 ? "Approved" : "Pending";
            orderPanel.Controls.Add(cmbReturnStatus);

            cmbReturnStatus.SelectedIndexChanged += (s, e) =>
            {
                if (cmbReturnStatus.SelectedItem.ToString() == "Approved")
                {
                    try
                    {
                        
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE ORDERS SET Return_Approve = 1 WHERE OrderID = @OrderID", con);
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating return approval: " + ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            };

            Button btnAccept = new Button
            {
                Text = "Accept Order",
                Location = new Point(600, 70),
                Width = 100,
                Height = 30
            };

            btnAccept.Click += (s, e) =>
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE ORDERS SET SellerAccept = 1 WHERE OrderID = @OrderID", con);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Accepted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error accepting order: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            };
            orderPanel.Controls.Add(btnAccept);

            return orderPanel;
        }



        private int GetSellerID()
        {
            int sellerID = -1;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT SellerID FROM SELLER s INNER JOIN USERS u ON s.UserID = u.UserID WHERE u.User_Mail = @Email", con);
                cmd.Parameters.AddWithValue("@Email", LoggedInEmail);
                sellerID = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Seller ID: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return sellerID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void LoadOrders()
        {
            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            try
            {
                con.Open();

                StringBuilder query = new StringBuilder(@"
            SELECT 
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
                o.Tracking_Number, 
                o.SellerAccept -- Include the SellerAccept field
            FROM ORDERS o
            JOIN ORDER_ITEM od ON o.OrderID = od.OrderID
            JOIN PRODUCTS p ON od.ProdID = p.ProdID
            WHERE p.SellerID = @SellerID");

                if (!string.IsNullOrEmpty(txtOrdID.Text))
                    query.Append(" AND o.OrderID = @orderID");

                if (!string.IsNullOrEmpty(txtCust.Text))
                    query.Append(" AND o.CustID = @custID");

                if (!string.IsNullOrEmpty(txtProd.Text))
                    query.Append(" AND p.Prod_Name LIKE @prodName");

                if (!string.IsNullOrEmpty(txtStartDate.Text) && DateTime.TryParse(txtStartDate.Text, out DateTime startDate))
                    query.Append(" AND o.Order_Date >= @startDate");

                if (!string.IsNullOrEmpty(txtEndDate.Text) && DateTime.TryParse(txtEndDate.Text, out DateTime endDate))
                    query.Append(" AND o.Order_Date <= @endDate");

                query.Append(" ORDER BY o.OrderID, p.Prod_Name");

                SqlCommand cmd = new SqlCommand(query.ToString(), con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                if (!string.IsNullOrEmpty(txtOrdID.Text))
                    cmd.Parameters.AddWithValue("@orderID", txtOrdID.Text);

                if (!string.IsNullOrEmpty(txtCust.Text))
                    cmd.Parameters.AddWithValue("@custID", txtCust.Text);

                if (!string.IsNullOrEmpty(txtProd.Text))
                    cmd.Parameters.AddWithValue("@prodName", "%" + txtProd.Text + "%");

                if (!string.IsNullOrEmpty(txtStartDate.Text) && DateTime.TryParse(txtStartDate.Text, out startDate))
                    cmd.Parameters.AddWithValue("@startDate", startDate);

                if (!string.IsNullOrEmpty(txtEndDate.Text) && DateTime.TryParse(txtEndDate.Text, out endDate))
                    cmd.Parameters.AddWithValue("@endDate", endDate);

                SqlDataReader reader = cmd.ExecuteReader();
                SellerOrd_Flow.Controls.Clear();

                while (reader.Read())
                {

                    int orderID = reader["OrderID"] != DBNull.Value ? Convert.ToInt32(reader["OrderID"]) : 0;
                    int custID = reader["CustID"] != DBNull.Value ? Convert.ToInt32(reader["CustID"]) : 0;
                    string product = reader["Product"] != DBNull.Value ? reader["Product"].ToString() : string.Empty;
                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;
                    decimal grandTotal = reader["Grand_Total"] != DBNull.Value ? Convert.ToDecimal(reader["Grand_Total"]) : 0;
                    string logisticsID = reader["LogisticsID"] != DBNull.Value ? reader["LogisticsID"].ToString() : string.Empty;
                    string shipmentStatus = reader["Shipment_Status"] != DBNull.Value ? reader["Shipment_Status"].ToString() : string.Empty;
                    DateTime? orderDate = reader["Order_Date"] != DBNull.Value ? (DateTime?)reader["Order_Date"] : null;
                    DateTime? deliveryDate = reader["Delivery_Date"] != DBNull.Value ? (DateTime?)reader["Delivery_Date"] : null;
                    bool orderReturn = reader["Order_Return"] != DBNull.Value && (bool)reader["Order_Return"];
                    int returnApprove = reader["Return_Approve"] != DBNull.Value ? Convert.ToInt32(reader["Return_Approve"]) : 0;
                    string trackingNumber = reader["Tracking_Number"] != DBNull.Value ? reader["Tracking_Number"].ToString() : string.Empty;
                    bool sellerAccept = reader["SellerAccept"] != DBNull.Value && (bool)reader["SellerAccept"];


                    Panel orderPanel = CreateOrderPanel(orderID, custID, product, quantity, grandTotal, logisticsID, shipmentStatus, orderDate, deliveryDate, orderReturn, returnApprove, trackingNumber, sellerAccept);
                    SellerOrd_Flow.Controls.Add(orderPanel);
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




        private void txtApplyButton_Click(object sender, EventArgs e)
        {
            LoadOrders();

        }

        private void txtClearlFilter_Click(object sender, EventArgs e)
        {
            txtOrdID.Clear();
            txtCust.Clear();
            txtProd.Clear();
            txtStartDate.Clear();
            txtEndDate.Clear();
            LoadOrders();
        }
    }
}
