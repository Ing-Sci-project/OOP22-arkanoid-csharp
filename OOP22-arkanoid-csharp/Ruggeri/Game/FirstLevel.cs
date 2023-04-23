using Castiglioni.Game;
namespace Ruggeri.Game
{

    /// <summary>
    /// Define the three round of FirstLevel.
    /// </summary>
    public class FirstLevel : AbstractLevel
    {
        private const int NormalFirst = 19;
        private const int NormalSecond = 27;
        private const int NormalThird = 35;
        private const int SurpriseFirst = 2;
        private const int SurpriseSecond = 3;
        private const int SurpriseThird = 4;
        private const int BrickColumns = 3;
        private const int BrickRowsFirst = 8;
        private const int BrickRowsSecond = 11;
        private const int BrickRowsThird = 13;
        private const int ID = 1;
        private SizeCalculation? sizeCalc;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public FirstLevel() : base(ID) {}

        public override void FirstRound()
        {
            this.Set(NormalFirst, SurpriseFirst);
        }

        public override void SecondRound()
        {
            this.Set(NormalSecond, SurpriseSecond);
        }

        public override void ThirdRound()
        {
            this.Set(NormalThird, SurpriseThird);
        }

        /// <summary>
        /// method that return the number of columns for the specific round.
        /// </summary>
        /// <returns> columns</returns>
        private int getCol()
        {
            if (this.NumRoundPassed == 0)
            {
                return BrickRowsFirst;
            }
            else if (this.NumRoundPassed == 1)
            {
                return BrickRowsSecond;
            }
            else
            {
                return BrickRowsThird;
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
            this.sizeCalc = new SizeCalculation(BrickColumns, rows);
            base.CurrentRound = new RoundEasy(normal, surprise, sizeCalc);
            base.CurrentRound.SetPosBrick();
        }
    }
}