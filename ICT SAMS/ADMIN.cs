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
    public partial class ADMIN : Form
    {
        public ADMIN()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN_Login ret = new ADMIN_Login();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee_Reg_Admin ret = new Employee_Reg_Admin();
            ret.Show();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {

        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_ADMIN ret = new Add_ADMIN();
            ret.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Supervisor ret = new Add_Supervisor();
            ret.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Charts ret = new Charts();
            ret.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appraise_ADMIN1 ret = new Appraise_ADMIN1();
            ret.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           Tasks_Create_ADMIN ret = new Tasks_Create_ADMIN();
            ret.Show();
        }
    }
}
