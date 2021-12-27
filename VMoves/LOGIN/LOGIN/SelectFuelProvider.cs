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
   
    public partial class SelectFuelProvider : Form

    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string name, lno, location, product, date, quantity;
        public static string price;
            public SelectFuelProvider()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
          ShareLocation st = new ShareLocation();
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
            else if (textBox5.Text == "0")
            {
                MessageBox.Show("Enter Valid Quantity", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (dateTimePicker1.Text == " ")
            {
                MessageBox.Show("Select Date", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePicker1.Focus();
            }

            else
            {
                date = this.dateTimePicker1.Text;
                this.Hide();
                Payment st = new Payment();
                st.Show();
            }

        }

        

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your Name!");
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
                errorProvider2.SetError(this.textBox2, "Enter your License Number!");
            }

            else
            {
                errorProvider2.Clear();
            }
        }

        
        
       
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Please Enter Only Digit ", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                quantity = textBox5.Text;
                price = (Convert.ToDouble(textBox5.Text) * 100).ToString();
                textBox6.Text = price;
            }   
             
            catch
            {
               //MessageBox.Show("Found error ", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void SelectFuelProvider_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) == true)
            {
                textBox5.Focus();
                errorProvider5.SetError(this.textBox5, "Enter quantity!");
            }

            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider4.SetError(this.textBox4, "Enter a fuel type!");
            }

            else
            {
                errorProvider4.Clear();
            }
        }

        

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) == true)
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Enter Location!");
            }

            else
            {
                errorProvider3.Clear();
            }
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select *  from FuelProvider where Location='" + ShareLocation.location + "'  and Status!='Block'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            name= textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            lno=textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            location=textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            product = textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
           
        }
    }
    
}
