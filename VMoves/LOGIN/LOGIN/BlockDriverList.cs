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
   
    public partial class BlockDriverList : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public BlockDriverList()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "update Driver set STATUS= 'Null' where NID_NUMBER=@nid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nid", textBox1.Text);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                { 
                    MessageBox.Show("Block Driver  successfully", "Successful", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox1.Clear();
                    this.Hide();
                   BlockDriverList ST = new BlockDriverList();
                    ST.Show();

                }
                else
                {
                    MessageBox.Show(" Failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
 
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_error;

                errorProvider1.SetError(this.textBox1, " Enter Driver Nid no. ");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select NAME,EMAIL,NID_NUMBER,DRIVING_LICENSE_NUMBER,VEHICLE_NUMBER,STATUS from Driver where STATUS='BLOCK' ";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
