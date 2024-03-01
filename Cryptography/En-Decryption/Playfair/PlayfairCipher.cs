using System.Text;

namespace Cryptography.En_Decryption.Playfair
{
    public class PlayfairCipher : Cipher
    {
        private const char ExtraLetter = 'X';
        
        private readonly IPlayfairQuadraticKeyFactory _playfairQuadraticKeyFactory;
        
        public PlayfairCipher(IPlayfairQuadraticKeyFactory playfairQuadraticKeyFactory) 
            : base(playfairQuadraticKeyFactory.UsedAlphabet, 
                new Alphabet(playfairQuadraticKeyFactory.UsedAlphabet, playfairQuadraticKeyFactory.KeyDelimiter))
        {
            _playfairQuadraticKeyFactory = playfairQuadraticKeyFactory;
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var mn = new MatrixNums(0, 3, 1, 2);
            return ProcessText(plaintext, keyword, mn).ToString();
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var mn = new MatrixNums(1, 2, 0, 3);
            return RemoveExtraLetters(ProcessText(ciphertext, keyword, mn));
        }
        
        private static string RemoveExtraLetters(StringBuilder text)
        {
            if (text.Length < 3)
                return text.ToString();
            
            int lastIndex = text.Length - 1;
            
            var result = new StringBuilder(text.Length).Append(text[0]);
            for (int i = 1; i < lastIndex; i++)
                if (IsNotExtraLetter(text[i]) || IsNotSurroundedBySameLetter(text, i))
                    result.Append(text[i]);

            if (IsNotExtraLetter(text[lastIndex]))
                result.Append(text[lastIndex]);

            return result.ToString();
        }
        private static bool IsNotExtraLetter(char letter) => letter != ExtraLetter;
        private static bool IsNotSurroundedBySameLetter(StringBuilder text, int index) => text[index - 1] != text[index + 1];
        
        private StringBuilder ProcessText(string text, string keyword, MatrixNums mn)
        {
            var pqk = _playfairQuadraticKeyFactory.Create(keyword);
            var processingText = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                var letterPair = GetLetterPair(text, ref i);
                var encryptedLetterPair = EncryptLetterPair(pqk, mn, letterPair);
                processingText.Append(encryptedLetterPair.Item1);
                processingText.Append(encryptedLetterPair.Item2);
            }

            return processingText;
        }
        
        private static (char, char) GetLetterPair(string text, ref int index)
        {
            var letter1 = text[index];
            var letter2 = index + 1 < text.Length && text[index + 1] != letter1 ? text[++index] : ExtraLetter;
            return (letter1, letter2);
        }
        
        private static (char, char) EncryptLetterPair(IPlayfairQuadraticKey pqk, MatrixNums mn, (char, char) letterPair)
        {
            var letterCoord1 = pqk[mn.IndexGivingCoord1, letterPair.Item1];
            var letterCoord2 = pqk[mn.IndexGivingCoord2, letterPair.Item2];

            var encryptedLetter1 = pqk[mn.IndexGivingLetter1, letterCoord1.Row, letterCoord2.Column];
            var encryptedLetter2 = pqk[mn.IndexGivingLetter2, letterCoord2.Row, letterCoord1.Column];

            return (encryptedLetter1, encryptedLetter2);
        }
    }
}