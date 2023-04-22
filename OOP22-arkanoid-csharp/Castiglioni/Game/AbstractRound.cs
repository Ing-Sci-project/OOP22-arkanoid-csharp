using Foschi.Game;
using Shapes;
using Castiglioni.Api;
using MovingShapesImpl;

namespace Castiglioni.Game
{
    /// <summary>
    /// class that implements the methods common to different rounds.
    /// </summary>
    public abstract class AbstractRound : IRound
    {
        private int _numBrick;
        private int _numSurprise;
        private List<IBrick> _brick = new List<IBrick>();
        private List<IMovingObject> _balls = new List<IMovingObject>();
        private List<IMovingObject> _extraBalls = new List<IMovingObject>();
        private IMovingObject _pad;
        private SizeCalculation _sizeC;
        private List<IMovingObject> _surprise = new List<IMovingObject>();
        private Random _random = new Random();
        /// <summary>
        /// constructor of the class.
        /// </summary>
        /// <param name="numB">number of normal bricks</param>
        /// <param name="numS">number of surprise bricks</param>
        /// <param name="size">objects that contains information of where collocate bricks</param>
        public AbstractRound(int numB, int numS, SizeCalculation size)
        {
            _numBrick = numB;
            _numSurprise = numS;
            _sizeC = size;
            _pad = new Pad(SizeCalculation.GetPadDim());
            _balls.Add(new Ball(SizeCalculation.GetBallDim()));
        }
        /// <inheritdoc />
        public SizeCalculation SizeCalc => _sizeC;
        /// <inheritdoc />
        public int NumBrick => _numBrick;
        /// <inheritdoc />
        public int NumSur => _numSurprise;
        /// <inheritdoc />
        public void Restart()
        {
            _balls.Clear();
            IMovingObject ball = new Ball(SizeCalculation.GetBallDim());
            ball.Physics.GetDir().ResetDirection();
            _balls.Add(ball);
            _surprise.Clear();
        }
        /// <inheritdoc />
        public List<IMovingObject> GetSurprise() => _surprise;
        /// <summary>
        /// method to add a brick in the list.
        /// </summary>
        /// <param name="brick">that we want to add</param>
        protected void AddBrick(IBrick brick) => _brick.Add(brick);
        /// <summary>
        /// method that add a surprise a new ball to the list.
        /// </summary>
        /// <param name="ball">the ball to add</param>
        private void AddSurprise(IMovingObject ball) => _surprise.Add(ball);
        /// <summary>
        /// method that to randomly places surprise bricks.
        /// </summary>
        /// <returns>true if a brick to replace is found</returns>
        protected bool SetBrickSurprise()
        {
            int idx = _random.Next(_brick.Count);

            if (_brick[idx].Type == BrickType.NORMAL)
            {
                _brick[idx].ChangeType(BrickType.SURPRISE);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <inheritdoc />
        public void SetPosBall(Tuple<double, double> pos, int index) => _balls[index].Pos = pos;
        /// <inheritdoc />
        public void SetPosPad(Tuple<double, double> pos) => _pad.Pos = pos;
        /// <inheritdoc />
        public List<Tuple<double, double>> GetPosBall()
        {
            List<Tuple<double, double>> output = new List<Tuple<double, double>>();
            foreach (var b in _balls)
            {
                output.Add(b.Pos);
            }
            return output;
        }
        /// <inheritdoc />
        public IMovingObject Pad { get => _pad; }
        /// <inheritdoc />
        public List<IMovingObject> GetBalls() => _balls;
        /// <inheritdoc />
        public void Remove(int index)
        {
            IBrick brick = _brick[index];
            if (brick.Type.Equals(BrickType.SURPRISE))
            {
                AddSurprise(AddSurprise(brick));
            }
            brick.Hit();
            if (brick.IsDestroyed())
            {
                _brick.RemoveAt(index);
            }
        }
        /// <summary>
        /// method that sets features of a new BonusBall.
        /// </summary>
        /// <param name="brick">the size of the brick is used to set the initial position of the ball</param>
        /// <returns>the ball to add to the list of bonus balls</returns>
        private IMovingObject AddSurprise(IBrick brick)
        {
            IMovingObject b = new Ball(SizeCalculation.GetBallDim());
            b.Pos = new Tuple<double, double>(brick.Pos.Item1 + brick.BrickW / 2,
                brick.Pos.Item2 + brick.BrickH);
            b.Speed = new Speed(0, 1);
            return b;
        }
        /// <inheritdoc />
        public List<IBrick> GetBrick() => _brick;
        /// <inheritdoc />
        public List<IMovingObject> GetExtraBalls() => _extraBalls;
        /// <inheritdoc />
        public abstract void SetPosBrick();
    }
}