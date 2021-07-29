using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICT_SAMS
{
    public partial class Supervisor : Form
    {
        public Supervisor()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show(); 
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Reg ret = new Employee_Reg();
            ret.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appraise ret = new Appraise();
            ret.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Charts1 ret = new Charts1();
            ret.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Task_Create_Supervisor ret = new Task_Create_Supervisor();
            ret.Show();
        }
    }
}
