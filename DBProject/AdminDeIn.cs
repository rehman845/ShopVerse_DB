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
    public partial class AdminDeIn : Form
    {
        public AdminDeIn(string loggedInEmail)
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
            string city = txtCity.Text.Trim(); 
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("Please enter a city.");
                return;
            }

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("City", city)
            };
            reportViewer13.LocalReport.SetParameters(reportParameters);

            DataTable ageData = GetReportData(city, "GetAgeDistribution");
            DataTable genderData = GetReportData(city, "GetGenderAnalysis");
            DataTable locationData = GetReportData(city, "GetLocationBasedInsights");
            DataTable DemogData = GetReportData(city, "GetDemographicPrefer");

            reportViewer13.LocalReport.DataSources.Clear();
            reportViewer13.LocalReport.DataSources.Add(new ReportDataSource("De1", ageData));
            reportViewer13.LocalReport.DataSources.Add(new ReportDataSource("De2", genderData));
            reportViewer13.LocalReport.DataSources.Add(new ReportDataSource("De3", locationData));
            reportViewer13.LocalReport.DataSources.Add(new ReportDataSource("D4", DemogData));

            reportViewer13.RefreshReport();
        }


        private DataTable GetReportData(string city, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@City", city);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        private void AdminDeIn_Load(object sender, EventArgs e)
        {

            this.reportViewer13.RefreshReport();
           
        }


    }
}
