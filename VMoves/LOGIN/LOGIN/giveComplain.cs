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
    public partial class giveComplain : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public giveComplain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            homePage f1 = new homePage();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into COMPLAIN values ('" + login.l_No + "',@COMPLAIN)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@COMPLAIN", textBox2.Text);



                con.Open();
                int ab = cmd.ExecuteNonQuery();
                if (ab > 0)
                {
                    MessageBox.Show("SUBMITTED", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Clear();


                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("PLEASE GIVE YOUR COMPLAIN!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                
                errorProvider1.SetError(this.textBox2, "Enter your Complain!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
    }

