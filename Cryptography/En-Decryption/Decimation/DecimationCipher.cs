using System;
using System.Text;

namespace Cryptography.En_Decryption.Decimation {
    public class DecimationCipher : Cipher
    {
        public DecimationCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet) {
        }
        
        private static bool AreRelPrime(int a, int b) {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
    
            return a == 1;
        }

        private bool IsKeyCorrect(string stringKey, out int key, out string message) {
            message = string.Empty;

            if (!int.TryParse(stringKey, out key))
                message = $"{nameof(DecimationCipher)}: The key '{stringKey}' is not a number!";
            else if (!AreRelPrime(key, TextAlphabet.Size))
                message = $"{nameof(DecimationCipher)}: The key '{stringKey}' is not mutually simple with the amount of characters in the alphabet, which is {TextAlphabet.Size}!";
            
            return message == string.Empty;
        }

        /// <exception cref="ArgumentException">
        /// Thrown | When the key is not a number. |
        /// When the key is not reversible (the key and the symbols amount are not relatively prime, the key
        /// is larger than the symbols amount or when the key is less than or equal to zero).
        /// </exception>
        protected override string Encrypt(string text, string stringKey) {
            if (!IsKeyCorrect(stringKey, out int key, out string message)) {
                throw new ArgumentException(message);    
            }
            
            var ciphertext = new StringBuilder(text.Length);
            foreach (var letter in text)
                ciphertext.Append(TextAlphabet.MultiplyLetter(letter, key));
            
            return ciphertext.ToString();
        }

        protected override string Decrypt(string ciphertext, string stringKey) {
            if (!IsKeyCorrect(stringKey, out int key, out string message)) {
                throw new ArgumentException(message);    
            }

            int inverseKey = InverseKeysGenerator.GenerateInverseKey(key, TextAlphabet.Size);
            
            var text = new StringBuilder(ciphertext.Length);
            foreach (var letter in ciphertext)
                text.Append(TextAlphabet.MultiplyLetter(letter, inverseKey));

            return text.ToString();
        }
    }
}