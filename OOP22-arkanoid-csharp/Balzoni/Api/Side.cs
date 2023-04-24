namespace Balzoni.Api
{   /// <summary>
    ///  Side where the box collide.
    /// </summary>
    public enum Side
    {
        /// <summary>
        /// Side top and bottom.
        /// </summary>
        UP_DOWN,
        ///<summary>
        ///Side left and right.
        ///summary>
        LEFT_RIGHT,
        ///<summary>
        ///Collision occurs in the corner.
        ///summary>
        CORNER,
         /// <summary>
        ///  Collision occurs in the centre of the pad.
        /// </summary>
        PAD_CENTRE
    }
}