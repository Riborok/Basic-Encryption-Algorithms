using System;
using System.Collections.Generic;
using System.Text;

namespace Encryption
{
    public class TranspositionCipher
    {
        private readonly Alphabet _alphabet;

        public TranspositionCipher(Alphabet alphabet)
        {
            _alphabet = alphabet;
        }
        
        public string Decrypt(string ciphertext, string keyword)
        {
            keyword = _alphabet.RemoveNonAlphabetic(keyword);
            int textLength = _alphabet.CountAlphabeticLetters(ciphertext);

            var table = new TranspositionTable(textLength, keyword.Length);
            var columnOrder = ColumnOrder.Create(keyword);

            table.FillTableWithCiphertext(ciphertext, columnOrder);
            
            return table.CreatePlaintext();
        }

        public string Encrypt(string plaintext, string keyword)
        {
            plaintext = _alphabet.RemoveNonAlphabetic(plaintext);
            keyword = _alphabet.RemoveNonAlphabetic(keyword);
    
            var table = new TranspositionTable(plaintext.Length, keyword.Length);
            table.FillTableWithPlaintext(plaintext);
            
            var columnOrder = ColumnOrder.Create(keyword);
    
            return table.CreateCiphertext(columnOrder);
        }
    }

    public static class ColumnOrder
    {
        public static IEnumerable<int> Create(string keyword)
        {
            var sortedIndexMap = CreateSortedIndexMap(keyword);
            return FlattenSortedIndexMap(sortedIndexMap);
        }

        private static SortedDictionary<char, List<int>> CreateSortedIndexMap(string keyword)
        {
            var sortedIndexMap = new SortedDictionary<char, List<int>>();

            for (int i = 0; i < keyword.Length; i++)
            {
                char c = keyword[i];
                if (!sortedIndexMap.ContainsKey(c))
                    sortedIndexMap[c] = new List<int>();

                sortedIndexMap[c].Add(i);
            }

            return sortedIndexMap;
        }

        private static IEnumerable<int> FlattenSortedIndexMap(SortedDictionary<char, List<int>> sortedIndexMap)
        {
            var result = new List<int>();
            foreach (var pair in sortedIndexMap)
                result.AddRange(pair.Value);
            
            return result;
        }
    }
    
    public class TranspositionTable
    {
        private const char FillCharacter = '\0';
        
        private readonly char[,] _table;

        public TranspositionTable(int textLength, int columns)
        {
            _table = new char[CalcRows(textLength, columns), columns];
        }
        
        private static int CalcRows(int textLength, int columns)
        {
            return (int)Math.Ceiling((double)textLength / columns);
        }

        private int Rows => _table.GetLength(0);
        private int Columns => _table.GetLength(1);

        public string CreatePlaintext()
        {
            StringBuilder plaintextBuilder = new StringBuilder();

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    if (_table[i, j] != FillCharacter)
                        plaintextBuilder.Append(_table[i, j]);
            
            return plaintextBuilder.ToString();
        }
        
        public string CreateCiphertext(IEnumerable<int> columnOrder)
        {
            var ciphertextBuilder = new StringBuilder();

            foreach (int columnIndex in columnOrder)
                ciphertextBuilder.Append(BuildColumn(columnIndex));

            return ciphertextBuilder.ToString();
        }

        private StringBuilder BuildColumn(int columnIndex)
        {
            StringBuilder columnBuilder = new StringBuilder();
            
            for (int i = 0; i < Rows; i++)
            {
                char c = _table[i, columnIndex];
                columnBuilder.Append(c);
            }

            return columnBuilder;
        }

        public void FillTableWithPlaintext(string plaintext)
        {
            int index = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    _table[i, j] = index < plaintext.Length ? plaintext[index++] : FillCharacter;
        }

        public void FillTableWithCiphertext(string ciphertext, IEnumerable<int> columnOrder)
        {
            int index = 0;
            foreach (int columnIndex in columnOrder)
            {
                for (int i = 0; i < Rows; i++)
                    _table[i, columnIndex] = index < ciphertext.Length ? ciphertext[index++] : FillCharacter;
            }
        }
    }
}