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
    public partial class AllDriverList : Form
    {
     
      string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AllDriverList()
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
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "delete from  Driver where  NID_NUMBER=@Nid";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nid", textBox1.Text);
                con.Open();
                int ab = cmd.ExecuteNonQuery();
                if (ab > 0)
                {
                    MessageBox.Show(" Driver deleted successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    this.Hide();
                    AllDriverList ST = new AllDriverList();
                    ST.Show();

                }
                else
                {
                    MessageBox.Show(" Failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();


            }
            else
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "update DRIVER set STATUS= 'Block' where NID_NUMBER=@NID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NID", textBox1.Text);
                con.Open();
                int c = cmd.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show(" Block User successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    this.Hide();
                    AllDriverList ST = new AllDriverList();
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

                errorProvider1.SetError(this.textBox1, " Enter  NId Number");
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
            button1.BackColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGreen;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
           
            string query = "select NAME,EMAIL,NID_NUMBER,DRIVING_LICENSE_NUMBER,VEHICLE_NUMBER,STATUS,Picture from Driver ";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

             DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
