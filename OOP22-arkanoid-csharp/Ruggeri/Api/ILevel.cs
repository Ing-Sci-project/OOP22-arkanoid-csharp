using Castiglioni.Api;

namespace Ruggeri
{
    /// <summary>
    /// interface Level that contains method that can be useful when a new Level
    /// starts.
    /// </summary>
    public interface ILevel
    {
        /// <summary>
        /// place items(pad,ball,bricks) within the first round.
        /// </summary>
        void FirstRound();// { set; }

        /// <summary>
        /// place items(pad,ball,bricks) within the second round.
        /// </summary>
        void SecondRound(); // { set; }

        /// <summary>
        /// place items(pad,ball,bricks) within the third round.
        /// </summary>
        void ThirdRound(); // { set; }

        /// <summary>
        /// increment lives.
        /// </summary>
        void IncreaseLife();

        /// <summary>
        /// decrement lives.
        /// </summary>
        void DecreaseLife();

        /// <summary>
        /// 
        /// </summary>
        /// <returns> true if player has other lives.</returns>
        bool IsAlive();

        /// <summary>
        /// 
        /// </summary>
        /// <returns> current round.</returns>
        IRound CurrentRound { get; set; }

        /// <summary>
        /// number of rounds passed.
        /// </summary>
        int NumRoundPassed { get; }

        /// <summary>
        /// pass to next round.
        /// </summary>
        void IncreaseRound();

        /// <summary>
        /// number of lives
        /// </summary>
        int Life { get; }

        /// <summary>
        /// level identifier.
        /// </summary>
        int Id { get; }

        //
        // <returns> player current score.
        //
        //IScore Score { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="suBrick">the input received</param>
        /// <param name="i">the input received</param>
        /// <returns> the last surprise brick destroyed.</returns>
        IBrick LastSurpriseBrick{ get; set; }

        /// <summary>
        /// the index of the last surprise brick destroyed.
        /// </summary>
        int IndexLastSurprise { get; set;}

        /// <summary>
        /// set the name of the called surprise method.
        /// </summary>
        /// <param name="surprise"> name of the surprise method</param>
        /// <returns> the index of the last surprise brick destroyed.</returns>
        string SurpriseString { get; set; }

        /// <summary>
        /// Reset the string of the surprise called empty.
        /// </summary>
        void ResetBonus();
    }
}