using Foschi.Api;

namespace Foschi.Game {

    public class Speed : ISpeed
    {
        private double _x;
        private double _y;
        private readonly double EPSILON=0.00000001;

        public double X => _x;

        public double Y => _y;

        public Speed(double valX, double valY)
        {
            _x=valX;
            _y=valY;
        }

        public void sum(ISpeed vel)
        {
            _x=_x+vel.X;
            _y=_y+vel.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is ISpeed vel &&
                Math.Abs(_x-vel.X)<EPSILON &&
                Math.Abs(_y-vel.Y)<EPSILON;
        }

        public override int GetHashCode() => HashCode.Combine(_x,_y);

        public override string ToString() => "["+_x+","+_y+"]";
    }
}