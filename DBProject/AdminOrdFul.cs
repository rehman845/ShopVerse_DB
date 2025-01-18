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
    public partial class AdminOrdFul : Form
    {
        public AdminOrdFul(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;

        }

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

  public string LoggedInEmail { get; set; }

        private void AdminOrdFul_Load(object sender, EventArgs e)
        {

            this.reportViewer7.RefreshReport();
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
        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string Mail = txtMail.Text.Trim();
            if (string.IsNullOrEmpty(Mail))
            {
                MessageBox.Show("Please enter a city.");
                return;
            }

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("Mail", Mail)
            };
            reportViewer7.LocalReport.SetParameters(reportParameters);

            DataTable avgFulfillmentTimeData = GetReportData(Mail,"GetAverageFulfillmentTime");
            DataTable shippingDelaysData = GetReportData(Mail,"GetShippingDelays");
            DataTable reliableShippingProvidersData = GetReportData(Mail,"GetMostReliableShippingProviders");
            DataTable orderCompletionRateData = GetReportData(Mail,"GetOrderCompletionRate");

            reportViewer7.LocalReport.DataSources.Clear();
            reportViewer7.LocalReport.DataSources.Add(new ReportDataSource("OrdFul1", avgFulfillmentTimeData));
            reportViewer7.LocalReport.DataSources.Add(new ReportDataSource("OrdFul2", shippingDelaysData));
            reportViewer7.LocalReport.DataSources.Add(new ReportDataSource("OrdFul3", reliableShippingProvidersData));
            reportViewer7.LocalReport.DataSources.Add(new ReportDataSource("OrdFul4", orderCompletionRateData));

            reportViewer7.RefreshReport();
        }

        private DataTable GetReportData(string Mail, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@Mail", Mail);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }


        private void reportViewer7_Load(object sender, EventArgs e)
        {

        }
    }
}
