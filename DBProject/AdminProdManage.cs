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
    public partial class AdminProdManage : Form
    {
        public AdminProdManage(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }


  public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminProdManage_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminProdManage_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT ProdID, Prod_Name, Prod_Description, Prod_Price, CatID, Prod_Picture FROM PRODUCTS", con);

                SqlDataReader reader = cmd.ExecuteReader();
                flowLayoutPanel1.Controls.Clear();

                while (reader.Read())
                {
                    TableLayoutPanel productPanel = new TableLayoutPanel
                    {
                        ColumnCount = 5,
                        AutoSize = true,
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                        Dock = DockStyle.Top
                    };
                    Font font = new Font("Century Gothic", 14, FontStyle.Bold);


                    int prodId = (int)reader["ProdID"];
                    string name = reader["Prod_Name"].ToString();
                    string description = reader["Prod_Description"].ToString();
                    float price = float.Parse(reader["Prod_Price"].ToString());
                    int category = (int)reader["CatID"];
                    string picture = reader["Prod_Picture"].ToString();

                    productPanel.Controls.Add(new Label { Text = prodId.ToString(), AutoSize = true, Font = font }, 0, 0);
                    productPanel.Controls.Add(new Label { Text = name, AutoSize = true, Font = font }, 1, 0);
                    productPanel.Controls.Add(new Label { Text = description, AutoSize = true, Font = font }, 2, 0);
                    productPanel.Controls.Add(new Label { Text = price.ToString("C"), AutoSize = true, Font = font }, 3, 0);
                    productPanel.Controls.Add(new Label { Text = category.ToString(), AutoSize = true, Font = font }, 4, 0);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }

                reader.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



    }
}
