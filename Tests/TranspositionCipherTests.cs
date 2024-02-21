using Cryptography.En_Decryption;
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
            string[] keywords =
            {
                "ELECTROENCEPHALOGRAPHY", 
                "PSYCHOTHERAPEUTIC", 
                "MISUNDERSTANDING", 
                "COUNTERREVOLUTIONARY", 
                "PHARMACOLOGICALLY",
            };

            Check(plaintext, keywords);
        }

        [Test]
        public void EncryptDecrypt_Plaintext_Longer_Keyword_ReturnsOriginalText()
        {
            const string plaintext = "THE ELECTROENCEPHALOGRAPHY RESULTS SHOWED SIGNS OF " +
                                     "PSYCHOTERAPEUTIC POTENTIAL DESPITE THE INITIAL " +
                                     "MISUNDERSTANDING LEADING TO A REVOLUTIONARY APPROACH " +
                                     "IN PHARMACOLOGICALLY ENHANCED TREATMENTS";
            string[] keywords =
            {
                "APPLE",
                "CARROT",
                "TABLE",
                "CHAIR",
                "RIVER",
            };
            
            Check(plaintext, keywords);
        }

        private void Check(string plaintext, params string[] keywords)
        {
            string ciphertext = _cipher.Encrypt(plaintext, keywords);
            string decryptedText = _cipher.Decrypt(ciphertext, keywords);

            Assert.AreEqual(plaintext.ToUpper(), decryptedText);
        }
    }
}