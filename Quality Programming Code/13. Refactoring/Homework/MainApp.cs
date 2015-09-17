using System;

namespace RotatingWalkInMatrix {
    public class MainApp {
        public static int[] GetNewDirection(int directionX, int directionY) 
        {
            var directionsCount = 8;
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int timesChangedDirections = 0;
            for (int i = 0; i < directionsCount; i++)
            {
                if (directionsX[i] == directionX && directionsY[i] == directionY) 
                { 
                    timesChangedDirections = i; 
                    break; 
                }
            }

            var directionResult = new int[2];

            if( timesChangedDirections == directionsCount - 1) 
            { 
                directionX = directionsX[0]; 
                directionY = directionsY[0];
            }
            else
            {
                directionX = directionsX[timesChangedDirections + 1];
                directionY = directionsY[timesChangedDirections + 1];
            }
            
            directionResult[0] = directionX;
            directionResult[1] = directionY;
            return directionResult; 
        }

        public static bool CheckForAvailableCell(int[,] matrix, int row, int col)
        {
            var directionsCount = 8;
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            var matrixSize = matrix.GetLength(0);
            for (int i = 0; i < directionsCount; i++)
            {
                if (row + directionsX[i] < 0 || row + directionsX[i] >= matrixSize)
                {
                    directionsX[i] = 0;
                }

                if (col + directionsY[i] < 0 || col + directionsY[i] >= matrixSize)
                {
                    directionsY[i] = 0;
                }

                if (matrix[row + directionsX[i], col + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void GetFirstAvailableCellClosestToStartPosition(int[,] matrix, out int x, out int y)
        {
            x = 0;
            y = 0;
            var matrixSize = matrix.GetLength(0);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == 0) 
                    { 
                        x = row;
                        y = col; 
                        return; 
                    }
                }
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            var matrixSize = matrix.GetLength(0);
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        static void Main(){
            //Console.WriteLine("Enter a positive number");
            //string input = Console.ReadLine(  );
            //int sizeOfMatrix = 0;
            //while (!int.TryParse(input, out sizeOfMatrix) || sizeOfMatrix <= 0 || sizeOfMatrix > 100)
            //{
            //    Console.WriteLine("You haven't entered a correct positive number");
            //    input = Console.ReadLine();
            //}
            int sizeOfMatrix = 3;
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];
            int cellCounter = 1,
                row = 0,
                col = 0,
                directionX = 1,
                directionY = 1;

            while(true)
            {
                matrix[row, col] = cellCounter;
                if(!CheckForAvailableCell(matrix, row, col))
                { 
                    break; 
                }

                var isOutOfXBoundaries = row + directionX < 0 || row + directionX >= sizeOfMatrix;
                var isOutOfYBoundaries = col + directionY < 0 || col + directionY >= sizeOfMatrix;
                var isThereValidMove = isOutOfXBoundaries || isOutOfYBoundaries || matrix[row + directionX, col + directionY] != 0;

                if (isThereValidMove)
                {
                    while (isThereValidMove)
                    {
                        var direction = GetNewDirection(directionX, directionY);
                        directionX = direction[0];
                        directionY = direction[1];

                        isOutOfXBoundaries = row + directionX < 0 || row + directionX >= sizeOfMatrix;
                        isOutOfYBoundaries = col + directionY < 0 || col + directionY >= sizeOfMatrix;
                        isThereValidMove = isOutOfXBoundaries || isOutOfYBoundaries || matrix[row + directionX, col + directionY] != 0;
                    }
                }

                row += directionX;
                col += directionY; 
                cellCounter++;
            }

            PrintMatrix(matrix);

            GetFirstAvailableCellClosestToStartPosition(matrix, out row, out col);
            //the function needs us to define out params
            if (row != 0 && col != 0)
            { 
                directionX = 1; directionY = 1;
                while (true)
                {
                    matrix[row, col] = cellCounter + 1;
                    if (!CheckForAvailableCell(matrix, row, col))
                    {
                        break;
                    }

                    if (row + directionX >= sizeOfMatrix || row + directionX < 0 || col + directionY >= sizeOfMatrix || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0)
                    {
                        while ((row + directionX >= sizeOfMatrix || row + directionX < 0 || col + directionY >= sizeOfMatrix || col + directionY < 0 || matrix[row + directionX, col + directionY] != 0))
                        {
                            var direction = GetNewDirection(directionX, directionY);
                            directionX = direction[0];
                            directionY = direction[1];

                        }
                    }

                    row += directionX;
                    col += directionY;
                    cellCounter++;
                }
            }

            PrintMatrix(matrix);
        }
    }
}
