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
    public partial class ComplainView : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ComplainView()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminStart f2 = new AdminStart();
            f2.Show();
        }


        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select * FROM COMPLAIN";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }
        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }
    }
}
