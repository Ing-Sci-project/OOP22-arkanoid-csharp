using Balzoni.Api;
namespace  Balzoni.Game
{
    public class CircleBoundingBox : AbstractBoundingBox
    {
        public CircleBoundingBox(IMovingObject obj) : base(obj.getDimension().getWidth(), obj.getDimension().getHeight(), obj.getPos())
        {

        }
    }
}