using Foschi.Api;

namespace Foschi.Game {

    /// <summary>
    /// Class that manages objects' speed.
    /// </summary>
    public class Speed : ISpeed
    {
        private double _x;
        private double _y;
        private readonly double EPSILON=0.00000001;

        /// <inheritdoc />
        public double X => _x;

        /// <inheritdoc />
        public double Y => _y;

        /// <summary>
        /// Costructor of this class.
        /// </summary>
        /// <param name="valX">X coordinate</param>
        /// <param name="valY">Y coordinate</param>
        public Speed(double valX, double valY)
        {
            _x=valX;
            _y=valY;
        }

        /// <inheritdoc />
        public void sum(ISpeed vel)
        {
            _x=_x+vel.X;
            _y=_y+vel.Y;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is ISpeed vel &&
                Math.Abs(_x-vel.X)<EPSILON &&
                Math.Abs(_y-vel.Y)<EPSILON;
        }

        /// <inheritdoc />
        public override int GetHashCode() => HashCode.Combine(_x,_y);

        /// <inheritdoc />
        public override string ToString() => "["+_x+","+_y+"]";
    }
}