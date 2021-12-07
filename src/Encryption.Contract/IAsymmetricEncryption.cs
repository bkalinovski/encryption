namespace Encryption.Contract
{
    public interface IAsymmetricEncryption
    {
        string Encrypt(string message, string publicKey);

        string Decrypt(string message, string privateKey);
    }
}