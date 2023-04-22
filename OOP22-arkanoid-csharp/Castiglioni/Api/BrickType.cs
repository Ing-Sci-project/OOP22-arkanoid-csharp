namespace Castiglioni.Api
{   /// <summary>
    /// differt types of brick in the game.
    /// </summary>
    public enum BrickType
    {
        /// <summary>
        /// obstacle is a brick that can't be destroyed.
        /// </summary>
        OBSTACLE,
        ///<summary>
        ///normal is a brick that has no specific features.
        ///summary>
        NORMAL,
        ///<summary>
        ///surprise is a brick that let the player to get bonus or malus.
        ///summary>
        SURPRISE
    }
}