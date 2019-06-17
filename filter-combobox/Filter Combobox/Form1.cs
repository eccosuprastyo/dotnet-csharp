using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace Filter_Combobox
{
    public partial class Form1 : Form
    {
        ConnectionDB con = new ConnectionDB();

        //arraylist to getter and setter data
        private static ArrayList ListID = new ArrayList();
        private static ArrayList ListFirstname = new ArrayList();
        private static ArrayList ListLastname = new ArrayList();
        private static ArrayList ListTelephone = new ArrayList();
        private static ArrayList ListAddress = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void getDataComboBox()
        {
            con.Open();
            string query = "select firstname from user";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    comboBox1.Items.Add(row["firstname"].ToString());
                }

            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getDataComboBox();
            GetData();
            if (ListID.Count > 0)
            {
                updateDatagrid();
            }
        }

        private void GetData()
        {
            try
            {
                con.Open();
                string query = "select id,firstname,lastname,telephone,address from user";

                //MySqlDataReader row;
                MySqlDataReader row;
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        ListID.Add(row["id"].ToString());
                        ListFirstname.Add(row["firstname"].ToString());
                        ListLastname.Add(row["lastname"].ToString());
                        ListTelephone.Add(row["telephone"].ToString());
                        ListAddress.Add(row["address"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void updateDatagrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = ListID[i];
                newRow.Cells[1].Value = ListFirstname[i];
                newRow.Cells[2].Value = ListLastname[i];
                newRow.Cells[3].Value = ListTelephone[i];
                newRow.Cells[4].Value = ListAddress[i];
                dataGridView1.Rows.Add(newRow);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "ALL")
                {
                    clearData();
                    GetData();
                    if (ListID.Count > 0)
                    {
                        updateDatagrid();
                    }
                }
                else
                {
                    clearData();
                    con.Open();
                    string query = "select id,firstname,lastname,telephone,address from user where firstname = '" + comboBox1.SelectedItem.ToString() + "'";

                    //MySqlDataReader row;
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            ListID.Add(row["id"].ToString());
                            ListFirstname.Add(row["firstname"].ToString());
                            ListLastname.Add(row["lastname"].ToString());
                            ListTelephone.Add(row["telephone"].ToString());
                            ListAddress.Add(row["address"].ToString());
                        }

                        textBox2.Text = row["telephone"].ToString();
                        textBox3.Text = row["address"].ToString();
                        updateDatagrid();
                    }
                    else
                    {
                        MessageBox.Show("Data not found");
                    }

                    con.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void clearData()
        {
            ListID.Clear();
            ListFirstname.Clear();
            ListLastname.Clear();
            ListAddress.Clear();
            ListTelephone.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
