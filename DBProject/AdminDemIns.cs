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
    public partial class AdminDemIns : Form
    {
        public AdminDemIns(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }


  public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        private void AdminDemIns_Load(object sender, EventArgs e)
        {

            this.reportViewer11.RefreshReport();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            AdminReports adminReports = new AdminReports(LoggedInEmail);
            adminReports.Show();
            this.Hide();
        }

        private DataTable GetReportData(string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private DataTable GetLocationBasedInsightsData(string city)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Adm3", connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@City", city);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                MessageBox.Show("Please enter a city name for Location-Based Insights.");
                return;
            }

            string city = txtCity.Text.Trim();

            DataTable ageDistributionData = GetReportData("GetAgeDistribution");
            ReportDataSource ageDistributionSource = new ReportDataSource("Adm1", ageDistributionData);

            DataTable genderAnalysisData = GetReportData("GetGenderAnalysis");
            ReportDataSource genderAnalysisSource = new ReportDataSource("Adm2", genderAnalysisData);

            DataTable locationBasedInsightsData = GetLocationBasedInsightsData(city);
            ReportDataSource locationBasedInsightsSource = new ReportDataSource("Adm3", locationBasedInsightsData);

            DataTable demographicPreferencesData = GetReportData("GetDemographicPreferences");
            ReportDataSource demographicPreferencesSource = new ReportDataSource("Adm4", demographicPreferencesData);

            reportViewer11.LocalReport.DataSources.Clear();
            reportViewer11.LocalReport.DataSources.Add(ageDistributionSource);
            reportViewer11.LocalReport.DataSources.Add(genderAnalysisSource);
            reportViewer11.LocalReport.DataSources.Add(locationBasedInsightsSource);
            reportViewer11.LocalReport.DataSources.Add(demographicPreferencesSource);

            reportViewer11.RefreshReport();
        }
    }
}
