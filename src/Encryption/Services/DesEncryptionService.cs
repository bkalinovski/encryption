using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Encryption.Contract;

namespace Encryption.Services
{
    public class DesEncryptionService : ISymmetricEncryption
    {
        public string Encrypt(string message, string password)
        {
            byte[] myEncryptedArray = UTF8Encoding.UTF8.GetBytes(message);

            var MyMD5CryptoService = new MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

            MyMD5CryptoService.Clear();

            var myTripleDesCryptoService = new TripleDESCryptoServiceProvider();

            myTripleDesCryptoService.Key = MysecurityKeyArray;

            myTripleDesCryptoService.Mode = CipherMode.ECB;

            myTripleDesCryptoService.Padding = PaddingMode.PKCS7;

            var myCrytpoTransform = myTripleDesCryptoService.CreateEncryptor();

            byte[] myresultArray = myCrytpoTransform.TransformFinalBlock(myEncryptedArray, 0, myEncryptedArray.Length);

            myTripleDesCryptoService.Clear();

            return Convert.ToBase64String(myresultArray, 0,
                myresultArray.Length);
        }

        public string Decrypt(string message, string password)
        {
            byte[] myDecryptArray = Convert.FromBase64String(message);

            var MyMD5CryptoService = new MD5CryptoServiceProvider();

            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));

            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = MysecurityKeyArray;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(myDecryptArray, 0, myDecryptArray.Length);

            MyTripleDESCryptoService.Clear();

            return UTF8Encoding.UTF8.GetString(MyresultArray);
        }
    }
}