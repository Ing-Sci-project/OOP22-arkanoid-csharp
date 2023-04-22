using Xunit;
using Castiglioni.Game;
using Castiglioni.Api;
namespace Castiglioni.Test
{
    public class TestNormalBrick
    {
        private const double X = 12.0;
        private const double Y = 4.0;
        private const int ResNormal = 1;
        private const int ResHard = 2;
        [Fact]
        public void TestType()
        {
            IBrick brickNormal = new NormalBrick(BrickType.NORMAL, new Foschi.Game.Dimension(X, Y), new Tuple<double, double>(X, Y), ResNormal);
            Assert.Equal(BrickType.NORMAL, brickNormal.Type);
            Assert.Equal(ResNormal, brickNormal.GetRes().Value);
            brickNormal.Hit();
            Assert.Equal(0, brickNormal.GetRes().Value);
            IBrick brickHard = new NormalBrick(BrickType.NORMAL, new Foschi.Game.Dimension(X, Y), new Tuple<double, double>(X, Y), ResHard);
            Assert.Equal(BrickType.NORMAL, brickHard.Type);
            Assert.Equal(ResNormal, brickHard.GetRes().Value);
            brickHard.Hit();
            Assert.Equal(1, brickHard.GetRes().Value);
            brickHard.Hit();
            Assert.Equal(0, brickHard.GetRes().Value);
        }

    }
}