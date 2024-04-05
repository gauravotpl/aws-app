using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Models.Auth
{
    public class Users
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int UserOnOff { get; set; }
        public int CCcd { get; set; }
        public string Opername { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int Status { get; set; }
        public string UIP { get; set; }
        public string UID { get; set; }
        public DateTime UDate { get; set; }
        public DateTime CrDate { get; set; }
        public int SecQId { get; set; }
        public string SecQAns { get; set; }
        public DateTime Dob { get; set; }
        public int LoginAttempt { get; set; }
        public string UCert { get; set; }
        public int DistCode { get; set; }
        public string AreaType { get; set; }
        public string Thana { get; set; }
        public string Designation { get; set; }
        public string EmpCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CreationDateJoin { get; set; }
        public string OrgPwd { get; set; }
        public string OTP { get; set; }
    }
}
