using Foschi.Game;
using OOP22_arkanoid_csharp.Desiderio.Api;

namespace Castiglioni.Game
{   /// <summary>
    /// Class that calculates the size of the entity based on the size of the model.
    /// </summary>
    public class SizeCalculation
    {
        private const double World_Height = 400d;
        private const double World_Width = 300d;
        private const int Divider_X = 6;
        private const int NumCol = 6;
        private const double Mul_X1 = 1.75;
        private const double Mul_X2 = 1.5;
        private const double Diveder_Pad_X = 60;
        private const double Diveder_Ball = 30;

        private int _numBrickCol;
        private double _startX;
        private double _startY;
        private double _stopX;
        private double _stopY;
        private double _brickL;
        private double _brickH;
        /// <summary>
        /// costructor of this class.
        /// </summary>
        /// <param name="numBrickCol">number of bricks in a column</param>
        /// <param name="numBrickRow">number of bricks in a row</param>
        public SizeCalculation(int numBrickCol, int numBrickRow)
        {
            _numBrickCol = numBrickCol;
            _startX = (World_Height / 2) / Divider_X;
            _stopX = GetStopX();
            _brickL = World_Width / numBrickRow;
            _brickH = (_stopX - _startX) / numBrickCol;
            _stopY = World_Width - (3 * (_brickL / 2));
            _startY = _brickL / 2;
        }
        /// <summary>
        /// the height at which to stop the placement of the bricks.
        /// </summary>
        /// <returns>the height</returns>
        private double GetStopX()
        {
            if (_numBrickCol > NumCol)
            {
                return (((World_Height / 2) / 3) * Mul_X1);
            }
            else if (_numBrickCol > 4)
            {
                return (((World_Height / 2) / 3) * Mul_X2);
            }
            else
            {
                return ((World_Height / 2) / 3);
            }
        }
        /// <summary>
        /// the size of the model.
        /// </summary>
        /// <returns>the size of model</returns>
        public static Tuple<double, double> GetWorldSize() => new Tuple<double, double>(World_Height, World_Width);
        /// <summary>
        /// the starting coordinates from which to start the positioning of the bricks.
        /// </summary>
        /// <returns>the starting coordinates</returns>
        public Tuple<double, double> GetStart() => new Tuple<double, double>(_startX, _startY);
        /// <summary>
        /// the end coordinates from which to stop the positioning of the bricks.
        /// </summary>
        /// <returns>the end coordinates</returns>
        public Tuple<double, double> GetStop() => new Tuple<double, double>(_stopX, _stopY);
        /// <summary>
        /// the brick dimension.
        /// </summary>
        /// <returns>the brick dimension</returns>
        public Tuple<double, double> GetBrickDim() => new Tuple<double, double>(_brickH, _brickL);
        /// <summary>
        /// method used to know the y of the rows of bricks.
        /// </summary>
        /// <returns>the y of rows</returns>
        /// <param name="x">number of row</param>
        public double GetRowCordinate(double x) => _startX + (x * _brickH);
        /// <summary>
        /// the pad dimension.
        /// </summary>
        /// <returns>pad dimension</returns>
        ///Provare quando ci sarà con Dimension
        public static IDimension GetPadDim() => new Dimension(World_Height / Diveder_Pad_X, World_Width / 4);
        /// <summary>
        /// the ball dimension.
        /// </summary>
        /// <returns>ball dimension</returns>
        ///Provare quando ci sarà con Dimension
        public static IDimension GetBallDim() => new Dimension(World_Width / Diveder_Ball, World_Width / Diveder_Ball);
    }
}