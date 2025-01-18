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
    public partial class CustForYou : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustForYou(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        
        }

        private void CustForYou_Load(object sender, EventArgs e)
        {

            try
            {
                con.Open();

                
                string query = @"
        SELECT TOP 10 
            p.Prod_Name, 
            p.Prod_Price 
            
        FROM PRODUCTS p
        
        GROUP BY p.Prod_Name, p.Prod_Price
        ORDER BY p.Prod_Price DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                CustForYou_ProdLayoutPanel.Controls.Clear(); 

                while (reader.Read())
                {
                    Panel productPanel = new Panel
                    {
                         
                        AutoSize = true,
                        Margin = new Padding(5),
                        
                    };

                    LinkLabel productLink = new LinkLabel
                    {
                        Text = reader["Prod_Name"].ToString(),
                        AutoSize = true,
                        LinkColor = Color.Black,
                        Font = new Font("Century Gothic", 18, FontStyle.Bold),
                        Cursor = Cursors.Hand,
                        Margin = new Padding(0, 10, 0, 20), 
                        
                    };

                    string productName = reader["Prod_Name"].ToString();  

                    productLink.Click += (s, arg) =>
                    {
                        
                        ProductInfo productInfoForm = new ProductInfo(productName, LoggedInEmail);
                        productInfoForm.Show();
                        this.Hide();
                    };


                    Label productPrice = new Label
                    {
                        Text = $"{Environment.NewLine}Price: ${reader["Prod_Price"]:0.00}", 
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.DarkGreen
                        
                    };

                    productPanel.Controls.Add(productLink);
                    productPanel.Controls.Add(productPrice);

                   
                    CustForYou_ProdLayoutPanel.Controls.Add(productPanel);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }






            try
            {
                con.Open();

                string query = "SELECT Cat_Name FROM CATEGORY";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LinkLabel categoryLink = new LinkLabel
                    {
                        Text = reader["Cat_Name"].ToString(),
                        AutoSize = true,
                        Margin = new Padding(5),
                        Cursor = Cursors.Hand,
                        ForeColor = Color.Black,
                        LinkColor = Color.Black,
                        Font = new Font("Century Gothic", 20, FontStyle.Bold)
                    };

                    categoryLink.Click += (s, args) =>
                    {
                        string selectedCategory = categoryLink.Text;

                        CatProds catProds = new CatProds(LoggedInEmail, selectedCategory);
                        catProds.Show();
                        this.Hide();
                    };

                    CustForYou_CatLayoutPanel.Controls.Add(categoryLink);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }






            try
            {
                con.Open();


                string query = @"
        SELECT TOP 10 
    p.Prod_Name, 
    p.Prod_Price,
    p.Prod_Release
FROM PRODUCTS p
ORDER BY p.Prod_Release DESC";


                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                CustForYou_NewArrivLayoutPanel.Controls.Clear();

                while (reader.Read())
                {
                    Panel productPanel = new Panel
                    {

                        AutoSize = true,
                        Margin = new Padding(5),

                    };

                    LinkLabel productLink = new LinkLabel
                    {
                        Text = reader["Prod_Name"].ToString(),
                        AutoSize = true,
                        LinkColor = Color.Black,
                        Font = new Font("Century Gothic", 18, FontStyle.Bold),
                        Cursor = Cursors.Hand,
                        Margin = new Padding(0, 10, 0, 20),

                    };

                    string productName = reader["Prod_Name"].ToString();  

                    productLink.Click += (s, arg) =>
                    {

                        ProductInfo productInfoForm = new ProductInfo(productName, LoggedInEmail);
                        productInfoForm.Show();
                        this.Hide();
                    };


                    Label productPrice = new Label
                    {
                        Text = $"{Environment.NewLine}Price: ${reader["Prod_Price"]:0.00}",
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.DarkGreen

                    };

                    productPanel.Controls.Add(productLink);
                    productPanel.Controls.Add(productPrice);


                    CustForYou_NewArrivLayoutPanel.Controls.Add(productPanel);
                }

                reader.Close();
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
        public string LoggedInEmail { get; set; }


        private void CustForYou_MyAcc_button_Click(object sender, EventArgs e)
        {
            CustDashboard custDashboard = new CustDashboard(LoggedInEmail);
            custDashboard.Show();
            this.Hide();
        }

        private void CustForYou_ViewCart_button_Click(object sender, EventArgs e)
        {
            CustCart custCart = new CustCart(LoggedInEmail);
            custCart.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CustForYou_CatLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void CustForYou_ProdLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustForYou_SearchBar_txtfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustForYou_Searc_button_Click(object sender, EventArgs e)
        {
            string searchQuery = CustForYou_SearchBar_txtfield.Text.Trim(); 
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    SearchResults searchResults = new SearchResults(LoggedInEmail, searchQuery);
                    searchResults.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please enter a search term.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
          

        }
    }
}
