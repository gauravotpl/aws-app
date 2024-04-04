using AWSApp.Common.Models;
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
         string GenerateToken(JwtModel user);
         JwtModel GetTokenDetails(HttpContext cntx);

         JsonModel ExecuteToken(JsonModel contect, HttpContext cntx);
    }
}
