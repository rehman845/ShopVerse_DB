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
    public partial class CustCheckout : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustCheckout(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        
        }

        public string LoggedInEmail { get; set; }


        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Checkout_Back_Button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void Checkout_PlaceOrder_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int customerID = GetCustomerID(LoggedInEmail);
                if (customerID == -1)
                {
                    MessageBox.Show("Customer not found!");
                    return;
                }

                List<int> cartIDs = GetCartIDs(customerID);

                int logisticsID = GetRandomLogisticsID();

                foreach (int cartID in cartIDs)
                {
                    int orderID = InsertOrder(customerID, logisticsID, cartID);

                    List<int> sellerIDs = ProcessCartItems(cartID, orderID);

                    if (sellerIDs.Count > 0)
                    {
                        UpdateOrderSeller(orderID, sellerIDs.First());
                    }

                    InsertPayment(orderID, cartID);

                    ClearCart(cartID);
                }

                OrderPlaced orderPlaced = new OrderPlaced(LoggedInEmail);
                orderPlaced.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Order Placement Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearCart(int cartID)
        {
            string query = "DELETE FROM CART WHERE CartID = @CartID";

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CartID", cartID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private int GetCustomerID(string email)
            {
                string query = @"
        SELECT CustID 
        FROM CUSTOMERS c
        INNER JOIN USERS u ON c.UserID = u.UserID
        WHERE u.User_Mail = @Email";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Email", email);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }

            private List<int> GetCartIDs(int customerID)
            {
                List<int> cartIDs = new List<int>();
                string query = "SELECT CartID FROM CART WHERE CustID = @CustomerID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cartIDs.Add(reader.GetInt32(0));
                    }
                }

                return cartIDs;
            }

            private int GetRandomLogisticsID()
            {
                string query = "SELECT TOP 1 ShipperID FROM LOGISTICS ORDER BY NEWID()";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

        private int InsertOrder(int customerID, int logisticsID, int cartID)
        {
            string query = @"
    INSERT INTO Orders 
        (CustID, Order_Date, Order_Amount, LogisticsID, Order_Return, Tracking_Number, Shipment_Status, Delivery_Date, EstDelivery_Date, OrderShipped, SellerAccept, Return_Approve)
    VALUES 
        (@CustID, @Order_Date, @Order_Amount, @LogisticsID, 0, @Tracking_Number, 'In Transit', @Delivery_Date, @EstDelivery_Date, @OrderShipped, 0, 0);
    SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                DateTime orderDate = DateTime.Now;
                DateTime deliveryDate = orderDate.AddDays(14); 
                DateTime estimatedDeliveryDate = orderDate.AddDays(16); 
                DateTime shippedDate = deliveryDate.AddDays(-3); 

                cmd.Parameters.AddWithValue("@CustID", customerID);
                cmd.Parameters.AddWithValue("@Order_Date", orderDate);
                cmd.Parameters.AddWithValue("@Order_Amount", CalculateTotalAmount(cartID));
                cmd.Parameters.AddWithValue("@LogisticsID", logisticsID);
                cmd.Parameters.AddWithValue("@Tracking_Number", GenerateRandomTrackingNumber());
                cmd.Parameters.AddWithValue("@Delivery_Date", deliveryDate);
                cmd.Parameters.AddWithValue("@EstDelivery_Date", estimatedDeliveryDate);
                cmd.Parameters.AddWithValue("@OrderShipped", shippedDate);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        private List<int> ProcessCartItems(int cartID, int orderID)
            {
                List<int> sellerIDs = new List<int>();
                string query = @"
        SELECT CAST(c.Cart_ProdQuant AS INT), 
               CAST(p.Prod_Price AS FLOAT), 
               p.ProdID, 
               p.SellerID
        FROM CART c
        JOIN PRODUCTS p ON c.ProdID = p.ProdID
        WHERE c.CartID = @CartID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productID = reader.GetInt32(2);
                        int productQuantity = reader.GetInt32(0);
                        float productPrice = (float)reader.GetDouble(1);
                        int sellerID = reader.GetInt32(3);

                        if (!sellerIDs.Contains(sellerID))
                        {
                            sellerIDs.Add(sellerID);
                        }

                        InsertOrderItem(orderID, productID, productPrice, productQuantity);

                        UpdateInventory(productID, sellerID, productQuantity);
                    }
                }

                return sellerIDs;
            }

            private void InsertOrderItem(int orderID, int productID, float productPrice, int productQuantity)
            {
                string query = @"
        INSERT INTO ORDER_ITEM (OrderID, ProdID, Order_Amount, Item_Quant)
        VALUES (@OrderID, @ProdID, @Order_Amount, @Item_Quant)";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@ProdID", productID);
                    cmd.Parameters.AddWithValue("@Order_Amount", productPrice);
                    cmd.Parameters.AddWithValue("@Item_Quant", productQuantity);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            private void UpdateInventory(int productID, int sellerID, int productQuantity)
            {
                string query = @"
        UPDATE INVENTORY 
        SET Stock = Stock - @Item_Quant, Last_Update = @Last_Update 
        WHERE ProdID = @ProdID AND SellerID = @SellerID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Item_Quant", productQuantity);
                    cmd.Parameters.AddWithValue("@Last_Update", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ProdID", productID);
                    cmd.Parameters.AddWithValue("@SellerID", sellerID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            private void UpdateOrderSeller(int orderID, int sellerID)
            {
                string query = "UPDATE Orders SET SellerID = @SellerID WHERE OrderID = @OrderID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SellerID", sellerID);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            private void InsertPayment(int orderID, int cartID)
            {
                string query = @"
        INSERT INTO PAYMENTS (OrderID, Payment_Method, Payed_Amount, Payment_Time)
        VALUES (@OrderID, 'Card', @Payed_Amount, @Payment_Time)";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@Payed_Amount", CalculateTotalAmount(cartID));
                    cmd.Parameters.AddWithValue("@Payment_Time", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            private string GenerateRandomTrackingNumber()
            {
                Random random = new Random();
                return random.Next(10000000, 99999999).ToString();
            }

            private float CalculateTotalAmount(int cartID)
            {
                string query = @"
        SELECT SUM(c.Cart_ProdQuant * p.Prod_Price)
        FROM CART c
        JOIN PRODUCTS p ON c.ProdID = p.ProdID
        WHERE c.CartID = @CartID";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    con.Open();
                    return Convert.ToSingle(cmd.ExecuteScalar());
                }
            }


            private void CustCheckout_Load(object sender, EventArgs e)
        {
                try
                {
                    con.Open();
                    string userMail = LoggedInEmail;

                    Checkout_Items_flow.Controls.Clear();
                    Checkout_Address_flow.Controls.Clear();
                    Checkout_PaymentMethod_flow.Controls.Clear();

                    string cartQuery = @"
            SELECT 
                p.Prod_Name, 
                p.Prod_Price, 
                c.Cart_ProdQuant
            FROM 
                CART c
            INNER JOIN CUSTOMERS cust ON c.CustID = cust.CustID
            INNER JOIN USERS u ON cust.UserID = u.UserID
            INNER JOIN PRODUCTS p ON c.ProdID = p.ProdID
            WHERE u.User_Mail = @UserMail";

                    SqlCommand cartCmd = new SqlCommand(cartQuery, con);
                    cartCmd.Parameters.AddWithValue("@UserMail", userMail);
                    decimal totalCartValue = 0;

                    using (SqlDataReader cartReader = cartCmd.ExecuteReader())
                    {
                        while (cartReader.Read())
                        {
                            
                            string productName = cartReader["Prod_Name"].ToString();
                            decimal productPrice = Convert.ToDecimal(cartReader["Prod_Price"]);
                            int productQuantity = Convert.ToInt32(cartReader["Cart_ProdQuant"]);

                            totalCartValue += productPrice * productQuantity;
                       

                        TableLayoutPanel itemTable = new TableLayoutPanel
                            {
                                AutoSize = true,
                                ColumnCount = 3,
                                RowCount = 1,
                                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                Padding = new Padding(10),
                                Dock = DockStyle.Top
                            };

                            itemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                            itemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                            itemTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

                            Label itemNameLabel = new Label
                            {
                                Text = productName,
                                AutoSize = false,
                                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Fill
                            };

                            Label itemPriceLabel = new Label
                            {
                                Text = $"${productPrice:0.00}",
                                AutoSize = false,
                                Font = new Font("Century Gothic", 12, FontStyle.Regular),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            };

                            Label itemQuantityLabel = new Label
                            {
                                Text = $"Qty: {productQuantity}",
                                AutoSize = false,
                                Font = new Font("Century Gothic", 12, FontStyle.Regular),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Dock = DockStyle.Fill
                            };

                            itemTable.Controls.Add(itemNameLabel, 0, 0);
                            itemTable.Controls.Add(itemPriceLabel, 1, 0);
                            itemTable.Controls.Add(itemQuantityLabel, 2, 0);

                            Checkout_Items_flow.Controls.Add(itemTable);
                        }
                    }
                totalCartValue += 150;
                Checkout_Total_label.Text = $"${totalCartValue:0.00}";

                string addressQuery = @"
            SELECT 
                a.Plot, 
                a.Area, 
                a.City, 
                a.Province, 
                a.Country, 
                a.ZipCode
            FROM 
                ADDRESS a
            INNER JOIN CUSTOMERS c ON a.CustID = c.CustID
            INNER JOIN USERS u ON c.UserID = u.UserID
            WHERE u.User_Mail = @UserMail";

                    SqlCommand addressCmd = new SqlCommand(addressQuery, con);
                    addressCmd.Parameters.AddWithValue("@UserMail", userMail);

                    using (SqlDataReader addressReader = addressCmd.ExecuteReader())
                    {
                        if (addressReader.Read())
                        {
                            string plot = addressReader["Plot"].ToString();
                            string area = addressReader["Area"].ToString();
                            string city = addressReader["City"].ToString();
                            string province = addressReader["Province"].ToString();
                            string country = addressReader["Country"].ToString();
                            string zipCode = addressReader["ZipCode"].ToString();

                            Label addressLabel = new Label
                            {
                                Text = $"Address: {plot} {area}, {city}, {province}, {country} - {zipCode}",
                                AutoSize = true,
                                Font = new Font("Century Gothic", 18, FontStyle.Regular),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Top
                            };

                            Checkout_Address_flow.Controls.Add(addressLabel);
                        }
                    }

                    string paymentQuery = @"
            SELECT 
                pm.Card_Num, 
                pm.Bank_Name, 
                pm.Expiry_Date
            FROM 
                CARDS pm
            INNER JOIN CUSTOMERS c ON pm.CustID = c.CustID
            INNER JOIN USERS u ON c.UserID = u.UserID
            WHERE u.User_Mail = @UserMail";

                    SqlCommand paymentCmd = new SqlCommand(paymentQuery, con);
                    paymentCmd.Parameters.AddWithValue("@UserMail", userMail);

                    using (SqlDataReader paymentReader = paymentCmd.ExecuteReader())
                    {
                        if (paymentReader.Read())
                        {
                            string cardNumber = paymentReader["Card_Num"].ToString();
                            string bankName = paymentReader["Bank_Name"].ToString();
                            string expiryDate = Convert.ToDateTime(paymentReader["Expiry_Date"]).ToString("MM/yyyy");

                            Label paymentMethodLabel = new Label
                            {
                                Text = $"Bank: {bankName}\nCard Number: **** **** **** {cardNumber.Substring(cardNumber.Length - 4)}\nExpiry Date: {expiryDate}",
                                AutoSize = true,
                                Font = new Font("Century Gothic", 18, FontStyle.Regular),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Top
                            };

                            Checkout_PaymentMethod_flow.Controls.Add(paymentMethodLabel);
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

        private void Checkout_PayViaCard_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = GetLatestOrderID(); 
                DateTime paymentTime = DateTime.Now;

                string query = @"
            INSERT INTO PAYMENTS (OrderID, Payment_Method, Payed_Amount, Payment_Time)
            VALUES (@OrderID, 'Card', @PayedAmount, @PaymentTime)";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@PayedAmount", GetOrderAmount(orderID)); 
                    cmd.Parameters.AddWithValue("@PaymentTime", paymentTime);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Payment Method set to 'Card'.", "Payment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Payment Method Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Checkout_PayViaCOD_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = GetLatestOrderID(); 
                DateTime paymentTime = DateTime.Now; 

                string query = @"
            INSERT INTO PAYMENTS (OrderID, Payment_Method, Payed_Amount, Payment_Time)
            VALUES (@OrderID, 'CashOnDelivery', @PayedAmount, @PaymentTime)";

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@OrderID", orderID);
                    cmd.Parameters.AddWithValue("@PayedAmount", GetOrderAmount(orderID)); 
                    cmd.Parameters.AddWithValue("@PaymentTime", paymentTime);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Payment Method set to 'Cash on Delivery'.", "Payment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Payment Method Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetLatestOrderID()
        {
            string query = "SELECT TOP 1 OrderID FROM ORDERS ORDER BY Order_Date DESC"; 

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private float GetOrderAmount(int orderID)
        {
            string query = "SELECT Order_Amount FROM ORDERS WHERE OrderID = @OrderID";

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                con.Open();
                return Convert.ToSingle(cmd.ExecuteScalar());
            }
        }



    }
}
