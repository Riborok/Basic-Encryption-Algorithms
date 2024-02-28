using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.En_Decryption
{
    internal class TextGenerator
    {
        private readonly TranspositionTable _table;

        public TextGenerator(TranspositionTable table)
        {
            _table = table;
        }

        public string GeneratePlaintext()
        {
            var plaintextBuilder = new StringBuilder(_table.TextLength);

            for (int rowIndex = 0; rowIndex < _table.Rows; rowIndex++)
                BuildPlaintextRow(plaintextBuilder, rowIndex);

            return plaintextBuilder.ToString();
        }

        private void BuildPlaintextRow(StringBuilder plaintextBuilder, int rowIndex)
        {
            for (int j = 0; j <  _table.Columns; j++)
            {
                char c = _table[rowIndex, j];
                if (c != TranspositionTable.FillCharacter)
                    plaintextBuilder.Append(c);
            }
        }
        
        public string GenerateCiphertext(IEnumerable<int> columnOrder)
        {
            var ciphertextBuilder = new StringBuilder(_table.TextLength);

            foreach (int columnIndex in columnOrder)
                BuildCiphertextColumn(ciphertextBuilder, columnIndex);

            return ciphertextBuilder.ToString();
        }

        private void BuildCiphertextColumn(StringBuilder ciphertextBuilder, int columnIndex)
        {
            for (int i = 0; i <  _table.Rows; i++)
            {
                char c = _table[i, columnIndex];
                if (c != TranspositionTable.FillCharacter)
                    ciphertextBuilder.Append(c);
            }
        }
    }
    
    internal class TranspositionTableFiller
    {
        private readonly TranspositionTable _table;

        public TranspositionTableFiller(TranspositionTable table)
        {
            _table = table;
        }

        public void FillWithPlaintext(string plaintext)
        {
            int index = 0;
            
            for (int i = 0; i < _table.Rows; i++)
                for (int j = 0; j < _table.Columns; j++)
                    _table[i, j] = index < plaintext.Length ? plaintext[index++] : TranspositionTable.FillCharacter;
        }

        public void FillWithCiphertext(string ciphertext, IEnumerable<int> columnOrder)
        {
            int index = 0;
            
            foreach (int columnIndex in columnOrder)
            {
                for (int i = 0; i < _table.LastRow(); i++)
                    _table[i, columnIndex] = ciphertext[index++];
                _table[_table.LastRow(), columnIndex] = columnIndex < _table.LetterCountInLastRow() 
                    ? ciphertext[index++] 
                    : TranspositionTable.FillCharacter;
            }
        }
    }
    
    internal class TranspositionTable
    {
        public const char FillCharacter = '\0';
        
        private readonly char[,] _table;

        public TranspositionTable(int textLength, int columns)
        {
            TextLength = textLength;
            _table = new char[CalcRows(textLength, columns), columns];
        }

        private static int CalcRows(int textLength, int columns)
        {
            return (int)Math.Ceiling((double)textLength / columns);
        }

        public char this[int rowIndex, int columnIndex]
        {
            get => _table[rowIndex, columnIndex];
            set => _table[rowIndex, columnIndex] = value;
        }

        public int TextLength { get; }

        public int Rows => _table.GetLength(0);
        
        public int Columns => _table.GetLength(1);
    }
    
    internal static class TranspositionTableExtensions
    {
        public static int LetterCountInLastRow(this TranspositionTable table) => 
            table.Columns - (table.Rows * table.Columns - table.TextLength);

        public static int LastRow(this TranspositionTable table) => table.Rows - 1;
    }
}