using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WalkInMatrix.Tests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void TestCreateMatrix()
        {
            Matrix matrix = new Matrix(6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateMatrixithNegativeLenhth()
        {
            Matrix matrix = new Matrix(-6);
        }

        [TestMethod]
        public void TestMatrixToString()
        {
            Matrix matrix = new Matrix(3);

            string expected = "0 0 0\n0 0 0\n0 0 0\n";
            string actual = matrix.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
