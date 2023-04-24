using Balzoni.Api;
using Shapes;
namespace  Balzoni.Game
{
    public class CircleBoundingBox : AbstractBoundingBox
    {
        public CircleBoundingBox(IMovingObject obj) : base(obj.Dimension.Width, obj.Dimension.Height, obj.Pos)
        {

        }
    }
}