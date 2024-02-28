using Cryptography.En_Decryption;
using NUnit.Framework;
using Tests.Utilities;

namespace Tests
{
    [TestFixture]
    public class VigenerCipherTests
    {
        private readonly VigenerCipher _cipher = 
            new VigenerCipher(Alphabets.EnAlphabet, new SelfGeneratingVigenerKeyGenerator());

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
            const int keyCount = 10;
            var plaintext = EnWordGenerator.GenerateWord();
            var keywords = EnWordGenerator.GenerateWords(keyCount);

            Checker.Check(_cipher, plaintext, keywords);
        }
    }
}