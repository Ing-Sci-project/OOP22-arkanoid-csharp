using Castiglioni.Api;
using Castiglioni.Game;
using Foschi.Game;

namespace Ruggeri.Game
{
    /// <summary>
    /// Defines how a round easy is designed.
    /// </summary>
    public class RoundEasy : AbstractRound
    {

        private double _startX;
        private double _startY;
        private double _endX;
        private double _endY;
        private int _numSurpriseBrick = 0;

        /// <summary>
        /// Constructor of this class.
        /// </summary>
        /// <param name="numB">num of normal bricks</param>
        /// <param name="numS">num of surprise bricks</param>
        /// <param name="size">information of where to collocate bricks</param>
        public RoundEasy(int numB, int numS, SizeCalculation size) : base(numB, numS, size)
        {
            this._startY = size.GetStart().Item2;
            this._startX = size.GetStart().Item1;
            this._endY = size.GetStop().Item2;
            this._endX = size.GetStop().Item1;
            this.SetPosBrick();
        }
        /// <inheritdoc />
        public override void SetPosBrick()
        {
            for (double i = _startX; i < _endX; i = i + SizeCalc.GetBrickDim().Item1)
            {
                for (double j = _startY; j <= _endY; j = j
                    + SizeCalc.GetBrickDim().Item2)
                {
                    NormalBrick brick = new NormalBrick(BrickType.NORMAL,
                        new Dimension(SizeCalc.GetBrickDim().Item1,
                            SizeCalc.GetBrickDim().Item2), new Tuple<double, double>(j, i), 1);
                    brick.Pos = new Tuple<Double, Double>(j, i);
                    base.AddBrick(brick);
                }
            }
            while (this._numSurpriseBrick < NumSur)
            {
                if (this.SetBrickSurprise())
                {
                    this._numSurpriseBrick++;
                }
            }
        }
    }
}
