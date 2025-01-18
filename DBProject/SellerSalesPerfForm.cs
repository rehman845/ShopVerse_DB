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
    public partial class SellerSalesPerfForm : Form
    {
        public SellerSalesPerfForm(String loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;

        }

        public string LoggedInEmail { get; set; }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");


        private void SellerSalesPerfForm_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }

        private DataTable GetSalesPerformanceData(string sellerEmail, DateTime startDate, DateTime endDate, string storedProcedure)
        {
            string connectionString = "Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@SellerMail", sellerEmail);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string loggedInMail = txtSellerMail.Text;
            DateTime startDate;
            DateTime endDate;

            if (!DateTime.TryParse(txtStartDate.Text, out startDate) || !DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                MessageBox.Show("Please enter valid dates.");
                return;
            }

            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("StartDate", startDate.ToString("yyyy-MM-dd")),
                new ReportParameter("EndDate", endDate.ToString("yyyy-MM-dd")),
                new ReportParameter("SellerMail", loggedInMail)
            };
            reportViewer1.LocalReport.SetParameters(parameters);

            DataTable totalSalesData = GetSalesPerformanceData(loggedInMail, startDate, endDate, "GetTotalSalesAndAvgOrderValue");
            ReportDataSource totalSalesDataSource = new ReportDataSource("SellerSalesPerf3", totalSalesData);

            DataTable bestSellingProductsData = GetSalesPerformanceData(loggedInMail, startDate, endDate, "GetBestSellingProducts");
            ReportDataSource bestSellingProductsDataSource = new ReportDataSource("SellerSalesPerf1", bestSellingProductsData);

            DataTable topCategoryData = GetSalesPerformanceData(loggedInMail, startDate, endDate, "GetTopCategory");
            ReportDataSource topCategoryDataSource = new ReportDataSource("SellerSalesPerf2", topCategoryData);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(totalSalesDataSource);
            reportViewer1.LocalReport.DataSources.Add(bestSellingProductsDataSource);
            reportViewer1.LocalReport.DataSources.Add(topCategoryDataSource);

            reportViewer1.RefreshReport();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            SellerReports sellerReports = new SellerReports(LoggedInEmail);
            sellerReports.Show();
            this.Hide();
        }
    }
}
