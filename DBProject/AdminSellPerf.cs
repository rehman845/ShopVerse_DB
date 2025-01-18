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
    public partial class AdminSellPerf : Form
    {
        public AdminSellPerf(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }


  public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void Back_Click(object sender, EventArgs e)
        {
            AdminReports adminReports = new AdminReports(LoggedInEmail);
            adminReports.Show();
            this.Hide();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSellerID.Text.Trim(), out int sellerId))
            {
                MessageBox.Show("Please enter a valid Seller ID.");
                return;
            }

            DataTable totalSalesData = GetSellerReportData(sellerId, "GetTotalSalesBySellerID");
            DataTable avgRatingData = GetSellerReportData(sellerId, "GetAvgRatingByProductSellerID");
            DataTable returnRateData = GetSellerReportData(sellerId, "GetReturnRateSellerID");

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("SellerID", sellerId.ToString())
            };
            reportViewer6.LocalReport.SetParameters(reportParameters);

            reportViewer6.LocalReport.DataSources.Clear();
            reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("AdmSelPerf4", totalSalesData));
            reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("AdmSelPerf2", avgRatingData));
            reportViewer6.LocalReport.DataSources.Add(new ReportDataSource("AdmSelPerf3", returnRateData));

            reportViewer6.RefreshReport();
        }

        private DataTable GetSellerReportData(int sellerId, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SellerID", sellerId);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void AdminSellPerf_Load(object sender, EventArgs e)
        {

            this.reportViewer6.RefreshReport();
        }
    }
}
