using System;
using System.Collections;
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
    public partial class ProductInfo : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public string ProdName { get; set; }


        public ProductInfo(string productName, string loggedInEmail)
        {
            InitializeComponent();
            ProdName = productName;
            LoggedInEmail = loggedInEmail;
    

        }


        public string LoggedInEmail { get; set; }
        private void ProductInfo_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = @"
SELECT p.Prod_Name, p.Prod_Price, p.Prod_Description, p.Prod_Picture, s.Seller_StoreName
FROM PRODUCTS p
JOIN SELLER s ON p.SellerID = s.SellerID
WHERE p.Prod_Name = @ProdName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProdName", ProdName);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ProdInfo_ProdName_label.Text = reader["Prod_Name"].ToString();
                    ProdInfo_Price_label.Text = $"Price: ${Convert.ToDecimal(reader["Prod_Price"]):0.00}";
                    ProdInfo_ProdDesc_label.Text = reader["Prod_Description"].ToString();
                    ProdInfo_StoreName_labellink.Text = $"Store: {reader["Seller_StoreName"].ToString()}";

                    string imagePath = reader["Prod_Picture"].ToString();

                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        ProductInfo_ProdPic_image.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        ProductInfo_ProdPic_image.Image = null;
                    }
                }

                reader.Close();

                string custIdQuery = @"
SELECT c.CustID 
FROM CUSTOMERS c
INNER JOIN USERS u ON c.UserID = u.UserID 
WHERE u.User_Mail = @Email";
                SqlCommand custIdCmd = new SqlCommand(custIdQuery, con);
                custIdCmd.Parameters.AddWithValue("@Email", LoggedInEmail);

                object result = custIdCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int custID = Convert.ToInt32(result);

                string orderCheckQuery = @"
SELECT COUNT(*) 
FROM ORDERS o
JOIN ORDER_ITEM od ON o.OrderID = od.OrderID
WHERE o.CustID = @CustID AND od.ProdID = (
    SELECT ProdID FROM PRODUCTS WHERE Prod_Name = @ProdName
)";
                SqlCommand orderCheckCmd = new SqlCommand(orderCheckQuery, con);
                orderCheckCmd.Parameters.AddWithValue("@CustID", custID);
                orderCheckCmd.Parameters.AddWithValue("@ProdName", ProdName);

                int hasOrdered = Convert.ToInt32(orderCheckCmd.ExecuteScalar());

                if (hasOrdered > 0)
                {
                    ProdInfo_WriteReview_Textbox.Visible = true;
                    ProdInfo_RatingComboBox.Visible = true;
                    ProdInfo_PostReviewButton.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    ProdInfo_WriteReview_Textbox.Visible = false;
                    ProdInfo_RatingComboBox.Visible = false;
                    ProdInfo_PostReviewButton.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                }

                string prodIdQuery = @"
SELECT ProdID
FROM PRODUCTS
WHERE Prod_Name = @ProdName";
                SqlCommand prodIdCmd = new SqlCommand(prodIdQuery, con);
                prodIdCmd.Parameters.AddWithValue("@ProdName", ProdName);

                SqlDataReader prodIdReader = prodIdCmd.ExecuteReader();

                int ProdID = 0;
                if (prodIdReader.Read())
                {
                    ProdID = Convert.ToInt32(prodIdReader["ProdID"]);
                }

                prodIdReader.Close();

                string reviewQuery = @"
SELECT u.User_FName + ' ' + u.User_LName AS Cust_Name, 
       r.Comment AS Review_Comment, 
       r.Rating AS Review_Rating, 
       r.R_Date AS Review_Date
FROM REVIEW r
JOIN CUSTOMERS c ON r.CustID = c.CustID
JOIN USERS u ON c.UserID = u.UserID
WHERE r.ProdID = @ProdID
ORDER BY r.R_Date DESC";

                SqlCommand reviewCmd = new SqlCommand(reviewQuery, con);
                reviewCmd.Parameters.AddWithValue("@ProdID", ProdID);

                SqlDataReader reviewReader = reviewCmd.ExecuteReader();

                while (reviewReader.Read())
                {
                    FlowLayoutPanel reviewPanel = new FlowLayoutPanel();
                    reviewPanel.FlowDirection = FlowDirection.LeftToRight;
                    reviewPanel.AutoSize = true;
                    reviewPanel.WrapContents = false;

                    Label nameLabel = new Label();
                    nameLabel.Text = reviewReader["Cust_Name"].ToString();
                    nameLabel.Font = new Font("Century Gothic", 18, FontStyle.Bold);
                    nameLabel.AutoSize = true;
                    reviewPanel.Controls.Add(nameLabel);

                    Label commentLabel = new Label();
                    commentLabel.Text = reviewReader["Review_Comment"].ToString();
                    commentLabel.Font = new Font("Century Gothic", 18);
                    commentLabel.AutoSize = true;
                    reviewPanel.Controls.Add(commentLabel);

                    Label ratingLabel = new Label();
                    ratingLabel.Text = $"Rating: {reviewReader["Review_Rating"]}";
                    ratingLabel.Font = new Font("Century Gothic", 18);
                    ratingLabel.AutoSize = true;
                    reviewPanel.Controls.Add(ratingLabel);

                    Label dateLabel = new Label();
                    dateLabel.Text = Convert.ToDateTime(reviewReader["Review_Date"]).ToString("yyyy-MM-dd");
                    dateLabel.Font = new Font("Century Gothic", 18);
                    dateLabel.AutoSize = true;
                    reviewPanel.Controls.Add(dateLabel);

                    ProdInfo_Review_flowpanel.Controls.Add(reviewPanel);
                }

                reviewReader.Close();
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



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductInfo_ProdPic_image_Click(object sender, EventArgs e)
        {

        }

        private void ProdInfo_Back_Button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void ProdInfo_AddToCart_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query1 = "SELECT ProdID, Prod_Price FROM PRODUCTS WHERE Prod_Name = @ProdName";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@ProdName", ProdName);

                SqlDataReader reader1 = cmd1.ExecuteReader();
                if (!reader1.HasRows)
                {
                    MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reader1.Read();
                int ProductID = Convert.ToInt32(reader1["ProdID"]);
                decimal ProdPrice = Convert.ToDecimal(reader1["Prod_Price"]);
                reader1.Close();

                string query2 = @"
    SELECT c.CustID 
    FROM CUSTOMERS c
    INNER JOIN USERS u ON c.UserID = u.UserID 
    WHERE u.User_Mail = @Email";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@Email", LoggedInEmail);

                object result = cmd2.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int custId = Convert.ToInt32(result);

                string checkCartQuery = @"
    SELECT CartID 
    FROM CART 
    WHERE CustID = @CustID AND Cart_SessStart IS NOT NULL AND Cart_SessStart > @SessionStartDate";
                SqlCommand checkCartCmd = new SqlCommand(checkCartQuery, con);
                checkCartCmd.Parameters.AddWithValue("@CustID", custId);
                checkCartCmd.Parameters.AddWithValue("@SessionStartDate", DateTime.Now.AddDays(-30)); 

                object cartResult = checkCartCmd.ExecuteScalar();
                int cartID = 0;

                if (cartResult != null)
                {
                    cartID = Convert.ToInt32(cartResult);
                    Console.WriteLine($"Existing cart found: CartID = {cartID}"); 
                }
                else
                {
                    Console.WriteLine("No existing cart found, will create new cart.");
                }

                if (cartID > 0)
                {
                    string checkQuery = @"
        SELECT CartID, Cart_ProdQuant, Cart_TotalValue 
        FROM CART 
        WHERE CartID = @CartID AND ProdID = @ProdID";

                    SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@CartID", cartID);
                    checkCmd.Parameters.AddWithValue("@ProdID", ProductID);

                    SqlDataReader checkReader = checkCmd.ExecuteReader();

                    if (checkReader.HasRows)
                    {
                        checkReader.Read();
                        int existingQuantity = Convert.ToInt32(checkReader["Cart_ProdQuant"]);
                        decimal existingTotalValue = Convert.ToDecimal(checkReader["Cart_TotalValue"]);
                        checkReader.Close();

                        string updateQuery = @"
            UPDATE CART 
            SET Cart_ProdQuant = @Cart_ProdQuant, Cart_TotalValue = @Cart_TotalValue
            WHERE CartID = @CartID AND ProdID = @ProdID";

                        SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@Cart_ProdQuant", existingQuantity + 1);
                        updateCmd.Parameters.AddWithValue("@Cart_TotalValue", existingTotalValue + ProdPrice);
                        updateCmd.Parameters.AddWithValue("@CartID", cartID);
                        updateCmd.Parameters.AddWithValue("@ProdID", ProductID);

                        updateCmd.ExecuteNonQuery();
                        Console.WriteLine($"Updated cart: CartID = {cartID}, ProductID = {ProductID}");
                    }
                    else
                    {
                        checkReader.Close();
                       
                        string addProductQuery = @"
            INSERT INTO CART (CustID, ProdID, Cart_TotalItems, Cart_TotalValue, Cart_ProdQuant, Cart_SessStart)
            VALUES (@CustID, @ProdID, 1, @ProdPrice, 1, @Cart_SessStart)";

                        SqlCommand addProductCmd = new SqlCommand(addProductQuery, con);
                        addProductCmd.Parameters.AddWithValue("@CustID", custId);
                        addProductCmd.Parameters.AddWithValue("@ProdID", ProductID);
                        addProductCmd.Parameters.AddWithValue("@ProdPrice", ProdPrice);
                        addProductCmd.Parameters.AddWithValue("@Cart_SessStart", DateTime.Now);

                        addProductCmd.ExecuteNonQuery();
                        Console.WriteLine($"Product added to cart: CartID = {cartID}, ProductID = {ProductID}");
                    }
                }
                else 
                {
                    string insertCartQuery = @"
        INSERT INTO CART (CustID, ProdID, Cart_TotalItems, Cart_TotalValue, Cart_ProdQuant, Cart_SessStart)
        VALUES (@CustID, @ProdID, 1, @ProdPrice, 1, @Cart_SessStart)";

                    SqlCommand insertCartCmd = new SqlCommand(insertCartQuery, con);
                    insertCartCmd.Parameters.AddWithValue("@CustID", custId);
                    insertCartCmd.Parameters.AddWithValue("@ProdID", ProductID);
                    insertCartCmd.Parameters.AddWithValue("@ProdPrice", ProdPrice);
                    insertCartCmd.Parameters.AddWithValue("@Cart_SessStart", DateTime.Now);

                    insertCartCmd.ExecuteNonQuery();
                    Console.WriteLine($"New cart created for customer: CartID = {cartID}, ProductID = {ProductID}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Product Added To Cart!");
                con.Close();
            }

        }



        private void ProdInfo_BuyNow_Button_Click(object sender, EventArgs e)
        {
            CustCheckout custCheckout = new CustCheckout(LoggedInEmail);
            custCheckout.Show();
            this.Hide();
        }

        private void ProdInfo_Review_flowpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ProdInfo_WriteReview_Textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdInfo_PostReviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ProdInfo_WriteReview_Textbox.Text))
                {
                    MessageBox.Show("Please write a review comment before posting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rating = Convert.ToInt32(ProdInfo_RatingComboBox.SelectedItem); 
                string comment = ProdInfo_WriteReview_Textbox.Text;

                con.Open();
                string prodIdQuery = @"
            SELECT ProdID
            FROM PRODUCTS
            WHERE Prod_Name = @ProdName";
                SqlCommand prodIdCmd = new SqlCommand(prodIdQuery, con);
                prodIdCmd.Parameters.AddWithValue("@ProdName", ProdName);

                SqlDataReader prodIdReader = prodIdCmd.ExecuteReader();
                int prodID = 0;

                if (prodIdReader.Read())
                {
                    prodID = Convert.ToInt32(prodIdReader["ProdID"]);
                }
                prodIdReader.Close();

                string custIdQuery = @"
            SELECT c.CustID 
            FROM CUSTOMERS c
            INNER JOIN USERS u ON c.UserID = u.UserID 
            WHERE u.User_Mail = @Email";
                SqlCommand custIdCmd = new SqlCommand(custIdQuery, con);
                custIdCmd.Parameters.AddWithValue("@Email", LoggedInEmail);

                object result = custIdCmd.ExecuteScalar();
                int custID = 0;

                if (result != null)
                {
                    custID = Convert.ToInt32(result);
                }

                string insertReviewQuery = @"
            INSERT INTO REVIEW (ProdID, CustID, Rating, Comment, R_Date)
            VALUES (@ProdID, @CustID, @Rating, @Comment, @R_Date)";

                SqlCommand insertReviewCmd = new SqlCommand(insertReviewQuery, con);
                insertReviewCmd.Parameters.AddWithValue("@ProdID", prodID);
                insertReviewCmd.Parameters.AddWithValue("@CustID", custID);
                insertReviewCmd.Parameters.AddWithValue("@Rating", rating);
                insertReviewCmd.Parameters.AddWithValue("@Comment", comment);
                insertReviewCmd.Parameters.AddWithValue("@R_Date", DateTime.Now);

                int rowsAffected = insertReviewCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Review posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to post review. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
