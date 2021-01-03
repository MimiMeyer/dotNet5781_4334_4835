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

        void AddLine(DO.Line line);
        DO.Line RequestLine(int Id);
        IEnumerable<DO.Line> RequestAllLines();
        void UpdateLine(DO.Line line);
        void DeleteLine(int id);

        #endregion 
        #region LineStation
        void AddLineStation(DO.LineStation Line);
        DO.LineStation RequestLineStation(int Station, int lineId);
        IEnumerable<DO.LineStation> RequestAllLinesStation();
        void UpdateLineStation(DO.LineStation Line);
        void DeleteLineStation(int Station, int lineId);
        #endregion 
        #region LineTrip
        void AddLineTrip(DO.LineTrip lineTrip);
        DO.LineTrip RequestLineTrip( int lineId, TimeSpan StartAt);
        IEnumerable<DO.LineTrip> RequestAllLineTrips();
        IEnumerable<int> RequestStationsByLine(int lineID);
        void UpdateLineTrip(DO.LineTrip lineTrip);
        void DeleteLineTrip(int lineId, TimeSpan StartAt);
        #endregion
        #region Station
        
        void AddStation( DO.Station station);
        DO.Station RequestStation(int code);
        IEnumerable<DO.Station> RequestAllStations();
        void UpdateStation(DO.Station station);
        void DeleteStation(int code);
        #endregion
        #region Trip
        
        void AddTrip(DO.Trip trip);
        DO.Trip RequestTrip(int id);
        IEnumerable<DO.Trip> RequestAllTrips();
        void UpdateTrip(DO.Trip trip);
        void DeleteTrip(int id);
        #endregion 
        #region User

        void AddUser(DO.User user);
        DO.User RequestUser(string userName);
        IEnumerable<DO.User> RequestAllUsers();
        void UpdateUser(DO.User user);
        void DeleteUser(string userName);
        #endregion
        #region AdjacentStations
        void AddAdjacentStations(DO.AdjacentStations Stations);
        DO.AdjacentStations RequestAdjacentStations(int station1, int station2);
        IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations();
        void UpdateAdjacentStations(DO.AdjacentStations Stations);
        void DeleteAdjacentStations(int station1,int station2);
        #endregion

    }
}
