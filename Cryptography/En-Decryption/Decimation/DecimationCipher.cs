using System;
using System.Text;

namespace Cryptography.En_Decryption.Decimation {
    public class DecimationCipher : Cipher
    {
        private readonly InverseKeysGenerator _inverseKeysGenerator;

        public DecimationCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet) {
            _inverseKeysGenerator = new InverseKeysGenerator(textAlphabet.Size);
        }

        private static bool AreRelPrime(int a, int b) {
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
            else if (key > TextAlphabet.Size)
                message = $"{nameof(DecimationCipher)}: The key '{stringKey}' is larger than the amount of characters in the alphabet, which is {TextAlphabet.Size}!";
            else if (key <= 0)
                message = $"{nameof(DecimationCipher)}: The key '{stringKey}' cannot be less than or equal to zero!";
            
            return message == string.Empty;
        }

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
            
            int inverseKey = _inverseKeysGenerator.GenerateInverseKey(key);
            
            var text = new StringBuilder(ciphertext.Length);
            foreach (var letter in ciphertext)
                text.Append(TextAlphabet.MultiplyLetter(letter, inverseKey));

            return text.ToString();
        }
    }
}