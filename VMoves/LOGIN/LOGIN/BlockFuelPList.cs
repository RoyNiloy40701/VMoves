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
    public partial class BlockFuelPList : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public BlockFuelPList()
        {
            InitializeComponent();
            BindGridView();
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_error;

                errorProvider1.SetError(this.textBox1, " Enter fuel provider's license no. ");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
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
                string query = "update FuelProvider  set Status= 'Null' where License_No=@license_no";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@license_no", textBox1.Text);
                con.Open();
                int c = cmd.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show(" Unblock Fuel Provider successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Clear();
                    this.Hide();
                    BlockFuelPList ST = new BlockFuelPList ();
                    ST.Show();

                }
                else
                {
                    MessageBox.Show(" Failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminStart f1 = new AdminStart();
            f1.Show();

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
            button2.BackColor = Color.White;
        }

      
     
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select NAME,License_No, Location,Product_Details,Status from FuelProvider where Status='Block' ";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

      

       
    }
}
