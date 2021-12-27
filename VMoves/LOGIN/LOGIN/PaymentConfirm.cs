using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN
{
    public partial class PaymentConfirm : Form
    {
        public static String amount;
        public PaymentConfirm()
        {
            InitializeComponent();
            textBox2.Text = SelectFuelProvider.price;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment st = new Payment();
            st.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {  if (textBox1.Text != " ")
            {
                 amount = textBox1.Text;
                 if (amount == SelectFuelProvider.price)
                 {
                    Payment.paystatus = "Paid";
                    this.Hide();
                     ConfirmOrder st = new ConfirmOrder();
                     st.Show();

                 }
                else
                 {
                     MessageBox.Show("YOUR Enter amount and Price is not Euqal", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
               
            }
            else
            {

                MessageBox.Show("Please Enter The Amount ", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "Enter  Amount !");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar!='.')
            {
               e.Handled =true;
                MessageBox.Show("Please Enter Only Digit ", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
