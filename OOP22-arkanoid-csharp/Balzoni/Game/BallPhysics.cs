using Balzoni.Api;

namespace  Balzoni.Game
{
    public class BallPhysics : IPhysics
    {
        private IDirection _d;
        private bool _centre = false;
        private Tuple<int, int> _temp;

        public BallPhysics()
        {
            _temp = _d.getDirection();
        }
        /// <inheritdoc />
        IDirection IPhysics.getDir => _d;

        /// <inheritdoc />
        public void changeDirection(Side side)
        { _d.setDirection(_temp);
          if(_centre)
          {
            _d.setDirectionUp();
            _centre=false;
          }
          if(side.Equals(Side.CORNER))
          {
            if(_d.isDirectionLeft())
            {
              _d.setDirectionRight();
            }
            else
            {
              _d.setDirectionLeft();
            }
            if (_d.isDirectionUp()) 
            {
                _d.setDirectionDown();
            } 
            else 
            {
               _d.setDirectionUp();
            }
            _temp =_d.getDirection();
          }
          else
          {
            if(side.Equals(Side.LEFT_RIGHT))
            {
               if (_d.isDirectionLeft()) 
               {
                  _d.setDirectionRight();
               } 
               else 
               {
                  _d.setDirectionLeft();
                }

              _temp = _d.getDirection();
            }
            else
           {
             if (side.Equals(Side.UP_DOWN)) 
              {
                if (_d.isDirectionUp()) 
                {
                  _d.setDirectionDown();
                }
                else 
                {
                  _d.setDirectionUp();
                }
                _temp = _d.getDirection();
              }
              else 
              {
                _centre = true;
               _d.setCentre();
               }
          }

        }
    
   }
 }
}
