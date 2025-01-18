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
    public partial class SearchResults : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SearchResults(string loggedInEmail, string searchedText)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
            SearchedText = searchedText;
        }


        private string SearchedText { get; set; }
        public string LoggedInEmail { get; set; }
        private void SerachResults_Back_Button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            PerformSearch();

        }

        



        private void txtApplyButton_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                con.Open();

                StringBuilder query = new StringBuilder(@"
    SELECT p.ProdID, p.Prod_Name, p.Prod_Price, s.Seller_StoreName, c.Cat_Name, 
           AVG(r.Rating) AS Rating
    FROM PRODUCTS p
    INNER JOIN SELLER s ON p.SellerID = s.SellerID
    INNER JOIN CATEGORY c ON p.CatID = c.CatID
    LEFT JOIN REVIEW r ON p.ProdID = r.ProdID
    WHERE p.Prod_Name LIKE @searchedText
");

                if (!string.IsNullOrEmpty(txtMinPrice.Text))
                    query.Append(" AND p.Prod_Price >= @minPrice");

                if (!string.IsNullOrEmpty(txtMaxPrice.Text))
                    query.Append(" AND p.Prod_Price <= @maxPrice");

                if (!string.IsNullOrEmpty(txtCategory.Text))
                    query.Append(" AND c.Cat_Name = @category");

                if (!string.IsNullOrEmpty(txtSKU.Text) && int.TryParse(txtSKU.Text, out int prodID) && prodID >= 1 && prodID <= 500)
                {
                    query.Append(" AND p.ProdID = @prodID");
                }

                if (!string.IsNullOrEmpty(txtStore.Text))
                    query.Append(" AND s.Seller_StoreName LIKE @store");

                query.Append(" GROUP BY p.ProdID, p.Prod_Name, p.Prod_Price, s.Seller_StoreName, c.Cat_Name");

                if (comboSort.SelectedItem != null)
                {
                    switch (comboSort.SelectedItem.ToString())
                    {
                        case "PriceHigh":
                            query.Append(" ORDER BY p.Prod_Price DESC");
                            break;
                        case "PriceLow":
                            query.Append(" ORDER BY p.Prod_Price ASC");
                            break;
                        case "RatingHigh":
                            query.Append(" ORDER BY AVG(r.Rating) DESC");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                  
                    query.Append(" ORDER BY p.Prod_Price ASC"); 
                }

                SqlCommand cmd = new SqlCommand(query.ToString(), con);
                cmd.Parameters.AddWithValue("@searchedText", "%" + SearchedText + "%");
                if (!string.IsNullOrEmpty(txtMinPrice.Text))
                    cmd.Parameters.AddWithValue("@minPrice", Convert.ToDecimal(txtMinPrice.Text));
                if (!string.IsNullOrEmpty(txtMaxPrice.Text))
                    cmd.Parameters.AddWithValue("@maxPrice", Convert.ToDecimal(txtMaxPrice.Text));
                if (!string.IsNullOrEmpty(txtCategory.Text))
                    cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                if (!string.IsNullOrEmpty(txtSKU.Text) && int.TryParse(txtSKU.Text, out prodID) && prodID >= 1 && prodID <= 500)
                    cmd.Parameters.AddWithValue("@prodID", prodID);
                if (!string.IsNullOrEmpty(txtStore.Text))
                    cmd.Parameters.AddWithValue("@store", "%" + txtStore.Text + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                SearchFlow.Controls.Clear(); 

                while (reader.Read())
                {
                    Panel productPanel = new Panel
                    {
                        AutoSize = true,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle 
                    };

                    TableLayoutPanel tableLayout = new TableLayoutPanel
                    {
                        RowCount = 1,
                        ColumnCount = 5,
                        AutoSize = true,
                        Dock = DockStyle.Fill
                    };

                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); 
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); 
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); 
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));

                    LinkLabel productLink = new LinkLabel
                    {
                        Text = reader["Prod_Name"].ToString(),
                        AutoSize = true,
                        LinkColor = Color.Black,
                        Font = new Font("Century Gothic", 14, FontStyle.Bold),
                        Cursor = Cursors.Hand,
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
                        Text = $"${reader["Prod_Price"]:0.00}",
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.DarkGreen
                    };

                    Label storeLabel = new Label
                    {
                        Text = reader["Seller_StoreName"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.Black
                    };

                    Label categoryLabel = new Label
                    {
                        Text = reader["Cat_Name"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.Black
                    };

                    Label ratingLabel = new Label
                    {
                        Text = $"{reader["Rating"]:0.0}",
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.DarkOrange
                    };

                    tableLayout.Controls.Add(productLink, 0, 0);
                    tableLayout.Controls.Add(productPrice, 1, 0);
                    tableLayout.Controls.Add(storeLabel, 2, 0);
                    tableLayout.Controls.Add(categoryLabel, 3, 0);
                    tableLayout.Controls.Add(ratingLabel, 4, 0);

                    productPanel.Controls.Add(tableLayout);

                    SearchFlow.Controls.Add(productPanel);
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


        private void txtClearlFilter_Click(object sender, EventArgs e)
        {
            txtMinPrice.Clear();
            txtMaxPrice.Clear();
            txtCategory.Clear();
            txtSKU.Clear();
            txtStore.Clear();

            comboSort.SelectedIndex = -1;

            PerformSearch();
        }
    }
}
