using System;

namespace Cryptography.En_Decryption.Transposition
{
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