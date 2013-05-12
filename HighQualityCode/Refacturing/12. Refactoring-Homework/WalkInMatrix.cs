using System;

class WalkInMatrix
{

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive number ");
        string input = Console.ReadLine();
        int matrixLength = 0;

        while (!int.TryParse(input, out matrixLength) || matrixLength < 0 || matrixLength > 100)
        {
            Console.WriteLine("You haven't entered a correct positive number");
            input = Console.ReadLine();
        }

        Matrix matrix = new Matrix(matrixLength);
        MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
        int number = 1;
        int row = 0;
        int col = 0;
        int horizontalStep = 1;
        int vericalStep = 1;

        matrixInitialiser.InitializeMatrixWhilePosible(matrix.Body, ref number, ref row, ref col,
            ref horizontalStep, ref vericalStep);

        //matrixInitialiser.FindNewCellToStartMoving(matrix.Body, out row, out col);

        //if (row != -1 && col != -1)
        //{
        //    horizontalStep = 1;
        //    vericalStep = 1;
        //    matrixInitialiser.InitializeMatrixWhilePosible(matrix.Body, ref number, ref row,
        //        ref col, ref horizontalStep, ref vericalStep);
        //}

        for (int matrixRow = 0; matrixRow < matrixLength; matrixRow++)
        {
            for (int matrixCol = 0; matrixCol < matrixLength; matrixCol++)
            {
                Console.Write("{0,3}", matrix.Body[matrixRow, matrixCol]);
            }

            Console.WriteLine();
        }
    }
}
