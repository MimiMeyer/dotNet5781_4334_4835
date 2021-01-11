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
            LineDO.CopyPropertiesTo(LineBO);//copys the properties from do to bo for the Line
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
            try
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
                    HelpAddLine(line, LineDO);//adds the line


                }
                if (count == 0)
                {

                    HelpAddLine(line, LineDO);//adds the line

                }
            }
            catch (DO.LineIdException ex)
            {
                throw new BO.LineIdException("Line Id already exists", ex);
            }
            catch (DO.StationCodeException ex)
            {
                throw new BO.StationCodeException("station Code does not exist", ex);
            }

        }
        public  void HelpAddLine(BO.Line line, DO.Line LineDO)//adds line
        {
            DO.Station st = dl.RequestStation(LineDO.FirstStation);//if station does not exist will throw exception
            st = dl.RequestStation(LineDO.LastStation);//if station does not exist will throw exception
            line.Id = dl.AddLine(LineDO);//if exception was not thrown will addline and get back running id
            BO.LineStation first = new BO.LineStation();
            BO.LineStation last = new BO.LineStation();
            first.Station = line.FirstStation;//inializing first station
            first.LineStationIndex = 0;
            first.LineId = line.Id;
            last.Station = line.LastStation;//inializing last station
            last.LineStationIndex = 1;
            last.LineId = line.Id;
            DO.LineStation firstDO = new DO.LineStation();
            first.CopyPropertiesTo(firstDO);//changing from bo to do
            dl.AddLineStation(firstDO);//adding to list
            DO.LineStation lastDO = new DO.LineStation();
            last.CopyPropertiesTo(lastDO);//changing from bo to do
            dl.AddLineStation(lastDO);//adding to list
            DO.AdjacentStations adj = dl.RequestAdjacentStations(first.Station, last.Station);
            if (adj == null)//only if doesn't exist add
            {
                DO.AdjacentStations adjacentStations = new DO.AdjacentStations();
                adjacentStations.Station1 = first.Station;
                adjacentStations.Station2 = last.Station;
                adjacentStations.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km ;
                adjacentStations.Time = adjacentStations.Distance * 2;
                dl.AddAdjacentStations(adjacentStations);//adding new adj stations
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
            try
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
            catch (DO.StationCodeException ex)
            {
                throw new BO.StationCodeException("Station code already exists", ex);
            }
        }


        public void UpdateStation(BO.Station station) //updates station

        {
            DO.Station StationDO = new DO.Station();
            station.CopyPropertiesTo(StationDO);//copys station properties into StationDO
            try
            {
                if (station.Lattitude < 31 || station.Lattitude > 33.3)
                {
                    throw new BO.StationCoordinatesException(station.Lattitude, "Lattitude must be between -31 to 33.3");
                }
                if (station.Longitude < 34.3 || station.Longitude > 35.5)
                {
                    throw new BO.StationCoordinatesException(station.Longitude, "Longitude must be between -34.3 to 35.5");
                }
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
                        if (dl.RequestStationsByLine(line.Id).Count() <= 2)
                        {
                            allow = false;
                            throw new BO.LineIdException(listofLines.Current, "Can't delete Station because this line has 2 stations");
                        }
                    }
                }
                if (allow) //if it does not = true it means we can't delete the requested station
                {
                    dl.DeleteStation(code);
                    
                    using (var listOfLines = lines.GetEnumerator())//going over the lines to update their LineStation
                    {
                        while (listOfLines.MoveNext())
                        {
                            int count = 0;

                            IEnumerable<int> ListOfStations = dl.RequestStationsByLine(listOfLines.Current);//gets back list of stations
                            DO.Line line = dl.RequestLine(listOfLines.Current);

                            line.FirstStation = ListOfStations.ElementAt(0);//updating first station
                            line.LastStation = ListOfStations.ElementAt(ListOfStations.Count() - 1);//updating last station
                            dl.UpdateLine(line);//updating line
                            using (var stations = ListOfStations.GetEnumerator())
                            {

                                while (stations.MoveNext())
                                {
                                    if (stations.Current == code) 
                                    { BO.LineStation ls = new BO.LineStation();
                                        ls.LineId = listOfLines.Current;
                                        ls.Station = code;
                                        DeleteLineStation(ls);
                                           
                                    }

                                }
                            }
                            

                        }
                       
                    }



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

            LineStationDO.CopyPropertiesTo(LineStationBO);//copys the properties from do to bo for the LineStation
            IEnumerable<int> stations = dl.RequestStationsByLine(LineStationDO.LineId);//returns list of stations
            if (LineStationDO.LineStationIndex != stations.Count()-1 ) //as long as we are not in the last station
            {
                DO.AdjacentStations st = dl.RequestAdjacentStations(stations.ElementAt(LineStationDO.LineStationIndex), stations.ElementAt((LineStationDO.LineStationIndex + 1)));
                if (st != null)
                {
                    LineStationBO.Distance = st.Distance;//gets AdjacentStations distance
                    LineStationBO.Time = st.Time;//gets AdjacentStations time
                }
            }
            return LineStationBO;
        }
        public IEnumerable<BO.LineStation> GetStationsForLine(int Id)//returns all stations that go through line
        {
            return from lineStationDO in dl.RequestAllLinesStation(Id)//gets all line stations for line from the function RequestAllLines
                   orderby lineStationDO.LineStationIndex//orders by index
                   select LineStationDoBoAdapter(lineStationDO);//each line goes to functionand changes to bo
        }
        public IEnumerable<BO.Line> GetAlllinesByStation(int code)//returns all lines that go through requested station
        {

            return from lineDO in dl.GetLinesByStation(code)//gets all lines that go through station from the function RequestAllLines
                   orderby lineDO.Id//orders by id number
                   select LineDoBoAdapter(lineDO);//each line goes to function and changes to bo
        }

        public void AddStationToLine(BO.LineStation lineStation)//add station to line
        {
            DO.Line lineDO = dl.RequestLine(lineStation.LineId);//gets the line for the line id

            DO.LineStation lineStationDO = new DO.LineStation();//new linesStation
            lineStation.CopyPropertiesTo(lineStationDO);//copys linestation properties into lineStationDO
            try
            {
                DO.Station st = dl.RequestStation(lineStation.Station);//if station does not exist in list we will throw an exception
                DO.Line l = dl.RequestLine(lineStation.LineId);//if line does not exist in list we will throw an exception
                if (lineStation.LineStationIndex == 0)//add to first
                {

                    lineDO.FirstStation = lineStation.Station;//updates First Station
                   
                    dl.UpdateLine(lineDO);//updates first station

                }
                else//if was not added as the first will continue checking
                {
                    if (lineStation.LineStationIndex > dl.RequestStationsByLine(lineDO.Id).Count())//if indexer is bigger then the number bus stations throws an exception

                        throw new BO.LineStationIndexException(lineStation.LineStationIndex, "index should be less than or equal to number of stations in line");

                    if (lineStation.LineStationIndex == dl.RequestStationsByLine(lineDO.Id).Count())//adds to last
                    {

                        lineStation.Distance = 0.0;
                        lineStation.Time = 0.0;
                        lineDO.LastStation = lineStation.Station;//new last station

                        dl.UpdateLine(lineDO);

                    }

                }
                int count = 0;

                IEnumerable<int> stations = dl.RequestStationsByLine(lineStation.LineId);

                using (var ListOfStation = stations.GetEnumerator())
                {
                    while (ListOfStation.MoveNext())
                    {
                        if (count < lineStation.LineStationIndex)
                        {
                            count++;

                        }
                        else
                        {

                            DO.LineStation StationDO = new DO.LineStation();//new line
                            StationDO.LineStationIndex = count + 1;//updating index 
                            StationDO.LineId = lineStation.LineId;//same line id
                            StationDO.Station = ListOfStation.Current;//same station
                            dl.UpdateLineStation(StationDO);//updating linestation
                            count++;//for index
                        }

                    }
                }
               
                    dl.AddLineStation(lineStationDO);//adds to list of linestation
                stations = dl.RequestStationsByLine(lineStation.LineId);//with new Station
                DO.AdjacentStations adj = new DO.AdjacentStations();
                if (lineStation.LineStationIndex != 0)//updating the time and distance from the station before so need to make sure its not first station
                {   adj.Station1 = stations.ElementAt(lineStation.LineStationIndex - 1);
                    adj.Station2 = stations.ElementAt(lineStation.LineStationIndex);
                    adj.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km 
                    adj.Time = adj.Distance * 2;
                }
              
                dl.AddAdjacentStations(adj);//adding the new adj stations
                if (lineStation.LineStationIndex != stations.Count() - 1)//if its the last stop it doesnt have a station after
                {
                    //updating the time for after the station
                    adj.Station1 = stations.ElementAt(lineStation.LineStationIndex);
                    adj.Station2 = stations.ElementAt(lineStation.LineStationIndex + 1);
                    adj.Distance = lineStation.Distance;
                    adj.Time = lineStation.Time;
                    dl.AddAdjacentStations(adj);//adding the new adj stations
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
            DO.LineStation LineStationDO = dl.RequestLineStation(lineStation.Station, lineStation.LineId);
            IEnumerable<int> stations = dl.RequestStationsByLine(LineStationDO.LineId);//returns all stations
            dl.UpdateLineStation(LineStationDO);
            try
            {
                if (stations.Count() - 1 != LineStationDO.LineStationIndex) //as long as we are not in the last station
                {
                   DO.AdjacentStations st = dl.RequestAdjacentStations(stations.ElementAt(LineStationDO.LineStationIndex), stations.ElementAt((LineStationDO.LineStationIndex + 1)));
                   
                    if (st != null) //if AdjacentStations exist
                    {
                        st.Station1 = stations.ElementAt(LineStationDO.LineStationIndex);
                        st.Station2 = stations.ElementAt((LineStationDO.LineStationIndex + 1));
                        st.Time = lineStation.Time;
                        st.Distance = lineStation.Distance;
                        dl.UpdateAdjacentStations(st);//updating the AdjacentStations

                    }
                }

            }
            catch (DO.LineIdException ex)//if line station does not exist will throw exception
            {
                throw new BO.LineIdException("Line id  does not exist", ex);
            }
        }
        public void DeleteLineStation(BO.LineStation lineStation)//deletes line station
        {
            int count = 0;//to update LineStation Index
            DO.LineStation lineStationDO1 = dl.RequestLineStation(lineStation.Station,lineStation.LineId);
            DO.Line line = dl.RequestLine(lineStation.LineId);//gets back line
            IEnumerable<int> ListOfStations = dl.RequestStationsByLine(line.Id);//gets back list of stations
            try
            {
                if (dl.RequestStationsByLine(line.Id).Count() > 2)//line has more then 2 stations we can delete
                {
                    if (lineStationDO1.LineStationIndex == 0) //if we're deleteing the first station
                    {
                        line.FirstStation = ListOfStations.ElementAt(1);//the second one
                        dl.UpdateLine(line);//updating first station
                    }
                    else if (lineStationDO1.LineStationIndex == (ListOfStations.Count() - 1))//if we're deleteing the last station
                    {
                        line.LastStation = ListOfStations.ElementAt((ListOfStations.Count() - 2));//the one before the last should be last station
                        dl.UpdateLine(line);//updating last station

                    }

                    dl.DeleteLineStation(lineStation.Station, lineStation.LineId);//deletes the line station
                    ListOfStations = dl.RequestStationsByLine(line.Id);//gets back the list of stations withouth the one that was deleted
                    using (var stations = ListOfStations.GetEnumerator())
                    {
                        while (stations.MoveNext())
                        {
                            DO.LineStation lineStationDO = new DO.LineStation();//new line
                            lineStationDO.LineStationIndex = count;//updating index
                            lineStationDO.LineId = line.Id;//same line id
                            lineStationDO.Station = stations.Current;//same station
                            dl.UpdateLineStation(lineStationDO);//updating linestation
                            count++;//fpr index


                        }
                    }
                    
                    
                    if (lineStationDO1.LineStationIndex != ListOfStations.Count()&& lineStationDO1.LineStationIndex!=0)//if its not the last station or first
                    {
                            DO.AdjacentStations adj = new DO.AdjacentStations();
                        adj.Station1 = ListOfStations.ElementAt(lineStationDO1.LineStationIndex - 1);//the one before the station that was deleted
                        adj.Station2 = ListOfStations.ElementAt(lineStationDO1.LineStationIndex);//the one after the station that was deleted
                        adj.Distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km ;
                        adj.Time = adj.Distance * 2;
                        dl.AddAdjacentStations(adj);//adding the new adj stations
                    }

                }
                else
                    throw new BO.LineIdException(lineStation.LineId, "Can't delete Station because this line has 2 stations");

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
