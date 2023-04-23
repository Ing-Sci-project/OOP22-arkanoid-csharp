using Xunit;
using Castiglioni.Game;
namespace Castiglioni.Test
{
    /// <summary>
    /// SizeCalculation test class.
    /// </summary>
    public class TestSizeCalculation
    {
        private const int Stop1 = 66;
        private const int Stop2 = 100;
        private const int Stop3 = 116;
        private const int StartX = 33;
        private const int StartY = 10;
        private const int BrickL = 20;
        private const int BrickH = (int)(Stop1 - StartX) / 4;
        /// <summary>
        /// test the StopX method.
        /// </summary>
        [Fact]
        public void TestStopX()
        {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(Stop1, (int)sizeCalculation.GetStop().Item1);
            SizeCalculation sizeCalculation2 = new SizeCalculation(6, 15);
            Assert.Equal(Stop2, (int)sizeCalculation2.GetStop().Item1);
            SizeCalculation sizeCalculation3 = new SizeCalculation(7, 15);
            Assert.Equal(Stop3, (int)sizeCalculation3.GetStop().Item1);
        }
        /// <summary>
        /// test the Start method.
        /// </summary>
        [Fact]
        public void TestStart()
        {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(StartX, (int)sizeCalculation.GetStart().Item1);
            Assert.Equal(StartY, (int)sizeCalculation.GetStart().Item2);
        }
        /// <summary>
        /// test the dimension of brick.
        /// </summary>
        [Fact]
        public void TestBrickDim()
        {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(BrickH, (int)sizeCalculation.GetBrickDim().Item1);
            Assert.Equal(BrickL, (int)sizeCalculation.GetBrickDim().Item2);
        }
    }
}