using System;
using System.Collections.Generic;
using Cryptography.En_Decryption;
using Cryptography.En_Decryption.Decimation;
using Cryptography.En_Decryption.RotatingGrille;
using NUnit.Framework;
using Tests.Utilities;

namespace Tests
{
    
    [TestFixture]
    public class TurningGrilleTests
    {
        private readonly GrilleCipher _cipher = 
            new GrilleCipher(Alphabets.EnAlphabet, Alphabets.DigitAlphabet);
        
        [Test]
        public void EncryptDecrypt_RandomPlaintextAndKeywords_ReturnsOriginalText()
        {
            var keyword = new[] { "1010000001001100100001000" };
            const int timesCount = 4200;
            for (int times = 0; times < timesCount; times++)
            {
                const int keyCount = 10;
                var plaintext = string.Join("", EnWordGenerator.GenerateWords(100));
                Checker.TurningGrilleCheck(_cipher, plaintext, keyword);   
            }
        }
    }
}