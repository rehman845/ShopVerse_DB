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
    public partial class AdminReports : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public AdminReports(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }
        public string LoggedInEmail { get; set; }
        private void AdminReports_Back_Button_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(LoggedInEmail);
            adminDashboard.Show();
            this.Hide();
        }

        private void AdminReports_Load(object sender, EventArgs e)
        {

        }

        private void AdminReports_SellerPerf_ReportButton_Click(object sender, EventArgs e)
        {
            AdminSellPerf adminSellPerf = new AdminSellPerf(LoggedInEmail);
            adminSellPerf.Show();
            this.Hide();
        }

        private void AdminReports_OrdShip_ReportButton_Click(object sender, EventArgs e)
        {
            AdminOrdFul adminOrdFul = new AdminOrdFul(LoggedInEmail);
            adminOrdFul.Show();
            this.Hide();
        }

        private void AdminReports_PlatGrowUser_ReportButton_Click(object sender, EventArgs e)
        {
            AdminPlat adminPlat = new AdminPlat(LoggedInEmail);
            adminPlat.Show();
            this.Hide();
        }

        private void AdminReports_UserDemographics_ReportButton_Click(object sender, EventArgs e)
        {
            AdminDeIn adminDeIn = new AdminDeIn(LoggedInEmail);
            adminDeIn.Show();
            this.Hide();
        }

        private void AdminReports_AbanCart_ReportButton_Click(object sender, EventArgs e)
        {
            AdminCart adminCart = new AdminCart(LoggedInEmail);
            adminCart.Show();
            this.Hide();
        }
    }
}
