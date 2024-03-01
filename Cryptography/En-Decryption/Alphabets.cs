namespace Cryptography.En_Decryption
{
    public static class Alphabets
    {
        public static readonly Alphabet EnAlphabet = new Alphabet('A', 'Z');
        public static readonly Alphabet RuAlphabet = new Alphabet('А', 'Я');
        public static readonly Alphabet DigitAlphabet = new Alphabet('0', '9');
    }
}