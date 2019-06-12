using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Add_textboxt_to_Datagridvew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            History_addGrid(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
        }

        private void History_addGrid(string name, string age, string telephone, string address)
        {
            try
            {
                int no = 0;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = no + 1;
                newRow.Cells[1].Value = name;
                newRow.Cells[2].Value = age;
                newRow.Cells[3].Value = telephone;
                newRow.Cells[4].Value = address;
                dataGridView1.Rows.Add(newRow);
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
