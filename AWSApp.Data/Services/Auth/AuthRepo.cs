using AWSApp.Data.Interfaces;
using AWSApp.Data.Interfaces.Auth;
using AWSApp.Models.Auth;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Data.Services.Auth
{
    public class AuthRepo:IAuthRepo
    {
        private IDapperDb _dapperDb { get; set; }
        public AuthRepo(IDapperDb dapperDb)
        {
            _dapperDb = dapperDb;
        }
        public Users getUserDetails(Users user)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@username", user.UserId);
            dynamicParameters.Add("@password", user.Password);
            dynamicParameters.Add("@Flag", "InvestorLogin");
            return _dapperDb.ExecuteGet<Users>("pro_IncentiveLogin", dynamicParameters);
        }

        public List<Users> LoginCheck(string username)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userid", username);
            var lst= _dapperDb.GetAll<Users>("LoginCheck", dynamicParameters);
            return lst;
        }
        public UserManager LoginAllow(string username)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@userid", username);
            dynamicParameters.Add("@status", 1);
            var lst = _dapperDb.ExecuteGet<UserManager>("LoginAllow", dynamicParameters);
            return lst;
        }
    }
}
