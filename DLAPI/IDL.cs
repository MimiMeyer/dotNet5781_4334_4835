using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    public interface IDL
    {
        #region Line

        int AddLine(DO.Line line);//add line
        DO.Line RequestLine(int Id);//requests for a line and returns it if it exists
        DO.Line RequestLineByCode(int code);//requests for a line by line number and returns it if it exists
        IEnumerable<DO.Line> RequestAllLines();//returns all lines
        void UpdateLine(DO.Line line);//updates line
        void DeleteLine(int id);//delets line
        

        #endregion 
        #region LineStation
        void AddLineStation(DO.LineStation Line);//adds linestation
        DO.LineStation RequestLineStation(int Station,int lineId);//requests for a linestation and returns it if it exists
        IEnumerable<DO.LineStation> RequestAllLinesStation(int id);//returns all lineStations
        void UpdateLineStation(DO.LineStation Line);//update linestation
        void DeleteLineStationbyLine(int lineId);//deletes all linestations with same line
        void DeleteLineStationbyStation(int code);//deletes all linestations with same station
        void DeleteLineStation(int Station, int lineId);//deletes line station
        IEnumerable<int> RequestStationsByLine(int lineID);//returns list of stations for requested line.
        IEnumerable<int> RequestLinesByStation(int Station);//returns list of lines for requested station.
        IEnumerable<DO.Line> GetLinesByStation(int Station);//returns list of lines for requested station.
        #endregion
        #region LineTrip
        void AddLineTrip(DO.LineTrip lineTrip);//adds linetrip
        DO.LineTrip RequestLineTrip( int lineId, TimeSpan StartAt);//requests for line trip and returns it if it exists;
        IEnumerable<DO.LineTrip> RequestAllLineTrips();//returns all line tripss;
        void UpdateLineTrip(DO.LineTrip lineTrip);//updates linetrip
        void DeleteLineTrip(int lineId, TimeSpan StartAt);//deletes linetrip
        #endregion
        #region Station
        
        void AddStation( DO.Station station);//adds station
        DO.Station RequestStation(int code);//requests for station and if exist returns it
        IEnumerable<DO.Station> RequestAllStations();//returns all stations
        void UpdateStation(DO.Station station);//updates selected station
        void DeleteStation(int code);//deletes station
        #endregion
        #region Trip
        
        int AddTrip(DO.Trip trip);//add trip
        DO.Trip RequestTrip(int id);//request trip
        IEnumerable<DO.Trip> RequestAllTrips();//returns all trips
        void UpdateTrip(DO.Trip trip);//updates trip
        void DeleteTrip(int id);//deletes tripo
        #endregion 
        #region User

        void AddUser(DO.User user);//add user
        DO.User RequestUser(string userName);//requests user and if exists returns it
        IEnumerable<DO.User> RequestAllUsers();//returnsall users
        void UpdateUser(DO.User user);//updates user
        void DeleteUser(string userName);//deletes user
        #endregion
        #region AdjacentStations
        void AddAdjacentStations(DO.AdjacentStations Stations);//adds AdjacentStations
        DO.AdjacentStations RequestAdjacentStations(int station1, int station2);//request and if it exists returns AdjacentStations
        IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations();//returns all AdjacentStations
        void UpdateAdjacentStations(DO.AdjacentStations Stations);//updates AdjacentStations
        void DeleteAdjacentStations(int station1,int station2);//deletes AdjacentStations
        #endregion

    }
}
