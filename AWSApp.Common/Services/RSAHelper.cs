using AWSApp.Common.Interfaces;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AWSApp.Common.Services
{
    public class RSAHelper: IRSAHelper
    {
        private readonly RSACryptoServiceProvider PrivateKey;
        private readonly string privateKeyName = "private.key.pem";
        private readonly string privateKeyPath = "RSA";

        public RSAHelper() => PrivateKey = GetPrivateKeyFromPemFile();

        public string Decrypt(string encrypted)
        {
            //CreatePemFile();

            var decryptedBytes = PrivateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }
        //The parameter is incorrect.
        static void CreatePemFile()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(128 * 8))
            {
                RSAParameters privateKey = rsa.ExportParameters(true);

                // Convert the private key to a Bouncy Castle AsymmetricCipherKeyPair
                AsymmetricCipherKeyPair bcKeyPair = DotNetUtilities.GetRsaKeyPair(privateKey);

                // Write the private key to a PEM file
                using (TextWriter textWriter = new StreamWriter("private.key.pem"))
                {
                    var pemWriter = new PemWriter(textWriter);
                    pemWriter.WriteObject(bcKeyPair.Private);
                }
            }
        }
        private RSACryptoServiceProvider GetPrivateKeyFromPemFile()
        {
            //CreatePemFile();
            try
            {
                using (TextReader privateKeyStringReader = new StringReader(File.ReadAllText(GetPath(privateKeyName, ""))))
                {
                    AsymmetricCipherKeyPair pemReader = (AsymmetricCipherKeyPair)new PemReader(privateKeyStringReader).ReadObject();
                    RSAParameters rsaPrivateCrtKeyParameters = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)pemReader.Private);
                    RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
                    rsaCryptoServiceProvider.ImportParameters(rsaPrivateCrtKeyParameters);
                    return rsaCryptoServiceProvider;
                }
            }
            catch (Exception ex) { return null; }
        }

        private string GetPath(string fileName, string filePath)
        {
            var path = Path.Combine(".", filePath);
            return Path.Combine(path, fileName);
        }

    }
}
