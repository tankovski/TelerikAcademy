using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPosiblePath
{
    class FindPosiblePath
    {
        static char[,] lab = new char[100,100];
        
        static List<char> path = new List<char>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                return;
            }


            if (lab[row, col] == 'e')
            {
                Console.WriteLine("Find the exit");
            }

            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';

                FindPathToExit(row, col - 1);
                FindPathToExit(row - 1, col);
                FindPathToExit(row, col + 1);
                FindPathToExit(row + 1, col);

            }
        }

        static void Main()
        {
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int l = 0; l < lab.GetLength(1); l++)
                {
                    lab[i, l] = ' ';
                }
            }
            lab[99, 99] = 'e';
            FindPathToExit(0, 0);
        }
    }
}
