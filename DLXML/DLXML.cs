using DLAPI;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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

        string linesPath = @"LinesXml.xml";//XElement and XMLSerializer
        string stationsPath = @"StationsXml.xml";  //XMLSerializer
        string lineStationsPath = @"LineStationsXml.xml"; //XMLSerializer
        //string usersPath = @"UsersXml.xml"; //XMLSerializer
        string lineTripsPath = @"LineTripsXml.xml"; //XElement
        //string tripsPath = @"TripsXml.xml"; //XMLSerializer
        string adjacentStationsPath = @"AdjacentStationsXml.xml"; //XMLSerializer
        string runningNuberPath = @"RunningNumberXml.xml";//XMLSerializer
        #endregion
        #region Line

        public int AddLine(DO.Line line) //adds line and returns running number
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            List<int> num = XMLTools.LoadListFromXMLSerializer<int>(runningNuberPath);
            line.Id = num.ElementAt(0);
            num = num.Select(x => x + 1).ToList();
            ListLines.Add(line); //no need to Clone()
            XMLTools.SaveListToXMLSerializer(ListLines, linesPath);
            XMLTools.SaveListToXMLSerializer(num,runningNuberPath );

            return line.Id;

        }
        public DO.Line RequestLine(int Id)//returns requested line by id
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            DO.Line line = ListLines.Find(l => l.Id == Id);


            if (line == null)//means that line doesnt exist and exeption is thrown
                throw new DO.LineIdException(Id, $"Line Doesn't exist: {Id}");

            return line;
        }
        public DO.Line RequestLineByCode(int code)//returns  requested line by code
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            DO.Line line = ListLines.Find(l => l.Code == code);
           

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
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            DO.Line li= ListLines.Find(l => l.Id == line.Id );//checks line station. if exists li will get the value of the chosen line.
            if (li != null)
            {
                ListLines.Remove(li);
                ListLines.Add(line); //no nee to Clone()
            }
            else//the line doesnt exist
                throw new DO.LineIdException(line.Id, $"Line Doesn't exist: {line.Id}");
            XMLTools.SaveListToXMLSerializer(ListLines, linesPath);
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
        public void AddLineStation(DO.LineStation lineStation)//adds station to line
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            if (!RequestStationsByLine(lineStation.LineId).Contains(lineStation.Station)) //if the station does not exist then you can add
            {

                ListLineStations.Add(lineStation); //no need to Clone()

                XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
            }
            else
            {
                throw new DO.LineIdException(lineStation.Station, $"station already exists in line: {lineStation.Station}");
            }

        }
        public DO.LineStation RequestLineStation(int Station, int lineId)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation sta = ListLineStations.Find(l => l.LineId == lineId && l.Station == Station);
            if (sta != null)
                return sta; //no need to Clone()
            else
            throw new DO.LineIdException(lineId, $"line Id does not exist: {lineId}");
        }
        public IEnumerable<DO.LineStation> RequestAllLinesStation(int id) //returns a  list of  Line stations by line
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            return from LineStation in ListLineStations.
                   FindAll(lineStation => lineStation.LineId == id)
                   select LineStation; //no need to Clone()
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation sta = ListLineStations.Find(l => l.LineId == lineStation.LineId && l.Station == lineStation.Station);//checks line station. if exists li will get the value of the chosen line.
            if (sta != null)
            {
                ListLineStations.Remove(sta);
                ListLineStations.Add(lineStation); //no nee to Clone()
            }
            else
                throw new DO.LineIdException(lineStation.LineId, $"line Id does not exist: {lineStation.LineId}");

            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }
        public void DeleteLineStationbyLine(int lineId)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            if (RequestStationsByLine(lineId) != null)//if it equels null it means line does not exist and will send exception
            {
                ListLineStations.RemoveAll(lineStation => lineStation.LineId == lineId);//removes all line stations that have the wanted line.
            }
            else
                throw new DO.LineIdException(lineId, $"line Id does not exist: {lineId}");
            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }
        public void DeleteLineStationbyStation(int code)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            if (RequestLinesByStation(code) != null)//if it equels null it means no lines does not go through requested station
            {
                ListLineStations.RemoveAll(lineStation => lineStation.Station == code);//removes all line stations that have the wanted station.
            }
            else
                throw new DO.StationCodeException(code, $"Station code does not exist: {code}");
            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);


        }
        public void DeleteLineStation(int Station, int lineId)
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation li = ListLineStations.Find(l => l.LineId == lineId && l.Station == Station);//checks line station. if exists li will get the value of the chosen lineStation.

            if (li != null)
            {
                ListLineStations.Remove(li);
            }
            else
                throw new DO.StationCodeException(Station, $"linestation does not exist: {Station}");

            XMLTools.SaveListToXMLSerializer(ListLineStations, lineStationsPath);
        }
        public IEnumerable<int> RequestStationsByLine(int lineID)//returns list of stations for requested line.
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            return ListLineStations.FindAll(lineStation => lineStation.LineId == lineID).
                                             OrderBy(lineStation => lineStation.LineStationIndex).//orders by index to make sure we get the list in the right order
                                             Select(lineStation => lineStation.Station);

        }
        public IEnumerable<int> RequestLinesByStation(int Station)//returns list of lines for requested station. 
        {
            List<LineStation> ListLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            return ListLineStations.FindAll(lineStation => lineStation.Station == Station).
                                              Select(lineStation => lineStation.LineId);
        }
        public IEnumerable<DO.Line> GetLinesByStation(int Station)//returns list of lines for requested station.
        {
            List<Line> ListLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            IEnumerable<int> lines = RequestLinesByStation(Station);//gets line ids
            IEnumerable<DO.Line> DOlines = ListLines.FindAll(line => lines.Contains(line.Id));//only adds line if it exists in line
            return DOlines;


        }
        #endregion
        #region LineTrip
        public void AddLineTrip(DO.LineTrip lineTrip) //adds linetrip
        {
            XElement lineTripsRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);

            XElement lineTripElem = new XElement("LineTrip",
                                 new XElement("LineId", lineTrip.LineId.ToString()),
                                 new XElement("StartAt", lineTrip.StartAtTotalSeconds));

            lineTripsRootElem.Add(lineTripElem);

            XMLTools.SaveListToXMLElement(lineTripsRootElem, lineTripsPath);
        }
        public DO.LineTrip RequestLineTrip(int lineId, TimeSpan StartAt) //returns require line trip
        {
            XElement lineTripssRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);//gets the wanted xml

            LineTrip trip = (from li in lineTripssRootElem.Elements()
                             where int.Parse(li.Element("LineId").Value) == lineId && TimeSpan.Parse(li.Element("StartAt").Value) == StartAt //only where the linetrip has the same id and start time
                             select new LineTrip()
                             {
                                 LineId = Int32.Parse(li.Element("LineId").Value),//gets id
                                 StartAt= TimeSpan.Parse(li.Element("StartAt").Value)//gets start time
                             }
                        ).FirstOrDefault();//line equals the first line that has the same id

            if (trip == null)//means that line doesnt exist and exeption is thrown
                throw new DO.LineIdException(lineId, $"Line trip Doesn't exist: {lineId}");
            return trip;
        }
        public IEnumerable<DO.LineTrip> RequestAllLineTripsByLine(int lineId)//returns all LineTrips for requested line
        {
            XElement lineTripsRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);//gets the wanted xml

            return (from li in lineTripsRootElem.Elements()//goes over all the items in linetrips
                    where int.Parse(li.Element("LineId").Value) == lineId
                    orderby TimeSpan.Parse(li.Element("StartAt").Value)
                    select new LineTrip()
                    {
                        LineId = Int32.Parse(li.Element("LineId").Value),//gets id
                        StartAtTotalSeconds = double.Parse(li.Element("StartAt").Value),//gets start time
                        StartAt=TimeSpan.FromSeconds(double.Parse(li.Element("StartAt").Value))
                    }
                   );

        }

        public IEnumerable<DO.LineTrip> RequestAllLineTrips() //returns all line trips
        {
            XElement lineTripsRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);//gets the wanted xml

            return (from li in lineTripsRootElem.Elements()//goes over all the items in linetrips
                    select new LineTrip()
                    {
                        LineId = Int32.Parse(li.Element("LineId").Value),//gets id
                        StartAt = TimeSpan.Parse(li.Element("StartAt").Value)//gets start time
                    }
                   );
        }
        public void UpdateLineTrip(DO.LineTrip lineTrip) //updates line trips
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int lineId, TimeSpan StartAt) //delets linetrips
        {


            XElement lineTripsRootElem = XMLTools.LoadListFromXMLElement(lineTripsPath);//gets wanted xml

            XElement lin = (from l in lineTripsRootElem.Elements()
                            where int.Parse(l.Element("LineId").Value) == lineId && double.Parse(l.Element("StartAt").Value) == StartAt.TotalSeconds //finds the line with the wante id
                            select l).FirstOrDefault();

            if (lin != null)//the line exist
            {
                lin.Remove();//deletes line
                XMLTools.SaveListToXMLElement(lineTripsRootElem, lineTripsPath);//updating xml
            }
            else//the line doesnt exist
            {
                throw new DO.LineIdException(lineId, $"Trip Line Doesn't exist: {lineId}");
        }
        }
        #endregion
        #region Station

        public void AddStation(DO.Station station) //adds station
        {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            if (ListStations.FirstOrDefault(s => s.Code == station.Code) != null)
                throw new DO.StationCodeException(station.Code, $"Duplicate station code: {station.Code}");

            ListStations.Add(station); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListStations, stationsPath);
        }
        public DO.Station RequestStation(int code)
        {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station sta = ListStations.Find(s => s.Code == code);
            if (sta != null)
                return sta; //no need to Clone()
            else
                throw new DO.StationCodeException(code, $"Station does't exist : {code}");


        }
        public IEnumerable<DO.Station> RequestAllStations()
        {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            return from Station in ListStations
                   select Station; //no need to Clone()
        }

        public void UpdateStation(DO.Station station)
        {
            List<Station> ListStationss = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station sta = ListStationss.Find(s => s.Code == station.Code);//checks station. if exists sta will get the value of the chosen station.
            if (sta != null)
            {
                ListStationss.Remove(sta);
                ListStationss.Add(station); //no nee to Clone()
            }
            else
                throw new DO.StationCodeException(station.Code, $"Station does't exist : {station.Code}");

            XMLTools.SaveListToXMLSerializer(ListStationss, stationsPath);
        }
        public void DeleteStation(int code)
        {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station st = ListStations.Find(s => s.Code == code);//checks station. if exists st will get the value of the chosen station.

            if (st != null)
            {
                ListStations.Remove(st);
            }
            else
                throw new DO.StationCodeException(code, $"Station does't exist : {code}");

            XMLTools.SaveListToXMLSerializer(ListStations, stationsPath);
        }
        #endregion
        #region AdjacentStations
        public void AddAdjacentStations(DO.AdjacentStations Stations)
        {
            List<AdjacentStations> ListAdjacentStationss = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            ListAdjacentStationss.Add(Stations); //no need to Clone()

            XMLTools.SaveListToXMLSerializer(ListAdjacentStationss, adjacentStationsPath);

        }
        public DO.AdjacentStations RequestAdjacentStations(int station1, int station2)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            DO.AdjacentStations sta = ListAdjacentStations.Find(s => s.Station1 == station1 && s.Station2 == station2);
            if (sta != null)
                return sta; //no need to Clone()
            else
                return null;
        }
        public IEnumerable<DO.AdjacentStations> RequestAllAdjacentStations()
        {
            List<AdjacentStations> ListAdjacentStationss = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            return from AdjacentStations in ListAdjacentStationss
                   select AdjacentStations; //no need to Clone()
        }
        public void UpdateAdjacentStations(DO.AdjacentStations Stations)
        {
            List<AdjacentStations> ListAdjacentStationss = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            DO.AdjacentStations sta = ListAdjacentStationss.Find(s => s.Station1 == Stations.Station1 && s.Station2 == Stations.Station2);//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.;
            if (sta != null)
            {
                ListAdjacentStationss.Remove(sta);
                ListAdjacentStationss.Add(Stations); //no nee to Clone()
            }
            else
                throw new DO.AdjacentStationseException(Stations.Station1, Stations.Station2, "AdjacentStations does't exist:");

            XMLTools.SaveListToXMLSerializer(ListAdjacentStationss, adjacentStationsPath);
        }
        public void DeleteAdjacentStations(int station1, int station2)
        {

            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationsPath);

            DO.AdjacentStations st = ListAdjacentStations.Find(s => s.Station1 == station1 && s.Station2 == station2);//checks AdjacentStations. if exists st will get the values of the chosen AdjacentStations.

            if (st != null)
            {
                ListAdjacentStations.Remove(st);
            }
            else
                throw new DO.AdjacentStationseException(station1, station2, "AdjacentStations does't exist:");

            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationsPath);
        }
        #endregion
        #region Trip

        public int AddTrip(DO.Trip trip)
        {
            throw new NotImplementedException();
        }
        public DO.Trip RequestTrip(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.Trip> RequestAllTrips()
        {
            throw new NotImplementedException();
        }
        public void UpdateTrip(DO.Trip trip)
        {
            throw new NotImplementedException();
        }
        public void DeleteTrip(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region User

        public void AddUser(DO.User user)
        {
            throw new NotImplementedException();
        }

        public DO.User RequestUser(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.User> RequestAllUsers()
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(DO.User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }
        #endregion










    }
}
