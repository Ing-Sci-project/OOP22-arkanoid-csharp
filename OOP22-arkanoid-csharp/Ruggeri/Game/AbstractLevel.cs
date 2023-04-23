using Castiglioni.Api;
using Ruggeri.Api;

namespace Ruggeri.Game
{
    /// <summary>
    /// This abstract class declares variables and defines methods in common with
    /// various levels.
    /// </summary>
    public abstract class AbstractLevel : ILevel
    {
        private const int INITIAL_LIVES = 3;
        private int _lives = INITIAL_LIVES;
        private IRound? _currentRound;
        //private Score score;
        private int _numRoundPassed = 0;
        private int _levelId;
        private IBrick? _lastSurpriseBrick;
        private int _indexLastSurprise;
        private string _bonus;

        /// <summary>
        /// constructor of this class.
        /// </summary>
        /// <param name="levelId"> represents level identifier</param>
        public AbstractLevel(int levelId)
        {
            this._levelId = levelId;
            this._bonus = " ";
            //this.score = new ScoreImpl();
        }
        /// <inheritdoc />
        public IRound? CurrentRound { get => this._currentRound; set => this._currentRound = value; }
        /// <inheritdoc />
        public int NumRoundPassed => this._numRoundPassed;
        /// <inheritdoc />
        public int Life => this._lives;
        /// <inheritdoc />
        public int Id => this._levelId;
        /// <inheritdoc />
        public IBrick? LastSurpriseBrick { get => this._lastSurpriseBrick; set => this._lastSurpriseBrick = value; }
        /// <inheritdoc />
        public int IndexLastSurprise { get => this._indexLastSurprise; set => this._indexLastSurprise = value; }
        /// <inheritdoc />
        public string SurpriseString { get => this._bonus; set => this._bonus = value; }
        /// <inheritdoc />
        public abstract void FirstRound();
        /// <inheritdoc />
        public abstract void SecondRound();
        /// <inheritdoc />
        public abstract void ThirdRound();
        /// <inheritdoc />
        public void IncreaseLife() => this._lives++;
        /// <inheritdoc />
        public void DecreaseLife() => this._lives--;
        /// <inheritdoc />
        public bool IsAlive() => this._lives > 0;
        /// <inheritdoc />
        public void IncreaseRound() => ++this._numRoundPassed;
        /// <inheritdoc />
        public void ResetBonus() => this._bonus = " ";
    }
}
