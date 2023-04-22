using Castiglioni.Api;
namespace Castiglioni.Game
{
    /// <summary>
    /// Abstract class of brick entity.
    /// </summary>
    public abstract class AbstractBrick : IBrick
    {
        private BrickType _type;
        private BoundingBox _box;
        private Dimension _d;
        private Tuple<double, double> _pos;
        /// <summary>
        /// Costructor of this class.
        /// </summary>
        /// <param name="type">type of brick</param>
        /// <param name="d">dimension of brick</param>
        /// <param name="pos">position of brick</param>
        public AbstractBrick(BrickType type, Dimension d, Tuple<double, double> pos)
        {
            _type = type;
            _pos = new Tuple<double, double>(pos.Item1, pos.Item2);
            _d = new DimensionImpl(d.GetHeight(), d.GetWidth());
            SetBoundingBox(new RectBoundingBox(this));

        }
        /// <inheritdoc />
        public BrickType Type => _type;
        /// <inheritdoc />
        public void ChangeType(BrickType type) => _type = type;
        /// <inheritdoc />
        public double BrickH => _d.GetHeight();
        /// <inheritdoc />
        public double BrickW => _d.GetWidth();
        /// <inheritdoc />
        public Tuple<double, double> Pos
        {
            set => _pos = value;
            get => _pos;
        }
        /// <inheritdoc />
        public BoundingBox BoundingBox
        {
            set => _box = value;
            get => _box;
        }
        /// <inheritdoc />
        public Dimension Dimension
        {
            set => _d = new DimensionImpl(value.GetHeight(), value.GetWidth());
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

        public abstract void DecreaseRes(int res);
    }
}