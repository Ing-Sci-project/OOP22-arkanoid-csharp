using Castiglioni.Api;
using Castiglioni.Game;

namespace Foschi.Game {
    public class Obstacle : AbstractBrick
    {
        public Obstacle(BrickType type, Dimension d, Tuple<double, double> pos) : base(type, d, pos){}

        public override void DecreaseRes(int res) {}

        public override int? GetRes() => null;

        public override void Hit() {}

        public override void IncreaseRes(int res) {}

        public override bool IsDestroyed() => false;
    }
}