using Encryption.Contract;

namespace Encryption.Services
{
    public class RsaEncryptionService : IAsymmetricEncryption
    {
        public RsaEncryptionService()
        {
        }

        public string Encrypt(string message, string publicKey)
        {
            throw new System.NotImplementedException();
        }

        public string Decrypt(string message, string privateKey)
        {
            throw new System.NotImplementedException();
        }
    }
}