
using OOP22_arkanoid_csharp.Desiderio.Api;

namespace Foschi.Game {

    /// <summary>
    /// Class that manages objects' dimension.
    /// </summary>
    public class Dimension : IDimension
    {

        private double _height;
        private double _width;

        /// <summary>
        /// costructor of this class.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public Dimension(double height, double width)
        {
            _height = height;
            _width = width;
        }

        /// <inheritdoc />
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <inheritdoc />
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <inheritdoc />
        public void IncreaseWidth(double value) => _width += value;

    }
}