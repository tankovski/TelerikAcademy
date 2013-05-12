using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WalkInMatrix.Tests
{
    [TestClass]
    public class MatrixInitialiserTests
    {
        [TestMethod]
        public void TestCreateMatrixInitialiser()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChangeDirectionsWithWrongVerticalStep()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int horizontalStep = 1;
            int verticalStep = -5;

            matrixInitialiser.ChangeDirection(ref horizontalStep, ref verticalStep);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestChangeDirectionsWithWrongHorizontalStep()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int horizontalStep = 6;
            int verticalStep = 1;

            matrixInitialiser.ChangeDirection(ref horizontalStep, ref verticalStep);
        }

        [TestMethod]
        public void TestChangeDirectionsWithCorectSteps()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int horizontalStep = 1;
            int verticalStep = 1;
            int expectedHorizontalstep = 1;
            int expectedVerticalStep = 0;

            matrixInitialiser.ChangeDirection(ref horizontalStep, ref verticalStep);

            Assert.AreEqual(expectedHorizontalstep, horizontalStep);
            Assert.AreEqual(expectedVerticalStep, verticalStep);
        }

        [TestMethod]
        public void TestValidDirectionWithPosibleDirection()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int[,] matrix = 
            {
                {0,0,0},
                {1,2,3},
                {6,5,4}
            };
            int startRow = 0;
            int startCol = 0;

            bool expeceted = true;
            bool actual = matrixInitialiser.CheckForValidDirection(matrix, startRow, startCol);

            Assert.AreEqual(expeceted, actual);
        }

        [TestMethod]
        public void TestValidDirectionWithoutPosibleDirection()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int[,] matrix = 
            {
                {3,5,6},
                {1,2,3},
                {6,5,4}
            };
            int startRow = 0;
            int startCol = 0;

            bool expeceted = false;
            bool actual = matrixInitialiser.CheckForValidDirection(matrix, startRow, startCol);

            Assert.AreEqual(expeceted, actual);
        }

        [TestMethod]
        public void TesFindNewCellToStartWithPosibleEmptyCell()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int[,] matrix = 
            {
                {3,5,6},
                {0,2,3},
                {6,0,4}
            };
            int currentRow = 0;
            int currentCol = 0;
            int expectedRow = 1;
            int expectedCol = 0;

            matrixInitialiser.FindNewCellToStartMoving(matrix, out currentRow, out currentCol);

            Assert.AreEqual(expectedRow, currentRow);
            Assert.AreEqual(expectedCol, currentCol);
        }

        [TestMethod]
        public void TesFindNewCellToStartWithouthPosibleEmptyCell()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();
            int[,] matrix = 
            {
                {3,5,6},
                {1,2,3},
                {6,7,4}
            };
            int currentRow = 0;
            int currentCol = 0;
            int expectedRow = -1;
            int expectedCol = -1;

            matrixInitialiser.FindNewCellToStartMoving(matrix, out currentRow, out currentCol);

            Assert.AreEqual(expectedRow, currentRow);
            Assert.AreEqual(expectedCol, currentCol);
        }

        [TestMethod]
        public void TesInitialiseMatrixWhilePosible()
        {
            MatrixInitialiser matrixInitialiser = new MatrixInitialiser();

            int[,] matrix = 
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            int[,] expectedMatrix = 
            {
                {1, 7, 8},
                {6, 2, 9},
                {5, 4, 3}
            };
            int row = 0;
            int col = 0;
            int verticalStep = 1;
            int horizontalStep = 1;
            int number = 1;

            matrixInitialiser.InitializeMatrixWhilePosible(matrix, ref number, ref row, ref col, ref horizontalStep, ref verticalStep);

            for (int i = 0; i < expectedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < expectedMatrix.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedMatrix[i, j], matrix[i, j]);
                }
            }

        }


    }
}
