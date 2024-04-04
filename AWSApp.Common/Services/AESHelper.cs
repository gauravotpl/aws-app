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
    public class AESHelper: IAESHelper
    {
        private readonly IConfiguration _config;
        public AESHelper(IConfiguration config)
        {
            _config = config;
        }

        private readonly string ivKey = "";
        public T Decrypt<T>(string encryptedValue, string aesKey)
        {
            // Decrypt the byte array using the provided method
            var encryptedBytes = Convert.FromBase64String(encryptedValue);
            byte[] decryptedBytes = DecryptStringFromBytes(encryptedBytes, Encoding.UTF8.GetBytes(aesKey), Encoding.UTF8.GetBytes(_config["Environment:EncryptKey"]));

            // Deserialize the decrypted byte array back into the original model
            T deserializedModel;


            //deserializedModel = (T)formatter.Deserialize(memoryStream);
            deserializedModel = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(decryptedBytes));


            return deserializedModel;
        }

        
        private static byte[] DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.ECB;
                rijAlg.Padding = PaddingMode.ISO10126;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var decryptedMemoryStream = new MemoryStream())
                {
                    csDecrypt.CopyTo(decryptedMemoryStream);
                    return decryptedMemoryStream.ToArray();
                }
            }
        }
    }
}
