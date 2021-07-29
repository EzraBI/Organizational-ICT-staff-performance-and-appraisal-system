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

    public partial class Appraise : Form
    {
        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";

        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Appraise()
        {
            InitializeComponent();
            //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 14;
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
            dataGridView1.Columns[10].Name = "Competence";
            dataGridView1.Columns[11].Name = "Flexibility";
            dataGridView1.Columns[12].Name = "TrainingNeeds";
            dataGridView1.Columns[13].Name = "LeadershipSkills";
           



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        //FILL DGVIEW
        private void populate(string id, string Description, string Department, string Datecreated,string Time,string Status, string Assignee, string Progress, string SComment, string EComment, string Competence, string Flexibility, string TrainingNeeds, string LeadershipSkills)
        {
            dataGridView1.Rows.Add(id, Description, Department,Datecreated, Time, Status, Assignee, Progress, SComment, EComment, Competence, Flexibility, TrainingNeeds, LeadershipSkills);
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
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(), row[11].ToString(), row[12].ToString(), row[13].ToString());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Appraise ret = new Appraise();
            ret.Show();
        }

       

        private void Appraise_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        
        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Charts1 ret = new Charts1();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
              if (textBox1.Text == " " || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "" || comboBox4.Text == "")
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else    
          
                try
                {

            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Appraise values('" + textBox1.Text + "','" + comboBox6.Text + "', '" + comboBox7.Text + "','" + dtpVisitDate.Text + "', '" + comboBox4.Text + "', '" + comboBox3.Text + "', '" + comboBox8.Text + "', '" + comboBox2.Text + "','" + comboBox5.Text + "', '" + comboBox1.Text + "', '" + comboBox13.Text + "', '" + comboBox12.Text + "', '" + comboBox11.Text + "', '" + comboBox10.Text + "')";
            cmd.ExecuteNonQuery();

            con.Close();
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox13.Text = "";
            comboBox12.Text = "";
            comboBox11.Text = "";
            comboBox10.Text = "";

            retrieve();
            MessageBox.Show("Inserted Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == " " || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "" || comboBox4.Text == "")
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else

                try
                {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);


            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "UPDATE Appraise SET  ID='" + textBox1.Text + "', D='" + comboBox6.Text + "', DP= '" + comboBox7.Text + "', DC= '" + dtpVisitDate.Text + "',T= '" + comboBox4.Text + "', S= '" + comboBox3.Text + "', N= '" + comboBox8.Text + "', P= '" + comboBox2.Text + "', SC= '" + comboBox5.Text + "', EC= '" + comboBox1.Text + "', C= '" + comboBox13.Text + "', F= '" + comboBox12.Text + "', TN= '" + comboBox11.Text + "', LS= '" + comboBox10.Text + "' WHERE ID=" + id + "";
           
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox13.Text = "";
            comboBox12.Text = "";
            comboBox11.Text = "";
            comboBox10.Text = "";

            retrieve();
            MessageBox.Show("Records Updated Successfully");
            
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Appraise where D='" + comboBox6.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox13.Text = "";
            comboBox12.Text = "";
            comboBox11.Text = "";
            comboBox10.Text = "";


            retrieve();
            MessageBox.Show("Deleted Successfully");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Complete")
                comboBox13.Text = "80";

            else if (comboBox2.Text == "Incomplete")
                comboBox13.Text = "40";
            else if (comboBox2.Text == "Going On")
                comboBox13.Text = "50";
            else if (comboBox2.Text == "Not Done")
                comboBox13.Text = "30";
            else
                comboBox13.Text = "20";

            if (comboBox1.Text == "Equiping")
                comboBox12.Text = "90";

            else if (comboBox1.Text == "Interesting")
                comboBox12.Text = "80";
            else if (comboBox1.Text == "Easy")
                comboBox12.Text = "70";
            else if (comboBox1.Text == "Difficult")
                comboBox12.Text = "60";
            else if (comboBox1.Text == "Tiresome")
                comboBox12.Text = "50";
            else if (comboBox1.Text == "Boring")
                comboBox12.Text = "30";

            else
                comboBox12.Text = "20";

            if (comboBox5.Text == "Excellent")
                comboBox11.Text = "90";

            else if (comboBox5.Text == "Very Good")
                comboBox11.Text = "70";
            else if (comboBox5.Text == "Good")
                comboBox11.Text = "60";
            else if (comboBox5.Text == "Fair")
                comboBox11.Text = "50";

            else
                comboBox11.Text = "20";


            if (comboBox3.Text == "Critical")
                comboBox10.Text = "90";

            else if (comboBox3.Text == "Urgent")
                comboBox10.Text = "80";
            else if (comboBox3.Text == "Important")
                comboBox10.Text = "70";


            else
                comboBox10.Text = "50";
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox13.Text = "";
            comboBox12.Text = "";
            comboBox11.Text = "";
            comboBox10.Text = "";
            retrieve();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Supervisor ret = new Supervisor();
            ret.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Charts1 ret = new Charts1();
            ret.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                comboBox6.Text = row.Cells[1].Value.ToString();
                comboBox7.Text = row.Cells[2].Value.ToString();
                dtpVisitDate.Text = row.Cells[3].Value.ToString();
                comboBox4.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
                comboBox8.Text = row.Cells[6].Value.ToString();
                comboBox2.Text = row.Cells[7].Value.ToString();
                comboBox5.Text = row.Cells[8].Value.ToString();
                comboBox1.Text = row.Cells[9].Value.ToString();
                comboBox13.Text = row.Cells[10].Value.ToString();
                comboBox12.Text = row.Cells[11].Value.ToString();
                comboBox11.Text = row.Cells[12].Value.ToString();
                comboBox10.Text = row.Cells[13].Value.ToString();

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ret = new Form1();
            ret.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        }
        }
      