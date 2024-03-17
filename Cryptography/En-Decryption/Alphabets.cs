namespace Cryptography.En_Decryption
{
    public static class Alphabets
    {
        public static readonly Alphabet EnAlphabet = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        public static readonly Alphabet RuAlphabet = new Alphabet("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");
        public static readonly Alphabet DigitAlphabet = new Alphabet("0123456789-");
        public static readonly Alphabet BinaryAlphabet = new Alphabet("01");
    }
}