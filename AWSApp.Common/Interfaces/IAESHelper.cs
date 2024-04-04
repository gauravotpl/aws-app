using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Interfaces
{
    public interface IAESHelper
    {
        T Decrypt<T>(string value, string aesKey);
    }
}
