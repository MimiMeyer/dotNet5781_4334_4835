using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    sealed class DLXML : IDL    //internal
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion
       
        #region DS XML Files
       
        string linesPath = @"LinesXml.xml";//XElement
        string stationsPath = @"StationsXml.xml";  //XMLSerializer
        string lineStationsPath = @"LineStationsXml.xml"; //XMLSerializer
        string usersPath = @"UsersXml.xml"; //XMLSerializer
        string lineTripsPath = @"LineTripsXml.xml"; //XMLSerializer
        string tripsPath = @"TripsXml.xml"; //XMLSerializer
        string adjacentStationsPath = @"AdjacentStationsXml.xml"; //XMLSerializer
        #endregion
        #region Line

        public int AddLine(DO.Line line) 
        {
            
        }
        public DO.Line RequestLine(int Id)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);

            Line line = (from per in linesRootElem.Elements()
                        where int.Parse(per.Element("Id").Value) == Id
                        select new Line()
                        {
                            Id = Int32.Parse(per.Element("Id").Value),
                            Code = Int32.Parse(per.Element("Code").Value),
                            Area = (Areas)Enum.Parse(typeof(Areas), per.Element("Area").Value),
                            FirstStation = Int32.Parse(per.Element("FirstStation").Value),
                            LastStation = Int32.Parse(per.Element("LastStation").Value)
                        } 
                        ).FirstOrDefault();

            if (line == null)
                throw new DO.LineIdException(Id, $"Line Doesn't exist: {Id}");

            return line;
        }
        public DO.Line RequestLineByCode(int code)//returns  requested line by code
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);

            Line line = (from per in linesRootElem.Elements()
                      where int.Parse(per.Element("Code").Value) == code
                      select new Line()
                      {
                          Id = Int32.Parse(per.Element("Id").Value),
                          Code = Int32.Parse(per.Element("Code").Value),
                          Area = (Areas)Enum.Parse(typeof(Areas), per.Element("Area").Value),
                          FirstStation = Int32.Parse(per.Element("FirstStation").Value),
                          LastStation = Int32.Parse(per.Element("LastStation").Value)
                      }
                        ).FirstOrDefault();

            if (line == null)
                throw new DO.LineIdException(code, $"Line Does Not exist: {code}");

            return line;
        }
        public IEnumerable<DO.Line> RequestAllLines()
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);

            return (from l in linesRootElem.Elements()
                    select new Line()
                    {
                        Id = Int32.Parse(l.Element("Id").Value),
                        Code = Int32.Parse(l.Element("Code").Value),
                        Area = (Areas)Enum.Parse(typeof(Areas), l.Element("Area").Value),
                        FirstStation = Int32.Parse(l.Element("FirstStation").Value),
                        LastStation = Int32.Parse(l.Element("LastStation").Value)
                    }
                   );
        }
        public void UpdateLine(DO.Line line)
        {
        }
        public void DeleteLine(int id)
        { 
        }


        #endregion
        #region LineStation
        public void AddLineStation(DO.LineStation Line) { }
        public DO.LineStation RequestLineStation(int Station, int lineId) { }
        public IEnumerable<DO.LineStation> RequestAllLinesStation(int id) { }
        public void UpdateLineStation(DO.LineStation Line) { }
        public void DeleteLineStationbyLine(int lineId) { }
        public void DeleteLineStationbyStation(int code) { }
        public void DeleteLineStation(int Station, int lineId) { }
        public IEnumerable<int> RequestStationsByLine(int lineID) { }
        public IEnumerable<int> RequestLinesByStation(int Station) { }
        public IEnumerable<DO.Line> GetLinesByStation(int Station) { }
        #endregion
        #region LineTrip
        public void AddLineTrip(DO.LineTrip lineTrip) { }
        public DO.LineTrip RequestLineTrip(int lineId, TimeSpan StartAt) { }
        public IEnumerable<DO.LineTrip> RequestAllLineTrips() { }
        public void UpdateLineTrip(DO.LineTrip lineTrip) { }
        public void DeleteLineTrip(int lineId, TimeSpan StartAt) { }
        #endregion
        #region Station

        public void AddStation(DO.Station station) { }
        public DO.Station RequestStation(int code) { }
        public IEnumerable<DO.Station> RequestAllStations() { }
        public void UpdateStation(DO.Station station) { }
        public void DeleteStation(int code) { }
        #endregion
        #region Trip

        public int AddTrip(DO.Trip trip) { }
        public DO.Trip RequestTrip(int id) { }
        public IEnumerable<DO.Trip> RequestAllTrips() { }
        public void UpdateTrip(DO.Trip trip) { }
        public void DeleteTrip(int id) { }
        #endregion
        #region User

        public void AddUser(DO.User user) { }
        public DO.User RequestUser(string userName) { }
        public IEnumerable<DO.User> RequestAllUsers() { }
        public void UpdateUser(DO.User user) { }
        public void DeleteUser(string userName) { }
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(DO.AdjacentStations Stations) { }
        public DO.AdjacentStations RequestAdjacentStations(int station1, int station2) { }
        public IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations() { }
        public void UpdateAdjacentStations(DO.AdjacentStations Stations) { }
        public void DeleteAdjacentStations(int station1, int station2) { }
        #endregion









    }
}
