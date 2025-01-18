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
    public partial class SellerReports : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public SellerReports(string loggedInEmail)
        {
            LoggedInEmail = loggedInEmail;
            InitializeComponent();
        }
        public string LoggedInEmail { get; set; }

        private void SellerReports_Load(object sender, EventArgs e)
        {

        }

        private void SellerReports_Back_Button_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard(LoggedInEmail);
            sellerDashboard.Show();
            this.Hide();
        }

        private void SellerReports_SalesPerf_ReportButton_Click(object sender, EventArgs e)
        {
            SellerSalesPerfForm sellerSalesPerfForm = new SellerSalesPerfForm(LoggedInEmail);
            sellerSalesPerfForm.Show(); 
            this.Hide();
        }

        private void SellerReports_CustPurchBehav_ReportButton_Click(object sender, EventArgs e)
        {
            SellerCustBehaveForm sellerCustBehaveForm = new SellerCustBehaveForm(LoggedInEmail);
            sellerCustBehaveForm.Show();
            this.Hide();
        }

        private void SellerReports_InvManage_ReportButton_Click(object sender, EventArgs e)
        {
            SellerInvReport sellerInvReport = new SellerInvReport(LoggedInEmail);
            sellerInvReport.Show();
            this.Hide();
        }

        private void SellerReports_RevenueByCategory_ReportButton_Click(object sender, EventArgs e)
        {
            SellerRevCat sellerRevCat = new SellerRevCat(LoggedInEmail);
            sellerRevCat.Show();
            this.Hide();
        }

        private void SellerReports_CustFeedRating_ReportButton_Click(object sender, EventArgs e)
        {
            SellerRating sellerRating = new SellerRating(LoggedInEmail);
            sellerRating.Show();
            this.Hide();
        }
    }
}
