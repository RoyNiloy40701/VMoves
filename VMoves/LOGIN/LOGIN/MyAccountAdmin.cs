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
using System.IO;

namespace LOGIN
{
    public partial class MyAccountAdmin : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
          

        
        public MyAccountAdmin()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void MyAccount_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM ADMIN WHERE NID='" + login.nid + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                if (dr.Read())
                {
                    login.nid = dr.GetValue(2).ToString();
                    login.Email = dr.GetValue(1).ToString();
                    login.name = dr.GetValue(0).ToString();
                    login.pass = dr.GetValue(3).ToString();
                    login.image = ((byte[])dr.GetValue(4));
                    textBox1.Text = login.name;
                    textBox2.Text = login.Email;
                    textBox3.Text = login.nid;
                    textBox4.Text = login.pass;
                    textBox5.Text = login.pass;
                    pictureBox1.Image = GetPhoto((byte[])login.image);
                    con.Close();
                }
            }
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please filled the Name", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please filled the Email", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please filled the National Id", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please filled the Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Please filled the Confirm Password", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
            }

            else
            {
                if (textBox5.Text == textBox4.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update ADMIN  set NAME=@NAME,EMAIL=@email,Pass=@pass,Picture=@image where NID='"+login.nid+"'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                    cmd.Parameters.AddWithValue("@image", SavePhoto());

                    con.Open();
                    int c = cmd.ExecuteNonQuery();
                    if (c > 0)
                    {
                        MessageBox.Show(" Update successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                     
                    }
                    else
                    {
                        MessageBox.Show(" Failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                {
                    MessageBox.Show(" Confirm Password Not Match", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox5.Clear();

                }
            }
        }
        private byte[] SavePhoto()
        {
            MemoryStream st = new MemoryStream();
            pictureBox1.Image.Save(st, pictureBox1.Image.RawFormat);

            return st.GetBuffer();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_error;

                errorProvider1.SetError(this.textBox1, " Enter your Name");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.sign_error;

                errorProvider2.SetError(this.textBox2, " Enter your Email");
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

                errorProvider3.SetError(this.textBox3, " Enter your National Id");
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

                errorProvider4.SetError(this.textBox4, " Enter your password");
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

                errorProvider5.SetError(this.textBox5, " Enter your Confirm password");
            }
            else
            {
                errorProvider5.Icon = Properties.Resources.sign_tick;
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
           AdminStart f2 = new AdminStart();
            f2.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
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
            button2.BackColor = Color.LightSteelBlue;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status1 = checkBox1.Checked;
            switch (status1)
            {
                case true:
                    textBox4.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox4.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool status2 = checkBox2.Checked;
            switch (status2)
            {
                case true:
                    textBox5.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox5.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog pd = new OpenFileDialog();
            pd.Title = "Select Image";

            pd.Filter = "Image File (All files) *.* | *.*";

            if (pd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(pd.FileName);
            }
        }
    }
}
