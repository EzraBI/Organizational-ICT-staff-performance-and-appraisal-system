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
    public partial class Employee_List : Form
    {
        static string conString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= C:\ICT SPAM\ICT SAMS\Databases.mdb;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;
        OleDbDataAdapter adapter;
        DataTable dt = new DataTable();
        public Employee_List()
        {
            InitializeComponent();
             //DATAGRIDVIEW PROPERTIES
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "EmployeeName";
            dataGridView1.Columns[2].Name = "Category";
            dataGridView1.Columns[3].Name = "EmployeeStatus";
            dataGridView1.Columns[4].Name = "Designation";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        
        //FILL DGVIEW
        private void populate(string id, string EmployeeName, string Category, string EmployeeStatus, string Designation)
        {
            dataGridView1.Rows.Add(id, EmployeeName, Category,EmployeeStatus,Designation);
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
                    populate(row[0].ToString(), row[1].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee ret = new Employee();
            ret.Show();
        }

        private void Employee_List_Load(object sender, EventArgs e)
        {
            retrieve();
        }
        }
    }
