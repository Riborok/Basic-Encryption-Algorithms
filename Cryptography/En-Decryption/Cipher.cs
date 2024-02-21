using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption
{
    public abstract class Cipher
    {
        protected readonly Alphabet TextAlphabet;
        protected readonly Alphabet KeyAlphabet;

        protected Cipher(Alphabet textAlphabet, Alphabet keyAlphabet)
        {
            TextAlphabet = textAlphabet;
            KeyAlphabet = keyAlphabet;
        }
        
        public string Encrypt(string plaintext, IEnumerable<string> keywords)
        {
            plaintext = RemoveNonAlphabetic(TextAlphabet, plaintext);
            foreach (string keyword in keywords)
            {
                var cleanedKeyword = RemoveNonAlphabetic(KeyAlphabet, keyword);
                if (cleanedKeyword.Length != 0)
                    plaintext = Encrypt(plaintext, cleanedKeyword);
            }

            return plaintext;
        }
        
        public string Decrypt(string ciphertext, IEnumerable<string> keywords)
        {
            ciphertext = RemoveNonAlphabetic(TextAlphabet, ciphertext);
            foreach (string keyword in keywords.Reverse())
            {
                var cleanedKeyword = RemoveNonAlphabetic(KeyAlphabet, keyword);
                if (cleanedKeyword.Length != 0)
                    ciphertext = Decrypt(ciphertext, cleanedKeyword);
            }
            
            return ciphertext;
        }
        
        private static string RemoveNonAlphabetic(Alphabet alphabet, string s)
        {
            return new string(s.Where(alphabet.Contains).ToArray());
        }

        protected abstract string Encrypt(string plaintext, string keyword);
        
        protected abstract string Decrypt(string ciphertext, string keyword);
    }
}