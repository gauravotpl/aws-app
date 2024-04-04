using AWSApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Data.Interfaces.Auth
{
    public interface IAuthRepo
    {
        Users getUserDetails(Users user);
    }
}
