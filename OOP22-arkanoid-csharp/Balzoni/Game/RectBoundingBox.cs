using Balzoni.Api;
using Shapes;
namespace  Balzoni.Game
{
    public class RectBoundingBox : AbstractBoundingBox
    {
        public RectBoundingBox(IGameObject obj) : base(obj.Dimension.Width, obj.Dimension.Height, obj.Pos)
        {

        }
    }
}