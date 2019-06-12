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

namespace Ecnryption_Decryption
{
    public partial class Form1 : Form
    {
        connection con = new connection();

        //arraylist to getter and setter data
        private static ArrayList ListID = new ArrayList();
        private static ArrayList ListName = new ArrayList();
        private static ArrayList Listtitle = new ArrayList();
        private static ArrayList ListAddress = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
            updateDatagrid();
        }

        private void GetData()
        {
            try
            {
                con.Open();
                string query = "select id as id,AES_DECRYPT(name,'camellabs.com') as name,AES_DECRYPT(title,'camellabs.com') as title,AES_DECRYPT(address,'camellabs.com') as address from title";

                //MySqlDataReader row;
                MySqlDataReader row;
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        ListID.Add(row["id"].ToString());
                        ListName.Add(row["name"].ToString());
                        Listtitle.Add(row["title"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into title (name,title,address) values(AES_ENCRYPT('" + textBox1.Text + "','camellabs.com'),AES_ENCRYPT('" + textBox2.Text + "','camellabs.com'),AES_ENCRYPT('" + textBox3.Text + "','camellabs.com'))";
                int hasil = con.ExecuteNonQuery(query);
                if (hasil > 0)
                {
                    MessageBox.Show("Data has been save Success");
                    clearList();
                    GetData();
                    updateDatagrid();
                }
                else
                {
                    MessageBox.Show("Failed to saving data");
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
                newRow.Cells[1].Value = ListName[i];
                newRow.Cells[2].Value = Listtitle[i];
                newRow.Cells[3].Value = ListAddress[i];
                dataGridView1.Rows.Add(newRow);
            }
        }

        private void clearList()
        {
            ListID.Clear();
            ListName.Clear();
            Listtitle.Clear();
            ListAddress.Clear();
        }
       
    }
}
