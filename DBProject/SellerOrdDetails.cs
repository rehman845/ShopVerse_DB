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
    public partial class SellerOrdDetails : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerOrdDetails(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void SellerOrdDetails_Back_Button_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void SellerOrdDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
