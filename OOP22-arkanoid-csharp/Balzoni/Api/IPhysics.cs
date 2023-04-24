namespace Balzoni.Api
{   /// <summary>
    ///  Interface that manages the change of direction of MovingObject.
    /// </summary>
    public interface IPhysics
    {
        /// <summary>
        /// Method for changing the direction of the ball.
        /// </summary>
        /// <param name="side">side of collision.</param>
        void changeDirection(Side side);
        /// <summary>
        /// Method for changing the direction of the ball.
        /// </summary>
        ///<returns>Ball direction</returns>
        IDirection Dir{ get; }
    }
}