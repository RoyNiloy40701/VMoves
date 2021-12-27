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
    public partial class AdminStart : Form
    {
        public AdminStart()
        {
            InitializeComponent();
        }

        private void AdminStart_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();


            MyAccountAdmin f2 = new MyAccountAdmin();
            f2.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

 
            AddFP f2 = new AddFP();
            f2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();



            BlockDriverList f2 = new BlockDriverList();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            BlockFuelPList f2 = new BlockFuelPList();
            f2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllDriverList f2 = new AllDriverList();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReviewAdmin f2 = new ViewReviewAdmin();
            f2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComplainView f2 = new ComplainView();
            f2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            login f2 = new login();
            f2.Show();
        }
        

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();


            ALLFP f2 = new ALLFP();
            f2.Show();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.RoyalBlue;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSteelBlue;
        }
        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.RoyalBlue;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightSteelBlue;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.RoyalBlue;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.LightSteelBlue;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.RoyalBlue;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.LightSteelBlue;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.RoyalBlue;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightSteelBlue;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.RoyalBlue;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightSteelBlue;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.RoyalBlue;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightSteelBlue;
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            button9.BackColor = Color.RoyalBlue;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.LightSteelBlue;
        }

      
    }
}
