using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Models.Auth
{
    public class Users
    {
        public string userid { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string msg { get; set; }
        public string username { get; set; }
        public string saltKey { get; set; }
        public string Role { get; set; }
    }
}
