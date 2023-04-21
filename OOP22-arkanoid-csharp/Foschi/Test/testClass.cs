using Xunit;
using Foschi.Api;
using Foschi.Game;

namespace Foschi.Test{

    public class testClass {

        private readonly double X = 12.0;
        private readonly double Y = 4.0;
        private readonly double INC_X = 0.43;
        private readonly double INC_Y = 0.43;

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
    }
}