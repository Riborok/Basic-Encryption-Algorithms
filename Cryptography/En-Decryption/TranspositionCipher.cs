using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptography.En_Decryption
{
    public class TranspositionCipher : Cipher
    {
        public TranspositionCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet)
        {
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var table = new TranspositionTable(plaintext.Length, keyword.Length);
            var columnOrder = ColumnOrder.Create(keyword);
            
            table.FillTableWithPlaintext(plaintext);
    
            return table.GenerateCiphertext(columnOrder);
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var table = new TranspositionTable(ciphertext.Length, keyword.Length);
            var columnOrder = ColumnOrder.Create(keyword);

            table.FillTableWithCiphertext(ciphertext, columnOrder);
            
            return table.GeneratePlaintext();
        }
    }

    internal static class ColumnOrder
    {
        public static IEnumerable<int> Create(string keyword)
        {
            var sortedIndexMap = CreateSortedIndexMap(keyword);
            return FlattenSortedIndexMap(sortedIndexMap);
        }

        private static IEnumerable<int> FlattenSortedIndexMap(SortedDictionary<char, List<int>> sortedIndexMap)
        {
            return sortedIndexMap.SelectMany(pair => pair.Value);
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
    }
    
    internal class TranspositionTable
    {
        private const char FillCharacter = '\0';

        private readonly int _textLength;
        private readonly char[,] _table;

        public TranspositionTable(int textLength, int columns)
        {
            _textLength = textLength;
            _table = new char[CalcRows(textLength, columns), columns];
        }
        
        private static int CalcRows(int textLength, int columns)
        {
            return (int)Math.Ceiling((double)textLength / columns);
        }

        public string GeneratePlaintext()
        {
            var plaintextBuilder = new StringBuilder(_textLength);

            for (int rowIndex = 0; rowIndex < Rows; rowIndex++)
                BuildPlaintextRow(plaintextBuilder, rowIndex);

            return plaintextBuilder.ToString();
        }

        private void BuildPlaintextRow(StringBuilder plaintextBuilder, int rowIndex)
        {
            for (int j = 0; j < Columns; j++)
            {
                char c = _table[rowIndex, j];
                if (c != FillCharacter)
                    plaintextBuilder.Append(c);
            }
        }
        
        public string GenerateCiphertext(IEnumerable<int> columnOrder)
        {
            var ciphertextBuilder = new StringBuilder(_textLength);

            foreach (int columnIndex in columnOrder)
                BuildCiphertextColumn(ciphertextBuilder, columnIndex);

            return ciphertextBuilder.ToString();
        }

        private void BuildCiphertextColumn(StringBuilder ciphertextBuilder, int columnIndex)
        {
            for (int i = 0; i < Rows; i++)
            {
                char c = _table[i, columnIndex];
                if (c != FillCharacter)
                    ciphertextBuilder.Append(c);
            }
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
                for (int i = 0; i < LastRows; i++)
                    _table[i, columnIndex] = ciphertext[index++];
                _table[LastRows, columnIndex] = columnIndex < LetterCountInLastRow ? ciphertext[index++] : FillCharacter;
            }
        }
        
        private int LetterCountInLastRow => Columns - (Rows * Columns - _textLength);
        private int Rows => _table.GetLength(0);
        private int LastRows => Rows - 1;
        private int Columns => _table.GetLength(1);
    }
}