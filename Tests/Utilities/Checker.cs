using System.Collections.Generic;
using Cryptography.En_Decryption;
using NUnit.Framework;

namespace Tests.Utilities
{
    public static class Checker
    {
        public static void Check(Cipher cipher, string plaintext, IReadOnlyCollection<string> keywords)
        {
            string ciphertext = cipher.Encrypt(plaintext, keywords);
            string decryptedText = cipher.Decrypt(ciphertext, keywords);

            string errorMessage = $"Decryption failed for {cipher.GetType().Name}\n" +
                                  $"Keys: {string.Join(", ", keywords)}\n" +
                                  $"Plaintext: {plaintext}\n" +
                                  $"Decrypted text: {decryptedText}\n";
            Assert.AreEqual(plaintext.ToUpper(), decryptedText.ToUpper(), errorMessage);
        }
    }
}