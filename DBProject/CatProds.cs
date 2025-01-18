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
    public partial class CatProds : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CatProds(string loggedInEmail, string selectedCat)
        {
            InitializeComponent();

            LoggedInEmail = loggedInEmail;
            SelectedCat = selectedCat;
        }


        public string SelectedCat { get; set; }
        public string LoggedInEmail { get; set; }

        private void CatProd_Back_button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void CatProds_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string query = @"
SELECT p.Prod_Name, p.Prod_Price, p.Prod_Description
FROM PRODUCTS p
JOIN CATEGORY c ON p.CatID = c.CatID
WHERE c.Cat_Name = @CategoryName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CategoryName", SelectedCat);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CatProd_CatNameTop_label.Text = SelectedCat;

                    Panel productPanel = new Panel
                    {
                        AutoSize = true,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle 
                    };

                    TableLayoutPanel tableLayout = new TableLayoutPanel
                    {
                        RowCount = 1,
                        ColumnCount = 3,
                        AutoSize = true,
                        Dock = DockStyle.Fill
                    };

                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40f)); 
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f)); 
                    tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f)); 

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

                    Label productPriceLabel = new Label
                    {
                        Text = $"${reader["Prod_Price"]:0.00}",
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.DarkGreen
                    };

                    Label productDescriptionLabel = new Label
                    {
                        Text = reader["Prod_Description"].ToString(),
                        AutoSize = true,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        ForeColor = Color.Black
                    };

                    tableLayout.Controls.Add(productLink, 0, 0);
                    tableLayout.Controls.Add(productPriceLabel, 1, 0);
                    tableLayout.Controls.Add(productDescriptionLabel, 2, 0);

                    productPanel.Controls.Add(tableLayout);

                    CatProd_FlowLayout.Controls.Add(productPanel);
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
    }
}
