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
    public partial class manageOrder : Form  
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public manageOrder()
        {
            InitializeComponent();
            BindGridView();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update ORDERTABLE set STATUS='Accept' where ORDER_ID=@nid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nid", textBox2.Text);
            


        
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if(a>0)
            {
                MessageBox.Show("Order Accepted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Order not Accepted!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from ordertable where STATUS ='Ordered' AND FUEL_PROVIDER_LNO='" + login.l_No + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
           
        }

        private void button3_Click(object sender, EventArgs e)
         {
             this.Hide();
             homePage f1 = new homePage();
             f1.Show();
         }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        void ResetControl()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
            textBox4.Clear();
            textBox5.Clear();


        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from ORDERTABLE where ORDER_ID=@nid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@nid", textBox2.Text);
    


          
            cmd.Parameters.AddWithValue("@customerName", textBox3.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Order Cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
                ResetControl();
            }
            else
            {
                MessageBox.Show("Order not Cancelled", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
