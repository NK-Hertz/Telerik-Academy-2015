using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingWalkInMatrix;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckForAvailableCellShouldReturnTrueWhenEmptyArrayIsPassedToIt()
        {
            var arr = new int[3, 3];
            Assert.IsTrue(MainApp.CheckForAvailableCell(arr, 0, 0));
        }

        [TestMethod]
        public void CheckForAvailableCellShouldReturnTrueWhenEmptyArrayIsPassedToItButRowIsBiggerThanArrayLength()
        {
            var arr = new int[3, 3] {{1, 0, 0}, {0, 2, 0}, {0, 0, 3} };
            Assert.IsTrue(MainApp.CheckForAvailableCell(arr, 2, 0));
        }

        [TestMethod]
        public void CheckForAvailableCellShouldReturnTrueWhenEmptyArrayIsPassedToItButColIsBiggerThanArrayLength()
        {
            var arr = new int[3, 3] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } };
            Assert.IsTrue(MainApp.CheckForAvailableCell(arr, 0, 2));
        }

        [TestMethod]
        public void CheckForAvailableCellShouldReturnFalseWhenFullArrayIsPassed()
        {
            var arr = new int[,] { { 1, 2 }, { 3, 4 } };
            Assert.IsFalse(MainApp.CheckForAvailableCell(arr, 0, 0));
        }

        [TestMethod]
        public void GetNewDirection()
        { 
        }

        [TestMethod]
        public void GetFirstAvailableCellClosestToStartPositionShouldReturnZeroForXAndYWhenEmptyArrayIsPassed()
        {
            var arr = new int[3, 3];
            var x = 0;
            var y = 0;
            MainApp.GetFirstAvailableCellClosestToStartPosition(arr, out x, out y);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void GetFirstAvailableCellClosestToStartPositionShouldReturnParticularWhatItsNameSais()
        {
            // start position is 0, 0
            var arr = new int[,] { { 1, 2 }, { 0, 0 } };
            var x = 0;
            var y = 0;
            MainApp.GetFirstAvailableCellClosestToStartPosition(arr, out x, out y);
            Assert.AreEqual(1, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void GetFirstAvailableCellClosestToStartPositionShouldChangeXAndYToZeroWhenThereIsNoAvailableCell()
        {
            var arr = new int[,] { { 1, 2 }, { 3, 4 } };
            var x = int.MaxValue;
            var y = int.MaxValue;
            MainApp.GetFirstAvailableCellClosestToStartPosition(arr, out x, out y);
            Assert.AreEqual(0, x);
            Assert.AreEqual(0, y);
        }

        [TestMethod]
        public void GetNewDirectionShouldReturnSecondDirectionWhenFirstIsPassed()
        {
            var expectedDirection = new int[] { 1, 0 };
            var direction = MainApp.GetNewDirection(1, 1);
            Assert.AreEqual(expectedDirection[0], direction[0]);
            Assert.AreEqual(expectedDirection[1], direction[1]);
        }

        [TestMethod]
        public void GetNewDirectionShouldReturnNextDirectionWhenMiddleOneIsPassed()
        {
            var expectedDirection = new int[] { -1, -1 };
            var direction = MainApp.GetNewDirection(0, -1);
            Assert.AreEqual(expectedDirection[0], direction[0]);
            Assert.AreEqual(expectedDirection[1], direction[1]);
        }

        [TestMethod]
        public void GetNewDirectionShouldReturnLastDirectionWhenPreviousIsPassed()
        {
            var expectedDirection = new int[] { 0, 1 };
            var direction = MainApp.GetNewDirection(-1, 1);
            Assert.AreEqual(expectedDirection[0], direction[0]);
            Assert.AreEqual(expectedDirection[1], direction[1]);
        }

        [TestMethod]
        public void GetNewDirectionShoudReturnFirstDirectionIfLastPositionIsPassed()
        {
            var expectedDirection = new int[] { 1, 1 };
            var direction = MainApp.GetNewDirection(0, 1);
            Assert.AreEqual(expectedDirection[0], direction[0]);
            Assert.AreEqual(expectedDirection[1], direction[1]);
        }
    }
}
