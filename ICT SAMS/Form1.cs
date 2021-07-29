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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Login ret = new Employee_Login();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_as_Supervisor ret = new Login_as_Supervisor();
            ret.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_Login ret = new ADMIN_Login();
            ret.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        
    }
}
