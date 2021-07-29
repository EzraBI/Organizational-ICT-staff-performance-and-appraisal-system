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
    public partial class Add_ADMIN : Form
    {
        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";
        //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\Perf\ \ICT SAMS11\ICT SAMS\ADMIN.mdb");
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        //int count = 0;
        public Add_ADMIN()
        {
            InitializeComponent();
            //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "ADMINNAME";
            dataGridView1.Columns[2].Name = "UserName";
            dataGridView1.Columns[3].Name = "Password";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

        }
        //INSERT INTO DB
        private void add(string ADMINNAME, string UserName, string Password)
        {
            //SQL STMT
            string sql = "INSERT INTO ADMIN(N,U,P) VALUES(@ADMINNAME,@UserName,@Password)";
            cmd = new OleDbCommand(sql, con);


            //ADD PARAMS
            cmd.Parameters.AddWithValue("@ADMINNAME", ADMINNAME);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);

            //OPEN CON AND EXEC insert
            try
            {
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    clearTxts();
                    MessageBox.Show("Successfully Inserted");

                }
                con.Close();

                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        //FILL DGVIEW
        private void populate(string id, string ADMINNAME, string UserName, string Password)
        {
            dataGridView1.Rows.Add(id, ADMINNAME, UserName, Password);
        }

        //RETRIEVAL OF DATA
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

            //SQL STMT
            String sql = "SELECT * FROM ADMIN ";
            cmd = new OleDbCommand(sql, con);

            try
            {
                con.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(dt);

                //LOOP THRU DT
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString());
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
        private void update(int id, string ADMINNAME, string UserName, string Password)
        {
            //SQL STMT
            string sql = "UPDATE ADMIN SET ID='" + id + "',N='" + ADMINNAME + "',U='" + UserName + "',P='" + Password + "' WHERE ID=" + id + "";

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
            String sql = "DELETE FROM ADMIN WHERE ID=" + id + "";
            cmd = new OleDbCommand(sql, con);

            //'OPEN CON,EXECUTE DELETE,CLOSE CON
            try
            {
                con.Open();
                adapter = new OleDbDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                //PROMPT FOR CONFIRMATION
                if (MessageBox.Show("Sure ??", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Successfully deleted");
                    }
                }

                con.Close();

                retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        //CLEAR TXT
        private void clearTxts()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }





        private void clearBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clearTxts();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supervisor ret = new Supervisor();
            ret.Show();
        }


        private void Tasks_Created_Load(object sender, EventArgs e)
        {
            retrieve();
        }


        private void retrieveBtn_Click(object sender, EventArgs e)
        {
            retrieve();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        
                String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
           
        }

        private void clearBtn_Click_2(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clearTxts();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ADMIN ret = new ADMIN();
            ret.Show();
        }





        private void Add_ADMIN_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text == " " || textBox2.Text == " " ||textBox3.Text == " " ||textBox4.Text == " " )
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
            cmd.CommandText = "UPDATE ADMIN SET  ID='" + textBox1.Text + "',N='" + textBox2.Text + "', U='" + textBox3.Text + "', P= '" + textBox4.Text + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            retrieve();

            MessageBox.Show("Records Updated Successfully");
                

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();

            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
              if (textBox1.Text == " " || textBox2.Text == " " ||textBox3.Text == " " ||textBox4.Text == " " )
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else    
          
                try
                {
               
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into ADMIN values('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            retrieve();

            MessageBox.Show("Inserted Successfully");
             }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
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

        
   