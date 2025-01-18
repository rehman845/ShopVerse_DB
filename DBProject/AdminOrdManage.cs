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
    public partial class AdminOrdManage : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public AdminOrdManage(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void AdminOrdManage_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminOrdManage_Load(object sender, EventArgs e)
        {
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
                o.Tracking_Number
            FROM ORDERS o
            JOIN ORDER_ITEM od ON o.OrderID = od.OrderID
            JOIN PRODUCTS p ON od.ProdID = p.ProdID
            WHERE 1=1");

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
                AdminOrdFlow.Controls.Clear();

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

                    Label lblOrderID = new Label { Text = "Order ID: " + reader["OrderID"], AutoSize = true, Location = new Point(10, 10) };
                    Label lblCustID = new Label { Text = "Customer ID: " + reader["CustID"], AutoSize = true, Location = new Point(10, 30) };
                  
                    string product = reader["Product"] != DBNull.Value ? reader["Product"].ToString() : "N/A";
                    Label lblProduct = new Label { Text = "Product: " + product, AutoSize = true, Location = new Point(10, 50) };

                    int quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;
                    Label lblQuantity = new Label { Text = "Quantity: " + quantity, AutoSize = true, Location = new Point(10, 70) };

                    decimal grandTotal = reader["Grand_Total"] != DBNull.Value ? Convert.ToDecimal(reader["Grand_Total"]) : 0.00m;
                    Label lblGrandTotal = new Label { Text = "Grand Total: $" + grandTotal.ToString("0.00"), AutoSize = true, Location = new Point(10, 90) };

                    Label lblLogisticsID = new Label { Text = "Logistics ID: " + (reader["LogisticsID"] != DBNull.Value ? reader["LogisticsID"].ToString() : "N/A"), AutoSize = true, Location = new Point(400, 10) };

                    string shipmentStatus = reader["Shipment_Status"] != DBNull.Value ? reader["Shipment_Status"].ToString() : "Not Available";
                    Label lblShipmentStatus = new Label { Text = "Shipment Status: " + shipmentStatus, AutoSize = true, Location = new Point(400, 30) };

                    string orderDate = reader["Order_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Order_Date"]).ToString("yyyy-MM-dd") : "N/A";
                    Label lblOrderDate = new Label { Text = "Order Date: " + orderDate, AutoSize = true, Location = new Point(400, 50) };

                    string deliveryDate = reader["Delivery_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Delivery_Date"]).ToString("yyyy-MM-dd") : "N/A";
                    Label lblDeliveryDate = new Label { Text = "Delivery Date: " + deliveryDate, AutoSize = true, Location = new Point(400, 70) };

                    string trackingNumber = reader["Tracking_Number"] != DBNull.Value ? reader["Tracking_Number"].ToString() : "N/A";
                    Label lblTrackingNumber = new Label { Text = "Tracking Number: " + trackingNumber, AutoSize = true, Location = new Point(400, 90) };

                    string orderReturnText = reader["Order_Return"] != DBNull.Value && Convert.ToBoolean(reader["Order_Return"]) ? "Return Requested" : "No Return Request";
                    Color orderReturnColor = reader["Order_Return"] != DBNull.Value && Convert.ToBoolean(reader["Order_Return"]) ? Color.Red : Color.Green;
                    Label lblOrderReturn = new Label
                    {
                        Text = orderReturnText,
                        ForeColor = orderReturnColor,
                        AutoSize = true,
                        Location = new Point(600, 10)
                    };

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
                    orderPanel.Controls.Add(lblOrderReturn);

                    AdminOrdFlow.Controls.Add(orderPanel);
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
            AdminOrdManage_Load(sender, e);
        }

        private void txtClearlFilter_Click(object sender, EventArgs e)
        {
            txtOrdID.Clear();
            txtCust.Clear();
            txtProd.Clear();
            txtStartDate.Clear();
            txtEndDate.Clear();

            AdminOrdManage_Load(sender, e);
        }
    }
}
