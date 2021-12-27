using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageOrder f11 = new manageOrder();
            f11.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            orderDetails f5 = new orderDetails();
            f5.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            login f6 = new login();
            f6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewReview f7 = new viewReview();
            f7.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            giveReview f8 = new giveReview();
            f8.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            giveComplain f9 = new giveComplain();
            f9.Show();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            MyProfile f11 = new MyProfile();
            
            f11.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            viewComplain f12 = new viewComplain();
            f12.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
