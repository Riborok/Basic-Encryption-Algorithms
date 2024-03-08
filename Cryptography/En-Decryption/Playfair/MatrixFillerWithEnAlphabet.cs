using System.Collections.Generic;
using System.Linq;

namespace Cryptography.En_Decryption.Playfair
{
    internal static class MatrixFillerWithEnAlphabet
    {
        public const char OriginalJ = 'J'; 
        public const char SubstitutedJ = 'I';
        
        public static void FillMatricesWithKeywords(Matrices2D matrices2D, string[] keywords)
        {
            for (int matrixNum = 0; matrixNum < matrices2D.MatrixCount; matrixNum++)
                FillMatrixWithKeyword(matrices2D[matrixNum], GetKeyword(keywords, matrixNum));
        }
        
        private static void FillMatrixWithKeyword(Matrices2D.Matrix2D matrix2D, string keyword)
        {
            var letterOrder = CreateLetterOrder(keyword);
            FillMatrixWithLetterOrder(matrix2D, letterOrder);
        }

        private static string GetKeyword(IReadOnlyList<string> keywords, int matrixNum)
        {
            return matrixNum < keywords.Count ? keywords[matrixNum] : string.Empty;
        }

        private static IReadOnlyList<char> CreateLetterOrder(string keyword)
        {
            var letterOrder = new List<char>(Alphabets.EnAlphabet.Size);

            var addedLetters = AddKeywordLetters(letterOrder, keyword);
            AddRemainingLetters(letterOrder, addedLetters);

            return letterOrder;
        }

        private static ICollection<char> AddKeywordLetters(ICollection<char> letterOrder, string keyword)
        {
            var addedLetters = new HashSet<char>(Alphabets.EnAlphabet.Size);
            foreach (var c in keyword)
            {
                char uppercaseC = char.ToUpper(c);
                if (uppercaseC == OriginalJ)
                    uppercaseC = SubstitutedJ;
                if (!addedLetters.Contains(uppercaseC))
                {
                    addedLetters.Add(uppercaseC);
                    letterOrder.Add(uppercaseC);
                }
            }

            return addedLetters;
        }

        private static void AddRemainingLetters(List<char> remainingLetters, ICollection<char> addedLetters)
        {
            remainingLetters.AddRange(Alphabets.EnAlphabet.Where(c => !addedLetters.Contains(c) && c != OriginalJ));
        }
        
        private static void FillMatrixWithLetterOrder(Matrices2D.Matrix2D matrix2D, IReadOnlyList<char> letterOrder)
        {
            int index = 0;
            for (int i = 0; i < matrix2D.RowCount; i++)
                for (int j = 0; j < matrix2D.ColumnCount; j++)
                    matrix2D[i, j] = letterOrder[index++];
        }
    }
}