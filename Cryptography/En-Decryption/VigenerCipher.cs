using System.Diagnostics;
using System.Text;

namespace Cryptography.En_Decryption
{
    public class VigenerCipher : Cipher
    {
        private readonly IVigenerKeyGenerator _vigenerKeyGenerator;

        public VigenerCipher(Alphabet alphabet, IVigenerKeyGenerator vigenerKeyGenerator) 
            : base(alphabet, alphabet)
        {
            _vigenerKeyGenerator = vigenerKeyGenerator;
        }
        
        protected override string Encrypt(string plaintext, string keyword)
        {
            string vigenerKeyword = _vigenerKeyGenerator.GenerateKey(KeyAlphabet, plaintext, keyword, true);
            Debug.Assert(plaintext.Length == vigenerKeyword.Length);
            return GenerateCiphertext(plaintext, vigenerKeyword);
        }

        private string GenerateCiphertext(string plaintext, string vigenerKeyword)
        {
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < plaintext.Length; i++)
                encryptedText.Append(GetEncryptChar(plaintext[i], vigenerKeyword[i]));

            return encryptedText.ToString();
        }
        
        private char GetEncryptChar(char plaintextChar, char keywordChar)
        {
            return TextAlphabet.AddLetters(plaintextChar, keywordChar);
        }
        
        protected override string Decrypt(string ciphertext, string keyword)
        {
            string vigenerKeyword = _vigenerKeyGenerator.GenerateKey(KeyAlphabet, ciphertext, keyword, false);
            Debug.Assert(ciphertext.Length == vigenerKeyword.Length);
            return GeneratePlaintext(ciphertext, vigenerKeyword);
        }
        
        private string GeneratePlaintext(string ciphertext, string vigenerKeyword)
        {
            StringBuilder decryptedText = new StringBuilder();
            for (int i = 0; i < ciphertext.Length; i++)
                decryptedText.Append(GetDecryptChar(ciphertext[i], vigenerKeyword[i]));

            return decryptedText.ToString();
        }

        private char GetDecryptChar(char ciphertextChar, char keywordChar)
        {
            return TextAlphabet.SubtractLetters(ciphertextChar, keywordChar);
        }
    }
}