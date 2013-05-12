using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MatrixInitialiser
{   

    public void ChangeDirection(ref int horizontalStep, ref int vericalStep)
    {
        if (horizontalStep<-1 || horizontalStep>1 || vericalStep<-1 || vericalStep>1)
        {
            throw new ArgumentOutOfRangeException("Step must be only one field at a time(between -1 an 1)!");
        }

        //Our initialiser works with all directions but only one field at a time
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        int curentDrirectionIndex = 0;

        //Find current direction
        for (int index = 0; index < directionsX.Length; index++)
        {
            if (directionsX[index] == horizontalStep && directionsY[index] == vericalStep)
            {
                curentDrirectionIndex = index;
                break;
            }
        }

        //Change current direction
        if (curentDrirectionIndex == 7)
        {
            horizontalStep = directionsX[0];
            vericalStep = directionsY[0];
            return;
        }
        else
        {
            horizontalStep = directionsX[curentDrirectionIndex + 1];
            vericalStep = directionsY[curentDrirectionIndex + 1];
        }

    }
    public bool CheckForValidDirection(int[,] matrix, int row, int col)
    {
        
        //Our initialiser works with all directions but only one field at a time
        int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        //Mark posible directions
        for (int i = 0; i < directionsX.Length; i++)
        {
            if (row + directionsX[i] >= matrix.GetLength(0) || row + directionsX[i] < 0)
            {
                directionsX[i] = 0;
            }

            if (col + directionsY[i] >= matrix.GetLength(1) || col + directionsY[i] < 0)
            {
                directionsY[i] = 0;
            }
        }

        //Check for in the derections array for marked directions
        for (int index = 0; index < directionsX.Length; index++)
        {
            if (matrix[row + directionsX[index], col + directionsY[index]] == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void FindNewCellToStartMoving(int[,] matrix, out int CurrentRow, out int CurrentCol)
    {
        CurrentRow = -1;
        CurrentCol = -1;

        //Check for the first posible empty cell(marked with 0), and return -1 if there is no such
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if (matrix[row, col] == 0)
                {
                    CurrentRow = row;
                    CurrentCol = col;
                    return;
                }
            }
        }
    }

    public void InitializeMatrixWhilePosible(int[,] matrix, ref int number, ref int row, ref int col, ref int horizontalStep, ref int vericalStep)
    {
        int matrixLength = matrix.GetLength(0);
        bool isValidDirection = true ;
        while (isValidDirection)
        {
            matrix[row, col] = number;
            isValidDirection = CheckForValidDirection(matrix, row, col);
            if (isValidDirection)
            {
                //Check if the next field is marked for empty(with zero), ot its out of the matrix bounds and if not change direction
                if (row + horizontalStep >= matrixLength || row + horizontalStep < 0 || col + vericalStep >= matrixLength ||
                    col + vericalStep < 0 || matrix[row + horizontalStep, col + vericalStep] != 0)
                {
                    while ((row + horizontalStep >= matrixLength || row + horizontalStep < 0 || col + vericalStep >= matrixLength ||
                        col + vericalStep < 0 || matrix[row + horizontalStep, col + vericalStep] != 0))
                    {
                        ChangeDirection(ref horizontalStep, ref vericalStep);
                    }
                }

                row += horizontalStep;
                col += vericalStep;
                number++;
            }   
        }       
    }
}
