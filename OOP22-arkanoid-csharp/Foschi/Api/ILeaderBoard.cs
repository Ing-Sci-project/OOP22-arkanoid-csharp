namespace Foschi.Api
{
    /// <summary>
    /// LeaderBoard interface.
    /// </summary>
    public interface ILeaderBoard
    {
        /// <summary>
        /// method to update player's points.
        /// </summary>
        /// <param name="name">name of the player</param>
        /// <param name="password">password of the player</param>
        /// <param name="points">points totalize by the player</param>
        /// <param name="levelId">level done by the player</param>
        void UpdatePoints(string name, string password, int points, int levelId);

        /// <summary>
        /// method to get best five players.
        /// </summary>
        /// <returns>list of pairs (player's name, points)</returns>
        List<Tuple<string,int>> GetBestFive();

        /// <summary>
        /// method to get player's points.
        /// </summary>
        /// <param name="name">name of the player</param>
        /// <param name="password">password of the player</param>
        /// <returns>null if player doesn't exists or his points</returns>
        int? GetPoints(string name, string password);
    }
}