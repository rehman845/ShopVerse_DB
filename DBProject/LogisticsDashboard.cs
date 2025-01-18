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
    public partial class LogisticsDashboard : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public LogisticsDashboard(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
    }
              public string LoggedInEmail { get; set; }

        private void AdminDashboard_CustManage_button_Click(object sender, EventArgs e) //mistakenly added
        {
            
        }

        private void LogisticsDashboard_SignOut_button_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Hide();
        }

        private void LogisticsDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query5 = @"
                SELECT Company_Name
                    FROM LOGISTICS l 
                    INNER JOIN USERS u ON l.UserID = u.UserID
                    WHERE u.User_Mail = @UserMail";
      

                SqlCommand cmd6 = new SqlCommand(query5, con);
                cmd6.Parameters.AddWithValue("@UserMail", LoggedInEmail); 

                string shipperName = (string)cmd6.ExecuteScalar();
                LogisticsDashboard_Name_label.Text = shipperName;

                string logisticsQuery = @"
                    SELECT ShipperID 
                    FROM LOGISTICS l 
                    INNER JOIN USERS u ON l.UserID = u.UserID
                    WHERE u.User_Mail = @UserEmail";

                SqlCommand logisticsCmd = new SqlCommand(logisticsQuery, con);
                logisticsCmd.Parameters.AddWithValue("@UserEmail", LoggedInEmail);
                int logisticsID = (int)logisticsCmd.ExecuteScalar();

                string query = @"
                    SELECT 
                        o.OrderID,
                        p.Prod_Name AS ProductName,
                        oi.Item_Quant AS Quantity,
                        (oi.Item_Quant * oi.Order_Amount) AS GrandTotal,
                        o.Order_Date AS OrderDate,
                        o.Shipment_Status AS ShipmentStatus,
                        s.Seller_StoreName AS StoreName,
                        o.Delivery_Date AS DeliveryDate
                    FROM 
                        ORDERS o
                    INNER JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
                    INNER JOIN PRODUCTS p ON oi.ProdID = p.ProdID
                    INNER JOIN SELLER s ON o.SellerID = s.SellerID
                    WHERE 
                        o.LogisticsID = @logisticsID
                    ORDER BY 
                        o.OrderID, o.Order_Date DESC;";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@LogisticsID", logisticsID);

                LogisticsDashboard_flow.Controls.Clear();
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
                                LogisticsDashboard_flow.Controls.Add(orderTable);
                            }

                            orderTable = new TableLayoutPanel
                   
                            {
                                AutoSize = true,
                                ColumnCount = 7,
                                RowCount = 2,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Margin = new Padding(10),
                                Padding = new Padding(10),
                                Dock = DockStyle.Top,
                                BackColor = Color.OldLace
                            };

                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // Order ID
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // Product Name
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10)); // Quantity
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // Grand Total
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10)); // Order Date
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15)); // Shipment Status
                            orderTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20)); // Store Name & Delivery Date

                            Label orderIDLabel = new Label
                            {
                                Text = $"Order ID: {currentOrderID}",
                                AutoSize = true,
                                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                                ForeColor = Color.Black,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Fill
                            };

                            Label headerLine = new Label
                            {
                                Text = "Product Name | Quantity | Grand Total | Order Date | Shipment Status | Store Name | Delivery Date",
                                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                                ForeColor = Color.Black,
                                Dock = DockStyle.Fill
                            };

                            orderTable.Controls.Add(orderIDLabel, 0, 0);
                            orderTable.SetColumnSpan(orderIDLabel, 7);

                            orderTable.Controls.Add(headerLine, 0, 1);
                            orderTable.SetColumnSpan(headerLine, 7);

                            lastOrderID = currentOrderID;
                        }

                        Label productNameLabel = new Label
                        {
                            Text = reader["ProductName"] == DBNull.Value ? "N/A" : reader["ProductName"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill
                        };

                        Label quantityLabel = new Label
                        {
                            Text = reader["Quantity"] == DBNull.Value ? "0" : reader["Quantity"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        };

                        Label grandTotalLabel = new Label
                        {
                            Text = reader["GrandTotal"] == DBNull.Value ? "0" : reader["GrandTotal"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleRight,
                            Dock = DockStyle.Fill
                        };

                        Label orderDateLabel = new Label
                        {
                            Text = reader["OrderDate"] == DBNull.Value ? "N/A" : Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 12, FontStyle.Italic),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        };

                        ComboBox shipmentStatusComboBox = new ComboBox
                        {
                            Text = reader["ShipmentStatus"] == DBNull.Value ? "N/A" : reader["ShipmentStatus"].ToString(),
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            DropDownStyle = ComboBoxStyle.DropDownList,
                            Dock = DockStyle.Fill
                        };
                        shipmentStatusComboBox.Items.AddRange(new object[] { "Pending", "Shipped", "In Transit", "Delivered", "Returned", "Cancelled" });
                        shipmentStatusComboBox.SelectedIndexChanged += (s, ev) =>
                        {
                            UpdateShipmentStatus(currentOrderID, shipmentStatusComboBox.SelectedItem.ToString());
                        };

                        DateTimePicker deliveryDatePicker = new DateTimePicker
                        {
                            Value = reader["DeliveryDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["DeliveryDate"]),
                            Format = DateTimePickerFormat.Short,
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            Dock = DockStyle.Fill
                        };
                        deliveryDatePicker.ValueChanged += (s, ev) =>
                        {
                            UpdateDeliveryDate(currentOrderID, deliveryDatePicker.Value);
                        };

                        Label storeNameLabel = new Label
                        {
                            Text = reader["StoreName"] == DBNull.Value ? "N/A" : reader["StoreName"].ToString(),
                            AutoSize = true,
                            Font = new Font("Century Gothic", 12, FontStyle.Regular),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill
                        };


                        orderTable.RowCount++;
                        orderTable.Controls.Add(productNameLabel, 1, orderTable.RowCount - 1);
                        orderTable.Controls.Add(quantityLabel, 2, orderTable.RowCount - 1);
                        orderTable.Controls.Add(grandTotalLabel, 3, orderTable.RowCount - 1);
                        orderTable.Controls.Add(orderDateLabel, 4, orderTable.RowCount - 1);
                        orderTable.Controls.Add(shipmentStatusComboBox, 5, orderTable.RowCount - 1);
                        orderTable.Controls.Add(storeNameLabel, 6, orderTable.RowCount - 1);
                        orderTable.Controls.Add(deliveryDatePicker, 7, orderTable.RowCount - 1);
                    }

                    if (orderTable != null)
                    {
                        LogisticsDashboard_flow.Controls.Add(orderTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void UpdateShipmentStatus(int orderID, string newStatus)
        {
            try
            {
                con.Open();
                string updateQuery = "UPDATE ORDERS SET Shipment_Status = @Status, ";

                if (newStatus == "Shipped")
                {
                    updateQuery += "OrderShipped = @OrderShipped ";
                }
                else if (newStatus == "Delivered")
                {
                    updateQuery += "Delivery_Date = @DeliveryDate, EstDelivery_Date = @EstDeliveryDate ";
                }
                else
                {
                    updateQuery += "OrderShipped = NULL ";
                }

                updateQuery += "WHERE OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                if (newStatus == "Shipped")
                {
                    cmd.Parameters.AddWithValue("@OrderShipped", DateTime.Now);
                }
                else if (newStatus == "Delivered")
                {
                    DateTime currentDate = DateTime.Now;
                    cmd.Parameters.AddWithValue("@DeliveryDate", currentDate);
                    cmd.Parameters.AddWithValue("@EstDeliveryDate", currentDate);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating shipment status: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }



        private void UpdateDeliveryDate(int orderID, DateTime newDate)
        {
            try
            {
                con.Open();
                string updateQuery = "UPDATE ORDERS SET Delivery_Date = @DeliveryDate WHERE OrderID = @OrderID";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@DeliveryDate", newDate);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating delivery date: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
