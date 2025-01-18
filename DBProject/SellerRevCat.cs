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
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;



namespace DBProject
{
    public partial class SellerRevCat : Form
    {
        public SellerRevCat(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }


  public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void SellerRevCat_Load(object sender, EventArgs e)
        {

            this.reportViewer4.RefreshReport();
            this.reportViewer4.RefreshReport();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            SellerReports sellerReports = new SellerReports(LoggedInEmail);
            sellerReports.Show();
            this.Hide();
        }

        private DataTable GetSellerReportData(string sellerEmail, string storedProcedure)
        {
            string connectionString = "Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SellerEmail", sellerEmail);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string loggedInMail = txtSellerMail.Text.Trim();

            DataTable revenueData = GetSellerReportData(loggedInMail, "GetRevenuePerCategory");
            DataTable contributionData = GetSellerReportData(loggedInMail, "GetCategoryContribution");
            DataTable trendingData = GetSellerReportData(loggedInMail, "GetTrendingCategories");

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("SellerMail", loggedInMail)
            };
            reportViewer4.LocalReport.SetParameters(reportParameters);

            reportViewer4.LocalReport.DataSources.Clear();
            reportViewer4.LocalReport.DataSources.Add(new ReportDataSource("CatRev1", revenueData));
            reportViewer4.LocalReport.DataSources.Add(new ReportDataSource("CatRev2", contributionData));
            reportViewer4.LocalReport.DataSources.Add(new ReportDataSource("CatRev3", trendingData));

            reportViewer4.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
