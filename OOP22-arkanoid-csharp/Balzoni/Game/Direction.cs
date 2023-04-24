using Balzoni.Api;

namespace  Balzoni.Game
{
    public class Direction : IDirection
    {   private const int Starter_Y = 2;
        private const int Left = -1;
        private const int Right = 1;
        private const int Up = -1;
        private const int Down = 1;
        private Tuple<int ,int > _d;
        public Direction(){
             _d = new Tuple<int, int>(Left, Up);
        }
         /// <inheritdoc />
        public Tuple<int, int> getDirection() => _d;
        /// <inheritdoc />
        public bool isDirectionLeft() => (_d.Item1 == Left);
        /// <inheritdoc />
        public bool isDirectionRight() => (_d.Item1 == Right);
         /// <inheritdoc />
        public bool isDirectionUp() => (_d.Item2 == Up);
         /// <inheritdoc />
        public void resetDirection()
        {
             _d = new Tuple<int, int>(Left, Up);
        }
        /// <inheritdoc />
        public void setCentre()
        {
             _d = new Tuple<int, int>(0, Up);
        }
         /// <inheritdoc />
        public void setDirection(Tuple<int, int> new_D)
        {
            _d= new_D;
        }
         /// <inheritdoc />
        public void setDirectionDown()
        {
             _d = new Tuple<int, int>(_d.Item1, Down);
        }
         /// <inheritdoc />
        public void setDirectionLeft()
        {
             _d = new Tuple<int, int>(Left, _d.Item2);
        }
         /// <inheritdoc />
        public void setDirectionRight()
        {
             _d = new Tuple<int, int>(Right, _d.Item2);
        }
         /// <inheritdoc />
        public void setDirectionUp()
        {
             _d = new Tuple<int, int>(_d.Item1, Up);
        }
    }
}