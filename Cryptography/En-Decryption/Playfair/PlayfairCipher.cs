using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Cryptography.Extensions;

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

        public override string Encrypt(string plaintext, IEnumerable<string> keywords) {
            plaintext = TextAlphabet.RemoveNonAlphabetic(plaintext);
            return base.Encrypt(ExtraLetterManipulator.AddExtraLetterIfOddLength(plaintext), keywords);
        }
        
        /// <exception cref="ArgumentException">Thrown when the length of the ciphertext is odd.</exception>
        public override string Decrypt(string ciphertext, IEnumerable<string> keywords) {
            if (ciphertext.Length.IsOdd())
                throw new ArgumentException($"{nameof(PlayfairCipher)}: The ciphertext length '{ciphertext.Length}' must be even.");
                
            return ExtraLetterManipulator.RemoveLastExtraLetterIfPresent(base.Decrypt(ciphertext, keywords));
        }
        
        protected override string Encrypt(string plaintext, string keyword)
        {
            var mim = new MatrixIndicesMapping(0, 3, 1, 2);
            Debug.Assert(plaintext.Length.IsEven());
            return ProcessText(plaintext, keyword, mim);
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var mim = new MatrixIndicesMapping(1, 2, 0, 3);
            Debug.Assert(ciphertext.Length.IsEven());
            return ProcessText(ciphertext, keyword, mim);
        }

        private string ProcessText(string text, string keyword, MatrixIndicesMapping mim)
        {
            var encryptionContext = new EncryptionContext(_playfairQuadraticKeyFactory.Create(keyword), mim);
            var processingText = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i += 2)
            {
                var encryptedLetterPair = encryptionContext.EncryptLetters(text[i], text[i + 1]);
                processingText.Append(encryptedLetterPair.Letter1).Append(encryptedLetterPair.Letter2);
            }

            return processingText.ToString();
        }
        
        private readonly struct EncryptionContext
        {
            private readonly IPlayfairQuadraticKey _pqk;
            private readonly MatrixIndicesMapping _mim;

            public EncryptionContext(IPlayfairQuadraticKey pqk, MatrixIndicesMapping mim)
            {
                _pqk = pqk;
                _mim = mim;
            }

            public (char Letter1, char Letter2) EncryptLetters(char letter1, char letter2)
            {
                var letterCoord1 = _pqk[_mim.Coord1Index, letter1];
                var letterCoord2 = _pqk[_mim.Coord2Index, letter2];

                var encryptedLetter1 = _pqk[_mim.Letter1Index, letterCoord1.Row, letterCoord2.Column];
                var encryptedLetter2 = _pqk[_mim.Letter2Index, letterCoord2.Row, letterCoord1.Column];

                return (encryptedLetter1, encryptedLetter2);
            }
        }
    }
}