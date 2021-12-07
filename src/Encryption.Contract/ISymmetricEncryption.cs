namespace Encryption.Contract
{
    public interface ISymmetricEncryption
    {
        string Encrypt(string message, string password);

        string Decrypt(string message, string password);
    }
}