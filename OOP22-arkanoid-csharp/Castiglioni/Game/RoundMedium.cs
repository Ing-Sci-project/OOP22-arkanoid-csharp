using Castiglioni.Api;
using Foschi.Game;

namespace Castiglioni.Game
{   /// <summary>
    /// class that contains informations about different rounds in second level.
    /// </summary>
    public class RoundMedium : AbstractRound
    {
        private int _countBrick = 0;
        private int _numHard;
        private int _numSur = 0;
        private int _numH = 0;
        private double _startY;
        private double _startX;
        private double _stopY;
        private double _stopX;
        private int _jump;
        private Random _random = new Random();
        /// <summary>
        /// constructor of the class.
        /// </summary>
        /// <param name="jump">number of bricks per column</param>
        /// <param name="numB">number of normal bricks</param>
        /// <param name="numS">number of surprise bricks</param>
        /// <param name="numHard">number of hard bricks</param>
        /// <param name="sizeC">information of where to collocate bricks</param>
        public RoundMedium(int jump, int numB, int numS, int numHard, SizeCalculation sizeC) : base(numB, numS, sizeC)
        {
            _jump = jump;
            _numHard = numHard;
            _startY = sizeC.GetStart().Item2;
            _startX = sizeC.GetStart().Item1;
            _stopY = sizeC.GetStop().Item2;
            _stopX = sizeC.GetStop().Item1;
        }
        /// <summary>
        /// method that to randomly places hard bricks.
        /// </summary>
        /// <returns>true if a brick to replace is found</returns>
        private bool SetBrickHard()
        {
            int idx = _random.Next(GetBrick().Count);
            if (GetBrick()[idx].Type == BrickType.NORMAL && GetBrick()[idx].GetRes().Equals(1))
            {
                GetBrick()[idx].IncreaseRes(GetBrick()[idx].GetRes().Value);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <inheritdoc />
        public override void SetPosBrick()
        {
            for (double i = _startX; i < _stopX; i = i + SizeCalc.GetBrickDim().Item1)
            {
                _countBrick = 0;
                for (double j = _startY; j <= _stopY; j = j
                    + SizeCalc.GetBrickDim().Item2)
                {
                    if (_countBrick != _jump)
                    {
                        NormalBrick b = new NormalBrick(BrickType.NORMAL,
                            new Dimension(SizeCalc.GetBrickDim().Item1,
                            SizeCalc.GetBrickDim().Item2), new Tuple<double, double>(j, i), 1);
                        b.Pos = new Tuple<Double, Double>(j, i);
                        base.AddBrick(b);
                        _countBrick++;
                    }
                    else
                    {
                        _countBrick = 0;
                    }
                }
            }

            while (_numSur < NumSur)
            {
                if (SetBrickSurprise())
                {
                    _numSur++;
                }
            }

            while (_numH < _numHard)
            {
                if (SetBrickHard())
                {
                    _numH++;
                }
            }
        }
    }
}