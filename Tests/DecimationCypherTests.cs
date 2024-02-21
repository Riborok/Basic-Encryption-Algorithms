using Cryptography.En_Decryption;
using NUnit.Framework;

namespace Tests {
    
    [TestFixture]
    public class DecimationCipherTests {
        private DecimationCipher _cipher;

        [SetUp]
        public void Setup() {
            var textAlphabet = new Alphabet('A', 'Z');
            var keysAlphabet = new Alphabet('0', '9');
            _cipher = new DecimationCipher(textAlphabet, keysAlphabet);
        }

        [Test]
        public void Check_InverseKey() {
            int[] keys = { 3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25 };
            int[] inverseKeys = { 9, 21, 15, 3, 19, 7, 23, 11, 5, 17, 25 };

            for (int i = 0; i < keys.Length; i++) {
                Assert.AreEqual(_cipher.InverseKeysGenerator.GenerateInverseKey(keys[i]), inverseKeys[i]);
            }
        }
        
        [Test]
        public void EncryptDecrypt_Plaintext_ReturnsOriginalText()
        {
            const string plaintext = "TODAY";
            string[] keywords = {
                "5"
            };
            const string cipherText = "RSPAQ";
        
            Check(plaintext, cipherText, keywords);
        }

        private void Check(string plainedText, string cypheredText, params string[] keywords)
        {
            string cipherText = _cipher.Encrypt(plainedText, keywords);
            string plainText = _cipher.Decrypt(cypheredText, keywords);

            Assert.AreEqual(plainedText, plainText);
        }
    }
}