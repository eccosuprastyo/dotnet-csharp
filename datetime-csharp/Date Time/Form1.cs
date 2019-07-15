using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Date_Time
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string day = DateTime.Today.ToString("dddd");
            string year = DateTime.Now.Year.ToString("0000");
            string month = DateTime.Now.Month.ToString("00");
            string date = DateTime.Now.Day.ToString("00");
            string hour = DateTime.Now.Hour.ToString("00");
            string minute = DateTime.Now.Minute.ToString("00");
            string second = DateTime.Now.Second.ToString("00");
            string month2;
            string day2;

            switch (month)
            {
                case "01":
                    month2 = "January";
                    break;
                case "02":
                    month2 = "February";
                    break;
                case "03":
                    month2 = "March";
                    break;
                case "04":
                    month2 = "April";
                    break;
                case "05":
                    month2 = "May";
                    break;
                case "06":
                    month2 = "June";
                    break;
                case "07":
                    month2 = "July";
                    break;
                case "08":
                    month2 = "August";
                    break;
                case "09":
                    month2 = "September";
                    break;
                case "10":
                    month2 = "October";
                    break;
                case "11":
                    month2 = "November";
                    break;
                case "12":
                    month2 = "December";
                    break;
                default:
                    month2 = "UnKnown";
                    break;
            }

            switch (day)
            {
                case "Sun":
                    day2 = "Sunday";
                    break;
                case "Mon":
                    day2 = "Monday";
                    break;
                case "Tue":
                    day2 = "Tuesday";
                    break;
                case "Wed":
                    day2 = "Wednesday";
                    break;
                case "Thu":
                    day2 = "Thursday";
                    break;
                case "Fri":
                    day2 = "Friday";
                    break;
                case "Sat":
                    day2 = "Saturday";
                    break;
                case "Sunday":
                    day2 = "Sunday";
                    break;
                case "Monday":
                    day2 = "Monday";
                    break;
                case "Tuesday":
                    day2 = "Tuesday";
                    break;
                case "Wednesday":
                    day2 = "Wednesday";
                    break;
                case "Thursday":
                    day2 = "Thursday";
                    break;
                case "Friday":
                    day2 = "Friday";
                    break;
                case "Saturday":
                    day2 = "Saturday";
                    break;
                //I'm Use Jakarta Timezone, change this case from your Timezone
                case "Minggu":
                    day2 = "Sunday";
                    break;
                case "Senin":
                    day2 = "Monday";
                    break;
                case "Selasa":
                    day2 = "Tuesday";
                    break;
                case "Rabu":
                    day2 = "Wednesday";
                    break;
                case "Kamis":
                    day2 = "Thursday";
                    break;
                case "Jum'at":
                    day2 = "Jum'at";
                    break;
                case "Jumat":
                    day2 = "Friday";
                    break;
                case "Sabtu":
                    day2 = "Sunday";
                    break;
                default:
                    day2 = "UnKnown";
                    break;
            }
            label1.Text = day2 + " , " + date + " " + month2 + " " + year + "  " + hour + ":" + minute + ":" + second;
            label1.Update();
           
            timer1.Enabled = true;
        }
    }
}
