using Foschi.Api;
namespace Shapes
{
    /// <summary>
    /// Interface that models the characteristics of a game object.
    /// </summary>
    public interface IGameObject {
        /// <summary>
        /// Gets or sets the position of the game object.
        /// </summary>
        Tuple<double, double> Pos { get; set; }

        /// <summary>
        /// Gets or sets the bounding box area of the game object.
        /// </summary>
        IBoundingBox BoundingBox { get; set; }

        /// <summary>
        /// Gets or sets the dimension of the game object.
        /// </summary>
        IDimension Dimension { get; set; }
    }
    /// <summary>
    /// Interface that models the characteristics of a mobile object.
    /// </summary>
    public interface IMovingObject : IGameObject {
        /// <summary>
        /// Assigns the physics of the object.
        /// </summary>
        /// <param name="phsycs">The physics to assign.</param>
        
        IPhysics Physics { get; set;}

        /// <summary>
        /// Gets or sets the dimension of the object.
        /// </summary>
        IDimension Dimension { get; set; }

        /// <summary>
        /// Gets and set the speed of the object.
        /// 
        /// </summary>
       ISpeed Speed { get; set;}
    }
}