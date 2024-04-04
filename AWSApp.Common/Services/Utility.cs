using AWSApp.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Services
{
    public class Utility: IUtility
    {
        private readonly IConfiguration _config;
        public Utility(IConfiguration config)
        {
            _config = config;
        }
        // Method for encryption using AES 256
        public string EncryptUsingAES256(string text)
        {

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_config["Environment:EncryptKey"]);
                aesAlg.IV = Encoding.UTF8.GetBytes(_config["Environment:EncryptIV"]);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }


        }

        // Method for decryption using AES 256
        public T DecryptUsingAES256<T>(string encryptedText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_config["Environment:EncryptKey"]); ;
                aesAlg.IV = Encoding.UTF8.GetBytes(_config["Environment:EncryptIV"]); ;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return JsonConvert.DeserializeObject<T>(srDecrypt.ReadToEnd());
                        }
                    }
                }
            }
        }
    }
}
