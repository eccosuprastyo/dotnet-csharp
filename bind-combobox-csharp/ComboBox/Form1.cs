using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ComboBox
{
    public partial class Form1 : Form
    {
        ConnectionDB con = new ConnectionDB();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getDataComboBox();
        }

        private void getDataComboBox()
        {
            con.Open();
            string query = "select title from user";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    comboBox1.Items.Add(row["title"].ToString());
                }

            }
            con.Close();
        }
    }
}
