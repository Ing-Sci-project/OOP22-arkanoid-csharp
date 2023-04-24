namespace Balzoni.Api
{    /// <summary>
    ///  Interface that manages the direction of MovingObject.
    /// </summary>
    public interface IDirection
    {
        /// <summary>
        /// Set the direction of the MovingObject Down.
        /// </summary>
        void setDirectionDown();
        /// <summary>
        /// Set the direction of the MovingObject Up.
        /// </summary>
        void setDirectionUp();
        /// <summary>
        /// Set the direction of the MovingObject Left.
        /// </summary>
        void setDirectionLeft();
        /// <summary>
        /// Set the direction of the MovingObject Right.
        /// </summary>
        void setDirectionRight();
        /// <summary>
        /// sets the direction of the MovingObject vertically without horizontal component.
        /// </summary>
        void setCentre();
        /// <summary>
        ///Method that tells if the direction of the ball is up.
        /// </summary>
        ///<returns>true if the direction of the Object is Up.</returns>
        bool isDirectionUp();
        /// <summary>
        ///Method that tells if the direction of the ball is left.
        /// </summary>
        ///<returns>true if the direction of the Object is Left.</returns>
        bool isDirectionLeft();
        /// <summary>
        ///  true if the direction of the Object is Right.
        /// </summary>
        ///<returns>true if the direction of the Object is Right</returns>
        bool isDirectionRight();
        /// <summary>
        /// Set the direction of the ball to the initial one.
        /// </summary>
        void resetDirection();
        /// <summary>
        /// Method that returns the current direction.
        /// </summary>
        ///<returns>The direction</returns>
        Tuple<Int32, Int32> getDirection();
        /// <summary>
        /// Method for changing the direction.
        /// </summary>
        /// <param name="new_D">new direction.</param>
        void setDirection(Tuple<Int32, Int32> new_D);
    }

}