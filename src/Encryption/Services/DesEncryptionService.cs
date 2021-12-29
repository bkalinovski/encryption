using System;
using System.Security.Cryptography;
using System.Text;
using Encryption.Contract;

namespace Encryption.Services
{
    public class DesEncryptionService : ISymmetricEncryption
    {
        public string Encrypt(string message, string password)
        {
            var myEncryptedArray = Encoding.UTF8.GetBytes(message);
            var myMd5CryptoService = new MD5CryptoServiceProvider();
            var mySecurityKeyArray = myMd5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(password));
            myMd5CryptoService.Clear();

            var myTripleDesCryptoService = new TripleDESCryptoServiceProvider
            {
                Key = mySecurityKeyArray, 
                Mode = CipherMode.ECB, 
                Padding = PaddingMode.PKCS7
            };
            
            var myCryptoTransform = myTripleDesCryptoService.CreateEncryptor();
            var myResultArray = myCryptoTransform.TransformFinalBlock(myEncryptedArray, 0, myEncryptedArray.Length);
            myTripleDesCryptoService.Clear();

            return Convert.ToBase64String(myResultArray, 0, myResultArray.Length);
        }

        public string Decrypt(string message, string password)
        {
            var myDecryptArray = Convert.FromBase64String(message);
            var myMd5CryptoService = new MD5CryptoServiceProvider();
            var mySecurityKeyArray = myMd5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(password));
            myMd5CryptoService.Clear();

            var myTripleDesCryptoService = new TripleDESCryptoServiceProvider
            {
                Key = mySecurityKeyArray, 
                Mode = CipherMode.ECB, 
                Padding = PaddingMode.PKCS7
            };
            
            var myCryptoTransform = myTripleDesCryptoService.CreateDecryptor();
            var myResultArray = myCryptoTransform.TransformFinalBlock(myDecryptArray, 0, myDecryptArray.Length);
            myTripleDesCryptoService.Clear();
            
            return Encoding.UTF8.GetString(myResultArray);
        }
    }
}