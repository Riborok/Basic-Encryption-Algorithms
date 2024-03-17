using System;
using System.Linq;
using System.Text;
using Cryptography.Extensions;


namespace Cryptography.En_Decryption.RotatingGrille
{
    public class GrilleCipher : Cipher
    {
        
        public GrilleCipher(Alphabet textAlphabet, Alphabet keyAlphabet) 
            : base(textAlphabet, keyAlphabet)
        {
        }

        protected override string Encrypt(string plaintext, string keyword)
        {
            var matrixDimension = (int)Math.Sqrt(keyword.Length);
            if (matrixDimension * matrixDimension != keyword.Length)
            {
                throw new ArgumentException("Incorrect key (key length doesn't match with the amount of cells in matrix");
            }

            bool[,] keyMatrix = CreateKeyMatrix(keyword);
            if (!CheckHoles(keyMatrix))
            {
                throw new ArgumentException("Incorrectly filled holes in the template (grille)");
            }

            if (!CheckHolesAmount(keyword))
            {
                throw new ArgumentException("Incorrect amount of holes");
            }
            return FillMatrixUsingGrille(plaintext, keyMatrix);;
        }

        protected override string Decrypt(string ciphertext, string keyword)
        {
            var matrixDimension = (int)Math.Sqrt(keyword.Length);
            if (matrixDimension * matrixDimension != keyword.Length)
            {
                throw new ArgumentException("Incorrect key (key length doesn't match with the amount of cells in matrix");
            }

            if (ciphertext.Length % keyword.Length != 0)
            {
                throw new ArgumentException("Incorrect ciphered text (should be multiple of the cells amount");
            }

            bool[,] keyMatrix = CreateKeyMatrix(keyword);
            if (!CheckHoles(keyMatrix))
            {
                throw new ArgumentException("Incorrectly filled holes in the template (grille)");
            }
            
            if (!CheckHolesAmount(keyword))
            {
                throw new ArgumentException("Incorrect amount of holes");
            }
            return ReadGrill(ciphertext, keyMatrix);
        }
        
        private char[,] FillWithRandom(char[,] charMatrix)
        {
            int size = charMatrix.GetLength(0);
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (charMatrix[i, j] == '\0')
                    {
                        charMatrix[i, j] = TextAlphabet.GetLetter(random.Next(TextAlphabet.Size));
                    }
                }
            }

            return charMatrix;
        }
        private string FillMatrixUsingGrille(string plaintext, bool[,] grille)
        {
            int size = grille.GetLength(0);
            char[,] filledMatrix = new char[size, size];
            int stringIndex = 0;
            var flag = size.IsOdd();
            StringBuilder ciphertext = new StringBuilder(plaintext.Length);
            
            // Проходим по всем ячейкам решетки
            do
            {
            
                for (int k = 0; k < 4; k++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            // Если в решетке есть дырка, добавляем символ из строки
                            if (grille[i, j])
                            {
                                
                                // Если индекс строки выходит за пределы длины строки, прерываем цикл
                                if (stringIndex >= plaintext.Length)
                                {
                                    filledMatrix = FillWithRandom(filledMatrix);
                                    break;
                                }
                            
                                filledMatrix[i, j] = plaintext[stringIndex++];


                                if (flag && i == size / 2 && j == size / 2)
                                {
                                    grille[i, j] = false;

                                }
                            }
                        }
                    }

                    grille = RotateGrid(grille);
                }

                ciphertext = CipherTextAppend(ciphertext, filledMatrix);
                filledMatrix = ClearCipherMatrix(filledMatrix);
                if (flag) grille[size / 2, size / 2] = true;
            } while (stringIndex < plaintext.Length);
            
            return ciphertext.ToString();
        }
            
        static char[,] FillGrillWithCipher(char[,] fillMatrix, string ciphertextPart)
        {
            int size = fillMatrix.GetLength(0);
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    fillMatrix[i, j] = ciphertextPart[index++];
                }
            }

            return fillMatrix;
        }
        static string ReadGrill(string ciphertext, bool[,] grille)
        {
            int size = grille.GetLength(0);
            char[,] filledMatrix = new char[size, size];
            int stringIndex = 0;
            var flag = size.IsOdd();

            StringBuilder plaintext = new StringBuilder(ciphertext.Length);

            // Проходим по всем ячейкам решетки
            
            do
            {
                filledMatrix = FillGrillWithCipher(filledMatrix, ciphertext.Substring(stringIndex));
                for (int k = 0; k < 4; k++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            // Если в решетке есть дырка, добавляем символ из строки
                            if (grille[i, j])
                            {
                                // Если индекс строки выходит за пределы длины строки, прерываем цикл
                                if (stringIndex >= ciphertext.Length) break;
                            
                                plaintext.Append(filledMatrix[i, j]);
                                stringIndex++;


                                if (flag && i == size / 2 && j == size / 2)
                                {
                                    grille[i, j] = false;
                                }
                            }
                        }
                    }

                    grille = RotateGrid(grille);
                }
                
                filledMatrix = ClearCipherMatrix(filledMatrix);
                if (flag) grille[size / 2, size / 2] = true;
            } while (stringIndex < ciphertext.Length - 1);
            
            return plaintext.ToString();
        }
        
        static char[,] ClearCipherMatrix(char[,] cipherMatrix)
        {
            var size = cipherMatrix.GetLength(0);
            return new char[size, size];
        }
            
        private static StringBuilder CipherTextAppend(StringBuilder ciphertext, char[,] cipherMatrix)
        {
            int size = cipherMatrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ciphertext.Append(cipherMatrix[i, j]);
                }
            }

            return ciphertext;
        }
            

        private bool[,] CreateKeyMatrix(string keyword)
        {
            var matrixDimension = (int)Math.Sqrt(keyword.Length);
            bool[,] keyMatrix = new bool[matrixDimension, matrixDimension];
            int index = 0;
            for (int row = 0; row < matrixDimension; row++)
            {
                for (int col = 0; col < matrixDimension; col++)
                {
                    keyMatrix[row, col] = keyword[index] == '1';
                    index++;
                }
            }

            return keyMatrix;
        }
            
        private static bool CheckHoles(bool[,] grid)
        {
            int size = grid.GetLength(0);
            bool[,] mask = new bool[size, size]; // Создаем пустую матрицу-маску

            // Проверяем каждое положение решетки
            for (int rotation = 0; rotation < 4; rotation++)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        // Если матрица имеет нечетный размер и текущая позиция является серединой, игнорируем дырку
                        if (size.IsOdd() && i == size / 2 && j == size / 2)
                        {
                            continue;
                        }
                    
                        // Если в решетке есть дырка, а в маске уже true, значит дырки пересекаются
                        if (grid[i, j] && mask[i, j])
                        {
                            return false;
                        }
                        // Если в решетке есть дырка, помечаем соответствующую ячейку маски как true
                        if (grid[i, j])
                        {
                            mask[i, j] = true;
                        }
                    }
                }
                // Вращаем решетку на 90 градусов по часовой стрелке
                grid = RotateGrid(grid);
            }

            // Если дырки не пересекаются ни при одном положении решетки, возвращаем true
            return true;
        }

        private static bool CheckHolesAmount(string keyword)
        {
            int size = keyword.Length;
            bool isOddMatrix = size.IsOdd();
            int correctAmount = isOddMatrix ? size / 4 + 1 : size / 4;
            int count = 0;
            foreach (char c in keyword)
            {
                if (c == '1')
                {
                    count++;
                }
            }
            return correctAmount == count;
        }

            // Функция для вращения решетки на 90 градусов по часовой стрелке
        private static bool[,] RotateGrid(bool[,] grid)
        {
            int size = grid.GetLength(0);
            bool[,] rotatedGrid = new bool[size, size];
            Array.Copy(grid, rotatedGrid, grid.Length);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = rotatedGrid[size - j - 1, i];
                }
            }

            return grid;
        }
    }
}