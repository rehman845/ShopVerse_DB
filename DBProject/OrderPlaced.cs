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
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;




namespace DBProject
{
    public partial class OrderPlaced : Form
    {
SqlConnection con = new SqlConnection("Data Source=DESKTOP-O8G1JU4\\SQLEXPRESS;Initial Catalog=SHOPVERSE;Integrated Security=True;Encrypt=False");
        public OrderPlaced(string loggedInEmail)
        {
            InitializeComponent();
            LoggedInEmail = loggedInEmail;
        }

        public string LoggedInEmail { get; set; }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void OrderPlace_TrackOrder_button_Click(object sender, EventArgs e)
        {
            CustMyOrders custMyOrders = new CustMyOrders(LoggedInEmail);
            custMyOrders.Show();
            this.Hide();
        }

        private void OrderPlace_ContShop_button_Click(object sender, EventArgs e)
        {
            CustForYou custForYou = new CustForYou(LoggedInEmail);
            custForYou.Show();
            this.Hide();
        }

        private void OrderPlaced_Load(object sender, EventArgs e)
        {

        }
    }
}
