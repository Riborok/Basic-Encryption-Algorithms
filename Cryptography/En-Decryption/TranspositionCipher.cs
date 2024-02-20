using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cryptography.En_Decryption
{
    public class TranspositionCipher
    {
        private readonly Alphabet _alphabet;

        public TranspositionCipher(Alphabet alphabet)
        {
            _alphabet = alphabet;
        }

        public string Encrypt(string plaintext, params string[] keywords)
        {
            plaintext = _alphabet.RemoveNonAlphabetic(plaintext);
            foreach (var keyword in keywords)
                plaintext = Encrypt(plaintext, _alphabet.RemoveNonAlphabetic(keyword));
            
            return plaintext;
        }
        
        private static string Encrypt(string plaintext, string keyword)
        {
            var table = new TranspositionTable(plaintext.Length, keyword.Length);
            var columnOrder = ColumnOrder.Create(keyword);
            
            table.FillTableWithPlaintext(plaintext);
    
            return table.GenerateCiphertext(columnOrder);
        }

        public string Decrypt(string ciphertext, params string[] keywords)
        {
            ciphertext = _alphabet.RemoveNonAlphabetic(ciphertext);
            foreach (var keyword in keywords.Reverse())
                ciphertext = Decrypt(ciphertext, _alphabet.RemoveNonAlphabetic(keyword));
            
            return ciphertext;
        }
        
        private static string Decrypt(string ciphertext, string keyword)
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
        
        private readonly char[,] _table;

        public TranspositionTable(int textLength, int columns)
        {
            _table = new char[CalcRows(textLength, columns), columns];
        }
        
        private static int CalcRows(int textLength, int columns)
        {
            return (int)Math.Ceiling((double)textLength / columns);
        }

        public string GeneratePlaintext()
        {
            var plaintextBuilder = new StringBuilder();

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
            var ciphertextBuilder = new StringBuilder();

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
            int lastRow = Rows - 1;
            int letterCountInLastRow = Columns - (Rows * Columns - ciphertext.Length);
            
            int index = 0;
            
            foreach (int columnIndex in columnOrder)
            {
                for (int i = 0; i < lastRow; i++)
                    _table[i, columnIndex] = ciphertext[index++];
                _table[lastRow, columnIndex] = columnIndex < letterCountInLastRow ? ciphertext[index++] : FillCharacter;
            }
        }

        private int Rows => _table.GetLength(0);
        
        private int Columns => _table.GetLength(1);
    }
}