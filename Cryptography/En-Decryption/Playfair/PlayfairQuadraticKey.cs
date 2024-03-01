using System;
using System.Collections.Generic;

namespace Cryptography.En_Decryption.Playfair
{
    internal interface IPlayfairQuadraticKey
    {
        char this[int matrixNum, int row, int column] { get; }
        MatrixCoordinate this[int matrixNum, char letter] { get; }
    }
    
    internal class PlayfairEnQuadraticKey : IPlayfairQuadraticKey
    {
        private const int MatrixCount = 4;
        
        private readonly Matrices2D _matrices2D;
        private readonly Dictionary<char, MatrixCoordinate>[] _maps;

        public PlayfairEnQuadraticKey(string[] keywords)
        {
            int matrixSize = CalcMatrixSize();
            _matrices2D = new Matrices2D(MatrixCount, matrixSize, matrixSize);
            MatrixFillerWithEnAlphabet.FillMatricesWithKeywords(_matrices2D, keywords);
            
            _maps = MapCreator.CreateByMatrices2D(_matrices2D);
        }
        private static int CalcMatrixSize() => (int)Math.Sqrt(UsedAlphabet.Size);

        public static Alphabet UsedAlphabet => Alphabets.EnAlphabet;

        public char this[int matrixNum, int row, int column] => _matrices2D[matrixNum, row, column];

        public MatrixCoordinate this[int matrixNum, char letter]
        {
            get
            {
                letter = char.ToUpper(letter);
                char actualLetter = letter == MatrixFillerWithEnAlphabet.OriginalJ 
                    ? MatrixFillerWithEnAlphabet.SubstitutedJ 
                    : letter;
                return _maps[matrixNum][actualLetter];
            }
        }
    }
}