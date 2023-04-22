using Castiglioni.Api;
using Foschi.Game;

namespace Castiglioni.Game
{
    /// <summary>
    /// class of normal and hard bricks.
    /// </summary>
    public class NormalBrick : AbstractBrick
    {
        private int _brickResistence;
        /// <summary>
        /// costructor of this class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="d"></param>
        /// <param name="pos"></param>
        /// <param name="resistence">resistence of the brick</param>
        public NormalBrick(BrickType type, Dimension d, Tuple<double, double> pos, int resistence) : base(type, d, pos)
        {
            _brickResistence = resistence;
        }
        /// <inheritdoc />
        public override int? GetRes() => _brickResistence;
        /// <inheritdoc />
        public override void Hit() => --_brickResistence;
        /// <inheritdoc />
        public override bool IsDestroyed() => _brickResistence == 0;
        /// <inheritdoc />
        public override void IncreaseRes(int res) => _brickResistence = res + 1;
        /// <inheritdoc />
        public override void DecreaseRes(int res) => _brickResistence = res - 1;
    }
}