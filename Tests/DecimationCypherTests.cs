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
                const int keyCount = 10;
                var plaintext = EnWordGenerator.GenerateWord();
                Checker.Check(_cipher, plaintext, GetRandomSequence(keys, keyCount));   
            }
        }
        
        private static string[] GetRandomSequence(IReadOnlyList<string> keys, int keyCount)
        {
            Random random = new Random();
            string[] selectedKeys = new string[keyCount];

            for (int i = 0; i < keyCount; i++)
                selectedKeys[i] = keys[random.Next(keys.Count)];
            
            return selectedKeys;
        }
    }
}