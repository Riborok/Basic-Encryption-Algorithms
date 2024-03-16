using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
    public abstract class VigenerKeyFactory
    {
        internal Alphabet Alphabet { get; }

        protected VigenerKeyFactory(Alphabet alphabet) => Alphabet = alphabet;

        internal string GenerateEncryptionKey(string plaintext, string keyword) => GenerateKey(plaintext, 
            keyword, true);

        internal string GenerateDecryptionKey(string ciphertext, string keyword) => GenerateKey(ciphertext, 
            keyword, false);
        
        private string GenerateKey(string text, string keyword, bool isEncryption)
        {
            var keyBuilder = new StringBuilder(text.Length);
    
            var charProvider = CreateKeywordCharProvider(text, keyword, keyBuilder);
            for (int i = 0; i < text.Length; i++)
                keyBuilder.Append(isEncryption
                    ? charProvider.GetNextForEncryption(i)
                    : charProvider.GetNextForDecryption(i)
                );

            return keyBuilder.ToString();
        }

        protected abstract IKeywordCharProvider CreateKeywordCharProvider(string text, string keyword, StringBuilder sb);
    }
    
    public interface IKeywordCharProvider
    {
        internal char GetNextForEncryption(int i);
        internal char GetNextForDecryption(int i);
    }
}