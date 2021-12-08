using System;
using System.Security.Cryptography;
using System.Text;
using Encryption.Contract;

namespace Encryption.Services
{
    public class RsaEncryptionService : IAsymmetricEncryption
    {
        private RSACryptoServiceProvider rsaService;
        public RsaEncryptionService()
        {
            rsaService = new RSACryptoServiceProvider();
        }

        public string Encrypt(string message, string publicKey)
        {
            //rsaService.ImportParameters(GetRSAParameters(publicKey));
            var data = Encoding.Unicode.GetBytes(message);
            var cypher = rsaService.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }

        public string Decrypt(string message, string privateKey)
        {
            //rsaService.ImportParameters(GetRSAParameters(privateKey));
            var data = Encoding.Unicode.GetBytes(message);
            var cypher = rsaService.Decrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
    }
}