namespace FindAllPathsBetweenTwoCellsInMatrix
{
    using System;

    public class FindAllPathsBetweenTwoCellsInMatrix
    {
        public static char[,] lab =
        {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

        public readonly static char UnpassableBlockChar = 'x';
        //public readonly static char EndBlockChar = 'е';
        public readonly static char VisitedBlockChar = 'o';
        public readonly static char NotVisitedBlockChar = ' ';
        public static bool pathFound = false;

        static void Main()
        {
            // Task 7 We are given a matrix of passable and non-passable cells.
            // - Write a recursive program for finding all paths between two cells in the matrix.

            //var startCellX = 0;
            //var startCellY = 0;
            //var endCellX = 4;
            //var endCellY = 6;
            //TraverseMatrix(lab, startCellX, startCellY, endCellX, endCellY);

            // Task 8 Modify the above program to check whether a path exists between two 
            // cells without finding all possible paths.
            // - Test it over an empty 100 x 100 matrix.

            var hundred = 100;
            var empty100X100Labyrinth = new char[hundred, hundred];
            for (int i = 0, len = empty100X100Labyrinth.GetLength(0); i < len; i++)
            {
                for (int j = 0, length = empty100X100Labyrinth.GetLength(1); j < length; j++)
                {
                    empty100X100Labyrinth[i, j] = NotVisitedBlockChar;
                }
            }

            //PrintMatrix(empty100X100Labyrinth);

            TraverseMatrix(empty100X100Labyrinth, 0, 0, empty100X100Labyrinth.GetLength(0) - 1, empty100X100Labyrinth.GetLength(1) - 1);
        }

        // remove first if clause to get all possible paths
        public static void TraverseMatrix(char[,] matrix, int startCellX, int startCellY, int endCellX, int endCellY)
        {
            // remove this
            if (pathFound == true)
            {
                return;
            }

            if (startCellX < 0 || matrix.GetLength(0) <= startCellX)
            {
                return;
            }

            if (startCellY < 0 || matrix.GetLength(1) <= startCellY)
            {
                return;
            }

            if (matrix[startCellX, startCellY] == UnpassableBlockChar ||
                    matrix[startCellX, startCellY] == VisitedBlockChar)
            {
                return;
            }

            if (startCellX.Equals(endCellX) && startCellY.Equals(endCellY))
            {
                pathFound = true;
                matrix[startCellX, startCellY] = VisitedBlockChar;
                PrintMatrix(matrix);
                matrix[startCellX, startCellY] = NotVisitedBlockChar;
            }

            matrix[startCellX, startCellY] = VisitedBlockChar;
            TraverseMatrix(matrix, startCellX - 1, startCellY, endCellX, endCellY); // up
            TraverseMatrix(matrix, startCellX, startCellY + 1, endCellX, endCellY); // right
            TraverseMatrix(matrix, startCellX + 1, startCellY, endCellX, endCellY); // down
            TraverseMatrix(matrix, startCellX, startCellY - 1, endCellX, endCellY); // left
            matrix[startCellX, startCellY] = NotVisitedBlockChar;
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

            Console.WriteLine();
        }
    }
}
