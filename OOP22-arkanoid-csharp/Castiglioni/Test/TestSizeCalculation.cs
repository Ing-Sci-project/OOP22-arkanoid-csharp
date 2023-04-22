using Xunit;
using Castiglioni.Game;
namespace Castiglioni.Test
{
    public class TestSizeCalculation
    {
        private const double Stop1 = (400 / 2) / 3;
        private const double Stop2 = ((400 / 2) / 3) * 1.5;
        private const double Stop3 = ((400 / 2) / 3) * 1.75;
        private const double StartX = ((400 / 2) / 6);
        private const double StartY = (300 / 15) / 2;
        private const double BrickL = 300 / 15;
        private const double BrickH = (Stop1 - StartX) / 4;
        [Fact]
        public void TestStopX()
        {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(Stop1, sizeCalculation.GetStop().Item1);
            SizeCalculation sizeCalculation2 = new SizeCalculation(6, 15);
            Assert.Equal(Stop2, sizeCalculation2.GetStop().Item1);
            SizeCalculation sizeCalculation3 = new SizeCalculation(7, 15);
            Assert.Equal(Stop3, sizeCalculation3.GetStop().Item1);
        }
        [Fact]
        public void TestStart()
        {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(StartX, sizeCalculation.GetStart().Item1);
            Assert.Equal(StartY, sizeCalculation.GetStart().Item2);
        }

        [Fact]
        public void TestBrickDim() {
            SizeCalculation sizeCalculation = new SizeCalculation(4, 15);
            Assert.Equal(BrickH, sizeCalculation.GetBrickDim().Item1);
            Assert.Equal(BrickL, sizeCalculation.GetBrickDim().Item2);
        }
    }
}