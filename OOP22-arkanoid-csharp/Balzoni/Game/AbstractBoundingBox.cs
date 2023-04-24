
using Balzoni.Api;

namespace Balzoni.Game
{
    public abstract class AbstractBoundingBox : IBoundingBox
    {   
        private const int Centre_Range = 10;
        private Dictionary<Corner, Tuple<double, double>> _corners = new Dictionary<Corner, Tuple<double, double>>();
        
        public AbstractBoundingBox(double w, double h, Tuple<double, double> pos ){
            _corners.Add(Corner.LEFT_DOWN, new Tuple<double, double>(pos.Item1, pos.Item2 + h));
            _corners.Add(Corner.LEFT_UP, pos);
            _corners.Add(Corner.RIGHT_DOWN, new Tuple<double, double>(pos.Item1 + w, pos.Item2 + h));
            _corners.Add(Corner.RIGHT_UP, new Tuple<double, double>(pos.Item1 + w, pos.Item2 + h));
        }
         /// <inheritdoc />
        public Side? checkCentre(IBoundingBox b)
        {   double d1 = (_corners[Corner.LEFT_DOWN].Item1)
             + _corners[Corner.RIGHT_DOWN].Item1 / 2;
            double d2 = (b.getBox()[Corner.LEFT_UP].Item1
            + b.getBox()[Corner.RIGHT_UP].Item1) / 2;
             if (d1 <= d2 + Centre_Range && d1 >= d2 - Centre_Range) 
            {
                 return Side.PAD_CENTRE;
            } 
            else 
            {
                  return null;
            }
        }
         /// <inheritdoc />
        public Side? collideWith(IBoundingBox b)
        { 
            if (checkCorners(Corner.LEFT_UP, Corner.RIGHT_DOWN, b)
                || checkCorners(Corner.LEFT_DOWN, Corner.RIGHT_UP, b)
                || checkCorners(Corner.RIGHT_UP, Corner.LEFT_DOWN, b)
                || checkCorners(Corner.RIGHT_DOWN, Corner.LEFT_UP, b)) 
                {
                    return Side.CORNER;
                }
                else
                {
                    if((range(_corners[Corner.LEFT_DOWN].Item2,b.getBox()[Corner.LEFT_UP].Item2)
                        || this.range(_corners[Corner.LEFT_UP].Item2,b.getBox()[Corner.LEFT_DOWN].Item2))
                        && (_corners[Corner.LEFT_UP].Item1 <= b.getBox()[Corner.RIGHT_DOWN].Item1
                         && _corners[Corner.RIGHT_UP].Item1 >= b.getBox()[Corner.LEFT_DOWN].Item1))
                         {
                                return Side.UP_DOWN;

                        }
                        else
                        {
                            if((range(_corners[Corner.RIGHT_DOWN].Item1, b.getBox()[Corner.LEFT_DOWN].Item1)
                          || this.range(_corners[Corner.LEFT_DOWN].Item1, b.getBox()[Corner.RIGHT_DOWN].Item1))
                          && (_corners[Corner.RIGHT_DOWN].Item2 >= b.getBox()[Corner.LEFT_UP].Item2
                          && _corners[Corner.RIGHT_UP].Item2 <= b.getBox()[Corner.LEFT_DOWN].Item2)) 
                          {
                                 return Side.LEFT_RIGHT;
                          }
                        }

                }
            return null;
        }
         /// <inheritdoc />
        public Dictionary<Corner, Tuple<double, double>> getBox() => _corners;
        /// <param name="d1">first double.</param>
        /// <param name="d2">second double.</param>
        ///<returns>true if d1 is within the range.</returns>
        private bool range(double d1, double d2) => (d1 >= d2 - 3 && d1 <= d2 + 3); 
        /// <param name="c1">Corner of this boundingBox.</param>
        /// <param name="c2">corner of boundingBox b</param>
        /// <param name="b">BoundingBox to check.</param>
        ///<returns>true if the two corners collide</returns>
        private bool checkCorners(Corner c1, Corner c2, IBoundingBox b ) => this.range(_corners[c1].Item1, b.getBox()[c2].Item1)
                && this.range(_corners[c1].Item2, b.getBox()[c2].Item2);
       
    }
}