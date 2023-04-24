using Balzoni.Api;

namespace  Balzoni.Game
{
    public class BallPhysics : IPhysics
    {
        private IDirection _d;
        private bool _centre = false;
        private Tuple<double, double> _temp;

        public BallPhysics()
        {
            // this.temp = d.getDirection();
        }

        IDirection IPhysics.getDir => throw new NotImplementedException();

        /// <inheritdoc />
        public void changeDirection(Side side)
        {
           /* this.d.setDirection(temp);
             if (centre) 
             {
                 d.setDirectionUp();
                centre = false;
             }
             if (side.equals(Side.CORNER)) {
            if (this.d.isDirectionLeft()) {
             this.d.setDirectionRight();
            } else {
             this.d.setDirectionLeft();
            } 

            if (this.d.isDirectionUp()) {
             this.d.setDirectionDown();
             } else {
             this.d.setDirectionUp();
            }
             temp = d.getDirection();
            } else if (side.equals(Side.LEFT_RIGHT)) {
            if (this.d.isDirectionLeft()) {
             this.d.setDirectionRight();
             } else {
             this.d.setDirectionLeft();
            }
            temp = d.getDirection();

             } else if (side.equals(Side.UP_DOWN)) {
             if (this.d.isDirectionUp()) {
             this.d.setDirectionDown();
             } else {
               this.d.setDirectionUp();
             }
      temp = d.getDirection();
    } else {
      centre = true;
      d.setCentre();
    }*/

        }
         /// <inheritdoc />
         public IDirection getDir() 
        {
           IDirection dir = _d;
             /*dir.setDirection(this.d.getDirection());*/
            return dir;
         }
    
   }
}