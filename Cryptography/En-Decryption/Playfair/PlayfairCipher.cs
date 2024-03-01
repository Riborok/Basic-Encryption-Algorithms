using System.Text;

namespace Cryptography.En_Decryption.Playfair
{
    public class PlayfairCipher : Cipher
    {
        private readonly IPlayfairQuadraticKeyFactory _playfairQuadraticKeyFactory;
        
        public PlayfairCipher(IPlayfairQuadraticKeyFactory playfairQuadraticKeyFactory) 
            : base(playfairQuadraticKeyFactory.UsedAlphabet, 
                new Alphabet(playfairQuadraticKeyFactory.UsedAlphabet, playfairQuadraticKeyFactory.KeyDelimiter))
        {
            _playfairQuadraticKeyFactory = playfairQuadraticKeyFactory;
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var mim = new MatrixIndicesMapping(0, 3, 1, 2);
            return ProcessText(plaintext, keyword, mim).ToString();
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var mim = new MatrixIndicesMapping(1, 2, 0, 3);
            return ExtraLetterManipulator.RemoveExtraLetters(ProcessText(ciphertext, keyword, mim));
        }

        private StringBuilder ProcessText(string text, string keyword, MatrixIndicesMapping mim)
        {
            var pqk = _playfairQuadraticKeyFactory.Create(keyword);
            var processingText = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                var letterPair = GetLetterPair(text, ref i);
                var encryptedLetterPair = EncryptLetterPair(pqk, mim, letterPair);
                processingText.Append(encryptedLetterPair.Item1);
                processingText.Append(encryptedLetterPair.Item2);
            }

            return processingText;
        }
        
        private static (char, char) GetLetterPair(string text, ref int index)
        {
            var letter1 = text[index];
            var letter2 = ExtraLetterManipulator.GetNextLetter(text, ref index);
            return (letter1, letter2);
        }
        
        private static (char, char) EncryptLetterPair(IPlayfairQuadraticKey pqk, MatrixIndicesMapping mim, (char, char) letterPair)
        {
            var letterCoord1 = pqk[mim.Coord1Index, letterPair.Item1];
            var letterCoord2 = pqk[mim.Coord2Index, letterPair.Item2];

            var encryptedLetter1 = pqk[mim.Letter1Index, letterCoord1.Row, letterCoord2.Column];
            var encryptedLetter2 = pqk[mim.Letter2Index, letterCoord2.Row, letterCoord1.Column];

            return (encryptedLetter1, encryptedLetter2);
        }
    }
}