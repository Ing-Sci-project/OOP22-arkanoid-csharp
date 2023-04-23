using Xunit;
using Castiglioni.Game;
using Castiglioni.Api;
namespace Castiglioni.Test
{
    /// <summary>
    /// NormalBrick test class.
    /// </summary>
    public class TestNormalBrick
    {
        private const double X = 12.0;
        private const double Y = 4.0;
        private const int ResNormal = 1;
        private const int ResHard = 2;
        /// <summary>
        /// test the resistence of the bricks and their type. 
        /// </summary>
        [Fact]
        public void Test()
        {
            IBrick brickNormal = new NormalBrick(BrickType.NORMAL, new Foschi.Game.Dimension(X, Y), new Tuple<double, double>(X, Y), ResNormal);
            Assert.Equal(BrickType.NORMAL, brickNormal.Type);
            Assert.Equal(ResNormal, brickNormal.GetRes());
            brickNormal.Hit();
            Assert.Equal(0, brickNormal.GetRes());
            IBrick brickHard = new NormalBrick(BrickType.NORMAL, new Foschi.Game.Dimension(X, Y), new Tuple<double, double>(X, Y), ResHard);
            Assert.Equal(BrickType.NORMAL, brickHard.Type);
            Assert.Equal(ResHard, brickHard.GetRes());
            brickHard.Hit();
            Assert.Equal(ResNormal, brickHard.GetRes());
            brickHard.Hit();
            Assert.Equal(0, brickHard.GetRes());
        }

    }
}