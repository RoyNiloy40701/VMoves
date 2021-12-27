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
    public partial class Payment : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public static string paymenttype,paystatus;
        public Payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            if (radioButton1.Checked == true) 
            {
                paymenttype = radioButton1.Text;
                this.Hide();
               PaymentConfirm st = new PaymentConfirm();
                st.Show();
                //MessageBox.Show("Ordered", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton2.Checked == true)
            {
                paymenttype = radioButton2.Text;
                this.Hide();
                PaymentConfirm st = new PaymentConfirm();
                st.Show();
                //MessageBox.Show("Ordered", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton3.Checked == true)
            {
                paymenttype = radioButton3.Text;
                this.Hide();
                PaymentConfirm st = new PaymentConfirm();
                st.Show();
                //MessageBox.Show("Ordered", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton4.Checked == true)
            {
                paymenttype = radioButton4.Text;
                paystatus = "Not Pay";
                this.Hide();
                ConfirmOrder st = new ConfirmOrder();
                st.Show();
                //MessageBox.Show("Ordered", "Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
              
                    MessageBox.Show("Please select anyone", "Failed..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectFuelProvider st = new SelectFuelProvider();
            st.Show();
        }
    }
}
