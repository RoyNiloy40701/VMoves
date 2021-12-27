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
    public partial class viewReview : Form


    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public viewReview()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * FROM REVIEW";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            homePage f1 = new homePage();
            f1.Show();
        }
    }
}
