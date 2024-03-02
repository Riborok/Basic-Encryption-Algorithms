using System.Collections.Generic;

namespace Cryptography.En_Decryption.Playfair
{
    internal static class MapCreator
    {
        public static Dictionary<char, MatrixCoordinate>[] CreateByMatrices2D(Matrices2D matrices2D)
        {
            var maps = InitializeMaps(matrices2D);
            for (int matrixNum = 0; matrixNum < matrices2D.MatrixCount; matrixNum++)
                FillMapByMatrix(maps[matrixNum], matrices2D[matrixNum]);
            return maps;
        }

        private static void FillMapByMatrix(IDictionary<char, MatrixCoordinate> map, Matrices2D.Matrix2D matrix2D)
        {
            for (int i = 0; i < matrix2D.RowCount; i++)
                for (int j = 0; j < matrix2D.ColumnCount; j++)
                    map[matrix2D[i, j]] = new MatrixCoordinate(i, j);
        }

        private static Dictionary<char, MatrixCoordinate>[] InitializeMaps(Matrices2D matrices2D)
        {
            var maps = new Dictionary<char, MatrixCoordinate>[matrices2D.MatrixCount];
            for (int matrixNum = 0; matrixNum < matrices2D.MatrixCount; matrixNum++)
                maps[matrixNum] = new Dictionary<char, MatrixCoordinate>(matrices2D.ElementsPerMatrix());
            return maps;
        }
    }
}