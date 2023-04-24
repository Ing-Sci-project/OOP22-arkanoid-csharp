namespace  Foschi.Api{

    /// <summary>
    /// Speed interface.
    /// </summary>
    public interface ISpeed
    {
        /// <summary>
        /// X coordinate of speed.
        /// </summary>
        /// <returns>X coordinate</returns>
        double X {get;}

        /// <summary>
        /// Y coordinate of speed.
        /// </summary>
        /// <returns>Y coordinate</returns>
        double Y {get;}

        /// <summary>
        /// method to modify speed.
        /// </summary>
        /// <param name="vel">the input received</param>
        void sum(ISpeed vel);
    }
}