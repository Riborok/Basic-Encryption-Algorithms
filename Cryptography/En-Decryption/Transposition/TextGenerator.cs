using System.Collections.Generic;
using System.Text;

namespace Cryptography.En_Decryption.Transposition
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
}