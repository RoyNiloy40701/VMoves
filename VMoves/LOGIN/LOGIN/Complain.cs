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
    public partial class Complain : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Complain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into COMPLAIN values ('" + login.nid + "',@COMPLAIN)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@COMPLAIN", textBox1.Text);

                con.Open();
                int ab = cmd.ExecuteNonQuery();
                if (ab > 0)
                {
                    MessageBox.Show("SUBMITTED", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("PLEASE GIVE YOUR COMPLAIN!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your username!");
            }

            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Complain_Load(object sender, EventArgs e)
        {

        }
    }
}
