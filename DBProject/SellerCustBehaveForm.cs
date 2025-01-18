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
    public partial class SellerCustBehaveForm : Form
    {
        public SellerCustBehaveForm(string loggedInEmail)
        {
            InitializeComponent();
        LoggedInEmail = loggedInEmail;
          
        }


  public string LoggedInEmail { get; set; }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");

        private void SellerCustBehaveForm_Load(object sender, EventArgs e)
        {

            this.reportViewer2.RefreshReport();
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            string loggedInMail = txtSellerMail.Text;

            if (string.IsNullOrEmpty(loggedInMail))
            {
                MessageBox.Show("Please enter a valid seller email.");
                return;
            }

            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("SellerEmail", loggedInMail)
            };
            reportViewer2.LocalReport.SetParameters(parameters); 

            DataTable mostActiveCustomersData = GetCustomerBehaviorData(loggedInMail, "GetMostActiveCustomers");
            ReportDataSource mostActiveCustomersDataSource = new ReportDataSource("SellerCustBehave3", mostActiveCustomersData);

            DataTable repeatPurchaseCustomersData = GetCustomerBehaviorData(loggedInMail, "GetRepeatPurchaseRate");
            ReportDataSource repeatPurchaseCustomersDataSource = new ReportDataSource("SellerCustBehave2", repeatPurchaseCustomersData);

            DataTable averageSpendCustomersData = GetCustomerBehaviorData(loggedInMail, "GetAverageSpendPerCustomer");
            ReportDataSource averageSpendCustomersDataSource = new ReportDataSource("SellerCustBehave1", averageSpendCustomersData);

            reportViewer2.LocalReport.DataSources.Clear(); 
            reportViewer2.LocalReport.DataSources.Add(mostActiveCustomersDataSource);
            reportViewer2.LocalReport.DataSources.Add(repeatPurchaseCustomersDataSource);
            reportViewer2.LocalReport.DataSources.Add(averageSpendCustomersDataSource);

            reportViewer2.RefreshReport(); 
        }

        private DataTable GetCustomerBehaviorData(string sellerEmail, string storedProcedure)
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

        private void Back_Click(object sender, EventArgs e)
        {
            SellerReports sellerReports = new SellerReports(LoggedInEmail);
            sellerReports.Show();
            this.Hide();
        }
    }
}
