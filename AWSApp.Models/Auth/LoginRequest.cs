using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Models.Auth
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
        public string RandomString { get; set; }
        public string Salt { get; set; }
    }
}
