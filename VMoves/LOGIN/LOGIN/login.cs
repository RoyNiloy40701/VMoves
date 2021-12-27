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
    public partial class login : Form

    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static String nid, Email, name, pass, dno, l_No, vno, location, phone, product_details;
         public  static byte[] image;

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }



        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkGray;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkGray;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.sign_error;

                errorProvider2.SetError(this.textBox2, " Enter your email");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.sign_tick;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_error;

                errorProvider1.SetError(this.textBox1, " Enter your email");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
        }

        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DriverReg st = new DriverReg();
            st.Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from  Admin where NID=@user  ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
              
                this.Hide();
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows == true)
                {
                    if (dr.Read())
                    {
                        if (dr.GetValue(2).ToString() == textBox1.Text )
                        {
                            if (dr.GetValue(3).ToString() == textBox2.Text)
                            {
                                nid = dr.GetValue(2).ToString();
                                Email = dr.GetValue(1).ToString();
                                name = dr.GetValue(0).ToString();
                                pass = dr.GetValue(3).ToString();
                                image = ((byte[])dr.GetValue(4));
                                AdminStart f2 = new AdminStart();
                                f2.Show();
                            }
                            else
                            {
                                MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                login r = new login();
                                r.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("User Id Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            login r = new login();
                            r.Show();
                        }

                    }

                }

                else if (dr.HasRows == false)
                {
                    con.Close();

                    String queryd = "SELECT * FROM DRIVER where NID_NUMBER=@user  ";
                    SqlCommand cmd1 = new SqlCommand(queryd, con);
                    cmd1.Parameters.AddWithValue("@user", textBox1.Text);
                   
                    this.Hide();

                    con.Open();
                    SqlDataReader drd = cmd1.ExecuteReader();

                    if (drd.HasRows == true)
                    {
                        if (drd.Read())
                        {
                            if (drd.GetValue(2).ToString() == textBox1.Text)
                            {
                                if (drd.GetValue(5).ToString() == textBox2.Text)
                                {
                                    if (drd.GetValue(6).ToString() != "Block")
                                    {


                                        name = drd.GetValue(0).ToString();
                                        Email = drd.GetValue(1).ToString();
                                        nid = drd.GetValue(2).ToString();
                                        dno = drd.GetValue(3).ToString();
                                        vno = drd.GetValue(4).ToString();
                                        pass = drd.GetValue(5).ToString();
                                        image = ((byte[])drd.GetValue(7));
                                        this.Hide();
                                        MainPage f2 = new MainPage();
                                        f2.Show();

                                    }
                                    else
                                    {
                                        MessageBox.Show("Your Account Block", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        login r = new login();
                                        r.Show();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    login r = new login();
                                    r.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("User Id Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                login r = new login();
                                r.Show();
                            }
                                

                         }
                     }

                    else if (drd.HasRows == false)
                    {
                        con.Close();
                        String queryf = "SELECT * FROM FuelProvider where License_No=@user  ";
                        SqlCommand cmd2 = new SqlCommand(queryf, con);
                        cmd2.Parameters.AddWithValue("@user", textBox1.Text);
                       
                        this.Hide();

                        con.Open();
                        SqlDataReader drf = cmd2.ExecuteReader();

                        if (drf.HasRows == true)
                        {
                            if (drf.Read())
                            {
                                if (drf.GetValue(1).ToString() == textBox1.Text)
                                {
                                    if (drf.GetValue(5).ToString() == textBox2.Text)
                                    {
                                        if (drf.GetValue(6).ToString() != "Block")
                                        {

                                           name = drf.GetValue(0).ToString();
                                           location = drf.GetValue(2).ToString();
                                           phone = drf.GetValue(3).ToString();
                                           l_No = drf.GetValue(1).ToString();
                                           pass = drf.GetValue(5).ToString();
                                           product_details = drf.GetValue(4).ToString();
                                  
                                           this.Hide();
                                           homePage f2 = new homePage();
                                           f2.Show();
                                          con.Close();

                                         }                                         
                                        else
                                        {
                                          MessageBox.Show("Your Account Block", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                          login r = new login();
                                          r.Show();

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Password Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        login r = new login();
                                        r.Show();
                                    }
                                }
                               else
                                {
                                   MessageBox.Show("User Id Not Match", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                   login r = new login();
                                    r.Show();
                                }

                            }

                        }
                        else
                        {
                            MessageBox.Show("You are not Register", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            login r = new login();
                            r.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill the Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
   

