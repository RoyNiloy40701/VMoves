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
    public partial class giveReview : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        
        public giveReview()
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
                string query = "insert into REVIEW values ('" + login.l_No + "',@REVIEW)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@REVIEW", textBox2.Text);



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
                MessageBox.Show("PLEASE GIVE YOUR REVIEW!", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void giveReview_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider1.SetError(this.textBox2, "Enter your Review!");
            }
            else
            {
                errorProvider1.Clear();
            }

        }
    }
    
}
