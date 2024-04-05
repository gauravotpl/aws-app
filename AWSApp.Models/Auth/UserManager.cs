using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Models.Auth
{
    public class UserManager
    {
        
        public DataTable tbl_Session{ get; set; }



        public string TokenPage { get; set; }


        public string AreaName { get; set; }

        public string dist_Eng { get; set; }

        public string dist_Hindi { get; set; }

        public string ApiUrl { get; set; }

        public string houseid { get; set; }

        public string cccd { get; set; }

        public string PASSWORD { get; set; }

        public string Opername { get; set; }

        public string userid { get; set; }
        public string id { get; set; }

        public string mobileno { get; set; }

        public string email
        {
            get;
            set;
        }

        public string USER_TYPE { get; set; }

        public string crdate { get; set; }

        public string useronoff { get; set; }

        public string loginattempt { get; set; }

        public string Ucert { get; set; }

        public string photo { get; set; }

        public string ccnm { get; set; }

        public string Distcode { get; set; }

        public string AreaType { get; set; }


        public string Dashname { get; set; }



        public string LjsId { get; set; }

        public string EE { get; set; }

        public string EE_English { get; set; }

        public string EE_Hindi { get; set; }

        public string EmpCode { get; set; }

        public string Oldcase { get; set; }

        public string RevTrackng { get; set; }




    }
}
