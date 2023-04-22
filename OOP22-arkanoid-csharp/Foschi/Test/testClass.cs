using Xunit;
using Foschi.Api;
using Foschi.Game;
using Castiglioni.Api;

namespace Foschi.Test{

    /// <summary>
    /// Test class.
    /// </summary>
    public class testClass {

        private readonly double X = 12.0;
        private readonly double Y = 4.0;
        private readonly double INC_X = 0.43;
        private readonly double INC_Y = 0.43;
        private  Random random = new Random();

        /// <summary>
        /// Test of class Speed.
        /// </summary>
        [Fact]
        public void testSpeed(){
            ISpeed speed = new Speed(X,Y);
            ISpeed speed2 = new Speed(speed.X,speed.Y);
            Assert.True(speed.X == X && speed.Y == Y);
            for(int i=0; i<20; i++) {
                speed.sum(new Speed(INC_X,INC_Y));
            }
            speed2.sum(new Speed(20*INC_X,20*INC_Y));
            Assert.Equal(speed,speed2);
        }

        /// <summary>
        /// Test of class Dimension.
        /// </summary>
        [Fact]
        public void testDimension(){
            Dimension dim = new Dimension(X,Y);
            Assert.Equal(dim.Height,X);
            Assert.Equal(dim.Width,Y);
            dim.IncreaseWidth(INC_Y);
            Assert.Equal(dim.Width,Y+INC_Y);
        }

        /// <summary>
        ///Test of class Obstacle.
        /// </summary>
        [Fact]
        public void testObstacle(){
            IBrick b = new Obstacle(BrickType.OBSTACLE, new Dimension(X,Y), new Tuple<double, double>(X,Y));
            Assert.False(b.GetRes().HasValue);
            for (int i=0; i<100000; i++) {
                b.Hit();
            }
            Assert.True(!b.IsDestroyed());
        }

        /// <summary>
        /// Test of class LeaderBoard.
        /// </summary>
        [Fact]
        public void testLeaderBoard(){
            ILeaderBoard l = new LeaderBoard();
            string name=RandomString();
            string password=RandomString();
            bool trovato = true;
            while(trovato) {
                if(!l.GetPoints(name,password).HasValue) {
                    trovato=false;
                } else {
                    name=RandomString();
                    password=RandomString();
                }
            }
            Assert.True(!l.GetPoints(name,password).HasValue);
            l.UpdatePoints(name,password,30,1);
            Assert.True(l.GetPoints(name,password).HasValue && l.GetPoints(name,password) == 30);
            l.UpdatePoints(name,password,10,2);
            Assert.True(l.GetPoints(name,password) == 40);
            l.UpdatePoints(name,password,10,1);
            Assert.True(l.GetPoints(name,password) == 20);
            l.UpdatePoints(name,password,80,3);
            Assert.True(l.GetPoints(name,password) == 100);
            l.UpdatePoints(name,password,60,2);
            Assert.True(l.GetPoints(name,password) == 150);
            l.UpdatePoints(name,password,20,1);
            Assert.True(l.GetPoints(name,password) == 160);
        }

        /// <summary>
        /// method to get a random string.
        /// </summary>
        /// <returns> a random string</returns>
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}