using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace newtonsoft_json
{
    public class modulePost
    {
        public static string urlServer = "http://localhost/json/ws.php";
       
        public void setURL(string url)
        {
            urlServer = url;
        }

        public string getURL()
        {
           return urlServer;
        }

        public string Post(string data)
        {
            string DataFromPHP = null;
            try
            {
                string url = getURL();
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                WebReq.Timeout = 1900000;
                WebReq.Method = "POST";
                WebReq.ContentType = "application/x-www-form-urlencoded";
                WebReq.ContentLength = buffer.Length;
                Stream PostData = WebReq.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
                Stream Answer = WebResp.GetResponseStream();
                StreamReader _Answer = new StreamReader(Answer);
                DataFromPHP = _Answer.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return DataFromPHP;
        }

}
