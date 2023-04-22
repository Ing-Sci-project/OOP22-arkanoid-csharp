using Castiglioni.Api;
using Castiglioni.Game;

namespace Foschi.Game {

    /// <summary>
    /// class of obstacles that are objects that can't be destroyed.
    /// </summary>
    public class Obstacle : AbstractBrick
    {
        /// <summary>
        /// costructor of this class.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="d"></param>
        /// <param name="pos"></param>
        public Obstacle(BrickType type, Dimension d, Tuple<double, double> pos) : base(type, d, pos) {}

        /// <inheritdoc />
        public override void DecreaseRes(int res) {}

        /// <inheritdoc />
        public override int? GetRes() => null;

        /// <inheritdoc />
        public override void Hit() {}

        /// <inheritdoc />
        public override void IncreaseRes(int res) {}

        /// <inheritdoc />
        public override bool IsDestroyed() => false;
    }
}