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
    public partial class AddFP : Form
    {

        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public AddFP()
        {
            InitializeComponent();
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminStart f2 = new AdminStart();
            f2.Show();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
           
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into FuelProvider values (@name,@license_no,@location,@mobile_no,@product,@pass,' ')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", textBox6.Text);
                cmd.Parameters.AddWithValue("@license_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@mobile_no", textBox3.Text);
                cmd.Parameters.AddWithValue("@location", textBox4.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd.Parameters.AddWithValue("@product", textBox5.Text);
                

                con.Open();
                int ab = cmd.ExecuteNonQuery();
                if (ab> 0)
                {
                    MessageBox.Show(" added successfully", "Successful..", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
                else
                {
                    MessageBox.Show(" added failed", "Failed..", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

      

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkOliveGreen;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_tick;

                errorProvider1.SetError(this.textBox1, " Enter fuel provider License No..");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
                errorProvider2.Icon = Properties.Resources.sign_error;

                errorProvider2.SetError(this.textBox6, " Enter fuel provider name..");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.Icon = Properties.Resources.sign_error;

                errorProvider3.SetError(this.textBox3, " Enter  Mobile No..");
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
                errorProvider4.Icon = Properties.Resources.sign_error;

                errorProvider4.SetError(this.textBox4, " Enter Location ..");
            }
            else
            {
                errorProvider4.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
                errorProvider5.Icon = Properties.Resources.sign_error;

                errorProvider5.SetError(this.textBox5, " Enter Products Details..");
            }
            else
            {
                errorProvider5.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider6.Icon = Properties.Resources.sign_error;

                errorProvider6.SetError(this.textBox2, " Enter  password");
            }
            else
            {
                errorProvider6.Icon = Properties.Resources.sign_tick;
            }
        }
    }
}
