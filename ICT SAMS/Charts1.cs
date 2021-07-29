using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICT_SAMS
{
    public partial class Charts1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\Perf\ICT SAMS11\ICT SAMS\Databases.mdb");




        public Charts1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;
Persist Security Info=False;";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supervisor ret = new Supervisor();
            ret.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select* from Appraise";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Flexibility.Series["F"].Points.AddXY(reader["N"].ToString(), reader["F"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }

        private void Charts1_Load(object sender, EventArgs e)
        {
           
          
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select* from Appraise";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    TrainingNeeds.Series["TN"].Points.AddXY(reader["N"].ToString(), reader["TN"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select* from Appraise";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    LeadershipSkills.Series["LS"].Points.AddXY(reader["N"].ToString(), reader["LS"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select* from Appraise";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Flexibility.Series["F"].Points.AddXY(reader["N"].ToString(), reader["F"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select* from Appraise";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Competence.Series["C"].Points.AddXY(reader["N"].ToString(), reader["C"].ToString());

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }
    }
}
