namespace Encryption.Host.Models
{
    public class AsymmetricViewModel
    {
        public string OriginalText { get; set; }

        public string EncryptedText { get; set; }

        public string PrivateKey { get; set; }
        
        public string PublicKey { get; set; }

        public EncryptionType Action { get; set; }
    }
}