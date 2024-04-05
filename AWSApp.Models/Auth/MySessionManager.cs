using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Models.Auth
{
    public class MySessionManager
    {
        public static UserManager CurrentSuperUser
        {
            get
            {
                UserManager user = new UserManager();
                return user;
            }
        }
        public static string AreaName
        {
            get
            {
                return CurrentSuperUser.AreaName;
            }
            set
            {
                CurrentSuperUser.AreaName = value;
            }
        }

        public static string dist_Eng
        {
            get
            {
                return CurrentSuperUser.dist_Eng;
            }
            set
            {
                CurrentSuperUser.dist_Eng = value;
            }
        }

        public static string dist_Hindi
        {
            get
            {
                return CurrentSuperUser.dist_Hindi;
            }
            set
            {
                CurrentSuperUser.dist_Hindi = value;
            }
        }

        public static string ApiUrl
        {
            get
            {
                return CurrentSuperUser.ApiUrl;
            }
            set
            {
                CurrentSuperUser.ApiUrl = value;
            }
        }

        public static string houseid
        {
            get
            {
                return CurrentSuperUser.houseid;
            }
            set
            {
                CurrentSuperUser.houseid = value;
            }
        }

        public static string Opername
        {
            get
            {
                return CurrentSuperUser.Opername;
            }
            set
            {
                CurrentSuperUser.Opername = value;
            }
        }
        public static string cccd
        {
            get
            {
                return CurrentSuperUser.cccd;
            }
            set
            {
                CurrentSuperUser.cccd = value;
            }
        }
        public static string PASSWORD
        {
            get
            {
                return CurrentSuperUser.PASSWORD;
            }
            set
            {
                CurrentSuperUser.PASSWORD = value;
            }
        }
        public static string userid
        {
            get
            {
                return CurrentSuperUser.userid;
            }
            set
            {
                CurrentSuperUser.userid = value;
            }
        }
        public static string id
        {
            get
            {
                return CurrentSuperUser.id;
            }
            set
            {
                CurrentSuperUser.id = value;
            }
        }

        public static string mobileno
        {
            get
            {
                return CurrentSuperUser.mobileno;
            }
            set
            {
                CurrentSuperUser.mobileno = value;
            }
        }

        public static string email
        {
            get
            {
                return CurrentSuperUser.email;
            }
            set
            {
                CurrentSuperUser.email = value;
            }
        }

        public static string USER_TYPE
        {
            get
            {
                return CurrentSuperUser.USER_TYPE;
            }
            set
            {
                CurrentSuperUser.USER_TYPE = value;
            }
        }

        public static string crdate
        {
            get
            {
                return CurrentSuperUser.crdate;
            }
            set
            {
                CurrentSuperUser.crdate = value;
            }
        }

        public static string useronoff
        {
            get
            {
                return CurrentSuperUser.useronoff;
            }
            set
            {
                CurrentSuperUser.useronoff = value;
            }
        }

        public static string loginattempt
        {
            get
            {
                return CurrentSuperUser.loginattempt;
            }
            set
            {
                CurrentSuperUser.loginattempt = value;
            }
        }

        public static string Ucert
        {
            get
            {
                return CurrentSuperUser.Ucert;
            }
            set
            {
                CurrentSuperUser.Ucert = value;
            }
        }

        public static string photo
        {
            get
            {


                return CurrentSuperUser.photo;
            }
            set
            {
                CurrentSuperUser.photo = value;
            }
        }

        public static string ccnm
        {
            get
            {
                return CurrentSuperUser.ccnm;
            }
            set
            {
                CurrentSuperUser.ccnm = value;
            }
        }

        public static string Distcode
        {
            get
            {
                return CurrentSuperUser.Distcode;
            }
            set
            {
                CurrentSuperUser.Distcode = value;
            }
        }

        public static string AreaType
        {
            get
            {
                return CurrentSuperUser.AreaType;
            }
            set
            {
                CurrentSuperUser.AreaType = value;
            }
        }

        public static string LJSId
        {
            get
            {
                return CurrentSuperUser.LjsId;
            }
            set
            {
                CurrentSuperUser.LjsId = value;
            }
        }

        public static string Dashname
        {
            get
            {
                return CurrentSuperUser.Dashname;
            }
            set
            {
                CurrentSuperUser.Dashname = value;
            }
        }

        public static string EE
        {
            get
            {
                return CurrentSuperUser.EE;
            }
            set
            {
                CurrentSuperUser.EE = value;
            }
        }

        public static string EE_English
        {
            get
            {
                return CurrentSuperUser.EE_English;
            }
            set
            {
                CurrentSuperUser.EE_English = value;
            }
        }

        public static string EE_Hindi
        {
            get
            {
                return CurrentSuperUser.EE_Hindi;
            }
            set
            {
                CurrentSuperUser.EE_Hindi = value;
            }
        }

        public static string EmpCode
        {
            get
            {
                return CurrentSuperUser.EmpCode;
            }
            set
            {
                CurrentSuperUser.EmpCode = value;
            }
        }

        public static string Oldcase
        {
            get
            {
                return CurrentSuperUser.Oldcase;
            }
            set
            {
                CurrentSuperUser.Oldcase = value;
            }
        }

        public static string RevTrackng
        {
            get
            {
                return CurrentSuperUser.RevTrackng;
            }
            set
            {
                CurrentSuperUser.RevTrackng = value;
            }
        }


    }
}
