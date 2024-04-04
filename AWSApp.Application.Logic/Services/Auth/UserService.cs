using AWSApp.Application.Logic.Interfaces.Auth;
using AWSApp.Common.Interfaces;
using AWSApp.Common.Models;
using AWSApp.Data.Interfaces.Auth;
using AWSApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Application.Logic.Services.Auth
{
    public class UserService:IUserService
    {
        private IJwtToken _jwtToken { get; set; }
        private IAuthRepo _authRepo { get; set; }
        public UserService(IJwtToken jwtToken, IAuthRepo authRepo)
        {
            this._jwtToken = jwtToken;
            _authRepo = authRepo;
        }

        public JsonModel GetLoginDetails(Users user)
        {

            return new JsonModel();
        }
        
    }
}
