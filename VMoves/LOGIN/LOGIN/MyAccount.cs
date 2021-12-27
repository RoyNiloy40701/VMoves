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
    public partial class MyAccount : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public MyAccount()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if (textBox2.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
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
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else
            {
                if (textBox6.Text == textBox7.Text)
                {


                    SqlConnection con = new SqlConnection(cs);
                    string query = "update DRIVER set NAME=@NAME,EMAIL=@EMAIL,DRIVING_LICENSE_NUMBER =@DRIVING_LICENSE_NUMBER,VEHICLE_NUMBER=@VEHICLE_NUMBER,PASS=@PASS,Picture=@image WHERE NID_NUMBER='" + login.nid + "'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@EMAIL", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DRIVING_LICENSE_NUMBER", textBox4.Text);
                    cmd.Parameters.AddWithValue("@VEHICLE_NUMBER", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PASS", textBox6.Text);
                    cmd.Parameters.AddWithValue("@image", SavePhoto());

                    con.Open();
                    int ab = cmd.ExecuteNonQuery();
                    if (ab > 0)
                    {
                        MessageBox.Show("UPDATE SUCCESSFULLY", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                    else
                    {
                        MessageBox.Show("Registration failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Confirm Password Not Matched", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox7.Clear();
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
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your name!");
            }

            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "Enter your email!");
            }

            else
            {
                errorProvider2.Clear();
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter your NID number!");
            }

            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter your driving license number!");
            }

            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter your vehicle number!");
            }

            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Enter a new password!");
            }

            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Retype your password!");
            }

            else
            {
                errorProvider7.Clear();
            }
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

        private void MyAccount_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM DRIVER  WHERE NID_NUMBER='" + login.nid + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                if (dr.Read())
                {
                    login.name = dr.GetValue(0).ToString();
                    login.Email = dr.GetValue(1).ToString();
                    login.nid = dr.GetValue(2).ToString();
                    login.dno = dr.GetValue(3).ToString();
                    login.vno = dr.GetValue(4).ToString();
                    login.pass = dr.GetValue(5).ToString();
                    login.image = ((byte[])dr.GetValue(7));

                    textBox1.Text = login.name;
                    textBox2.Text = login.Email;
                    textBox3.Text = login.nid;
                    textBox4.Text = login.dno;
                    textBox5.Text = login.vno;
                    textBox6.Text = login.pass;
                    textBox7.Text = login.pass;
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
