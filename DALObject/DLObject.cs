using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using DS;
using DO;
namespace DL
{
    sealed class DLObject: IDL

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion
        //Implement IDL methods, CRUD
        #region Line

        void AddLine(DO.Line line) 
        { //need to add exeception of lines to make sure there isn't duplicates and that code is 3 digits or under
            DataSource.listLines.Add(line.Clone());
        }
        DO.Line RequestLine(int Id) 
        {
            DO.Line li = DataSource.listLines.Find(l => l.Id == Id);//checks line. if exists li will get the value of the chosen line.

            if (li != null)//if li = null that means line does not exist
                return li.Clone();//returns the chosen line
            else
                throw new DO.LineIdException(Id, $"line Id does not exist: {Id}");
        }
        IEnumerable<DO.Line> RequestAllLinesBy(Predicate<DO.Line> predicate) 
        { 
            throw new NotImplementedException(); 
        }
        IEnumerable<DO.Line> RequestAllLines()//returns a copy of list of lines
        {
            return from Line in DataSource.listLines
                   select Line.Clone();
        }
        void UpdateLine(DO.Line line)
        {
            DO.Line li = DataSource.listLines.Find (l=> l.Id == line.Id);//checks line. if exists li will get the value of the chosen line.

            if (li != null)////if li = null that means line does not exist
            {
                DataSource.listLines.Remove(li);//remove 
                DataSource.listLines.Add(line.Clone());//add new uodated line
            }
            else
                throw new DO.LineIdException(line.Id, $"line Id does not exist: {line.Id}");
        }
        void DeleteLine(int id)
        {
            DO.Line li = DataSource.listLines.Find(l => l.Id == id);//checks line. if exists li will get the value of the chosen line.

            if (li != null)////if li = null that means line does not exist
            {
                DataSource.listLines.Remove(li);//remove 
                
            }
            else
                throw new DO.LineIdException(id, $"line Id does not exist: {id}");
        }

        #endregion 
        #region LineStation
        void AddLineStation(DO.LineStation line) //adds station to bus
        {//need to check if bus exists and index and if station is good!
            DataSource.listLineStation.Add(line.Clone()); 
        }
        DO.LineStation RequestLineStation(int Station, int lineId) 
        { }
        IEnumerable<DO.LineStation> RequestAllLineStationsBy(Predicate<DO.Line> predicate) 
        { }
        IEnumerable<DO.LineStation> RequestAllLinesStation() //returns a copy of list of  Line stations
        {
            return from LineStation in DataSource.listLineStation
                   select LineStation.Clone();
        }
        void UpdateLineStation(int Station, int lineId) 
        { }
        void DeleteLineStation(int Station, int lineId) 
        { }
        #endregion 
        #region LineTrip
        void AddLineTrip(DO.LineTrip lineTrip) 
        { //check if id exists
            DataSource.listLineTrip.Add(lineTrip.Clone());
        }
        DO.LineTrip RequestLineTrip(int lineId, TimeSpan StartAt) 
        { 
        }
        IEnumerable<DO.LineTrip> RequestAllLineTripsBy(Predicate<DO.Line> predicate) 
        { 
        }
        IEnumerable<DO.LineTrip> RequestAllLineTrips()//returns a copy of list of line trips
        {
            return from LineTrip in DataSource.listLineTrip
                   select LineTrip.Clone();
        }
        void UpdateLineTrip(int lineId, TimeSpan StartAt) 
        {
        }
        void DeleteLineTrip(int lineId, TimeSpan StartAt) 
        {
        }
        #endregion
        #region Station
      
        void AddStation(DO.Station station)//Add station to station list
        { //check that there isn't duplicats
            DataSource.listStations.Add(station.Clone());
        }
        DO.Station RequestStation(int code) 
        { }
        IEnumerable<DO.Station> RequestAllStationsBy(Predicate<DO.Line> predicate)
        { }
        IEnumerable<DO.Station> RequestAllStations()// returns a copy of list of stations
        {
            return from Station in DataSource.listStations
                   select Station.Clone();
        }
        void UpdateStation(int code) 
        { }
        void DeleteStation(int code) 
        { }
        #endregion
        #region Trip

        void AddTrip(DO.Trip trip) 
        { //need to check id chheck that username and if line id exists
            DataSource.listTrip.Add(trip.Clone()); 
        }
        DO.Trip RequestTrip(int id) 
        { }
        IEnumerable<DO.Trip> RequestAllTripsBy(Predicate<DO.Line> predicate) 
        { }
        IEnumerable<DO.Trip> RequestAllTrips()//returns a copy of list of trips
        {
            return from Trip in DataSource.listTrip
                   select Trip.Clone();
        }
        void UpdateTrip(int id) 
        { }
        void DeleteTrip(int id)
        { }
        #endregion 
        #region User

        void AddUser(DO.User user) 
        { //need to make sure there are no duplicates of username
            DataSource.listUser.Add(user.Clone());
        }
        DO.User RequestUser(string userName)
        { }
        IEnumerable<DO.User> RequestAllUsersBy(Predicate<DO.Line> predicate)
        { }
        IEnumerable<DO.User> RequestAllUsers() //returns a copy of list of users
        {
            return from User in DataSource.listUser
                   select User.Clone();
        }
        void UpdateUser(string userName) { }
        void DeleteUser(string userName) { }
        #endregion 
    }
}
