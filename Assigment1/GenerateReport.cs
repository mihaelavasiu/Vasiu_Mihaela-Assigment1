using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Assigment1
{
    public partial class GenerateReport : Form
    {
        private string connString = "datasource=127.0.0.1;port=3306;username=root;password=;database=assigment1;";
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                int id=Convert.ToInt32(txtID.Text);
                DateTime d1 = dateTimePicker1.Value;
                DateTime d2 = dateTimePicker2.Value;
            StreamWriter File = new StreamWriter("Report.txt");
           // File.Write("HI\r\n");
           // File.Write("YOu\r\n");
          
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT `id`, `name`, `description`, `date`, `employee_id` FROM `activities` WHERE employee_id=" + id + " AND date>'" + d1 + "' AND date<'" + d2 + "';";
                    cmd.Prepare();


                    using (MySqlDataReader rdr = cmd.ExecuteReader()) {
                        while (rdr.Read())
                        {
                            string idc = rdr["id"].ToString();
                            string  namec= rdr["name"].ToString();
                            string descriptionc = rdr["description"].ToString();
                            string datec = rdr["date"].ToString();
                            string employeec = rdr["employee_id"].ToString();
                            File.Write(idc);
                            File.Write("\r\n");
                            File.Write(namec);
                            File.Write("\r\n");
                            File.Write(descriptionc);
                            File.Write("\r\n");
                            File.Write(datec);
                            File.Write("\r\n");
                            File.Write(employeec);

                        }
                    }
                   

                  File.Close();  
                }
            MessageBox.Show("Report generated!", "Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }

        }
    }
}
