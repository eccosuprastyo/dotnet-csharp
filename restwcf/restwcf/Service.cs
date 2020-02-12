using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restwcf
{
    public class Service : IService
    {
        public string PostUser(USER data)
        {
            try
            {
                string result = "";
                //Function insert database
                result = "You have been post api with wcf restful!";
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
