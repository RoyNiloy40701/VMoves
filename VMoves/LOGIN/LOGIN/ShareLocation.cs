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
    public partial class ShareLocation : Form
    {
        public static string location;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ShareLocation()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }

        private void ShareLocation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the information", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
               BindGridView();
               
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter your Location");
            }

            else
            {
                errorProvider1.Clear();
            }
        }

        void BindGridView()
        {
           
            SqlConnection con = new SqlConnection(cs);

            string query = "select *  from FuelProvider where Location=@location and Status!='Block'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@location", textBox1.Text);
         
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows == true)
            {
                if (dr.Read())

                {
                    
                    
                    location = textBox1.Text;
                    this.Hide();
                    SelectFuelProvider av = new SelectFuelProvider();
                    av.Show();
                    

                }

            }
            else
            {
                MessageBox.Show("Not Found", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}

