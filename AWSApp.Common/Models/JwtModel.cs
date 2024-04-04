using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Models
{
    public class JwtModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string StateId { get; set; }
        public string DistrictId { get; set; }
    }
}
