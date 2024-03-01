using Cryptography.En_Decryption.Playfair;
using NUnit.Framework;
using Tests.Utilities;

namespace Tests
{
    [TestFixture]
    public class PlayfairCipherTests
    {
        private const int MatrixCount = 4;
        private const char KeyDelimiter = ' ';
        private readonly PlayfairCipher _cipher = 
            new PlayfairCipher(new PlayfairEnQuadraticKeyFactory(KeyDelimiter));
        
        [Test]
        public void EncryptDecrypt_RandomPlaintextAndKeywords_ReturnsOriginalText()
        {
            const int keyCount = 1;
            var plaintext = EnWordGenerator.GenerateWord();

            var keywords = new string[keyCount];
            for (int i = 0; i < keyCount; i++)
                keywords[i] = string.Join(KeyDelimiter.ToString(), EnWordGenerator.GenerateWords(MatrixCount));

            Checker.Check(_cipher, plaintext, keywords);
        }
    }
}