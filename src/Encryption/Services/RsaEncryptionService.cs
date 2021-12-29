using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Encryption.Contract;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace Encryption.Services
{
    public class RsaEncryptionService : IAsymmetricEncryption
    {
        public string Encrypt(string message, string publicKey)
        {
            var rsaPublicKey = ImportPublicKey(publicKey);
            var bytesPlainTextData = Encoding.Unicode.GetBytes(message);
            var bytesCypherText = rsaPublicKey.Encrypt(bytesPlainTextData, false);
            return Convert.ToBase64String(bytesCypherText);
        }

        public string Decrypt(string message, string privateKey)
        {
            var rsaPrivateKey = ImportPrivateKey(privateKey);
            var bytesCypherText = Convert.FromBase64String(message);
            var bytesPlainTextData = rsaPrivateKey.Decrypt(bytesCypherText, false);
            return Encoding.Unicode.GetString(bytesPlainTextData);
        }
        
        private static RSACryptoServiceProvider ImportPrivateKey(string pem)
        {
            var pr = new PemReader(new StringReader(pem));
            var keyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
            var rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)keyPair.Private);

            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            return csp;
        }
        
        private static RSACryptoServiceProvider ImportPublicKey(string pem)
        {
            var pr = new PemReader(new StringReader(pem));
            var publicKey = (AsymmetricKeyParameter)pr.ReadObject();
            var rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters)publicKey);

            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            return csp;
        }
    }
}