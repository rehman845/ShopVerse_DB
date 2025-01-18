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
    public partial class SellerInvReport : Form
    {
        public SellerInvReport(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
  public string LoggedInEmail { get; set; }
        private void SellerInvReport_Load(object sender, EventArgs e)
        {

            this.reportViewer3.RefreshReport();
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

            if (string.IsNullOrEmpty(loggedInMail))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("SellerMail", loggedInMail)
            };
            reportViewer3.LocalReport.SetParameters(reportParameters);

            DataTable lowStockData = GetSellerReportData(loggedInMail, "GetLowStock");
            DataTable deadStockData = GetSellerReportData(loggedInMail, "GetDeadStock");
            DataTable stockTurnoverData = GetSellerReportData(loggedInMail, "GetStockTurnover");
            DataTable mostReturnedData = GetSellerReportData(loggedInMail, "GetMostReturnedItems");

            reportViewer3.LocalReport.DataSources.Clear();
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("SellerInv1", lowStockData));
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("SellerInv2", deadStockData));
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("SellerInv3", stockTurnoverData));
            reportViewer3.LocalReport.DataSources.Add(new ReportDataSource("SellerInv4", mostReturnedData));

            reportViewer3.RefreshReport();
        }
    }
}
