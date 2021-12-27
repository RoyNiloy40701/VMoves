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
    public partial class OrderDetailsDriver : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public OrderDetailsDriver()
        {
            InitializeComponent();
            BindGridView();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.sign_error;

                errorProvider1.SetError(this.textBox1, " Enter Order Id");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.sign_tick;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            MainPage st = new MainPage();
            st.Show();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);

            string query = "select *  from ORDERTABLE where (STATUS ='Ordered' OR STATUS='Accept') AND DRIVER_NID='" + login.nid + "'";

            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill The Information", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "delete from ORDERTABLE where ORDER_ID=@oid  and STATUS='Ordered'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@oid", textBox1.Text);

                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Order Cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindGridView();
                    this.Hide();
                    OrderDetailsDriver st = new OrderDetailsDriver();
                    st.Show();
                }
                else
                {
                    MessageBox.Show("Your Order Is Accepted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

   

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
        }
    }
}
