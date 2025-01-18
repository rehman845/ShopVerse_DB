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
    public partial class CustMyOrders : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustMyOrders(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }


        private void CustMyOrders_Back_Button_Click(object sender, EventArgs e)
        {
            CustDashboard custDashboard = new CustDashboard(LoggedInEmail);
            custDashboard.Show();
            this.Hide();
        }

        private void CustMyOrders_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string userMail = LoggedInEmail;

                StringBuilder queryBuilder = new StringBuilder(@"
SELECT 
    o.OrderID,
    p.Prod_Name AS ProductName,
    oi.Item_Quant AS Quantity,
    (oi.Item_Quant * oi.Order_Amount) AS TotalAmount,
    o.Order_Date AS OrderDate,
    o.Shipment_Status AS ShipmentStatus,
    o.Delivery_Date AS DeliveryDate
FROM 
    ORDERS o
INNER JOIN CUSTOMERS c ON o.CustID = c.CustID
INNER JOIN USERS u ON c.UserID = u.UserID
INNER JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
INNER JOIN PRODUCTS p ON oi.ProdID = p.ProdID
WHERE 
    u.User_Mail = @UserMail");

                if (!string.IsNullOrEmpty(txtOrdID.Text))
                {
                    queryBuilder.Append(" AND o.OrderID = @OrderID");
                }
                if (!string.IsNullOrEmpty(txtProd.Text))
                {
                    queryBuilder.Append(" AND p.Prod_Name LIKE @ProductName");
                }
                if (!string.IsNullOrEmpty(txtStartDate.Text))
                {
                    queryBuilder.Append(" AND o.Order_Date >= @StartDate");
                }
                if (!string.IsNullOrEmpty(txtEndDate.Text))
                {
                    queryBuilder.Append(" AND o.Order_Date <= @EndDate");
                }

                queryBuilder.Append(" ORDER BY o.OrderID, o.Order_Date DESC;");

                SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con);
                cmd.Parameters.AddWithValue("@UserMail", userMail);

                if (!string.IsNullOrEmpty(txtOrdID.Text))
                {
                    cmd.Parameters.AddWithValue("@OrderID", Convert.ToInt32(txtOrdID.Text));
                }
                if (!string.IsNullOrEmpty(txtProd.Text))
                {
                    cmd.Parameters.AddWithValue("@ProductName", "%" + txtProd.Text + "%");
                }
                if (!string.IsNullOrEmpty(txtStartDate.Text))
                {
                    cmd.Parameters.AddWithValue("@StartDate", Convert.ToDateTime(txtStartDate.Text));
                }
                if (!string.IsNullOrEmpty(txtEndDate.Text))
                {
                    cmd.Parameters.AddWithValue("@EndDate", Convert.ToDateTime(txtEndDate.Text));
                }

                CustMyOrders_Orders_FlowLayout.Controls.Clear();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    TableLayoutPanel orderTable = null;
                    int lastOrderID = -1;

                    while (reader.Read())
                    {
                        int currentOrderID = Convert.ToInt32(reader["OrderID"]);

                        if (currentOrderID != lastOrderID)
                        {
                            if (orderTable != null)
                            {
                                CustMyOrders_Orders_FlowLayout.Controls.Add(orderTable);
                            }

                            orderTable = new TableLayoutPanel
                            {
                                AutoSize = true,
                                ColumnCount = 6,
                                RowCount = 1,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(10),
                                Padding = new Padding(10),
                                Dock = DockStyle.Top,
                                BackColor = Color.OldLace
                            };

                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); 
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); 
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25)); 

                            Label orderIDLabel = new Label
                            {
                                Text = $"Order ID: {currentOrderID}",
                                AutoSize = true,
                                Font = new Font("Century Gothic", 16, FontStyle.Bold),
                                ForeColor = Color.Black,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Fill
                            };

                            orderTable.Controls.Add(orderIDLabel, 0, 0);
                            orderTable.SetColumnSpan(orderIDLabel, 6);

                            lastOrderID = currentOrderID;
                        }

                        Label productNameLabel = new Label
                        {
                            Text = reader["ProductName"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            Dock = DockStyle.Fill
                        };

                        Label quantityLabel = new Label
                        {
                            Text = reader["Quantity"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            Dock = DockStyle.Fill
                        };

                        Label totalAmountLabel = new Label
                        {
                            Text = reader["TotalAmount"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            Dock = DockStyle.Fill
                        };

                        Label orderDateLabel = new Label
                        {
                            Text = Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Italic),
                            Dock = DockStyle.Fill
                        };

                        Label shipmentStatusLabel = new Label
                        {
                            Text = reader["ShipmentStatus"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            Dock = DockStyle.Fill
                        };

                        FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                        {
                            AutoSize = true,
                            Dock = DockStyle.Fill
                        };

                        Button returnButton = new Button
                        {
                            Text = "Return Order",
                            AutoSize = true,
                            Tag = currentOrderID
                        };

                        returnButton.Click += CustMyOrders_Return_Button_Click;
                        buttonPanel.Controls.Add(returnButton);

                        orderTable.RowCount++;
                        orderTable.Controls.Add(productNameLabel, 0, orderTable.RowCount - 1);
                        orderTable.Controls.Add(quantityLabel, 1, orderTable.RowCount - 1);
                        orderTable.Controls.Add(totalAmountLabel, 2, orderTable.RowCount - 1);
                        orderTable.Controls.Add(orderDateLabel, 3, orderTable.RowCount - 1);
                        orderTable.Controls.Add(shipmentStatusLabel, 4, orderTable.RowCount - 1);
                        orderTable.Controls.Add(buttonPanel, 5, orderTable.RowCount - 1);
                    }

                    if (orderTable != null)
                    {
                        CustMyOrders_Orders_FlowLayout.Controls.Add(orderTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }


        }

        private void CustMyOrders_Details_Button_Click(object sender, EventArgs e)
        {
            
        }

        private void CustMyOrders_WriteReview_Button_Click(object sender, EventArgs e)
        {

        }

        private void CustMyOrders_Return_Button_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(((Button)sender).Tag);

            var result = MessageBox.Show($"Are you sure you want to return order ID {orderID}?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                    {
                        con.Open();

                        string updateQuery = "UPDATE ORDERS SET Order_Return = 1 WHERE OrderID = @OrderID";

                        SqlCommand cmd = new SqlCommand(updateQuery, con);
                        cmd.Parameters.AddWithValue("@OrderID", orderID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Order ID {orderID} has been marked as returned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Error: Could not update the return status for Order ID {orderID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtClearlFilter_Click(object sender, EventArgs e)
        {
            txtStartDate.Clear();
            txtEndDate.Clear();
            txtProd.Clear();
            txtOrdID.Clear();

            CustMyOrders_Load(sender, e);
        }

        private void txtApplyButton_Click(object sender, EventArgs e)
        {
            CustMyOrders_Load(sender, e);
        }
    }
    
}
