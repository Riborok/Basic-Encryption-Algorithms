using System;

namespace Cryptography.En_Decryption {
    public class DecimationCipher : Cipher {
        private readonly int _textAlphabetSize;
        public InverseKeysGenerator InverseKeysGenerator { get; }

        public DecimationCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet) {
            _textAlphabetSize = TextAlphabet.Size;
            InverseKeysGenerator = new InverseKeysGenerator(_textAlphabetSize);
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
            if (!int.TryParse(stringKey, out key)) {
                message = "DecimationCipher: Key is not a number!";
                return false;
            }
            
            if (!AreRelPrime(key, _textAlphabetSize)) {
                message = $"DecimationCipher: The key {key} is not mutually simple with the number of characters in the alphabet {_textAlphabetSize}!";
                return false;
            }
            
            if (key > _textAlphabetSize) {
                message = $"DecimationCipher: The key {key} is larger than the number of characters in the alphabet {_textAlphabetSize}!";
                return false;
            }
            
            if (key <= 0) {
                message = $"DecimationCipher: Key {key} cannot be less than or equal to zero!";
                return false;
            }

            message = "";
            return true;
        }

        protected override string Encrypt(string text, string stringKey) {
            if (!IsKeyCorrect(stringKey, out int key, out string message)) {
                throw new ArgumentException(message);    
            }
            
            string ciphertext = "";
            foreach (var letter in text) {
                ciphertext += TextAlphabet.MultiplyLetter(letter, key);
            }

            return ciphertext;
        }

        protected override string Decrypt(string ciphertext, string stringKey) {
            if (!IsKeyCorrect(stringKey, out int key, out string message)) {
                throw new ArgumentException(message);    
            }
            
            int inverseKey = InverseKeysGenerator.GenerateInverseKey(key);
            
            string text = "";
            foreach (var letter in ciphertext) {
                text += TextAlphabet.MultiplyLetter(letter, inverseKey);
            }
            
            return text;
        }
    }
}