namespace Cryptography.En_Decryption.Playfair
{
    internal class Matrices2D
    {
        private readonly char[,,] _matrices2D;

        public Matrices2D(int matrixCount, int rowCount, int columnCount)
        {
            _matrices2D = new char[matrixCount, rowCount, columnCount];
        }

        public char this[int matrixNum, int row, int column]
        {
            get => _matrices2D[matrixNum, row, column];
            set => _matrices2D[matrixNum, row, column] = value;
        }
        public Matrix2D this[int matrixNum] => new Matrix2D(_matrices2D, matrixNum);
        
        public int MatrixCount => _matrices2D.GetLength(0);
        public int RowCount => _matrices2D.GetLength(1);
        public int ColumnCount => _matrices2D.GetLength(2);
        
        internal readonly struct Matrix2D
        {
            private readonly char[,,] _matrices2D;
            private readonly int _matrixIndex;

            public Matrix2D(char[,,] matrices2D, int matrixIndex)
            {
                _matrices2D = matrices2D;
                _matrixIndex = matrixIndex;
            }
            
            public char this[int row, int column] 
            {
                get => _matrices2D[_matrixIndex, row, column];
                set => _matrices2D[_matrixIndex, row, column] = value;
            }
            
            public int RowCount => _matrices2D.GetLength(1);
            public int ColumnCount => _matrices2D.GetLength(2);
        }
    }

    internal static class Matrices2DExtensions
    {
        public static int ElementsPerMatrix(this Matrices2D matrices2D) => matrices2D.ColumnCount * matrices2D.RowCount;
    }
}