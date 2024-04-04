using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Interfaces
{
    public interface IUtility
    {
        string EncryptUsingAES256(string text);
        T DecryptUsingAES256<T>(string encryptedText);
    }
}
