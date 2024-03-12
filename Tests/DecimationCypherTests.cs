using System;
using System.Collections.Generic;
using Cryptography.En_Decryption;
using Cryptography.En_Decryption.Decimation;
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

            var inverseKeysGenerator = new InverseKeysGenerator(Alphabets.EnAlphabet.Size);
            for (int i = 0; i < keys.Length; i++) {
                Assert.AreEqual(inverseKeysGenerator.GenerateInverseKey(keys[i]), inverseKeys[i]);
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
        
        [Test]
        public void EncryptDecrypt_RandomPlaintextAndKeywords_ReturnsOriginalText()
        {
            var keys = new []{ "3", "5", "7", "9", "11", "15", "17", "19", "21", "23", "25" };
            const int timesCount = 4200;
            for (int times = 0; times < timesCount; times++)
            {
                var plaintext = EnWordGenerator.GenerateWord();
                Checker.Check(_cipher, plaintext, GetRandomSubarray(keys));   
            }
        }
        
        private static string[] GetRandomSubarray(string[] keys)
        {
            Random random = new Random();
            int subarrayLength = random.Next(1, keys.Length + 1); 
            int startIndex = random.Next(0, keys.Length - subarrayLength + 1); 
            string[] subarray = new string[subarrayLength];
            Array.Copy(keys, startIndex, subarray, 0, subarrayLength);
            return subarray;
        }
    }
}