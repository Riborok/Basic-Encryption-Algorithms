using Cryptography.En_Decryption;

namespace Tests.Utilities
{
    public static class Alphabets
    {
        public static readonly Alphabet EnAlphabet = new Alphabet('A', 'Z');
        public static readonly Alphabet DigitAlphabet = new Alphabet('0', '9');
    }
}