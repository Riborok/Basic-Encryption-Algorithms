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
        
        public virtual string Encrypt(string plaintext, IEnumerable<string> keywords)
        {
            plaintext = TextAlphabet
                .RemoveNonAlphabetic(plaintext)
                .ToUpper();
            if (plaintext.Length != 0)
                foreach (string keyword in keywords)
                {
                    var cleanedKeyword = KeyAlphabet.RemoveNonAlphabetic(keyword);
                    if (cleanedKeyword.Length != 0)
                        plaintext = Encrypt(plaintext, cleanedKeyword);
                }

            return plaintext;
        }
        
        public virtual string Decrypt(string ciphertext, IEnumerable<string> keywords)
        {
            ciphertext = TextAlphabet
                .RemoveNonAlphabetic(ciphertext)
                .ToUpper();
            if (ciphertext.Length != 0)
                foreach (string keyword in keywords.Reverse())
                {
                    var cleanedKeyword = KeyAlphabet.RemoveNonAlphabetic(keyword);
                    if (cleanedKeyword.Length != 0)
                        ciphertext = Decrypt(ciphertext, cleanedKeyword);
                }
            
            return ciphertext;
        }

        protected abstract string Encrypt(string plaintext, string keyword);
        
        protected abstract string Decrypt(string ciphertext, string keyword);
    }
}