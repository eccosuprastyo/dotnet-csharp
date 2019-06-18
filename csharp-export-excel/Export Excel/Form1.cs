using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Export_Excel
{
    public partial class Form1 : Form
    {
        moduleExcel excelImp = new moduleExcel();

        public Form1()
        {
            InitializeComponent();
        }

        private void staticDatagrid()
        {
            dataGridView1.Rows.Add("1","Book 1");
            dataGridView1.Rows.Add("2","Book 2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string title = " Excel Export by Tutorial Coding";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Tutorial Coding.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excelImp.ToCsV(dataGridView1,textBox1.Text, textBox2.Text, textBox3.Text,title, sfd.FileName);   
                  MessageBox.Show("Finish");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            staticDatagrid();
        }
       
    }
}
