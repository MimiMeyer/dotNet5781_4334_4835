using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{

    #region Line
    public class LineIdException : Exception
    {
        public int ID;
        public LineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.LineIdException)innerException).ID;
        public LineIdException(int id,string message) :
            base(message) => ID=id;

        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    public class LineAreaException : Exception
    {
        public BO.Areas Area;
       
        public LineAreaException(BO.Areas area, string message) :
            base(message) => Area = area;

        public override string ToString() => base.ToString() + $", bad line Area: {Area}";
    }
    #endregion

    #region general
    public class CantBeMinusException : Exception
    {
        public double X;
        public CantBeMinusException(double x, string message) :
           base(message) => X = x;
        public override string ToString() => base.ToString() + $", Can't be minus: {X}";
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
    #region LineStation
    public class LineStationIndexException : Exception
    {
        public int Index;
        public LineStationIndexException(int index, string message) :
           base(message) => Index= index;
        public override string ToString() => base.ToString() + $", bad LineStation index: {Index}";
    }
    #endregion
    #region lineTrip
    public class LineTripTimeSpanException : Exception
    {
        public TimeSpan Time;
        public LineTripTimeSpanException(TimeSpan time, string message) :
           base(message) => Time = time;
        public override string ToString() => base.ToString() + $", bad LineTrip time index: {Time}";
    }
    #endregion




}
