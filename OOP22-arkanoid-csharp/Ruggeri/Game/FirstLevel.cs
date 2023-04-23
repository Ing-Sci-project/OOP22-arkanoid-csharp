using Castiglioni.Game;
namespace Ruggeri.Game
{

    /// <summary>
    /// Define the three round of FirstLevel.
    /// </summary>
    public class FirstLevel : AbstractLevel
    {
        private const int NORMAL_FIRST = 19;
        private const int NORMAL_SECOND = 27;
        private const int NORMAL_THIRD = 35;
        private const int SURPRISE_FIRST = 2;
        private const int SURPRISE_SECOND = 3;
        private const int SURPRISE_THIRD = 4;
        private const int BRICK_COLUMNS = 3;
        private const int BRICK_ROWS_FIRST = 8;
        private const int BRICK_ROWS_SECOND = 11;
        private const int BRICK_ROWS_THIRD = 13;
        private const int ID = 1;
        private SizeCalculation? sizeCalc;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public FirstLevel() : base(ID) {}

        public override void FirstRound()
        {
            this.Set(NORMAL_FIRST, SURPRISE_FIRST);
        }

        public override void SecondRound()
        {
            this.Set(NORMAL_SECOND, SURPRISE_SECOND);
        }

        public override void ThirdRound()
        {
            this.Set(NORMAL_THIRD, SURPRISE_THIRD);
        }

        /// <summary>
        /// method that return the number of columns for the specific round.
        /// </summary>
        /// <returns> columns</returns>
        private int getCol()
        {
            if (this.NumRoundPassed == 0)
            {
                return BRICK_ROWS_FIRST;
            }
            else if (this.NumRoundPassed == 1)
            {
                return BRICK_ROWS_SECOND;
            }
            else
            {
                return BRICK_ROWS_THIRD;
            }
        }

        /// <summary>
        /// method that sets a new round.
        /// </summary>
        /// <param name=""></param>
        /// <param name="normal"> number of normal bricks in the round</param>
        /// <param name=""></param>
        /// <param name="surprise"> number of surprise brick in the round</param>
        private void Set(int normal, int surprise)
        {
            int rows = this.getCol();
            this.sizeCalc = new SizeCalculation(BRICK_COLUMNS, rows);
            base.CurrentRound = new RoundEasy(normal, surprise, sizeCalc);
            base.CurrentRound.SetPosBrick();
        }
    }
}