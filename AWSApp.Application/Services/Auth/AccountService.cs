using AWSApp.Application.Interfaces.Auth;
using AWSApp.Common.Models;
using AWSApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Application.Services.Auth
{
    public class AccountService: IAccountService
    {
        public JsonModel Login(Users user)
        {
            return new JsonModel();
        }
    }
}
