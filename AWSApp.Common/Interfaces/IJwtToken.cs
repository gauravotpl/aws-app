using AWSApp.Common.Models;
using AWSApp.Models.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Interfaces
{
    public interface IJwtToken
    {
         string GenerateToken(UserManager user);
        UserManager GetTokenDetails(HttpContext cntx);

         JsonModel ExecuteToken(UserManager contect, HttpContext cntx);
    }
}
