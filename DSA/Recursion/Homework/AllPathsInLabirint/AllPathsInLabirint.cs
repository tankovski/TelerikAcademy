using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPathsInLabirint
{
    class AllPathsInLabirint
    {

        static char[,] lab = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        static List<char> path = new List<char>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void PrintPath(List<char> path)
        {
            Console.Write("Found path to the exit: ");
            foreach (var dir in path)
            {
                Console.Write(dir);
            }
            Console.WriteLine();
        }

        static void FindPathToExit(int row, int col, char direction)
        {
            if (! InRange(row,col))
            {
                return;
            }

            path.Add(direction);

            if (lab[row,col]=='e')
            {
                PrintPath(path);
            }

            if (lab[row,col]==' ')
            {
                lab[row, col] = 's';

                FindPathToExit(row, col - 1, 'L'); 
                FindPathToExit(row - 1, col, 'U'); 
                FindPathToExit(row, col + 1, 'R'); 
                FindPathToExit(row + 1, col, 'D');

                lab[row, col] = ' ';
            }

            path.RemoveAt(path.Count - 1);
        }

        static void Main()
        {
            FindPathToExit(0, 0, 'S');
        }
    }
}
