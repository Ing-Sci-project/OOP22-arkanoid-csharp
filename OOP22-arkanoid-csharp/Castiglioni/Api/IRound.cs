namespace Castiglioni.Api
{
    /// <summary>
    /// interface that contains useful methods to manage different rounds in a game.
    /// </summary>   
    public interface IRound
    {
        /// <summary>
        /// object of class SizeCalculation.
        /// </summary>
        /// <returns>SizeCalculation</returns>
        SizeCalculation SizeCalc { get; }
        /// <summary>
        /// number of normal bricks.
        /// </summary>
        /// <returns>number of normal bricks</returns>
        int NumBrick { get; }
        /// <summary>
        /// number of surprise bricks.
        /// </summary>
        /// <returns>number of surprise bricks</returns>
        int NumSur { get; }
        /// <summary>
        /// returns the ball to its initial position.
        /// </summary>
        void Restart();
        /// <summary>
        /// method to get all the bricks in the game.
        /// </summary>
        /// <returns>list of all bricks</returns>
        List<IBrick> GetBrick();
        /// <summary>
        /// method to set ball position.
        /// </summary>
        /// <param name="pos">new position of ball</param>
        /// <param name="index">ball position in the list</param>
        void SetPosBall(Tuple<double, double> pos, int index);
        /// <summary>
        /// method to set pos of pad.
        /// </summary>
        /// <param name="pos">new position of pad</param>
        void SetPosPad(Tuple<double, double> pos);
        /// <summary>
        /// method to get all bonus ball in the game.
        /// </summary>
        /// <returns>list of surprise balls</returns>
        List<MovingObject> GetSurprise();
        /// <summary>
        /// method to get positions of all balls in the game.
        /// </summary>
        /// <returns>a list that contains positions of all balls</returns>
        List<Tuple<double, double>> GetPosBall();
        /// <summary>
        /// return pad object.
        /// </summary>
        /// <returns>pad</returns>
        MovingObject Pad { get; }
        /// <summary>
        /// return balls objects.
        /// </summary>
        /// <returns>balls</returns>
        List<MovingObject> GetBalls();
        /// <summary>
        /// method to remove a brick when is hitten.
        /// </summary>
        /// <param name="index">position of brick in the list</param>
        void Remove(int index);
        /// <summary>
        /// return extra-balls objects.
        /// </summary>
        /// <returns>list of extra balls</returns>
        List<MovingObject> GetExtraBalls();
        /// <summary>
        /// method to set brick in right position.
        /// </summary>
        void SetPosBrick();

    }
}