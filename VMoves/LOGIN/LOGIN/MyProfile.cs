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
    public partial class MyProfile : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public MyProfile()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void MyProfile_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM FuelProvider WHERE License_No='" + login.l_No + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                if (dr.Read())
                {
                    login.name = dr.GetValue(0).ToString();
                    login.location = dr.GetValue(2).ToString();
                    login.phone = dr.GetValue(3).ToString();
                    login.l_No = dr.GetValue(1).ToString();
                    login.pass = dr.GetValue(5).ToString();
                    login.product_details = dr.GetValue(4).ToString();
                   
                    textBox1.Text = login.name;
                    textBox2.Text = login.location;
                    textBox3.Text = login.l_No;
                    textBox4.Text = login.pass;
                    textBox5.Text = login.pass;
                    textBox6.Text = login.product_details;
                    textBox7.Text = login.phone;
                   


                    con.Close();
                }
            }
           
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please filled the Name", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please filled the Location", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Please filled the License Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Please filled the Product details", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox6.Focus();

            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Please filled the Phone Number", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
            }

            else
            {
                if (textBox5.Text == textBox4.Text)
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "update FuelProvider  set Name=@NAME,Location=@loc,Pass=@pass, MobileNo=@phone, Product_Details=@pd where License_No='" + login.l_No + "'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
                    cmd.Parameters.AddWithValue("@loc", textBox2.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox4.Text);
                    cmd.Parameters.AddWithValue("@pd", textBox6.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox7.Text);
                

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
     
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            homePage f1 = new homePage();
            f1.Show();
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Please Enter your Name!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider2.SetError(this.textBox2, "Please Enter your Location!");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox3, "Please Enter your License Number!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox4_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider4.SetError(this.textBox4, "Please Enter your Password!");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void textBox5_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox1.Focus();
                errorProvider5.SetError(this.textBox5, "Please Enter Confirm Password!");
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
                errorProvider6.SetError(this.textBox6, "Please Enter your Product Details!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox7.Focus();
                errorProvider7.SetError(this.textBox7, "Please Enter your Phone Number!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox4.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox4.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            bool status = checkBox2.Checked;
            switch (status)
            {
                case true:
                    textBox5.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox5.UseSystemPasswordChar = true;
                    break;
            }
        }

      
    }
}
