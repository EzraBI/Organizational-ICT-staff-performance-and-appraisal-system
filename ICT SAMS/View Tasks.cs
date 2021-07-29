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
    public partial class View_Tasks : Form
    {
        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public View_Tasks()
        {
            InitializeComponent();
            //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Description";
            dataGridView1.Columns[2].Name = "Department";
            dataGridView1.Columns[3].Name = "Datecreated";
            dataGridView1.Columns[4].Name = "Time";
            dataGridView1.Columns[5].Name = "Status";
            dataGridView1.Columns[6].Name = "Assignee";
            dataGridView1.Columns[7].Name = "Progress";
            dataGridView1.Columns[8].Name = "SComment";
            dataGridView1.Columns[9].Name = "EComment";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        //FILL DGVIEW
        private void populate(string id, string Description, string Department, string Datecreated, string Time, string Status, string Assignee, string Progress, string SComment, string EComment)
        {
            dataGridView1.Rows.Add(id, Description, Department, Datecreated,Time, Status, Assignee, Progress, SComment, EComment);
        }

        //RETRIEVAL OF DATA
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

            //SQL STMT
            String sql = "SELECT * FROM Appraise ";
            cmd = new OleDbCommand(sql, con);

            try
            {
                con.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(dt);

                //LOOP THRU DT
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                }

                con.Close();

                //CLEAR DT 
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {

            retrieve();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee ret = new Employee();
            ret.Show();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void View_Tasks_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            //UPDATE( txt_name.Text, txt_username.Text, txt_password.Text, txt_Category.Text, txt_status.Text, txt_designation.Text); 

            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Appraise SET   P= '" + comboBox2.Text + "' WHERE ID=" + id + "";
            //string sql = "UPDATE ADMIN SET N='" + ADMINNAME + "',U='" + UserName + "',P='" + Password + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();
            con.Close();


            comboBox1.Text = "";
            comboBox2.Text = "";

            MessageBox.Show("Records Updated Successfully");
            retrieve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            //UPDATE( txt_name.Text, txt_username.Text, txt_password.Text, txt_Category.Text, txt_status.Text, txt_designation.Text); 

            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Appraise SET   EC= '" + comboBox1.Text + "' WHERE ID=" + id + "";
            //string sql = "UPDATE ADMIN SET N='" + ADMINNAME + "',U='" + UserName + "',P='" + Password + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();
            con.Close();


            comboBox1.Text = "";
            comboBox2.Text = "";

            MessageBox.Show("Records Updated Successfully");
            retrieve();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox2.Text = row.Cells[7].Value.ToString();
                comboBox1.Text = row.Cells[9].Value.ToString();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);

            //UPDATE( txt_name.Text, txt_username.Text, txt_password.Text, txt_Category.Text, txt_status.Text, txt_designation.Text); 

            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Appraise SET   P= '" + comboBox2.Text + "', EC= '" + comboBox1.Text + "' WHERE ID=" + id + "";
            //string sql = "UPDATE ADMIN SET N='" + ADMINNAME + "',U='" + UserName + "',P='" + Password + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();
            con.Close();


            comboBox1.Text = "";
            comboBox2.Text = "";

            MessageBox.Show("Records Updated Successfully");
            retrieve();
        }
    }
}
    

