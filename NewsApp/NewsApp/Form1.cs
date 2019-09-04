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

namespace NewsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connString = Properties.Settings.Default.ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string query = "SELECT * FROM Categories";
            SqlCommand command = new SqlCommand(query,conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MessageBox.Show($"{reader.GetInt32(0)} - {reader.GetString(1)}");
            }

            conn.Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conn.Open();

            string query = "INSERT INTO Categories(Name) VALUES('Teymur')";
            SqlCommand command = new SqlCommand(query, conn);
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows > 0)
            {
                MessageBox.Show("Added");
            }

            conn.Close();
        }
    }
}
