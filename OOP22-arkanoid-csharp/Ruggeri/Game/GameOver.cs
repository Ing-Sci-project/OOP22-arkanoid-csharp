using Castiglioni.Api;

namespace Ruggeri
{

    /// <summary>
    /// This class checks round states.
    /// </summary>
    public class GameOver
    {
        private IRound _round;

        /// <summary>
        /// constructor of this class.
        /// </summary>
        /// <param name="round"> represents the playing round</param>
        public GameOver(IRound round)
        {
            this._round = round;
        }

        /// <summary>
        /// Check if the player missed the ball.
        /// </summary>
        /// <returns> boolean value that indicates if the pad has missed the ball</returns>
        public bool HasMissedBall()
        {
            foreach (var ball in this._round.GetBalls())
            {
                if (!(ball.Pos.Item2 > this._round.Pad.Pos.Item2))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the player has finished the round.
        /// </summary>
        /// <returns> boolean value that indicates if the round is finished.</returns>
        public bool IsRoundFinished()
        {
            return this._round.GetBrick().Count < 1 || RemainsOnlyObstacles();
        }

        /// <summary>
        /// Check if remains only obstacles.
        /// </summary>
        /// <returns> boolean value that indicates if remains only obstacles in round.</returns>
        private bool RemainsOnlyObstacles()
        {
            foreach (IBrick element in this._round.GetBrick())
            {
                if (element.Type != BrickType.OBSTACLE)
                {
                    return false;
                }
            }
            return true;
        }
    }
}