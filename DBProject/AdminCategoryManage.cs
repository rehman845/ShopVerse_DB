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
    public partial class AdminCategoryManage : Form
    {
        public AdminCategoryManage(string loggedInEmail)
        {
            LoggedInEmail = loggedInEmail;
            InitializeComponent();
        }

        public string LoggedInEmail { get; set; }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void AdminCategoryManage_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminCategoryManage_Load(object sender, EventArgs e)
        {

        }

        private void AdminCategoryManage_UpdProd_button_Click(object sender, EventArgs e)
        {

        }

        private void AdminCategoryManage_AddCategory_Button_Click(object sender, EventArgs e)
        {
            string categoryName = AdminCategoryManage_CatName_txtfield.Text;

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM CATEGORY WHERE Cat_Name = @CatName", con);
                checkCmd.Parameters.AddWithValue("@CatName", categoryName);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Category already exists.");
                    return;
                }

                SqlCommand addCmd = new SqlCommand("INSERT INTO CATEGORY (Cat_Name, Cat_Creation) VALUES (@CatName, GETDATE())", con);
                addCmd.Parameters.AddWithValue("@CatName", categoryName);

                addCmd.ExecuteNonQuery();
                MessageBox.Show("Category added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AdminCategoryManage_DeleteProd_Button_Click(object sender, EventArgs e)
        {
            string categoryName = AdminCategoryManage_CatName_txtfield.Text;

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            try
            {
                con.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM CATEGORY WHERE Cat_Name = @CatName", con);
                checkCmd.Parameters.AddWithValue("@CatName", categoryName);
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Category not found.");
                    return;
                }

                SqlCommand deleteCmd = new SqlCommand("DELETE FROM CATEGORY WHERE Cat_Name = @CatName", con);
                deleteCmd.Parameters.AddWithValue("@CatName", categoryName);

                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
