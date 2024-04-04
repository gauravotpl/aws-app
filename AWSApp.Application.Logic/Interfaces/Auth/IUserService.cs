using AWSApp.Common.Models;
using AWSApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Application.Logic.Interfaces.Auth
{
    public interface IUserService
    {
        JsonModel GetLoginDetails(Users user);
       
    }
}
