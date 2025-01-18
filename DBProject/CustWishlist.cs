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
    public partial class CustWishlist : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public CustWishlist(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }


        private void Wishlist_Back_Button_Click(object sender, EventArgs e)
        {
            CustDashboard custDashboard = new CustDashboard(LoggedInEmail);
            custDashboard.Show();
            this.Hide();
        }

        private void CustWishlist_Load(object sender, EventArgs e)
        {

        }
    }
}
