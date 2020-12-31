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
        IEnumerable<DO.Line> RequestAllLinesBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.Line> RequestAllLines();
        void UpdateLine(DO.Line line);
        void DeleteLine(int id);

        #endregion 
        #region LineStation
        void AddLineStation(DO.LineStation Line);
        DO.LineStation RequestLineStation(int Station ,int lineId);
        IEnumerable<DO.LineStation> RequestAllLineStationsBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.LineStation> RequestAllLinesStation();
        void UpdateLineStation(int Station, int lineId);
        void DeleteLineStation(int Station, int lineId);
        #endregion 
        #region LineTrip
        void AddLineTrip(DO.LineTrip lineTrip);
        DO.LineTrip RequestLineTrip( int lineId, TimeSpan StartAt);
        IEnumerable<DO.LineTrip> RequestAllLineTripsBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.LineTrip> RequestAllLineTrips();
        void UpdateLineTrip(int lineId, TimeSpan StartAt);
        void DeleteLineTrip(int lineId, TimeSpan StartAt);
        #endregion
        #region Station
        
        void AddStation( DO.Station station);
        DO.Station RequestStation(int code);
        IEnumerable<DO.Station> RequestAllStationsBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.Station> RequestAllStations();
        void UpdateStation(int code);
        void DeleteStation(int code);
        #endregion
        #region Trip
        
        void AddTrip(DO.Trip trip);
        DO.Trip RequestTrip(int id);
        IEnumerable<DO.Trip> RequestAllTripsBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.Trip> RequestAllTrips();
        void UpdateTrip(int id);
        void DeleteTrip(int id);
        #endregion 
        #region User

        void AddUser(DO.User user);
        DO.User RequestUser(string userName);
        IEnumerable<DO.User> RequestAllUsersBy(Predicate<DO.Line> predicate);
        IEnumerable<DO.User> RequestAllUsers();
        void UpdateUser(string userName);
        void DeleteUser(string userName);
        #endregion 

    }
}
