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
    public partial class Employee_Reg : Form
    {
        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Employee_Reg()
        {
            InitializeComponent();
            //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "EmployeeName";
            dataGridView1.Columns[2].Name = "UserName";
            dataGridView1.Columns[3].Name = "Password";
            dataGridView1.Columns[4].Name = "Category";
            dataGridView1.Columns[5].Name = "EmployeeStatus";
            dataGridView1.Columns[6].Name = "Designation";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        //INSERT INTO DB
        private void add(string EmployeeName, string UserName, string Password, string Category, string EmployeeStatus, string Designation)
        {
            //SQL STMT
            string sql = "INSERT INTO Employeereg(N,U,P,C,S,D) VALUES(@EmployeeName,@UserName,@Password,@Category,@EmployeeStatus,@Designation)";
            cmd = new OleDbCommand(sql, con);


            //ADD PARAMS
            cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Category", Category);
            cmd.Parameters.AddWithValue("@EmployeeStatus", EmployeeStatus);
            cmd.Parameters.AddWithValue("@Designation", Designation);

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
        private void populate(string id, string EmployeeName, string UserName, string Password, string Category, string EmployeeStatus, string Designation)
        {
            dataGridView1.Rows.Add(id, EmployeeName, UserName, Password, Category,EmployeeStatus,Designation);
        }

        //RETRIEVAL OF DATA
        private void retrieve()
        {
            dataGridView1.Rows.Clear();

            //SQL STMT
            String sql = "SELECT * FROM Employeereg ";
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
        private void update(int id, string EmployeeName, string UserName, string Password, string Category, string EmployeeStatus, string Designation)
        {
            //SQL STMT
            string sql = "UPDATE Employeereg SET N='" + EmployeeName + "',U='" + UserName + "',P='" + Password + "' ,C='" + Category + "',S='" + EmployeeStatus + "',D='" + Designation + "'WHERE ID=" + id + "";

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
            String sql = "DELETE FROM Employeereg WHERE ID=" + id + "";
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
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txt_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_username.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_password.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txt_Category.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txt_status.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txt_designation.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

       
        private void clearBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clearTxts();
        }

        

     
        private void Tasks_Created_Load(object sender, EventArgs e)
        {
            retrieve();
        }



        private void button1_Click(object sender, EventArgs e)
        {
             String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE Employeereg SET  N='" + txt_name.Text + "', U='" + txt_username.Text + "', P= '" + txt_password.Text + "', C= '" + txt_Category.Text + "', S= '" + txt_status.Text + "' , D= '" + txt_designation.Text + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();
            con.Close();

           textBox1.Text = "";
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";
            retrieve();

            MessageBox.Show("Records Updated Successfully");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                txt_name.Text = row.Cells[1].Value.ToString();
                txt_username.Text = row.Cells[2].Value.ToString();
                txt_password.Text = row.Cells[3].Value.ToString();
                txt_Category.Text = row.Cells[4].Value.ToString();
                txt_status.Text = row.Cells[5].Value.ToString();
                txt_designation.Text = row.Cells[6].Value.ToString();
                
            }
        }
        private void retrieveBtn_Click_1(object sender, EventArgs e)
        {
            retrieve();
        }

        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clearTxts();
        }

        private void deleteBtn_Click_1(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int id = Convert.ToInt32(selected);
            delete(id);
           textBox1.Text = "";
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";
        }

        private void Add_Supervisor_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == " " || txt_name.Text == " " || txt_username.Text == " ")
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
            cmd.CommandText = "UPDATE Employeereg SET  ID='" + textBox1.Text + "',N='" + txt_name.Text + "', U='" + txt_username.Text + "', P= '" + txt_password.Text + "', C= '" + txt_Category.Text + "', S= '" + txt_status.Text + "' , D= '" + txt_designation.Text + "' WHERE ID=" + id + "";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";
            retrieve();

            MessageBox.Show("Records Updated Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        
        }

        
    

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from Employeereg";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

      

        private void btn_new_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employeereg values('" + textBox1.Text + "','" + txt_name.Text + "', '" + txt_username.Text + "', '" + txt_password.Text + "', '" + txt_Category.Text + "', '" + txt_status.Text + "', '" + txt_designation.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";

            MessageBox.Show("Inserted Successfully");


        }

        private void btn_close_Click(object sender, EventArgs e)
        {

            this.Hide();
            Supervisor ret = new Supervisor();
            ret.Show();
        }

       

        private void btn_new_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || txt_name.Text == " " || txt_username.Text == " ")
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else

                try
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Employeereg values('" + textBox1.Text + "','" + txt_name.Text + "', '" + txt_username.Text + "', '" + txt_password.Text + "', '" + txt_Category.Text + "', '" + txt_status.Text + "', '" + txt_designation.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    textBox1.Text = "";
                    txt_name.Text = "";
                    txt_username.Text = "";
                    txt_password.Text = "";
                    txt_Category.Text = "";
                    txt_status.Text = "";
                    txt_designation.Text = "";

                    MessageBox.Show("Inserted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            retrieve();
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Employeereg where N='" + txt_name.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Text = "";
            txt_name.Text = "";
            txt_username.Text = "";
            txt_password.Text = "";
            txt_Category.Text = "";
            txt_status.Text = "";
            txt_designation.Text = "";

            MessageBox.Show("Deleted Successfully");

        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Supervisor ret = new Supervisor();
            ret.Show();
        }

        private void btn_save_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || txt_name.Text == " " || txt_username.Text == " ")
            {

                MessageBox.Show(" Please enter all the Required Details!");

            }

            else

                try
                {
                    con.Open();
                    OleDbCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Employeereg values('" + textBox1.Text + "','" + txt_name.Text + "', '" + txt_username.Text + "', '" + txt_password.Text + "', '" + txt_Category.Text + "', '" + txt_status.Text + "', '" + txt_designation.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    textBox1.Text = "";
                    txt_name.Text = "";
                    txt_username.Text = "";
                    txt_password.Text = "";
                    txt_Category.Text = "";
                    txt_status.Text = "";
                    txt_designation.Text = "";

                    MessageBox.Show("Inserted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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

        private void Employee_Reg_Load(object sender, EventArgs e)
        {
            retrieve();
        }

        
    }
}
