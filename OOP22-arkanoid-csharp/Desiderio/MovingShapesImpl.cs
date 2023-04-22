using Shapes;
using Foschi.Game;
namespace MovingShapesImpl
{
    ///part common to any moving obj. 
    public abstract class AbstractMovingObject : IMovingObject
    {
        private Tuple<double, double> _pos;
        private BoundingBox _box;
        private Speed _speed;
        private Dimension _d;
        private Physics _pysic;

        /// <summary>
        /// Constructors accept position and dimension of moving obj.
        /// </summary>
        /// <param name="pos">The position of the object.</param>
        /// <param name="d">The dimension of the object.</param>
        public AbstractMovingObject(readonly Tuple<double, double> pos, readonly Dimension d)
        {
            _pos = Tuple.Create(pos.Item1, pos.Item2);
            _d = new DimensionImpl(d.Height, d.Width);
            _speed = new Speed(3, 3);
        }


        public Tuple<double, double> Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public BoundingBox BoundingBox
        {
            get { return _box; }
            set { _box = value; }
        }

        public Speed Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        public Dimension Dimension
        {
            get { return _d; }
            set { _d = value; }
        }

        public Physics Physics
        {
            get { return _pysic; }
            set { return _pysic = value; }
        }
    }

    /// <summary>
    /// Ball is a moving object.
    /// </summary>
    public class Ball : AbstractMovingObject
    {

        private static readonly int TOLLERANCE = 5;

        /// <summary>
        /// Set the dimension of the ball.
        /// </summary>
        /// <param name="d">The dimension of the ball.</param>
        public Ball(Dimension d) : base(
            new Tuple<double, double>(
                SizeCalculation.getWorldSize().Y / 2 - d.Width / 2,
                (SizeCalculation.getWorldSize().X - 100) - (2 * d.Height) - TOLLERANCE
            ),
            d
        )
        {
            base.Speed = new Speed(4, 3);
            base.Physics = new BallPhysicsImpl();
            base.BoundingBox = new CircleBoundingBox(this);
        }

    }

    /// <summary>
    /// Pad is a moving object.
    /// </summary>
    public class Pad : AbstractMovingObject
    {

        /// <summary>
        /// Set the dimension of the pad.
        /// </summary>
        /// <param name="d">The dimension of the pad.</param>
        public Pad(Dimension d) : base(
            new Tuple<double, double>(
                SizeCalculation.getWorldSize().Y / 2 - d.Width / 2,
                SizeCalculation.getWorldSize().X - 100
            ),
            d
        )
        {
            base.BoundingBox = new RectBoundingBox(this);
            base.Speed = new Speed(10, 0);
        }

    }
}
