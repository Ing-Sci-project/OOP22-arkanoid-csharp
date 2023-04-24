using Shapes;

namespace Castiglioni.Api
{   /// <summary>
    /// Brick entity interface.
    /// </summary>
    public interface IBrick : IGameObject
    {
        /// <summary>
        /// Type of brick.
        /// </summary>
        /// <returns>type of brick</returns>
        BrickType Type { get; }
        /// <summary>
        /// method for changing the type to the brick.
        /// </summary>
        /// <param name="type">the input received</param>
        void ChangeType(BrickType type);
        /// <summary>
        /// Height of brick.
        /// </summary>
        /// <returns>Brick heigh</returns>
        double BrickH { get; }
        /// <summary>
        /// Width of brick.
        /// </summary>
        /// <returns>Brick width</returns>
        double BrickW { get; }
        /// <summary>
        /// Resistence of brick.
        /// </summary>
        /// <returns>the resistence of the brick</returns>
        int? GetRes();
        /// <summary>
        /// if a brick is destructible.
        /// </summary>
        /// <returns>if a brick is destructible.</returns>
        bool IsDestroyed();
        /// <summary>
        /// method that decrease the resistence if is present of brick when hit.
        /// </summary>
        void Hit();
        /// <summary>
        /// method to increase resistence of brick.
        /// </summary>
        /// <param name="res">the input received</param>
        void IncreaseRes(int res);
        /// <summary>
        /// method to decrease resistence of brick.
        /// </summary>
        /// <param name="res">the input received</param>
        void DecreaseRes(int res);
    }
}