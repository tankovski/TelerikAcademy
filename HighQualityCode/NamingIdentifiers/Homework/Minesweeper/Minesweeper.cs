using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Minesweeper
{
    public class Points
    {
        //Fields
        private string name;
        private int numberOfPoints;

        //Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int NumberOfPoints
        {
            get { return this.numberOfPoints; }
            set { this.numberOfPoints = value; }
        }

        //Constructors
        public Points()
        {
        }

        public Points(string name, int numberOfPoints)
        {
            this.Name = name;
            this.NumberOfPoints = numberOfPoints;
        }
    }

    static void Main()
    {
        string command = string.Empty;
        char[,] field = CreateGameField();
        char[,] bombs = PlaceBombs();
        int counter = 0;
        bool haveExplosion = false;
        List<Points> champions = new List<Points>(6);
        int row = 0;
        int col = 0;
        bool isNewGame = true;
        const int MAX = 35;
        bool isWon = false;

        do
        {
            if (isNewGame)
            {
                Console.WriteLine("Let's play  “Minesweeper”. Try your luck and find the fields without mines." +
                " command 'top' show the standing, 'restart' start a new game, 'exit' leave the game!");
                DrawGameField(field);
                isNewGame = false;
            }

            Console.Write("Enter row and col : ");
            command = Console.ReadLine().Trim();
            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                    row <= field.GetLength(0) && col <= field.GetLength(1))
                {
                    command = "turn";
                }
            }

            switch (command)
            {
                case "top":
                    ShowStanding(champions);
                    break;
                case "restart":
                    field = CreateGameField();
                    bombs = PlaceBombs();
                    DrawGameField(field);
                    haveExplosion = false;
                    isNewGame = false;
                    break;
                case "exit":
                    Console.WriteLine("Bye, bye player !");
                    break;
                case "turn":
                    if (bombs[row, col] != '*')
                    {
                        if (bombs[row, col] == '-')
                        {
                            MakeAMove(field, bombs, row, col);
                            counter++;
                        }

                        if (MAX == counter)
                        {
                            isWon = true;
                        }
                        else
                        {
                            DrawGameField(field);
                        }
                    }
                    else
                    {
                        haveExplosion = true;
                    }

                    break;
                default:
                    Console.WriteLine("\n Error! Invalid command \n");
                    break;
            }

            if (haveExplosion)
            {
                DrawGameField(bombs);
                Console.Write("\nBoom! You blow your self! You have {0} points. " +
                    "Enter nickname: ", counter);
                string nickname = Console.ReadLine();
                Points points = new Points(nickname, counter);
                if (champions.Count < 5)
                {
                    champions.Add(points);
                }
                else
                {
                    for (int i = 0; i < champions.Count; i++)
                    {
                        if (champions[i].NumberOfPoints < points.NumberOfPoints)
                        {
                            champions.Insert(i, points);
                            champions.RemoveAt(champions.Count - 1);
                            break;
                        }
                    }
                }

                champions.Sort((Points point1, Points point2) => point2.Name.CompareTo(point1.Name));
                champions.Sort((Points point1, Points point2) => point2.NumberOfPoints.CompareTo(point1.NumberOfPoints));
                ShowStanding(champions);

                field = CreateGameField();
                bombs = PlaceBombs();
                counter = 0;
                haveExplosion = false;
                isNewGame = true;
            }

            if (isWon)
            {
                Console.WriteLine("\nWHOOPEE! You open 35 cells without any explosions.");
                DrawGameField(bombs);
                Console.WriteLine("Please enter your nickname: ");
                string nickname = Console.ReadLine();
                Points points = new Points(nickname, counter);

                champions.Add(points);
                ShowStanding(champions);
                field = CreateGameField();
                bombs = PlaceBombs();
                counter = 0;
                isWon = false;
                isNewGame = true;
            }
        }
        while (command != "exit");
        Console.WriteLine("Made in Bulgaria!");
        Console.WriteLine("Play again.");
        Console.Read();
    }

    private static void ShowStanding(List<Points> points)
    {
        Console.WriteLine("\nPoints:");
        if (points.Count > 0)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} cells",
                    i + 1, points[i].Name, points[i].NumberOfPoints);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("prazna klasaciq!\n");
        }
    }

    private static void MakeAMove(char[,] field,
        char[,] bombs, int row, int col)
    {
        char amountOfBombs = CalculateNumberOfSurroundingBombs(bombs, row, col);
        bombs[row, col] = amountOfBombs;
        field[row, col] = amountOfBombs;
    }

    private static void DrawGameField(char[,] field)
    {
        int numberOfRows = field.GetLength(0);
        int numberOfCols = field.GetLength(1);

        Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("   ---------------------");
        for (int i = 0; i < numberOfRows; i++)
        {
            Console.Write("{0} | ", i);
            for (int j = 0; j < numberOfCols; j++)
            {
                Console.Write(string.Format("{0} ", field[i, j]));
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine("   ---------------------\n");
    }

    private static char[,] CreateGameField()
    {
        int fieldRows = 5;
        int fieldColumns = 10;
        char[,] field = new char[fieldRows, fieldColumns];
        for (int i = 0; i < fieldRows; i++)
        {
            for (int j = 0; j < fieldColumns; j++)
            {
                field[i, j] = '?';
            }
        }

        return field;
    }

    private static char[,] PlaceBombs()
    {
        int rows = 5;
        int cols = 10;
        char[,] gameField = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                gameField[i, j] = '-';
            }
        }

        List<int> bombsLocation = new List<int>();
        while (bombsLocation.Count < 15)
        {
            Random random = new Random();
            int randomLocation = random.Next(50);
            if (!bombsLocation.Contains(randomLocation))
            {
                bombsLocation.Add(randomLocation);
            }
        }

        foreach (int location in bombsLocation)
        {
            int col = location / cols;
            int row = location % cols;
            if (row == 0 && location != 0)
            {
                col--;
                row = cols;
            }
            else
            {
                row++;
            }

            gameField[col, row - 1] = '*';
        }

        return gameField;
    }

    private static void PlaceNumberOfSurroundingBombs(char[,] field)
    {
        int col = field.GetLength(0);
        int row = field.GetLength(1);

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (field[i, j] != '*')
                {
                    char amountOfBombs = CalculateNumberOfSurroundingBombs(field, i, j);
                    field[i, j] = amountOfBombs;
                }
            }
        }
    }

    private static char CalculateNumberOfSurroundingBombs(char[,] bombField, int row, int col)
    {
        int amount = 0;
        int rows = bombField.GetLength(0);
        int cols = bombField.GetLength(1);

        if (row - 1 >= 0)
        {
            if (bombField[row - 1, col] == '*')
            {
                amount++;
            }
        }

        if (row + 1 < rows)
        {
            if (bombField[row + 1, col] == '*')
            {
                amount++;
            }
        }

        if (col - 1 >= 0)
        {
            if (bombField[row, col - 1] == '*')
            {
                amount++;
            }
        }

        if (col + 1 < cols)
        {
            if (bombField[row, col + 1] == '*')
            {
                amount++;
            }
        }

        if ((row - 1 >= 0) && (col - 1 >= 0))
        {
            if (bombField[row - 1, col - 1] == '*')
            {
                amount++;
            }

        }
        if ((row - 1 >= 0) && (col + 1 < cols))
        {
            if (bombField[row - 1, col + 1] == '*')
            {
                amount++;
            }
        }

        if ((row + 1 < rows) && (col - 1 >= 0))
        {
            if (bombField[row + 1, col - 1] == '*')
            {
                amount++;
            }
        }

        if ((row + 1 < rows) && (col + 1 < cols))
        {
            if (bombField[row + 1, col + 1] == '*')
            {
                amount++;
            }
        }

        return char.Parse(amount.ToString());
    }
}