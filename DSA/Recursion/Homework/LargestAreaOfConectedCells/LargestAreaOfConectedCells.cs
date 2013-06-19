using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaOfConectedCells
{
    class LargestAreaOfConectedCells
    {
        static int[,] matrix = { 
                               { 1, 3, 2, 2, 2, 4 },
                               { 3, 3, 3, 2, 4, 4 },
                               { 4, 3, 1, 2, 3, 3 },
                               { 4, 3, 1, 3, 3, 1 },
                               { 4, 3, 3, 3, 1, 1 } };
        static int currentCellNumber;
        static int mosteOftenNumber;
        static int sum=0;
        static int maxSum=0;
        static bool[,] visitedCells = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
             bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindLongestArea(int row,int col)
        {
            if (!InRange(row,col) || matrix[row,col]!=currentCellNumber || visitedCells[row,col]==true)
            {
                return;
            }

            sum += 1;
            visitedCells[row, col] = true;
            currentCellNumber = matrix[row, col];
            if (sum>maxSum)
            {
                maxSum = sum;
                mosteOftenNumber = currentCellNumber;
            }

            if (matrix[row,col]==currentCellNumber || visitedCells[row,col]==false)
            {
                FindLongestArea(row, col - 1);
                FindLongestArea(row - 1, col);
                FindLongestArea(row, col + 1);
                FindLongestArea(row + 1, col);

                visitedCells[row, col] = false;
            }


        }

        static void Main()
        {
            for (int i = 0; i < visitedCells.GetLength(0) ; i++)
            {
                for (int l = 0; l < visitedCells.GetLength(1); l++)
                {
                    visitedCells[i, l] = false;
                }
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int l = 0; l < matrix.GetLength(1); l++)
                {
                    if (visitedCells[i,l]==false)
                    {
                        currentCellNumber = matrix[i, l];
                        FindLongestArea(i, l);
                        sum = 0;
                    }
                }
            }

            Console.WriteLine("The largest area of conected cells is {0} times the number {1}.",maxSum,mosteOftenNumber);
        }
    }
}
