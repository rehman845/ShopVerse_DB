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
    public partial class AdminCart : Form
    {
        public AdminCart(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
        }

SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

  public string LoggedInEmail { get; set; }

        private void AdminCart_Load(object sender, EventArgs e)
        {

            this.reportViewer8.RefreshReport();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            AdminReports adminReports = new AdminReports(LoggedInEmail);
            adminReports.Show();
            this.Hide();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDays.Text.Trim(), out int days))
            {
                MessageBox.Show("Please enter a valid number of days.");
                return;
            }

            DataTable abandonedCartCountData = GetCartReportData(days, "GetAbandonedCartCount");
            DataTable avgCartValueData = GetCartReportData(days, "GetAverageAbandonedCartValue");
            DataTable frequentProductsData = GetCartReportData(days, "GetFrequentAbandonedProducts");
            DataTable abandonmentReasonsData = GetCartReportData(days, "GetCartAbandonmentReasons");

            ReportParameter[] reportParameters = new ReportParameter[]
            {
                new ReportParameter("Days", days.ToString())
            };
            reportViewer8.LocalReport.SetParameters(reportParameters);

            reportViewer8.LocalReport.DataSources.Clear();
            reportViewer8.LocalReport.DataSources.Add(new ReportDataSource("Cart1", abandonedCartCountData));
            reportViewer8.LocalReport.DataSources.Add(new ReportDataSource("Cart2", avgCartValueData));
            reportViewer8.LocalReport.DataSources.Add(new ReportDataSource("Cart3", frequentProductsData));
            reportViewer8.LocalReport.DataSources.Add(new ReportDataSource("Cart4", abandonmentReasonsData));

            reportViewer8.RefreshReport();
        }

        private DataTable GetCartReportData(int days, string storedProcedure)
        {
            using (SqlConnection connection = new SqlConnection(con.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(storedProcedure, connection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                dataAdapter.SelectCommand.Parameters.AddWithValue("@Days", days);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
