namespace Encryption.Host.Models
{
    public class EncryptionViewModel
    {
        public string OriginalText { get; set; }

        public string EncryptedText { get; set; }

        public string Password { get; set; }

        public EncryptionType Action { get; set; }
    }

    public enum EncryptionType
    {
        Encryption,
        Decryption
    }
}