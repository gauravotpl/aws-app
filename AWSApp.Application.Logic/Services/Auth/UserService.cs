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
        public JsonModel Login(LoginRequest login)
        {
            var loginChkLst = _authRepo.LoginCheck(login.Username);
            if(loginChkLst != null&&loginChkLst.Count>0)
            {
            string pswd=loginChkLst.FirstOrDefault().Password;
                if (pswd == login.Password)
                {
                  var userDetails=_authRepo.LoginAllow(login.Username);
                        if(userDetails != null)
                        {
                            if(Convert.ToInt32(userDetails.loginattempt) >0)
                            {
                                return new JsonModel()
                                {
                                    data = userDetails,
                                    message = "Login Success.",
                                    httpStatusCode = System.Net.HttpStatusCode.OK,
                                    accessToken = _jwtToken.GenerateToken(userDetails)
                                };
                            }
                            else
                            {
                                return new JsonModel()
                                {
                                    data = userDetails,
                                    message = "Login Success.",
                                    httpStatusCode = System.Net.HttpStatusCode.OK,
                                    accessToken = _jwtToken.GenerateToken(userDetails)
                                };
                            }
                        }
                        else
                        {
                            return new JsonModel()
                            {
                                data = userDetails,
                                message = "User Details Not Found.",
                                httpStatusCode = System.Net.HttpStatusCode.NotFound,
                                accessToken = null
                            };
                        }
                }
                else
                {
                    return new JsonModel()
                    {
                        data = new object(),
                        message = "Invalid Password",
                        httpStatusCode = System.Net.HttpStatusCode.NotFound
                    };
                }
            }
            else
            {
                return new JsonModel()
                {
                    data = new object(),
                    message = "User Details Not Found.",
                    httpStatusCode = System.Net.HttpStatusCode.NotFound,
                    accessToken = null
                };
            }
        }

    }
}
