namespace Foschi.Game {

    public class Dimension {

        private double _height;
        private double _width;

        public Dimension(double height, double width) 
        {
            _height=height;
            _width=width;
        }

        public double Height
        {
            get {return _height;}
            set {_height=value;}
        }

        public double Width
        {
            get {return _width;}
            set {_width=value;}
        }

        public void IncreaseWidth(double value) => _width += value;

    }
}