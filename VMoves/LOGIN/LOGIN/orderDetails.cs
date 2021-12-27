using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LOGIN
{
    
    public partial class orderDetails : Form

    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public orderDetails()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            homePage f1 = new homePage();
            f1.Show();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * FROM ORDERTABLE where STATUS ='Accept' AND FUEL_PROVIDER_LNO='"+login.l_No+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void orderDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
