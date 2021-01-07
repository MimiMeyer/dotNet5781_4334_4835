using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    #region LineId
    public class LineIdException : Exception
    {
        public int ID;
        public LineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.LineIdException)innerException).ID;
        public LineIdException(int id,string message) :
            base(message) => ID=id;

        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    #endregion

 
   
    #region Station
    public class StationCodeException : Exception
    {
        public int Code;
        public StationCodeException(string message, Exception innerException) :
            base(message, innerException) => Code = ((DO.StationCodeException)innerException).Code;
        public StationCodeException(int code, string message) :
           base(message) => Code= code;
        public override string ToString() => base.ToString() + $", bad Station Code: {Code}";
    }
    public class StationCoordinatesException : Exception
    {
        public  double Coordinates;
        public StationCoordinatesException(double coord, string message) :
           base(message) => Coordinates = coord;
        public override string ToString() => base.ToString() + $", bad Station Coordinates: {Coordinates}";
    }
    #endregion



}
