using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LOGIN
{
    public partial class MyComplain : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public MyComplain()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * FROM COMPLAIN where NID_LNO='"+login.nid+"'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void MyComplain_Load(object sender, EventArgs e)
        {

        }
    }
}
