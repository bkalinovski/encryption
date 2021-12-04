namespace Encryption.Contract
{
    public interface IEncryption
    {
        string Encrypt(string message, string key);

        string Decrypt(string message, string key);
    }
}