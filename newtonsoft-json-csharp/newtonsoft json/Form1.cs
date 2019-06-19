using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace newtonsoft_json
{
    public partial class Form1 : Form
    {
        modulePost _modul = new modulePost();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string firstname,lastname,address;
            string app;
            string module;
            string action;
            string entity;
            string data;
            string respon;
            string json;
            try
            {
                app = "user";
                module = "user";
                action = "loginUser";

                entity = "&username=" + txtUsername.Text + "&password=" + txtPassword.Text;
                data = "&app=" + app + "&module=" + module + "&action=" + action + "" + entity;
                respon = _modul.Post(data);

                json = respon.TrimStart('[');
                json = json.TrimEnd(']');
                JObject o = JObject.Parse(json);
                JArray jsonarray = (JArray)o["data"];
                for (int i = 0; i < jsonarray.Count; i++)
                {
                    JObject aItem = (JObject)jsonarray[i];
                    firstname = (string)aItem["firstname"];
                    lastname = (string)aItem["lastname"];
                    address = (string)aItem["address"];

                    MessageBox.Show("Data Found My Name is " + firstname + lastname + " and I Live at " + address);
                }
            }
            catch
            {

            }
        }
    }
}
