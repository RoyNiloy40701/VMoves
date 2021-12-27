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
    public partial class ConfirmOrder : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ConfirmOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into ORDERTABLE values ('" + login.name + "','" + login.nid + "','" + login.Email + "','" + SelectFuelProvider.name + "','" + SelectFuelProvider.lno + "','" + SelectFuelProvider.location+ "','" + SelectFuelProvider.product+ "','" + Payment.paymenttype + "','" + SelectFuelProvider.date + "','Ordered','" + SelectFuelProvider.quantity + "','" + SelectFuelProvider.price + "','" + Payment.paystatus + "')";

            SqlCommand cmd = new SqlCommand(query, con);

           
       
            con.Open();
            int ab = cmd.ExecuteNonQuery();
            if (ab > 0)
            {

                MessageBox.Show("Orderd", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainPage st = new MainPage();
                st.Show();
            }
            else
            {
                MessageBox.Show("Order failed", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

           
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment st = new Payment();
            st.Show();
        }
    }
}
