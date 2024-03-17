namespace Cryptography.En_Decryption.Transposition
{
    public class TranspositionCipher : Cipher
    {
        public TranspositionCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet)
        {
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var (transpositionTableFiller, textGenerator) = TranspositionCipherTools.Create(
                plaintext.Length, keyword.Length);
            
            transpositionTableFiller.FillWithPlaintext(plaintext);
            return textGenerator.GenerateCiphertext(ColumnOrder.Create(keyword, KeyAlphabet));
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var (transpositionTableFiller, textGenerator) = TranspositionCipherTools.Create(
                ciphertext.Length, keyword.Length);
            
            transpositionTableFiller.FillWithCiphertext(ciphertext, ColumnOrder.Create(keyword, KeyAlphabet));
            return textGenerator.GeneratePlaintext();
        }
    }
    
    internal static class TranspositionCipherTools
    {
        public static (TranspositionTableFiller filler, TextGenerator generator) Create(int textLength, int keywordLength)
        {
            var table = new TranspositionTable(textLength, keywordLength);
            var filler = new TranspositionTableFiller(table);
            var generator = new TextGenerator(table);

            return (filler, generator);
        }
    }
}