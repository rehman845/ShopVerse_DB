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
    public partial class SellerInventory : Form
    {

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerInventory(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void SellerInventory_AddProd_Button_Click(object sender, EventArgs e)
        {
            SellerProdEdit sellerProdEdit = new SellerProdEdit(LoggedInEmail);
            sellerProdEdit.Show();
            this.Hide();
        }

        private void SellerInventory_RemoveProd_Button_Click(object sender, EventArgs e)
        {
            SellerProdEdit sellerProdEdit = new SellerProdEdit(LoggedInEmail);
            sellerProdEdit.Show();
            this.Hide();
        }

        private void SellerInventory_UpdateProd_Button_Click(object sender, EventArgs e)
        {
            SellerProdEdit sellerProdEdit = new SellerProdEdit(LoggedInEmail);
            sellerProdEdit.Show();
            this.Hide();
        }

        private void SellerInventory_Back_Button_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void SellerInventory_Products_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SellerInventory_Load(object sender, EventArgs e)
        {

            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                p.ProdID, 
                p.Prod_Name, 
                p.Prod_Release, 
                i.Stock, 
                i.Last_Update 
              FROM PRODUCTS p
              JOIN INVENTORY i ON p.ProdID = i.ProdID
              WHERE p.SellerID = @SellerID", con);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                SqlDataReader reader = cmd.ExecuteReader();
                Inventory_Flow.Controls.Clear();

                while (reader.Read())
                {
                    Panel productPanel = new Panel
                    {
                        Width = 500,
                        Height = 80,
                        BackColor = Color.MistyRose,
                        Margin = new Padding(10),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    Label lblProdID = new Label
                    {
                        Text = "Product ID: " + reader["ProdID"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12),
                        Location = new Point(10, 10)
                    };

                    Label lblProdName = new Label
                    {
                        Text = "Name: " + reader["Prod_Name"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12),
                        Location = new Point(10, 30)
                    };

                    Label lblProdRelease = new Label
                    {
                        Text = "Release Date: " + Convert.ToDateTime(reader["Prod_Release"]).ToString("yyyy-MM-dd"),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12),
                        Location = new Point(10, 50)
                    };

                    Label lblStock = new Label
                    {
                        Text = "Stock: " + reader["Stock"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12),
                        Location = new Point(250, 10)
                    };

                    Label lblLastUpdate = new Label
                    {
                        Text = "Last Update: " + Convert.ToDateTime(reader["Last_Update"]).ToString("yyyy-MM-dd"),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12),
                        Location = new Point(250, 30)
                    };

                    productPanel.Controls.Add(lblProdID);
                    productPanel.Controls.Add(lblProdName);
                    productPanel.Controls.Add(lblProdRelease);
                    productPanel.Controls.Add(lblStock);
                    productPanel.Controls.Add(lblLastUpdate);

                    Inventory_Flow.Controls.Add(productPanel);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
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

    }
}
