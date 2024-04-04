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
    internal class AuthRepo:IAuthRepo
    {
        private IDapperDb _dapperDb { get; set; }
        public AuthRepo(IDapperDb dapperDb)
        {
            _dapperDb = dapperDb;
        }
        public Users getUserDetails(Users user)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@username", user.username);
            dynamicParameters.Add("@password", user.password);
            dynamicParameters.Add("@Flag", "InvestorLogin");
            return _dapperDb.ExecuteGet<Users>("pro_IncentiveLogin", dynamicParameters);
        }
    }
}
