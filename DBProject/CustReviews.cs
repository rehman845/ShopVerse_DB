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
    public partial class CustReviews : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustReviews(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;

        }

        private void Cart_CartItems_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string LoggedInEmail { get; set; }
        private void CustReviews_BackDashboard_Button_Click(object sender, EventArgs e)
        {
            CustDashboard custDashboard = new CustDashboard(LoggedInEmail);
            custDashboard.Show();
            this.Hide();
        }

        private void CustReviews_BackHome_Button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void CustReviews_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string userMail = LoggedInEmail;

                string query = @"
    SELECT 
        r.ReviewID,
        r.Comment AS Review_Comment,
        r.Rating AS Review_Rating,
        r.R_Date AS Review_Date,
        p.Prod_Name
    FROM 
        REVIEW r
    INNER JOIN CUSTOMERS c ON r.CustID = c.CustID
    INNER JOIN USERS u ON c.UserID = u.UserID
    INNER JOIN PRODUCTS p ON r.ProdID = p.ProdID
    WHERE 
        u.User_Mail = @UserMail
    ORDER BY 
        r.R_Date DESC;
    ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserMail", userMail);

                CustReviews_Reviews_FlowLayout.Controls.Clear();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TableLayoutPanel ReviewsTable = new TableLayoutPanel
                        {
                            AutoSize = true,
                            ColumnCount = 6, 
                            RowCount = 1,
                            AutoSizeMode = AutoSizeMode.GrowAndShrink,
                            Margin = new Padding(10),
                            Padding = new Padding(10),
                            Dock = DockStyle.Top,
                            BackColor = Color.NavajoWhite
                        };

                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
                        ReviewsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10)); 

                        Label reviewIDLabel = new Label
                        {
                            Text = $"Review ID: {reader["ReviewID"]}",
                            AutoSize = false,
                            Font = new Font("Century Gothic", 10, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Label productNameLabel = new Label
                        {
                            Text = reader["Prod_Name"].ToString(),
                            AutoSize = false,
                            Font = new Font("Century Gothic", 16, FontStyle.Bold),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Label ratingLabel = new Label
                        {
                            Text = $"Rating: {reader["Review_Rating"]}",
                            AutoSize = false,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            ForeColor = Color.Goldenrod,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Label commentLabel = new Label
                        {
                            Text = reader["Review_Comment"].ToString(),
                            AutoSize = false,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            ForeColor = Color.Black,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Label dateLabel = new Label
                        {
                            Text = Convert.ToDateTime(reader["Review_Date"]).ToString("yyyy-MM-dd"),
                            AutoSize = false,
                            Font = new Font("Century Gothic", 10, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            TextAlign = ContentAlignment.MiddleRight,
                            Dock = DockStyle.Fill,
                            Padding = new Padding(5)
                        };

                        Button deleteButton = new Button
                        {
                            Text = "Delete",
                            AutoSize = true,
                            Font = new Font("Century Gothic", 16, FontStyle.Regular),
                            ForeColor = Color.White,
                            BackColor = Color.Red,
                            Tag = reader["ReviewID"],
                            Dock = DockStyle.Fill,
                            Margin = new Padding(5)
                        };
                        deleteButton.Click += CustReviews_DeleteButton_Click;

                        ReviewsTable.Controls.Add(reviewIDLabel, 0, 0);
                        ReviewsTable.Controls.Add(productNameLabel, 1, 0);
                        ReviewsTable.Controls.Add(ratingLabel, 2, 0);
                        ReviewsTable.Controls.Add(commentLabel, 3, 0);
                        ReviewsTable.Controls.Add(dateLabel, 4, 0);
                        ReviewsTable.Controls.Add(deleteButton, 5, 0); 

                        CustReviews_Reviews_FlowLayout.Controls.Add(ReviewsTable);

                        Label lineSpace = new Label
                        {
                            Text = Environment.NewLine, 
                            AutoSize = false,
                            Height = 10 
                        };
                        CustReviews_Reviews_FlowLayout.Controls.Add(lineSpace);
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

        private void CustReviews_Reviews_FlowLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustReviews_DeleteButton_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            int reviewID = Convert.ToInt32(deleteButton.Tag);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this review?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    con.Open();

                    string deleteQuery = @"
            DELETE FROM REVIEW
            WHERE ReviewID = @ReviewID
            ";

                    SqlCommand cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@ReviewID", reviewID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Review deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
