using System.Diagnostics;
using System.Text;

namespace Cryptography.En_Decryption.Vigener
{
    public class VigenerCipher : Cipher
    {
        private readonly VigenerKeyFactory _vigenerKeyGenerator;

        public VigenerCipher(VigenerKeyFactory vigenerKeyGenerator) 
            : base(vigenerKeyGenerator.Alphabet, vigenerKeyGenerator.Alphabet)
        {
            _vigenerKeyGenerator = vigenerKeyGenerator;
        }
        
        protected override string Encrypt(string plaintext, string keyword)
        {
            string vigenerKeyword = _vigenerKeyGenerator.GenerateEncryptionKey(plaintext, keyword);
            Debug.Assert(plaintext.Length == vigenerKeyword.Length);
            return GenerateCiphertext(plaintext, vigenerKeyword);
        }

        private string GenerateCiphertext(string plaintext, string vigenerKeyword)
        {
            StringBuilder encryptedText = new StringBuilder(plaintext.Length);
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
            string vigenerKeyword = _vigenerKeyGenerator.GenerateDecryptionKey(ciphertext, keyword);
            Debug.Assert(ciphertext.Length == vigenerKeyword.Length);
            return GeneratePlaintext(ciphertext, vigenerKeyword);
        }
        
        private string GeneratePlaintext(string ciphertext, string vigenerKeyword)
        {
            StringBuilder decryptedText = new StringBuilder(ciphertext.Length);
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