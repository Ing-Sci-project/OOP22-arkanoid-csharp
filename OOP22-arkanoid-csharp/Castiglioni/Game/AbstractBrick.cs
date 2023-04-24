using Castiglioni.Api;
using Foschi.Game;
using OOP22_arkanoid_csharp.Desiderio.Api;
using Shapes;

namespace Castiglioni.Game
{
    /// <summary>
    /// Abstract class of brick entity.
    /// </summary>
    public abstract class AbstractBrick : IBrick
    {
        private BrickType _type;
        //private BoundingBox _box;
        private IDimension _d;
        private Tuple<double, double> _pos;
        /// <summary>
        /// Costructor of this class.
        /// </summary>
        /// <param name="type">type of brick</param>
        /// <param name="d">dimension of brick</param>
        /// <param name="pos">position of brick</param>
        public AbstractBrick(BrickType type, IDimension d, Tuple<double, double> pos)
        {
            _type = type;
            _pos = new Tuple<double, double>(pos.Item1, pos.Item2);
            _d = new Dimension(d.Height, d.Width);
            //SetBoundingBox(new RectBoundingBox(this));

        }
        /// <inheritdoc />
        public BrickType Type => _type;
        /// <inheritdoc />
        public void ChangeType(BrickType type) => _type = type;
        /// <inheritdoc />
        public double BrickH => _d.Height;
        /// <inheritdoc />
        public double BrickW => _d.Width;
        /// <inheritdoc />
        public Tuple<double, double> Pos
        {
            set => _pos = value;
            get => _pos;
        }

        /// <inheritdoc />
        /*
        public IBoundingBox BoundingBox
        {
            get => _box;
            set =>  _box = value;
        }*/
        /// <inheritdoc />
        public IDimension Dimension
        {
            set => _d = new Dimension(value.Height, value.Width);
            get => _d;
        }

        /// <inheritdoc />
        public abstract bool IsDestroyed();
        /// <inheritdoc />
        public abstract void Hit();
        /// <inheritdoc />
        public abstract int? GetRes();
        /// <inheritdoc />
        public abstract void IncreaseRes(int res);
        /// <inheritdoc />
        public abstract void DecreaseRes(int res);
    }
}