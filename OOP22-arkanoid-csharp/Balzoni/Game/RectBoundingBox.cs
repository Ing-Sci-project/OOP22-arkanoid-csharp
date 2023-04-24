using Balzoni.Api;
namespace  Balzoni.Game
{
    public class RectBoundingBox : AbstractBoundingBox
    {
        public RectBoundingBox(IGameObject obj) : base(obj.getDimension().getWidth(), obj.getDimension().getHeight(), obj.getPos())
        {

        }
    }
}