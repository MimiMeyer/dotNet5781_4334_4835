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

        public int AddLine(DO.Line line) //adds line and returns running number
        {
            
        }
        public DO.Line RequestLine(int Id)//returns requested line by id
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);//gets the wanted xml

            Line line = (from per in linesRootElem.Elements()
                        where int.Parse(per.Element("Id").Value) == Id//only where the line has the sam id
                         select new Line()
                        {
                            Id = Int32.Parse(per.Element("Id").Value),//gets id
                            Code = Int32.Parse(per.Element("Code").Value),//gest bus number
                            Area = (Areas)Enum.Parse(typeof(Areas), per.Element("Area").Value),//gets area
                            FirstStation = Int32.Parse(per.Element("FirstStation").Value),//gets first station
                            LastStation = Int32.Parse(per.Element("LastStation").Value)//gets last station
                        } 
                        ).FirstOrDefault();//line equals the first line that has the same id

            if (line == null)//means that line doesnt exist and exeption is thrown
                throw new DO.LineIdException(Id, $"Line Doesn't exist: {Id}");

            return line;
        }
        public DO.Line RequestLineByCode(int code)//returns  requested line by code
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);//gets the wanted xml

            Line line = (from l in linesRootElem.Elements()
                      where int.Parse(l.Element("Code").Value) == code//only where the line has the sam code
                      select new Line()
                      {
                          Id = Int32.Parse(l.Element("Id").Value),//gets id
                          Code = Int32.Parse(l.Element("Code").Value),//gest bus number
                          Area = (Areas)Enum.Parse(typeof(Areas), l.Element("Area").Value),//gets area
                          FirstStation = Int32.Parse(l.Element("FirstStation").Value),//gets first station
                          LastStation = Int32.Parse(l.Element("LastStation").Value)//gets last station
                      }
                        ).FirstOrDefault();//line equals the first line that has the same bus Number

            if (line == null)//means that line doesnt exist and exeption is thrown
                throw new DO.LineIdException(code, $"Line Doesn't exist: {code}");

            return line;
        }
        public IEnumerable<DO.Line> RequestAllLines()//returns all lines
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);//gets the wanted xml

            return (from line in linesRootElem.Elements()//goes over all the items in lines
                    select new Line()
                    {
                        Id = Int32.Parse(line.Element("Id").Value),//gets id
                        Code = Int32.Parse(line.Element("Code").Value),//gets bus num
                        Area = (Areas)Enum.Parse(typeof(Areas), line.Element("Area").Value),//gets area
                        FirstStation = Int32.Parse(line.Element("FirstStation").Value),//gets first station
                        LastStation = Int32.Parse(line.Element("LastStation").Value)//gets last station
                    }
                   );
        }
        public void UpdateLine(DO.Line line)//updates line
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);//gets wanted xml

            XElement lin = (from l in linesRootElem.Elements()
                            where int.Parse(l.Element("ID").Value) == line.Id//finds the line with same id
                            select l).FirstOrDefault();

            if (lin != null)//the line exists
            {

                lin.Element("Id").Value = line.Id.ToString();//updating id
                lin.Element("Code").Value = line.Code.ToString();//updating code
                lin.Element("Area").Value = line.Area.ToString();//updating area
                lin.Element("FirstStation").Value = line.FirstStation.ToString();//updating first station
                lin.Element("LastStation").Value = line.LastStation.ToString();//updating last station
 
                XMLTools.SaveListToXMLElement(linesRootElem, linesPath);//updating xml
            }
            else//the line doesnt exist
                throw new DO.LineIdException(line.Id, $"Line Doesn't exist: {line.Id}");
        }
        public void DeleteLine(int id)
        {
            XElement linesRootElem = XMLTools.LoadListFromXMLElement(linesPath);//gets wanted xml

            XElement lin = (from l in linesRootElem.Elements()
                            where int.Parse(l.Element("Id").Value) == id//finds the line with the wante id
                            select l).FirstOrDefault();

            if (lin != null)//the line exists
            {
                lin.Remove();//deletes line
                XMLTools.SaveListToXMLElement(linesRootElem, linesPath);//updating xml
            }
            else//the line doesnt exist
                throw new DO.LineIdException(id, $"Line Doesn't exist: {id}");

        }


        #endregion
        #region LineStation
        public void AddLineStation(DO.LineStation Line)
        {
           
        }
        public DO.LineStation RequestLineStation(int Station, int lineId) { }
        public IEnumerable<DO.LineStation> RequestAllLinesStation(int id) { }
        public void UpdateLineStation(DO.LineStation Line) { }
        public void DeleteLineStationbyLine(int lineId) { }
        public void DeleteLineStationbyStation(int code) { }
        public void DeleteLineStation(int Station, int lineId) { }
        public IEnumerable<int> RequestStationsByLine(int lineID)
        {
           

        }
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

        public void AddUser(DO.User user) 
        { 
        }
        public DO.User RequestUser(string userName) 
        {
        }
        public IEnumerable<DO.User> RequestAllUsers()
        { 
        }
        public void UpdateUser(DO.User user) { }
        public void DeleteUser(string userName) { }
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(DO.AdjacentStations Stations) 
        { 
        }
        public DO.AdjacentStations RequestAdjacentStations(int station1, int station2)
        { 
        }
        public IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations() 
        { 
        }
        public void UpdateAdjacentStations(DO.AdjacentStations Stations) 
        {
        }
        public void DeleteAdjacentStations(int station1, int station2) 
        {
        }
        #endregion









    }
}
