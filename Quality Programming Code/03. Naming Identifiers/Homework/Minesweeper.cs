namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Minesweeper
    {
        static void Main(string[] args)
        {
            const int MINIMUM_LENGHT_OF_VALID_COMMAND = 3;
            const int MAX_SAFE_CELLS = 35;

            string command = string.Empty;
            int openedSafeCellsCount = 0;

            char[,] field = CreateGameField();
            char[,] bombsField = PlaceBombs();
                        
            bool steppedOnMine = false;

            List<Score> champions = new List<Score>(6);

            int row = 0;
            int column = 0;

            bool introActivated = true;
            bool outroActivated = false;

            do
            {
                if (introActivated)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    DrawField(field);
                    introActivated = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= MINIMUM_LENGHT_OF_VALID_COMMAND)
                {
                    var inputIsNumber = int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column);
                    var inputIsWithinField = row <= field.GetLength(0) && column <= field.GetLength(1);
                    if (inputIsNumber && inputIsWithinField)
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintLeaderboard(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        bombsField = PlaceBombs();
                        DrawField(field);
                        steppedOnMine = false;
                        introActivated = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombsField[row, column] != '*')
                        {
                            if (bombsField[row, column] == '-')
                            {
                                MakeAMove(field, bombsField, row, column);
                                openedSafeCellsCount++;
                            }

                            if (MAX_SAFE_CELLS == openedSafeCellsCount)
                            {
                                outroActivated = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            steppedOnMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (steppedOnMine)
                {
                    DrawField(bombsField);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", openedSafeCellsCount);
                    string playerName = Console.ReadLine();
                    Score score = new Score(playerName, openedSafeCellsCount);
                    if (champions.Count < 5)
                    {
                        champions.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < score.Points)
                            {
                                champions.Insert(i, score);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score scoreFirst, Score scoreSecond) => scoreSecond.Name.CompareTo(scoreFirst.Name));
                    champions.Sort((Score scoreFirst, Score scoreSecond) => scoreSecond.Points.CompareTo(scoreFirst.Points));

                    PrintLeaderboard(champions);

                    field = CreateGameField();
                    bombsField = PlaceBombs();
                    openedSafeCellsCount = 0;
                    steppedOnMine = false;
                    introActivated = true;
                }

                if (outroActivated)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    DrawField(bombsField);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string playerName = Console.ReadLine();
                    Score score = new Score(playerName, openedSafeCellsCount);
                    champions.Add(score);

                    PrintLeaderboard(champions);

                    field = CreateGameField();
                    bombsField = PlaceBombs();
                    openedSafeCellsCount = 0;
                    outroActivated = false;
                    introActivated = true;
                }
            }

            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void PrintLeaderboard(List<Score> score)
        {
            Console.WriteLine("\nTo4KI:");
            if (score.Count > 0)
            {
                for (int i = 0; i < score.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, score[i].Name, score[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void MakeAMove(char[,] board, char[,] bombsField, int row, int column)
        {
            char bombsCount = GetBombCountNearCell(bombsField, row, column);
            bombsField[row, column] = bombsCount;
            board[row, column] = bombsCount;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] board = new char[rows, columns];

            int bombsToPlace = 15;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < bombsToPlace)
            {
                Random randomGenerator = new Random();
                int currentRandomNumber = randomGenerator.Next(50);
                if (!randomNumbers.Contains(currentRandomNumber))
                {
                    randomNumbers.Add(currentRandomNumber);
                }
            }

            foreach (int currentRandomNumber in randomNumbers)
            {
                int column = (currentRandomNumber / columns);
                int row = (currentRandomNumber % columns);
                if (row == 0 && currentRandomNumber != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                board[column, row - 1] = '*';
            }

            return board;
        }

        private static void DisplayNumberOfBombsNearCell(char[,] board)
        {
            int columns = board.GetLength(0);
            int rows = board.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char bombCount = GetBombCountNearCell(board, i, j);
                        board[i, j] = bombCount;
                    }
                }
            }
        }

        private static char GetBombCountNearCell(char[,] board, int row, int column)
        {
            int bombsAroundCell = 0;
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, column] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, column] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (column - 1 >= 0)
            {
                if (board[row, column - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if (column + 1 < columns)
            {
                if (board[row, column + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (board[row - 1, column - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (board[row - 1, column + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (board[row + 1, column - 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (board[row + 1, column + 1] == '*')
                {
                    bombsAroundCell++;
                }
            }

            return char.Parse(bombsAroundCell.ToString());
        }
    }
}
