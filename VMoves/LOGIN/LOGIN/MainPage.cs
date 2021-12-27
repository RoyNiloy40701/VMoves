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
    public partial class MainPage : Form
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ShareLocation st = new ShareLocation();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReviewViewDriver st = new ReviewViewDriver();
            st.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Complain st = new Complain();
            st.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            GiveReviewDriver st = new GiveReviewDriver();
            st.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectFuelProvider st = new SelectFuelProvider();
            st.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ConfirmOrder st = new ConfirmOrder();
            st.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment st = new Payment();
            st.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            login st = new login();
            st.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyAccount st = new MyAccount();
            st.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            this.Hide();
            OrderDetailsDriver st = new OrderDetailsDriver();
            st.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MyComplain st = new MyComplain();
            st.Show();
        }
    }
}
