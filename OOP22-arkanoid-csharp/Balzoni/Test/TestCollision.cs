using Xunit;
using Balzoni.Api;
using Balzoni.Game;
using MovingShapesImpl;
using Foschi.Game;

namespace Balzoni.Test
{
    /// <summary>
    /// BoundingBox collisions test class.
    /// </summary>
    public class TestCollision 
    {   private const double Ball_H = 10;
        private const double Pad_H = 15;
        private const double Pad_W = 50;

        private const double Pos_Pad_x = 100;
        private const double Pos_Pad_y = 100;
         [Fact]
        public void TestColl()
        {   Dimension ballD = new Dimension(Ball_H, Ball_H);
            Dimension padD = new Dimension(Pad_H, Pad_W);
            Ball ball = new Ball(ballD);
            Pad pad = new Pad(padD);
            pad.Pos = new Tuple<double, double>(Pos_Pad_x, Pos_Pad_y);
            ball.Pos = new Tuple<double, double>(pad.Pos.Item1 + Ball_H , pad.Pos.Item2 - Ball_H -1);
            CircleBoundingBox ballBox = new CircleBoundingBox(ball);
            RectBoundingBox padBox = new RectBoundingBox(pad);
            Assert.Equal(ballBox.collideWith(padBox), Side.UP_DOWN);

            ball.Pos = new Tuple<double, double>(pad.Pos.Item1 - Ball_H , pad.Pos.Item2 +1);
            CircleBoundingBox ballBox2 = new CircleBoundingBox(ball);

            Assert.Equal(ballBox2.collideWith(padBox), Side.LEFT_RIGHT);
        }
          [Fact]
        public void changeDirTest()
        {   Ball ball = new Ball(new Dimension(Ball_H, Ball_H));
            ball.Physics = new BallPhysics();
            ball.Physics.changeDirection(Side.UP_DOWN);
            Assert.Equal(ball.Physics.Dir.getDirection().Item2, 1 );
            ball.Physics.changeDirection(Side.LEFT_RIGHT);
            Assert.Equal(ball.Physics.Dir.getDirection().Item1, 1 );
        }
    }

}
    
