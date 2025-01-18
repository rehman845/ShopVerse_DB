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
    public partial class AdminPlat : Form
    {
        public AdminPlat(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

  public string LoggedInEmail { get; set; }

        private void AdminPlat_Load(object sender, EventArgs e)
        {

            this.reportViewer9.RefreshReport();
        }



        private void Back_Click(object sender, EventArgs e)
        {
            AdminReports adminReports = new AdminReports(LoggedInEmail);
            adminReports.Show();
            this.Hide();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStartDate.Text) || string.IsNullOrEmpty(txtEndDate.Text))
            {
                MessageBox.Show("Please enter both start and end dates.");
                return;
            }

            DateTime startDate, endDate;

            if (!DateTime.TryParse(txtStartDate.Text, out startDate) || !DateTime.TryParse(txtEndDate.Text, out endDate))
            {
                MessageBox.Show("Please enter valid start and end dates.");
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("End date cannot be earlier than start date.");
                return;
            }

            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("StartDate", startDate.ToString("yyyy-MM-dd")),
                new ReportParameter("EndDate", endDate.ToString("yyyy-MM-dd"))
            };
            reportViewer9.LocalReport.SetParameters(parameters);

            DataTable newUserRegistrationsData = GetReportData("GetNewUserRegistrations", startDate, endDate);
            ReportDataSource newUserRegistrationsSource = new ReportDataSource("Plat1", newUserRegistrationsData);

            DataTable userEngagementMetricsData = GetUserEngagementMetricsData(); 
            ReportDataSource userEngagementMetricsSource = new ReportDataSource("Plat2", userEngagementMetricsData);

            DataTable churnRateData = GetReportData("GetChurnRate", startDate, endDate);
            ReportDataSource churnRateSource = new ReportDataSource("Plat3", churnRateData);

            DataTable activeUserRatioData = GetReportData("GetActiveUserRatio", startDate, endDate);
            ReportDataSource activeUserRatioSource = new ReportDataSource("Plat4", activeUserRatioData);

            reportViewer9.LocalReport.DataSources.Clear();
            reportViewer9.LocalReport.DataSources.Add(newUserRegistrationsSource);
            reportViewer9.LocalReport.DataSources.Add(userEngagementMetricsSource);
            reportViewer9.LocalReport.DataSources.Add(churnRateSource);
            reportViewer9.LocalReport.DataSources.Add(activeUserRatioSource);

            reportViewer9.RefreshReport();
        }

        private DataTable GetUserEngagementMetricsData()
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("GetUserEngagementMetrics", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private DataTable GetReportData(string storedProcedure, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }



    }
}
