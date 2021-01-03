using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using DS;
using DO;
namespace DL
{//look at addline
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
        {
            if (DataSource.listLines.FirstOrDefault(l=> l.Id == line.Id) != null)//makes sure there are no duplicates
                throw new DO.LineIdException(line.Id, $"Duplicate lineId: {line.Id}");
            
            
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
        void AddLineStation(DO.LineStation lineStation) //adds station to bus
        {

            
            if (!RequestStationsByLine(lineStation.LineId). Contains(lineStation.Station)) //if the station does not exist then you can add
            { 
            DataSource.listLineStation.Add(lineStation.Clone()); //add line station to list
            }
            throw new DO.LineIdException(lineStation.Station, $"station already exists in line: {lineStation.Station}");

        }
        IEnumerable<int> RequestStationsByLine(int lineID)//returns list of stations for lines
        {
            return DataSource.listLineStation.FindAll(lineStation => lineStation.LineId == lineID).
                                              Select(lineStation => lineStation.Station);

        }
        DO.LineStation RequestLineStation(int Station, int lineId) 
        {//need to find if station exists in line
            DO.LineStation li = DataSource.listLineStation.Find(l => l.LineId == lineId);//checks line station. if exists li will get the value of the chosen line.

            if (li != null)//if li = null that means line station does not exist
                return li.Clone();//returns the chosen line
            else
                throw new DO.LineIdException(lineId, $"line Id does not exist: {lineId}");
        }

       


        IEnumerable<DO.LineStation> RequestAllLinesStation() //returns a copy of list of  Line stations
        {
            return from LineStation in DataSource.listLineStation
                   select LineStation.Clone();
        }
        void UpdateLineStation(int Station, int lineId) 
        { 
        }
        void DeleteLineStation(int Station, int lineId) 
        { 
        }
        #endregion 
        #region LineTrip
        void AddLineTrip(DO.LineTrip lineTrip) 
        { //check if id exists
            DataSource.listLineTrip.Add(lineTrip.Clone());
        }
        DO.LineTrip RequestLineTrip(int lineId, TimeSpan StartAt) 
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
        {
            if (DataSource.listStations.FirstOrDefault(s => s.Code == station.Code) != null)//makes sure there are no duplicates
                throw new DO.StationCodeException(station.Code, $"Duplicate station code: {station.Code}");
            DataSource.listStations.Add(station.Clone());
        }
        DO.Station RequestStation(int code) 
        {
            DO.Station st = DataSource.listStations.Find(s => s.Code == code);//checks station. if exists st will get the value of the chosen station.

            if (st != null)//if st = null that means station does not exist
                return st.Clone();//returns the chosen station
            else
                throw new DO.StationCodeException(code, $"Station does't exist : {code}");
        }
        
        IEnumerable<DO.Station> RequestAllStations()// returns a copy of list of stations
        {
            return from Station in DataSource.listStations
                   select Station.Clone();
        }
        void UpdateStation(DO.Station station) 
        {
            DO.Station st = DataSource.listStations.Find(s => s.Code==station.Code );//checks station. if exists st will get the value of the chosen station.

            if (st != null)////if st = null that means station does not exist
            {
                DataSource.listStations.Remove(st);//remove 
                DataSource.listStations.Add(station.Clone());//add new updated station
            }
            else
                throw new DO.StationCodeException(station.Code, $"Station does't exist : {station.Code}");
        }
        void DeleteStation(int code) 
        {
            DO.Station st = DataSource.listStations.Find(s => s.Code == code);//checks station. if exists st will get the value of the chosen station.

            if (st != null)////if st = null that means station does not exist
            {
                DataSource.listStations.Remove(st);//remove 
                
            }
            else
                throw new DO.StationCodeException(code, $"Station does't exist : {code}");
        }
        #endregion
        #region Trip

        void AddTrip(DO.Trip trip) 
        { //need to check id chheck that username and if line id exists
            DataSource.listTrip.Add(trip.Clone()); 
        }
        DO.Trip RequestTrip(int id) 
        { }
       
        IEnumerable<DO.Trip> RequestAllTrips()//returns a copy of list of trips
        {
            return from Trip in DataSource.listTrip
                   select Trip.Clone();
        }
        void UpdateTrip(int id) 
        {
        }
        void DeleteTrip(int id)
        {
        }
        #endregion 
        #region User

        void AddUser(DO.User user)
        {
            if (DataSource.listUser.FirstOrDefault(u => u.UserName == user.UserName) != null)//makes sure there are no duplicates
               throw new DO.UserIdException(user.UserName, $"Duplicate UserName: {user.UserName}");
            DataSource.listUser.Add(user.Clone());
        }
        DO.User RequestUser(string userName)
        {
            
        }
        
        IEnumerable<DO.User> RequestAllUsers() //returns a copy of list of users
        {
            return from User in DataSource.listUser
                   select User.Clone();
        }
        void UpdateUser(string userName) { }
        void DeleteUser(string userName) { }
        #endregion
        #region AdjacentStations
        void AddAdjacentStations(DO.AdjacentStations Stations) { }
        DO.AdjacentStations RequestAdjacentStations(int station1, int station2)
        { }
        IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations()
        { }
        void UpdateAdjacentStations(DO.AdjacentStations Stations) 
        { }
        void DeleteAdjacentStations(int station1, int station2) 
        { }
        #endregion

    }
}
