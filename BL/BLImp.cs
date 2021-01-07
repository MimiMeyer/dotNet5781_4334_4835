using BLAPI;
using DLAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    class BLImp : IBL
    {
        Random r = new Random();
        IDL dl = DLFactory.GetDL();
        #region Line
        BO.Line LineDoBoAdapter(DO.Line LineDO) //convert  do to bo
        {
            BO.Line LineBO = new BO.Line();
            int Id = LineDO.Id;
            LineBO.Stations = dl.RequestStationsByLine(Id);
            LineDO.CopyPropertiesTo(LineBO);//copys the properties from do to bo for the Line
            for (int i = 0; i < LineBO.Stations.Count(); i++)//list will go over 
            {
                DO.AdjacentStations st=dl.RequestAdjacentStations(LineBO.Stations.ElementAt(i), LineBO.Stations.ElementAt(i + 1));//gets the requested AdjacentStation for the time and distance
                BO.LineStation lineStation= new BO.LineStation();//new line station
                lineStation.Distance = st.Distance;//gets the AdjacentStation distance
                lineStation.Time = st.Time;//gets the AdjacentStation time
                lineStation.LineId = LineBO.Id;//gets the line
                lineStation.Station = LineBO.Stations.ElementAt(i);//gets the station
                lineStation.LineStationIndex = i;//gets the index
                AddStationToLine(lineStation);//adds the line station
                    
            }
            return LineBO;
        }
        public BO.Line GetLine(int id)//returns requested line
        {
            DO.Line lineDO;
            try
            {
                lineDO = dl.RequestLine(id);
            }
            catch (DO.LineIdException ex)
            {
                throw new BO.LineIdException("line Id does not exist", ex);
            }
            return LineDoBoAdapter(lineDO);
        }
        public IEnumerable<BO.Line> GetAlllines()//returns all lines
        {

            return from lineDO in dl.RequestAllLines()//gets all lines from the function RequestAllLines
                   orderby lineDO.Id//orders by id number
                   select LineDoBoAdapter(lineDO);//each line goes to functionand changes to bo
        }

        public void AddLine(BO.Line line)//adds line
        {
            DO.Line LineDO = new DO.Line();
            line.CopyPropertiesTo(LineDO);//copys line properties into LineDO
            int count = GetAlllines().Count(l => l.Code == line.Code);
            if (count >= 2)// throws exception if line already appears twice in list.
            {
                throw new BO.LineIdException(line.Code, "Line Number already has back and forth buses");
            }
            if (count == 1)

            {
                DO.Line Line1 = dl.RequestLineByCode(line.Code);//returns the requested line that has the same bus line number.
                if (Line1.FirstStation != LineDO.LastStation || LineDO.FirstStation != Line1.LastStation)//makes sure added line is the opposite route if has the same bus line number.
                    throw new BO.LineIdException(line.Code, "The line is not traveling in the opposite direction so can't be added");
                try
                {
                    DO.Station st = dl.RequestStation(LineDO.FirstStation);//if station does not exist will throw exception
                    st = dl.RequestStation(LineDO.LastStation);//if station does not exist will throw exception
                    line.Id = dl.AddLine(LineDO);//if exception was not thrown will addline
                    line.Stations.ToList().Add(line.FirstStation);//adding first station to the list of stations
                    line.Stations.ToList().Add(line.LastStation);//adding last station to the list of stations
                    BO.LineStation first = new BO.LineStation();
                    BO.LineStation last = new BO.LineStation();
                    first.Station = line.FirstStation;//inializing first station
                    first.LineStationIndex = 0;
                    first.LineId = line.Id;
                    last.Station = line.LastStation;//inializing last station
                    last.LineStationIndex = 1;
                    last.LineId = line.Id;
                    AddStationToLine(first);//adding to list
                    AddStationToLine(last);//adding to list
                }
                catch (DO.StationCodeException ex)
                {
                    throw new BO.StationCodeException("station Code does not exist", ex);
                }

            }
            if (count == 0)
            {
                try
                {
                    DO.Station st = dl.RequestStation(LineDO.FirstStation);//if station does not exist will throw exception
                    st = dl.RequestStation(LineDO.LastStation);//if station does not exist will throw exception
                    dl.AddLine(LineDO);//if exception was not thrown will addline
                }
                catch (DO.StationCodeException ex)
                {
                    throw new BO.StationCodeException("station Code does not exist", ex);
                }

            }

        }

        public void UpdateLine(BO.Line line)//updates a line
        {
            DO.Line LineDO = new DO.Line();
            line.CopyPropertiesTo(LineDO);//copys line properties into LineDO
            try
            {
                dl.UpdateLine(LineDO);//updates and if does not exist will throw exception
            }
            catch (DO.LineIdException ex)
            {
                throw new BO.LineIdException("line Id does not exist", ex);
            }
        }


        public void DeleteLine(int Id)//deletes a line
        {
            try
            {
                dl.DeleteLine(Id);//deletes the line
                dl.DeleteLineStationbyLine(Id);//deletes all the stations for that line

            }
            catch (DO.LineIdException ex)//if line id does not exist will throw exception
            {
                throw new BO.LineIdException("line Id does not exist", ex);
            }
        }
        #endregion
        #region Station
        BO.Station StationDoBoAdapter(DO.Station StationDO)//convert do to bo
        {
            BO.Station stationBO = new BO.Station();
            int code = StationDO.Code;
            StationDO.CopyPropertiesTo(stationBO);//copys the properties from do to bo for the station
            return stationBO;
        }
        public BO.Station GetStation(int code)//returns requested station
        {
            DO.Station StationDO;
            try
            {
                StationDO = dl.RequestStation(code);//gets the requested station and if does not exist will throw exception
            }
            catch (DO.StationCodeException ex)
            {
                throw new BO.StationCodeException("Station Id does not exist", ex);
            }
            return StationDoBoAdapter(StationDO);//returns the Station if did not exist will return null
        }
        public IEnumerable<BO.Station> GetAllStations()//returns all stations
        {
            return from stationDO in dl.RequestAllStations()//gets all stations from the function RequestAllStations
                   orderby stationDO.Code//orders by station code
                   select StationDoBoAdapter(stationDO);//each Station 
        }
        public void AddStation(BO.Station station)//adds station
        {
            DO.Station StationDO = new DO.Station();
            station.CopyPropertiesTo(StationDO);//copys station properties into StationDO
            if (station.Code < 0 || station.Code >= 1000000)//checks if station code is under 7 didgits
            {
                throw new BO.StationCodeException(station.Code, "Station code must be under 7 digits");
            }
            if (station.Lattitude < 31 || station.Lattitude > 33.3)
            {
                throw new BO.StationCoordinatesException(station.Lattitude, "Lattitude must be between -31 to 33.3");
            }
            if (station.Longitude < 34.3 || station.Longitude > 35.5)
            {
                throw new BO.StationCoordinatesException(station.Longitude, "Longitude must be between -34.3 to 35.5");
            }
            dl.AddStation(StationDO);
        }


        public void UpdateStation(BO.Station station) //updates station

        {
            DO.Station StationDO = new DO.Station();
            station.CopyPropertiesTo(StationDO);//copys station properties into StationDO
            try
            {
                dl.UpdateStation(StationDO);//updates
            }
            catch (DO.StationCodeException ex)
            {
                throw new BO.StationCodeException("Station does not exist", ex);
            }

        }

        public void DeleteStation(int code) //deletes station
        {
            bool allow = true;
            try
            {
                IEnumerable<int> lines = dl.RequestLinesByStation(code);//returns list of all the line ids with requested station
                using (var listofLines = lines.GetEnumerator())
                {
                    while (listofLines.MoveNext())//makes sure we are not deleting a station that would make a line not valid because it has less then 2 stations
                    {
                        BO.Line line = GetLine(listofLines.Current);//gets current line using lineid
                        if (line.Stations.Count() <= 2)
                        {
                            allow = false;
                            throw new BO.LineIdException(listofLines.Current, "Can't delete Station because this line has 2 stations");
                        }
                    }
                }
                if (allow) //if it does not = true it means we can't delete the requested station
                {
                    dl.DeleteStation(code);
                    dl.DeleteLineStationbyStation(code);
                }


            }
            catch (DO.StationCodeException ex)
            {
                throw new BO.StationCodeException("station Code does not exist", ex);
            }
        }

        #endregion
        #region LineStation
        BO.LineStation LineStationDoBoAdapter(DO.LineStation LineStationDO) //convert  do to bo
        {
            BO.LineStation LineStationBO = new BO.LineStation();
            int LineId = LineStationDO.LineId;
            LineStationDO.CopyPropertiesTo(LineStationBO);//copys the properties from do to bo for the LineStation

            return LineStationBO;
        }
        public IEnumerable<int> GetAlllinesByStation(int code)//returns all lines that go through requested station
        {
            return dl.RequestLinesByStation(code);
        }
        public void AddStationToLine(BO.LineStation lineStation)//add station to line
        {
            BO.Line line = GetLine(lineStation.LineId);//gets the line for the line id
            DO.LineStation lineStationDO = new DO.LineStation();//new linesStation
            lineStation.CopyPropertiesTo(lineStationDO);//copys linestation properties into lineStationDO
            try
            {
                DO.Station st = dl.RequestStation(lineStation.Station);//if station does not exist in list we will throw an exception
                DO.Line l = dl.RequestLine(lineStation.LineId);//if line does not exist in list we will throw an exception
                if (lineStation.LineStationIndex == 0)//add to first
                {
                    line.Stations.ToList().Insert(0, lineStation.Station);//adds station to beginging of list
                    line.FirstStation = lineStation.Station;//updates First Station
                    if (lineStation.Distance == 0.0d)//if it doesnt have a value
                    {
                        lineStation.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km 
                    }
                    if (lineStation.Time == 0.0d)//if it doesnt have a value
                    {
                        lineStation.Time = 2 * lineStation.Distance;//assuming that each km takes 2 minutes
                    }
                    dl.AddLineStation(lineStationDO);//adds to list of linestation

                }
                else//if was not added as the first will continue checking
                {
                    if (lineStation.LineStationIndex > line.Stations.Count())//if indexer is bigger then the number bus stations throws an exception

                        throw new BO.LineStationIndexException(lineStation.LineStationIndex, "index should be less than or equal to number of stations in line");

                    if (lineStation.LineStationIndex == line.Stations.Count())//adds to last
                    {

                        line.Stations.ToList().Add(lineStation.Station);//adds to end of list
                        line.LastStation = lineStation.Station;//new last station
                        if (lineStation.Distance == 0.0d)//if it doesnt have a value
                        {
                            lineStation.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km 
                        }
                        if (lineStation.Time == 0.0d)//if it doesnt have a value
                        {
                            lineStation.Time = 2 * lineStation.Distance;//assuming that each km takes 2 minutes
                        }
                        dl.AddLineStation(lineStationDO);//adds to list of linestation
                    }
                    else if (lineStation.LineStationIndex < line.Stations.Count()) //adds to the middle
                    {
                        line.Stations.ToList().Insert(lineStation.LineStationIndex, lineStation.Station);
                        if(lineStation.Distance==0.0d)//if it doesnt have a value
                        {
                        lineStation.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km 
                        }
                        if (lineStation.Time == 0.0d)//if it doesnt have a value
                        {
                            lineStation.Time = 2 * lineStation.Distance;//assuming that each km takes 2 minutes
                        }
                        
                        dl.AddLineStation(lineStationDO);//adds to list of linestation


                    }


                }
            }
            catch (DO.StationCodeException ex)//will catch if station does not exist
            {
                throw new BO.StationCodeException("Station Id does not exist", ex);
            }
            catch (DO.LineIdException ex)//will catch if line does not exist
            {
                throw new BO.LineIdException("line Id does not exist", ex);
            }
        }
        public void UpdateLineStation(BO.LineStation lineStation) //updating line station
        {
            DO.LineStation LineStationDO = new DO.LineStation();
            lineStation.CopyPropertiesTo(LineStationDO);//copys lineStation properties into LineStationDO
            try
            {
                dl.UpdateLineStation(LineStationDO);//updates

            }
            catch (DO.LineIdException ex)//if line station does not exist will throw exception
            {
                throw new BO.LineIdException("Line id  does not exist", ex);
            }
        }
        public void DeleteLineStation(int lineId, int code)//deletes line station
        {
            BO.Line line = GetLine(lineId);
            try
            {
                if (line.Stations.Count() > 2)//line has more then 2 stations we can delete
                {
                    dl.DeleteLineStation(code, lineId);//deletes the line station
                    line.Stations.ToList().Remove(code);//deletes the station from the line
                }
                else
                    throw new BO.LineIdException(lineId, "Can't delete Station because this line has 2 stations");

            }
            catch (DO.StationCodeException ex)//if line station does not exist will throw exception
            {
                throw new BO.StationCodeException("Station does not exist", ex);
            }
        }
        #endregion
        #region LineTrip
        public void AddLineTrip(BO.LineTrip lineTrip)//add LineTrip
        {

        }
        public void UpdateLineTrip(BO.LineTrip lineTrip) //updating lineTrip
        {
        }
        public void DeleteLineTrip(int Id)//deletes lineTrip
        {
        }
        #endregion
    }
}
