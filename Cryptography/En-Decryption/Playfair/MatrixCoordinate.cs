namespace Cryptography.En_Decryption.Playfair
{
    internal struct MatrixCoordinate
    {
        public int Row { get; }
        public int Column { get; }
        public MatrixCoordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}