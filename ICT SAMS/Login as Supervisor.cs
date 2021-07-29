using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ICT_SAMS
{
    public partial class Login_as_Supervisor : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Login_as_Supervisor()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;
Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select* from Supervisor where U='" + textBox1.Text + "'and P='" + textBox2.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Credentials Correct");

                this.Hide();
                Supervisor ret = new Supervisor();
                ret.Show();
            }

            else
            {
                if (count > 1)
                {
                    MessageBox.Show("Duplicate UserName and Password");
                }
                else
                {
                    MessageBox.Show("UserName and Password incorrect");
                }
                {

                    connection.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }
    }
}
