namespace Balzoni.Api
{  
    /// <summary>
    ///  interface for creating BoundiBox.
    /// </summary>
    public interface IBoundingBox
    {  
        /// <summary>
        ///  method to get the Box.
        /// </summary>
        ///<returns>Dictionary of Corners and their respective coordinates.</returns>

        Dictionary<Corner, Tuple<double, double>> getBox();
    
        /// <summary>
        ///  method to check the collision with two BoundingBox.
        /// </summary>
        ///<returns>the side where the box collide or an empty optional if no collision occurs.</returns>
        /// <param name="b">BoundingBox.</param>
        Nullable<Side> collideWith(IBoundingBox b);

        /// <summary>
        ///  method tho check if the ball collide with the centre of the pad.
        /// </summary>
        ///<returns>Side.PAD_CENTRE if the collision occurred in the centre of b.</returns>
        /// <param name="b">BoundingBox.</param>
        Nullable<Side> checkCentre(IBoundingBox b);
    }
}