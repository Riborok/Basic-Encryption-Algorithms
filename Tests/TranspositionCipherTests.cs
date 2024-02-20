using Encryption;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TranspositionCipherTests
    {
        private TranspositionCipher _cipher;

        [SetUp]
        public void Setup()
        {
            var alphabet = new Alphabet('A', 'Z', ' ');
            _cipher = new TranspositionCipher(alphabet);
        }

        [Test]
        public void EncryptDecrypt_Plaintext_Shorter_Keyword_ReturnsOriginalText()
        {
            const string plaintext = "CAT";
            const string keyword = "ENCRYPTION";

            string ciphertext = _cipher.Encrypt(plaintext, keyword);
            string decryptedText = _cipher.Decrypt(ciphertext, keyword);

            Assert.AreEqual(plaintext, decryptedText);
        }

        [Test]
        public void EncryptDecrypt_Plaintext_Longer_Keyword_ReturnsOriginalText()
        {
            const string plaintext = "ENCRYPTION";
            const string keyword = "CAT";

            string ciphertext = _cipher.Encrypt(plaintext, keyword);
            string decryptedText = _cipher.Decrypt(ciphertext, keyword);

            Assert.AreEqual(plaintext, decryptedText);
        }
    }
}