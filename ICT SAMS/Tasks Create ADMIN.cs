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
    public partial class Tasks_Create_ADMIN : Form
    {

        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";

        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
       public Tasks_Create_ADMIN()
        {
            InitializeComponent();
           
            //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 7;

            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Description";
            dataGridView1.Columns[2].Name = "Department";
            dataGridView1.Columns[3].Name = "Datecreated";
            dataGridView1.Columns[4].Name = "Time";
            dataGridView1.Columns[5].Name = "Status";
            dataGridView1.Columns[6].Name = "Assignee";



            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }



       //FILL DGVIEW
       private void populate(string id, string Description, string Department, string Datecreated, string Time, string Status, string Assignee)
       {
           dataGridView1.Rows.Add(id, Description, Department, Datecreated, Time, Status, Assignee);
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
                   populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
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

       //UPDATE DB
       private void update(int id, string Description, string Department, string Time, string Status, string Assignee, string Progress, string SComment, string EComment)
       {
           //SQL STMT
           string sql = "UPDATE Appraise SET D='" + Description + "',DP='" + Department + "', DC= '" + dtpVisitDate.Text + "',T='" + Time + "',S='" + Status + "',N='" + Assignee + "',P='" + Progress + "',SC='" + SComment + "',SC='" + EComment + "'  WHERE ID=" + id + "";
           cmd = new OleDbCommand(sql, con);

            //OPEN CON,UPDATE,RETRIEVE DGVIEW
            try
            {
                con.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;

                if (adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Updated");
                    retrieve();
                }

                con.Close();

                //REFRESH
                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        //DELETE FROM DB
        private void delete(int id)
        {
            //SQL STMT
            String sql = "DELETE FROM Appraise WHERE ID=" + id + "";
            cmd = new OleDbCommand(sql, con);

            //'OPEN CON,EXECUTE DELETE,CLOSE CON
            try
            {
                con.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                retrieve();
            }
        }

        //CLEAR TXT
        private void clearTxts()
        {
            textBox1.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox8.Text = "";
            comboBox5.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "Other")
                comboBox2.Text = "Complete";

            else
                comboBox13.Text = "Complete";

            if (comboBox6.Text == "Other")
                comboBox5.Text = " ";

            else
                comboBox5.Text = " ";

            if (comboBox6.Text == "Other")
                comboBox1.Text = "Not Done";

            else
                comboBox1.Text = "Not Done";

            if (comboBox2.Text == "Complete")
                comboBox13.Text = "0";

            else
                comboBox13.Text = "0";


            if (comboBox1.Text == "Equiping")
                comboBox12.Text = "0";

            else
                comboBox12.Text = "0";


            if (comboBox5.Text == "Excellent")
                comboBox11.Text = "0";

            else
                comboBox11.Text = "0";


            if (comboBox3.Text == "Critical")
                comboBox10.Text = "0";


            else
                comboBox10.Text = "0";
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
                    cmd.CommandText = "insert into Appraise values('" + textBox1.Text + "','" + comboBox6.Text + "', '" + comboBox7.Text + "', '" + dtpVisitDate.Text + "','" + comboBox4.Text + "', '" + comboBox3.Text + "', '" + comboBox8.Text + "', '" + comboBox2.Text + "','" + comboBox5.Text + "', '" + comboBox1.Text + "', '" + comboBox13.Text + "', '" + comboBox12.Text + "', '" + comboBox11.Text + "', '" + comboBox10.Text + "')";
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


                    MessageBox.Show("Inserted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            retrieve();
        }

        private void Tasks_Create_ADMIN_Load(object sender, EventArgs e)
        {
              retrieve();retrieve();
        }

        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            retrieve();
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
            comboBox7.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox8.Text = "";
            comboBox2.Text = "";
            comboBox5.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Deleted Successfully");
            retrieve();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clearTxts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {



            if (comboBox6.Text == "Other")
                comboBox2.Text = "Complete";

            else
                comboBox13.Text = "Complete";

            if (comboBox6.Text == "Other")
                comboBox5.Text = "Excellent";

            else
                comboBox5.Text = "Excellent";

            if (comboBox6.Text == "Other")
                comboBox1.Text = "Not Done";

            else
                comboBox1.Text = "Not Done";

            if (comboBox2.Text == "Complete")
                comboBox13.Text = "0";

            else
                comboBox13.Text = "0";


            if (comboBox1.Text == "Equiping")
                comboBox12.Text = "0";

            else
                comboBox12.Text = "0";


            if (comboBox5.Text == "Excellent")
                comboBox11.Text = "0";

            else
                comboBox11.Text = "0";


            if (comboBox3.Text == "Critical")
                comboBox10.Text = "0";


            else
                comboBox10.Text = "0";

            if (textBox1.Text == " " || comboBox6.Text == "" || comboBox7.Text == "" || comboBox8.Text == "" || comboBox4.Text == "")
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else

                try
                {


                    String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    int id = Convert.ToInt32(selected);

                    //UPDATE( txt_name.Text, txt_username.Text, txt_password.Text, txt_Category.Text, txt_status.Text, txt_designation.Text); 

                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Appraise SET ID='" + textBox1.Text + "', D='" + comboBox6.Text + "', DP= '" + comboBox7.Text + "', DC= '" + dtpVisitDate.Text + "', T= '" + comboBox4.Text + "', S= '" + comboBox3.Text + "', N= '" + comboBox8.Text + "', P= '" + comboBox2.Text + "', SC= '" + comboBox5.Text + "', EC= '" + comboBox1.Text + "', C= '" + comboBox13.Text + "', F= '" + comboBox12.Text + "', TN= '" + comboBox11.Text + "', LS= '" + comboBox10.Text + "' WHERE ID=" + id + "";

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

                    MessageBox.Show("Records Updated Successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            retrieve();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN ret = new ADMIN();
            ret.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

            }
        }

        private void Tasks_Create_ADMIN_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
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
