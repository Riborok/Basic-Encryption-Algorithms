using System.Collections.Generic;

namespace Cryptography.En_Decryption.Transposition
{
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
}