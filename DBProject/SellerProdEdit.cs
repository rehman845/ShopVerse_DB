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
    public partial class SellerProdEdit : Form
    {
        public SellerProdEdit(string loggedInEmail)
        {

            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void SellerProdEdit_Back_Button_Click(object sender, EventArgs e)
        {
           SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SellerProdEdit_RemoveProd_Button_Click(object sender, EventArgs e)
        {
            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            string productName = SellerProdEdit_ProdName_txtfield.Text;

            try
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT ProdID FROM PRODUCTS WHERE Prod_Name = @ProdName AND SellerID = @SellerID", con);
                checkCmd.Parameters.AddWithValue("@ProdName", productName);
                checkCmd.Parameters.AddWithValue("@SellerID", sellerID);

                object result = checkCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Product not found.");
                    return;
                }

                int productId = (int)result;

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM INVENTORY WHERE ProdID = @ProdID; DELETE FROM PRODUCTS WHERE ProdID = @ProdID;", con);
                deleteCmd.Parameters.AddWithValue("@ProdID", productId);

                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Product removed successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing product: " + ex.Message);
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


        private void SellerProdEdit_AddProd_Button_Click(object sender, EventArgs e)
        {
            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            string productName = SellerProdEdit_ProdName_txtfield.Text;
            string priceText = SellerProdEdit_Price_txtfield.Text;
            string categoryText = SellerProdEdit_Category_txtfield.Text;
            string stockText = SellerProdEdit_Stock_txtfield.Text;
            string picPath = SellerProdEdit_PicPath_txtfield.Text;

            if (!float.TryParse(priceText, out float price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            if (!int.TryParse(categoryText, out int category))
            {
                MessageBox.Show("Please enter a valid category.");
                return;
            }

            if (!int.TryParse(stockText, out int stock))
            {
                MessageBox.Show("Please enter a valid stock number.");
                return;
            }



            try
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM PRODUCTS WHERE Prod_Name = @ProdName AND SellerID = @SellerID", con);
                checkCmd.Parameters.AddWithValue("@ProdName", productName);
                checkCmd.Parameters.AddWithValue("@SellerID", sellerID);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Product already exists.");
                    return;
                }

                SqlCommand addCmd = new SqlCommand(
                    "INSERT INTO PRODUCTS (Prod_Name, Prod_Description, Prod_Price, CatID, SellerID, Prod_Release, Prod_Picture) VALUES (@ProdName, @Description, @Price, @Category, @SellerID, GETDATE(), @PicPath); " +
                    "INSERT INTO INVENTORY (ProdID, SellerID, Stock, Last_Update) VALUES (SCOPE_IDENTITY(), @SellerID, @Stock, GETDATE());", con);
                addCmd.Parameters.AddWithValue("@ProdName", productName);
                addCmd.Parameters.AddWithValue("@Description", SellerProdEdit_ProdDesc_txtfield.Text);
                addCmd.Parameters.AddWithValue("@Price", price);
                addCmd.Parameters.AddWithValue("@Category", category);
                addCmd.Parameters.AddWithValue("@SellerID", sellerID);
                addCmd.Parameters.AddWithValue("@Stock", stock);
                addCmd.Parameters.AddWithValue("@PicPath", picPath);

                addCmd.ExecuteNonQuery();
                MessageBox.Show("Product added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SellerProdEdit_UpdateProd_Button_Click(object sender, EventArgs e)
        {
            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            string productName = SellerProdEdit_ProdName_txtfield.Text;

            try
            {
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT ProdID FROM PRODUCTS WHERE Prod_Name = @ProdName AND SellerID = @SellerID", con);
                checkCmd.Parameters.AddWithValue("@ProdName", productName);
                checkCmd.Parameters.AddWithValue("@SellerID", sellerID);

                object result = checkCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Product not found.");
                    return;
                }

                int productId = (int)result;

                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE PRODUCTS SET Prod_Description = @Description, Prod_Price = @Price, CatID = @Category, Prod_Picture = @PicPath WHERE ProdID = @ProdID; " +
                    "UPDATE INVENTORY SET Stock = @Stock, Last_Update = GETDATE() WHERE ProdID = @ProdID;", con);
                updateCmd.Parameters.AddWithValue("@Description", SellerProdEdit_ProdDesc_txtfield.Text);
                updateCmd.Parameters.AddWithValue("@Price", float.Parse(SellerProdEdit_Price_txtfield.Text));
                updateCmd.Parameters.AddWithValue("@Category", int.Parse(SellerProdEdit_Category_txtfield.Text));
                updateCmd.Parameters.AddWithValue("@Stock", int.Parse(SellerProdEdit_Stock_txtfield.Text));
                updateCmd.Parameters.AddWithValue("@ProdID", productId);
                updateCmd.Parameters.AddWithValue("@PicPath", SellerProdEdit_PicPath_txtfield.Text);

                updateCmd.ExecuteNonQuery();
                MessageBox.Show("Product updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SellerProdEdit_Load(object sender, EventArgs e)
        {

        }

        private void SellerProdEdit_ViewProd_Button_Click(object sender, EventArgs e)
        {
            int sellerID = GetSellerID();
            if (sellerID == -1) return;

            string productName = SellerProdEdit_ProdName_txtfield.Text;

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT p.Prod_Name, p.Prod_Description, p.Prod_Price, p.CatID, p.Prod_Picture, i.Stock " +
                    "FROM PRODUCTS p " +
                    "INNER JOIN INVENTORY i ON p.ProdID = i.ProdID " +
                    "WHERE p.Prod_Name = @ProdName AND p.SellerID = @SellerID", con);
                cmd.Parameters.AddWithValue("@ProdName", productName);
                cmd.Parameters.AddWithValue("@SellerID", sellerID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string description = reader["Prod_Description"].ToString();
                    float price = float.Parse(reader["Prod_Price"].ToString());
                    int category = int.Parse(reader["CatID"].ToString());
                    string picPath = reader["Prod_Picture"].ToString();
                    int stock = int.Parse(reader["Stock"].ToString());

                    SellerProdEdit_ProdDesc_txtfield.Text = description;
                    SellerProdEdit_Price_txtfield.Text = price.ToString();
                    SellerProdEdit_Category_txtfield.Text = category.ToString();
                    SellerProdEdit_PicPath_txtfield.Text = picPath;
                    SellerProdEdit_Stock_txtfield.Text = stock.ToString();

                    MessageBox.Show("Product details loaded successfully.");
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product details: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
