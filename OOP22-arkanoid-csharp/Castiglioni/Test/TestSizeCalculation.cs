using Xunit;
using Castiglioni.Api;
using Castiglioni.Game;
namespace Castiglioni.Test
{
    public class TestSizeCalculation
    {
        private const double Stop1 = (400 / 2) / 3;
        private const double Stop2 = ((400 / 2) / 3) * 1.5;
        private const double Stop3 = ((400 / 2) / 3) * 1.75;
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
    }
}