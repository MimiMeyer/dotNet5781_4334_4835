using System;

namespace DO
{

   
        #region LineId
        public class LineIdException : Exception
        {
            public int ID;
            public LineIdException(int id) : base() => ID = id;
            public LineIdException(int id, string message) :
                base(message) => ID = id;
            public LineIdException(int id, string message, Exception innerException) :
                base(message, innerException) => ID = id;

            public override string ToString() => base.ToString() + $", bad line id: {ID}";
        }
    #endregion

    #region LineStationID
    public class LineStationIDException : Exception
        {
            public int lineID;
            public int stationID;
            public LineStationIDException(int liID, int staID) : base() { lineID = liID; stationID = staID; }
            public LineStationIDException(int liID, int staID, string message) :
                base(message)
            { lineID = liID; stationID = staID; }
            public LineStationIDException(int liID, int staID, string message, Exception innerException) :
                base(message, innerException)
            { lineID = liID; stationID = staID; }

            public override string ToString() => base.ToString() + $", bad Line id: {lineID}" ;
        }
        #endregion
        #region StationCode
        public class StationCodeException : Exception
        {
            public int Code;
            public StationCodeException(int code) : base() => Code = code;
            public StationCodeException(int code, string message) :
                base(message) => Code = code;
            public StationCodeException(int code, string message, Exception innerException) :
                base(message, innerException) => Code = code;

            public override string ToString() => base.ToString() + $", bad Station code: {Code}";
        }
    #endregion
   
    #region TripId
    public class TripIdException : Exception
        {
            public int ID;
            public TripIdException(int id) : base() => ID = id;
            public TripIdException(int id, string message) :
                base(message) => ID = id;
            public TripIdException(int id, string message, Exception innerException) :
                base(message, innerException) => ID = id;

            public override string ToString() => base.ToString() + $", bad trip id: {ID}";
        }
        #endregion
        #region UserId
        public class UserIdException : Exception
        {
            public string ID;
            public UserIdException(string id) : base() => ID = id;
            public UserIdException(string id, string message) :
                base(message) => ID = id;
            public UserIdException(string id, string message, Exception innerException) :
                base(message, innerException) => ID = id;

            public override string ToString() => base.ToString() + $", Bad UserName: {ID}";
        }
    #endregion
    #region AdjacentStations
    public class AdjacentStationseException : Exception
    {
        public int Station1;
        public int Station2;
        public AdjacentStationseException(int st1, int st2) : base() { Station1 = st1; Station2 = st2; }
        public AdjacentStationseException(int st1, int st2, string message) :
            base(message)
        { Station1 = st1; Station2 = st2; }
        public AdjacentStationseException(int st1, int st2, string message, Exception innerException) :
            base(message, innerException)
        { Station1 = st1; Station2 = st2; }

        public override string ToString() => base.ToString() + $", bad station1: {Station1} and station2: {Station2}";
    }
    #endregion
    #region xml
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
    #endregion
}


