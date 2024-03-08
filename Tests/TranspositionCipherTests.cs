using Cryptography.En_Decryption;
using Cryptography.En_Decryption.Transposition;
using NUnit.Framework;
using Tests.Utilities;

namespace Tests
{
    [TestFixture]
    public class TranspositionCipherTests
    {
        private readonly TranspositionCipher _cipher = 
            new TranspositionCipher(Alphabets.EnAlphabet, Alphabets.EnAlphabet);

        [Test]
        public void EncryptDecrypt_Plaintext_Shorter_Keyword_ReturnsOriginalText()
        {
            const int keyCount = 10;
            var plaintext = ReservedEnWords.ShortestWord;
            var keywords = ReservedEnWords.GetLongestKeys(keyCount);

            Checker.Check(_cipher, plaintext, keywords);
        }

        [Test]
        public void EncryptDecrypt_Plaintext_Longer_Keyword_ReturnsOriginalText()
        {
            const int keyCount = 10;
            var plaintext = ReservedEnWords.AllWordsAsString;
            var keywords = ReservedEnWords.GetShortestKeys(keyCount);

            Checker.Check(_cipher, plaintext, keywords);
        }
        
        [Test]
        public void EncryptDecrypt_RandomPlaintextAndKeywords_ReturnsOriginalText()
        {
            const int timesCount = 4200;
            for (int times = 0; times < timesCount; times++)
            {
                const int keyCount = 10;
                var plaintext = EnWordGenerator.GenerateWord();
                var keywords = EnWordGenerator.GenerateWords(keyCount);

                Checker.Check(_cipher, plaintext, keywords);   
            }
        }
    }
}