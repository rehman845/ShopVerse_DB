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
    public partial class CustCart : Form
    {
       
        public CustCart(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
          
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");


        public string LoggedInEmail { get; set; }



        private void Cart_Back_Button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void Cart_CartItems_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Cart_CheckOut_Button_Click(object sender, EventArgs e)
        {
            CustCheckout custCheckout = new CustCheckout(LoggedInEmail);
            custCheckout.Show();
            this.Hide();
        }

        private void CustCart_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string userMail = LoggedInEmail;

                string query = @"
    SELECT 
        c.CartID,
        c.Cart_TotalItems,
        c.Cart_TotalValue,
        c.Cart_ProdQuant,
        c.Cart_SessStart,
         c.ProdID,
        p.Prod_Name,
        p.Prod_Price
    FROM 
        CART c
    INNER JOIN CUSTOMERS cust ON c.CustID = cust.CustID
    INNER JOIN USERS u ON cust.UserID = u.UserID
    INNER JOIN PRODUCTS p ON c.ProdID = p.ProdID
    WHERE 
        u.User_Mail = @UserMail;
    ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserMail", userMail);

                Cart_CartItems_FlowLayout.Controls.Clear();
                decimal totalCartValue = 0;
                int totalItems = 0;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        decimal productPrice = Convert.ToDecimal(reader["Prod_Price"]);
                        int productQuantity = Convert.ToInt32(reader["Cart_ProdQuant"]);

                        totalCartValue += productPrice * productQuantity;
                        totalItems += productQuantity;


                        TableLayoutPanel cartItemsTable = new TableLayoutPanel
                        {
                            AutoSize = true,
                            ColumnCount = 4,
                            RowCount = 1,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Margin = new Padding(10),
                            Padding = new Padding(10),
                            Dock = DockStyle.Top,
                            BackColor = Color.NavajoWhite
                        };

                        cartItemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
                        cartItemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        cartItemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        cartItemsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

                        Label productName = new Label
                        {
                            Text = reader["Prod_Name"].ToString(),
                            AutoSize = false,
                            Font = new Font("Century Gothic", 18, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Label productPriceLabel = new Label
                        {
                            Text = $"${productPrice:0.00}",
                            AutoSize = false,
                            Font = new Font("Century Gothic", 18, FontStyle.Regular),
                            ForeColor = Color.DarkGreen,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        TextBox productQuantityTextBox = new TextBox
                        {
                            Text = productQuantity.ToString(),
                            Font = new Font("Century Gothic", 18, FontStyle.Regular),
                            ForeColor = Color.DarkRed,
                            TextAlign = HorizontalAlignment.Center,
                            Dock = DockStyle.Fill,
                            Margin = new Padding(5),
                            Tag = reader["CartID"]
                        };

                        productQuantityTextBox.Leave += (s, ev) =>
                        {
                            try
                            {
                                int cartId = Convert.ToInt32((s as TextBox).Tag);
                                int newQuantity;

                                if (int.TryParse(productQuantityTextBox.Text, out newQuantity) && newQuantity > 0)
                                {
                                    string updateProductQuantityQuery = "UPDATE CART SET Cart_ProdQuant = @NewQuantity WHERE CartID = @CartId";

                                    using (SqlCommand updateCmd = new SqlCommand(updateProductQuantityQuery, con))
                                    {
                                        updateCmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                                        updateCmd.Parameters.AddWithValue("@CartId", cartId);

                                        con.Open();
                                        updateCmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid quantity entered. Please enter a positive number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                if (con.State == ConnectionState.Open)
                                    con.Close();
                            }
                        };



                        Button deleteButton = new Button
                        {
                            Text = "Delete",
                            AutoSize = true,
                            Font = new Font("Century Gothic", 10, FontStyle.Regular),
                            ForeColor = Color.White,
                            BackColor = Color.Red,
                            Tag = reader["CartID"],
                            Dock = DockStyle.Fill,
                            Margin = new Padding(5)
                        };
                        deleteButton.Click += CustCart_DeleteProd_button_Click;

                        cartItemsTable.Controls.Add(productName, 0, 0);
                        cartItemsTable.Controls.Add(productPriceLabel, 1, 0);
                        cartItemsTable.Controls.Add(productQuantityTextBox, 2, 0);

                        cartItemsTable.Controls.Add(deleteButton, 3, 0);

                        Cart_CartItems_FlowLayout.Controls.Add(cartItemsTable);
                    }
                }

                Cart_TotalValue_Label.Text = $"${totalCartValue:0.00}";

                


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

        private void CustCart_DeleteProd_button_Click(object sender, EventArgs e)
        {
            try
            {
               
                int cartId = Convert.ToInt32((sender as Button).Tag);

                string deleteQuery = "DELETE FROM CART WHERE CartID = @CartId";

                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                {
                    deleteCmd.Parameters.AddWithValue("@CartId", cartId);

                    con.Open();
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product successfully removed from the cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product could not be removed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
