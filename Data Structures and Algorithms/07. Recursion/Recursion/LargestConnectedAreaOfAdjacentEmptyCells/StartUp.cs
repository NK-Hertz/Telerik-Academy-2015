namespace LargestConnectedAreaOfAdjacentEmptyCells
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static char[,] lab =
        {
            {' ', 'x', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', ' ', 'x', 'x', ' '},
            {' ', ' ', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', 'x', 'x', 'x', 'x', 'x'},
            {'x', 'x', ' ', ' ', 'x', ' ', ' '},
        };
        public static char[,] unpassableLab =
        {
            {' ', 'x', 'x', 'x', 'x', 'x', 'x'},
            {'x', 'x', 'x', 'x', 'x', 'x', 'x'},
            {'x', 'x', 'x', 'x', 'x', 'x', 'x'},
            {'x', 'x', 'x', 'x', 'x', 'x', 'x'},
            {'x', 'x', 'x', 'x', 'x', 'x', 'x'},
        };
        public static char[,] traversedMatrix;

        public static int maxConnectedPassableCellsCount = 0;
        public static int currentConnectedPassableCellsCount = 0;

        public readonly static char UnpassableBlockChar = 'x';
        public readonly static char VisitedBlockChar = 'o';
        public readonly static char NotVisitedBlockChar = ' ';

        public static void Main()
        {
            traversedMatrix = CopyMatrix(unpassableLab);
            ItterateThroughAreas(traversedMatrix);
            Console.WriteLine("Number of connected passable cells: {0}", maxConnectedPassableCellsCount);

            maxConnectedPassableCellsCount = 0;

            traversedMatrix = CopyMatrix(lab);
            ItterateThroughAreas(traversedMatrix);
            Console.WriteLine("Number of connected passable cells: {0}", maxConnectedPassableCellsCount);

            maxConnectedPassableCellsCount = 0;

            traversedMatrix = CopyMatrix(unpassableLab);
            ItterateThroughAreas(traversedMatrix);
            Console.WriteLine("Number of connected passable cells: {0}", maxConnectedPassableCellsCount);
        }

        public static bool FreeCellExists(char[,] matrix, out int x, out int y)
        {
            var freeCellFound = false;

            x = -1;
            y = -1;

            for (int i = 0, len = matrix.GetLength(0); i < len; i++)
            {
                for (int j = 0, length = matrix.GetLength(1); j < length; j++)
                {
                    if (matrix[i, j].Equals(NotVisitedBlockChar))
                    {
                        x = i;
                        y = j;
                        freeCellFound = true;
                        break;
                    }
                }

                if (freeCellFound == true)
                {
                    break;
                }
            }

            return freeCellFound;
        }

        public static void FindLargestConnectedArea(char[,] matrix, int x, int y)
        {
            if (x < 0 || matrix.GetLength(0) <= x)
            {
                return;
            }

            if (y < 0 || matrix.GetLength(1) <= y)
            {
                return;
            }

            if (matrix[x, y] == UnpassableBlockChar ||
                    matrix[x, y] == VisitedBlockChar)
            {
                return;
            }

            if (matrix[x, y].Equals(NotVisitedBlockChar))
            {
                matrix[x, y] = VisitedBlockChar;
                currentConnectedPassableCellsCount += 1;
                if (maxConnectedPassableCellsCount < currentConnectedPassableCellsCount)
                {
                    maxConnectedPassableCellsCount = currentConnectedPassableCellsCount;
                }
            }

            matrix[x, y] = VisitedBlockChar;
            FindLargestConnectedArea(matrix, x - 1, y);
            FindLargestConnectedArea(matrix, x, y + 1);
            FindLargestConnectedArea(matrix, x + 1, y);
            FindLargestConnectedArea(matrix, x, y - 1);
            currentConnectedPassableCellsCount = 0;
        }

        public static void ItterateThroughAreas(char[,] matrix)
        {
            var x = 0;
            var y = 0;
            var isThereAvailableCell = FreeCellExists(traversedMatrix, out x, out y);
            while (isThereAvailableCell)
            {
                FindLargestConnectedArea(matrix, x, y);
                isThereAvailableCell = FreeCellExists(traversedMatrix, out x, out y);
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0, len = matrix.GetLength(0); i < len; i++)
            {

                for (int j = 0, length = matrix.GetLength(1); j < length; j++)
                {
                    Console.Write("'{0}'", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static char[,] CopyMatrix(char[,] matrix)
        {
            var resultMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0, len = matrix.GetLength(0); i < len; i++)
            {
                for (int j = 0, length = matrix.GetLength(1); j < length; j++)
                {
                    resultMatrix[i, j] = matrix[i, j];
                }
            }

            return resultMatrix;
        }
    }
}
