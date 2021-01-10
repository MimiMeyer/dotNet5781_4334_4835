using DLAPI;
using DO;
using DS;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DL
{//look at addline
    sealed class DLObject : IDL

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion
        //Implement IDL methods, CRUD
        #region Line

        public int AddLine(DO.Line line)
        {
            line.Id = RunningNumber.RunningNumberID;
            DataSource.listLines.Add(line.Clone());
            RunningNumber.RunningNumberID++;
            return line.Id;
        }
        public DO.Line RequestLine(int Id)
        {
            DO.Line li = DataSource.listLines.Find(l => l.Id == Id);//checks line. if exists li will get the value of the chosen line.

            if (li != null)//if li = null that means line does not exist
                return li.Clone();//returns the chosen line
            else
                throw new DO.LineIdException(Id, $"line Id does not exist: {Id}");
        }
        public DO.Line RequestLineByCode(int code)
        {
            DO.Line li = DataSource.listLines.Find(l => l.Code == code);//checks line. if exists li will get the value of the chosen line.

            if (li != null)//if li = null that means line does not exist
                return li.Clone();//returns a copy of the chosen line
            else
                throw new DO.LineIdException(code, $"line number does not exist: {code}");
        }
        public IEnumerable<DO.Line> RequestAllLines()//returns a copy of list of lines
        {
            return from Line in DataSource.listLines
                   select Line.Clone();
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line li = DataSource.listLines.Find(l => l.Id == line.Id);//checks line. if exists li will get the value of the chosen line.

            if (li != null)////if li = null that means line does not exist
            {
                DataSource.listLines.Remove(li);//remove 
                DataSource.listLines.Add(line.Clone());//add new uodated line
            }
            else
                throw new DO.LineIdException(line.Id, $"line Id does not exist: {line.Id}");
        }
        public void DeleteLine(int id)
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
        public void AddLineStation(DO.LineStation lineStation) //adds station to bus
        {

            if (!RequestStationsByLine(lineStation.LineId).Contains(lineStation.Station)) //if the station does not exist then you can add
            {
                DataSource.listLineStation.Add(lineStation.Clone()); //add line station to list
            }
            throw new DO.LineIdException(lineStation.Station, $"station already exists in line: {lineStation.Station}");

        }
        public IEnumerable<int> RequestStationsByLine(int lineID)//returns list of stations for requested line.
        {
            return DataSource.listLineStation.FindAll(lineStation => lineStation.LineId == lineID).
                                              Select(lineStation => lineStation.Station);

        }
        public IEnumerable<int> RequestLinesByStation(int Station)//returns list of lines for requested station.
        {
            return DataSource.listLineStation.FindAll(lineStation => lineStation.Station == Station).
                                              Select(lineStation => lineStation.LineId);

        }
       public IEnumerable<DO.Line> GetLinesByStation(int Station)//returns list of lines for requested station.
        {
            IEnumerable<int> lines = RequestLinesByStation(Station);//gets line ids
            IEnumerable < DO.Line > DOlines= DataSource.listLines.FindAll(line => lines.Contains(line.Id));//only adds line if it exists in line
            return DOlines;
        }
       
        public DO.LineStation RequestLineStation(int Station, int lineId)//returns line station if it exists
        {
            DO.LineStation li = DataSource.listLineStation.Find(l => l.LineId == lineId);//checks line station. if exists li will get the value of the chosen line.

            if (li == null)//if li = null that means line station does not exist

                throw new DO.LineIdException(lineId, $"line Id does not exist: {lineId}");


            if (!RequestStationsByLine(li.LineId).Contains(Station)) //checks if station exists in line

                throw new DO.StationCodeException(Station, $"Station does't exist : {Station}");


            return li.Clone();//returns the chosen line

        }


        public IEnumerable<DO.LineStation> RequestAllLinesStation(int lineID) //returns a copy of list of  Line stations by line
        {
            return from LineStation in DataSource.listLineStation.
                   FindAll(lineStation => lineStation.LineId == lineID)
                   select LineStation.Clone();
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            DO.LineStation li = DataSource.listLineStation.Find(l => l.LineId == lineStation.LineId&& l.Station == lineStation.Station);//checks line station. if exists li will get the value of the chosen line.

            if (li != null)//if li = null that means line station does not exist
            {

                DataSource.listLineStation.Remove(li);//first removes
                DataSource.listLineStation.Add(lineStation);//updating
            }
            else
                throw new DO.LineIdException(lineStation.LineId, $"line Id does not exist: {lineStation.LineId}");

        }
        public void DeleteLineStationbyLine(int lineId)//deletes all line stations with same line
        {
            if (RequestStationsByLine(lineId) != null)//if it equels null it means line does not exist and will send exception
            {
                DataSource.listLineStation.RemoveAll(lineStation => lineStation.LineId == lineId);//removes all line stations that have the wanted line.
            }
            else
                throw new DO.LineIdException(lineId, $"line Id does not exist: {lineId}");
        }
       public void DeleteLineStationbyStation(int station) ////deletes all line stations with same Station
        {
            if (RequestLinesByStation(station) != null)//if it equels null it means no lines does not go through requested station
            {
                DataSource.listLineStation.RemoveAll(lineStation => lineStation.Station == station);//removes all line stations that have the wanted station.
            }
            else
                throw new DO.StationCodeException(station, $"Station code does not exist: {station}");
        }
        public void DeleteLineStation(int Station, int lineId)
        {
            DO.LineStation li = DataSource.listLineStation.Find(l => l.LineId == lineId && l.Station == Station);//checks line station. if exists li will get the value of the chosen lineStation.

            if (li == null)//if li = null that means line station does not exist
            {
                throw new DO.StationCodeException(Station, $"linestation does not exist: {Station}");

            }
            else
                DataSource.listLineStation.Remove(li);

                
        }
        #endregion
        #region LineTrip
        public void AddLineTrip(DO.LineTrip lineTrip)
        {//dont need to check for duplicates there can be busses starting at the same time because it's a line and not a physical bus
            DataSource.listLineTrip.Add(lineTrip.Clone());//adding new lineTrip
        }
        public DO.LineTrip RequestLineTrip(int lineId, TimeSpan StartAt)
        {
            DO.LineTrip li = DataSource.listLineTrip.Find(l => l.LineId == lineId && l.StartAt == StartAt);//checks linetrip. if exists li will get the value of the chosen linetrip.

            if (li != null)//if li = null that means linetrip does not exist
                return li.Clone();//returns the chosen line
            else
                throw new DO.LineIdException(lineId, $"linetrip does not exist for  this start time and linetrip : {lineId}");
        }

        public IEnumerable<DO.LineTrip> RequestAllLineTrips()//returns a copy of list of line trips
        {
            return from LineTrip in DataSource.listLineTrip
                   select LineTrip.Clone();
        }
        public void UpdateLineTrip(DO.LineTrip lineTrip)
        {
            DO.LineTrip li = DataSource.listLineTrip.Find(l => l.LineId == lineTrip.LineId);//checks lineTrip. if exists li will get the value of the chosen lineTrip.

            if (li != null)////if li = null that means lineTrip does not exist
            {
                DataSource.listLineTrip.Remove(li);//remove 
                DataSource.listLineTrip.Add(lineTrip.Clone());//add new uodated lineTrip
            }
            else
                throw new DO.LineIdException(lineTrip.LineId, $"lineTrip does not exist : {lineTrip.LineId}");
        }
        public void DeleteLineTrip(int lineId, TimeSpan StartAt)
        {
            DO.LineTrip li = DataSource.listLineTrip.Find(l => l.LineId == lineId && l.StartAt == StartAt);//checks linetrip. if exists li will get the value of the chosen linetrip.
            DO.LineTrip Id = DataSource.listLineTrip.Find(l => l.LineId == lineId);
            if (li != null)//if li = null that means linetrip does not exist
                DataSource.listLineTrip.Remove(li);//remove 
            else
                if (Id != null)//if Id = null it means that the linetrip doesnt exist at all
                throw new DO.LineIdException(lineId, $"linetrip does not exist for this start time : {lineId}");
            else
                throw new DO.LineIdException(lineId, $"linetrip does not exist : {lineId}");
        }
        #endregion
        #region Station

        public void AddStation(DO.Station station)//Add station to station list
        {
            if (DataSource.listStations.FirstOrDefault(s => s.Code == station.Code) != null)//makes sure there are no duplicates
                throw new DO.StationCodeException(station.Code, $"Duplicate station code: {station.Code}");
            DataSource.listStations.Add(station.Clone());
        }
        public DO.Station RequestStation(int code)
        {
            DO.Station st = DataSource.listStations.Find(s => s.Code == code);//checks station. if exists st will get the value of the chosen station.

            if (st != null)//if st = null that means station does not exist
                return st.Clone();//returns the chosen station
            else
                throw new DO.StationCodeException(code, $"Station does't exist : {code}");
        }

        public IEnumerable<DO.Station> RequestAllStations()// returns a copy of list of stations
        {
            return from Station in DataSource.listStations
                   select Station.Clone();
        }
        public void UpdateStation(DO.Station station)
        {
            DO.Station st = DataSource.listStations.Find(s => s.Code == station.Code);//checks station. if exists st will get the value of the chosen station.

            if (st != null)////if st = null that means station does not exist
            {
                DataSource.listStations.Remove(st);//remove 
                DataSource.listStations.Add(station.Clone());//add new updated station
            }
            else
                throw new DO.StationCodeException(station.Code, $"Station does't exist : {station.Code}");
        }
        public void DeleteStation(int code)
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

        public int AddTrip(DO.Trip trip)
        {
            
            
            trip.Id= RunningNumber.RunningTripID;
            DataSource.listTrip.Add(trip.Clone());
            RunningNumber.RunningTripID++;
            return trip.Id;
        }
        public DO.Trip RequestTrip(int id)
        {
            DO.Trip tr = DataSource.listTrip.Find(t => t.Id == id);//checks trip. if exists tr will get the value of the chosen station.

            if (tr != null)//if tr= null that means trip does not exist
                return tr.Clone();//returns the chosen trip
            else
                throw new DO.StationCodeException(id, $"Trip does't exist : {id}");
        }

        public IEnumerable<DO.Trip> RequestAllTrips()//returns a copy of list of trips
        {
            return from Trip in DataSource.listTrip
                   select Trip.Clone();
        }
        public void UpdateTrip(DO.Trip trip)
        {
            DO.Trip tr = DataSource.listTrip.Find(t => t.Id == trip.Id);//checks trip. if exists tr will get the value of the chosen station.

            if (tr != null)//if tr= null that means trip does not exist
            {
                DataSource.listTrip.Remove(tr);//remove 
                DataSource.listTrip.Add(trip.Clone());//add new updated trip
            }

            else
                throw new DO.StationCodeException(trip.Id, $"Trip does't exist : {trip.Id}");
        }
        public void DeleteTrip(int id)
        {
            DO.Trip tr = DataSource.listTrip.Find(t => t.Id == id);//checks trip. if exists tr will get the value of the chosen station.

            if (tr != null)//if tr= null that means trip does not exist
            {
                DataSource.listTrip.Remove(tr);//remove 
            }
            else
                throw new DO.StationCodeException(id, $"Trip does't exist : {id}");
        }
        #endregion
        #region User

        public void AddUser(DO.User user)
        {
            if (DataSource.listUser.FirstOrDefault(u => u.UserName == user.UserName) != null)//makes sure there are no duplicates
                throw new DO.UserIdException(user.UserName, $"Duplicate UserName: {user.UserName}");
            DataSource.listUser.Add(user.Clone());
        }
        public DO.User RequestUser(string userName)
        {
            DO.User us = DataSource.listUser.Find(u => u.UserName == userName);//checks user. if exists tr will get the value of the chosen user.

            if (us != null)//if us= null that means user does not exist
                return us.Clone();//returns the chosen user
            else
                throw new DO.UserIdException(userName, $"UserName does not exist: {userName}");
        }

        public IEnumerable<DO.User> RequestAllUsers() //returns a copy of list of users
        {
            return from User in DataSource.listUser
                   select User.Clone();
        }
        public void UpdateUser(DO.User user)
        {
            DO.User us = DataSource.listUser.Find(u => u.UserName == user.UserName);//checks user. if exists tr will get the value of the chosen user.

            if (us != null)//if us= null that means user does not exist
            {
                DataSource.listUser.Remove(us);//removes 
                DataSource.listUser.Add(user);//updating

            }
            else
                throw new DO.UserIdException(user.UserName, $"UserName does not exist: {user.UserName}");
        }
        public void DeleteUser(string userName)
        {
            DO.User us = DataSource.listUser.Find(u => u.UserName == userName);//checks user. if exists tr will get the value of the chosen user.

            if (us != null)//if us= null that means user does not exist
            {
                DataSource.listUser.Remove(us);//deleting the user
            }
            else
                throw new DO.UserIdException(userName, $"UserName does not exist: {userName}");
        }
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(DO.AdjacentStations stations)//add AdjacentStations
        {
            DataSource.listAdjacentStations.Add(stations.Clone());
        }
        public DO.AdjacentStations RequestAdjacentStations(int station1, int station2)
        {
            DO.AdjacentStations st = DataSource.listAdjacentStations.Find(s => s.Station1 == station1 && s.Station2 == station2);//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.

            if (st != null)//if st = null that means AdjacentStations does not exist
                return st.Clone();//returns the chosen AdjacentStations
            else
                throw new DO.AdjacentStationseException(station1, station2, "AdjacentStations does't exist:");
        }
        public DO.AdjacentStations RequestOneAdjacentStation(int station1)//for bl to get time and distance
        {
            DO.AdjacentStations st = DataSource.listAdjacentStations.Find(s => s.Station1 == station1 );//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.

            if (st != null)//if st = null that means AdjacentStations does not exist
                return st.Clone();//returns the chosen AdjacentStations
            else
                return null;
        }
        public IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations()//returns all AdjacentStations
        {
            return from AdjacentStations in DataSource.listAdjacentStations
                   select AdjacentStations.Clone();
        }
        public void UpdateAdjacentStations(DO.AdjacentStations Stations)
        {
            DO.AdjacentStations st = DataSource.listAdjacentStations.Find(s => s.Station1 == Stations.Station1 && s.Station2 == Stations.Station2);//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.

            if (st != null)//if st = null that means AdjacentStations does not exist
            {
                DataSource.listAdjacentStations.Remove(st);//remove
                DataSource.listAdjacentStations.Add(Stations);//updates
            }
            else
                throw new DO.AdjacentStationseException(Stations.Station1, Stations.Station2, "AdjacentStations does't exist:");
        }
        public void DeleteAdjacentStations(int station1, int station2)
        {
            DO.AdjacentStations st = DataSource.listAdjacentStations.Find(s => s.Station1 == station1 && s.Station2 == station2);//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.

            if (st != null)//if st = null that means AdjacentStations does not exist
            {
                DataSource.listAdjacentStations.Remove(st);//deletes requested AdjacentStations.
            }
            else
                throw new DO.AdjacentStationseException(station1, station2, "AdjacentStations does't exist:");
        }
        #endregion

    }
}
