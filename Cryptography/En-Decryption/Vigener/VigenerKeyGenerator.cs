namespace Cryptography.En_Decryption.Vigener
{
    public interface IVigenerKeyGenerator
    {
        /**
         * Generates a Vigener key for the given text and keyword.
         * The length of the generated key MUST BE equal to the length of the text.
         */
        internal string GenerateKey(Alphabet alphabet, string text, string keyword, bool isEncryption);
    }
}