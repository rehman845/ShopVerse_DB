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
    public partial class SellerRating : Form
    {
        public SellerRating(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;

        }

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

  public string LoggedInEmail { get; set; }

        private void Back_Click(object sender, EventArgs e)
        {
            SellerReports sellerReports = new SellerReports(LoggedInEmail);
            sellerReports.Show();
            this.Hide();
        }

        private DataTable GetSellerReportData(string sellerEmail, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
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
            if (string.IsNullOrEmpty(LoggedInEmail))
            {
                MessageBox.Show("Seller email is missing.");
                return;
            }

            // Setting up report parameters
            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("SellerMail", LoggedInEmail)
            };
            reportViewer5.LocalReport.SetParameters(reportParameters);

            // Loading data for reports
            DataTable avgRatingData = GetSellerReportData(LoggedInEmail, "GetAverageRatingByProduct");
            DataTable sentimentData = GetSellerReportData(LoggedInEmail, "GetProductSentimentAnalysis");
            DataTable topRatedData = GetSellerReportData(LoggedInEmail, "GetTopRatedProducts");

            // Clearing and setting report data sources
            reportViewer5.LocalReport.DataSources.Clear();
            reportViewer5.LocalReport.DataSources.Add(new ReportDataSource("SelRat1", avgRatingData));
            reportViewer5.LocalReport.DataSources.Add(new ReportDataSource("SelRat2", sentimentData));
            reportViewer5.LocalReport.DataSources.Add(new ReportDataSource("SelRat3", topRatedData));

            reportViewer5.RefreshReport();
        }

        private void SellerRating_Load(object sender, EventArgs e)
        {

            this.reportViewer5.RefreshReport();
        }
    }
}
