using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Assigment1
{
    public partial class CrudForm : Form
    {
        MySqlConnection con;
        MySqlDataAdapter adapt;
        DataSet ds;
        int selectedRow;
        int indexRow;
        public CrudForm()
        {
            InitializeComponent();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CrudForm_Load(object sender, EventArgs e)
        {
            try
            {
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.FistName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.Sex = txtSex.Text;
                employee.Age = Convert.ToInt32(txtAge.Text);

                IDBManager db = new MySQLDBManager();
                db.AddEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Created!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtID.Text;
            newDataRow.Cells[1].Value = txtFirstName.Text;
            newDataRow.Cells[2].Value = txtLastName.Text;
            newDataRow.Cells[3].Value = txtSex.Text;
            newDataRow.Cells[4].Value = txtAge.Text;
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.FistName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.Sex = txtSex.Text;
                employee.Age = Convert.ToInt32(txtAge.Text);


                IDBManager db = new MySQLDBManager();
                db.DeleteEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Refreshed!", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtID.Text;
            newDataRow.Cells[1].Value = txtFirstName.Text;
            newDataRow.Cells[2].Value = txtLastName.Text;
            newDataRow.Cells[3].Value = txtSex.Text;
            newDataRow.Cells[4].Value = txtAge.Text;
            try
            {
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.FistName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.Sex = txtSex.Text;
                employee.Age = Convert.ToInt32(txtAge.Text);


                IDBManager db = new MySQLDBManager();
                db.UpdateEmployee(employee);
                BindingSource bindingsource = new BindingSource();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bindingsource;
                dataGridView1.Refresh();
                con = new MySqlConnection();
                con.ConnectionString = @"datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;Convert Zero Datetime=True;";
                con.Open();
                adapt = new MySqlDataAdapter("select id,first_name,last_name,sex,age from employees", con);
                ds = new System.Data.DataSet();
                adapt.Fill(ds, "Employee_Details");
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex; // get the selected Row Index
            DataGridViewRow row = dataGridView1.Rows[indexRow];

            txtID.Text = row.Cells[0].Value.ToString();
            txtFirstName.Text = row.Cells[1].Value.ToString();
            txtLastName.Text = row.Cells[2].Value.ToString();
            txtSex.Text = row.Cells[3].Value.ToString();
            txtAge.Text = row.Cells[4].Value.ToString();
        }
    }
}
