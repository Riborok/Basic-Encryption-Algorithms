using System.Collections.Generic;
using Cryptography.En_Decryption;
using NUnit.Framework;
using Tests.Utilities;

namespace Tests {
    
    [TestFixture]
    public class DecimationCipherTests {
        private readonly DecimationCipher _cipher = 
            new DecimationCipher(Alphabets.EnAlphabet, Alphabets.DigitAlphabet);

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
            const string originalText = "TODAY";
            var keywords = new[] { "5" };
            const string expectedCipherText = "RSPAQ";

            CheckEncryption(originalText, expectedCipherText, keywords);
        }

        private void CheckEncryption(string originalText, string expectedCipherText, IReadOnlyCollection<string> keywords)
        {
            string actualCipherText = _cipher.Encrypt(originalText, keywords);
            string decryptedText = _cipher.Decrypt(expectedCipherText, keywords);

            Assert.AreEqual(originalText, decryptedText);
            Assert.AreEqual(expectedCipherText, actualCipherText);
        }
        
        /*[Test]
        public void EncryptDecrypt_RandomPlaintextAndKeywords_ReturnsOriginalText()
        {
            const int keyCount = 10;
            
            var plaintext = EnWordGenerator.GenerateWord();
            var keywords = DigitWordGenerator.GenerateWords(keyCount, Alphabets.EnAlphabet.Size);

            Checker.Check(_cipher, plaintext, keywords);
        }*/
    }
}