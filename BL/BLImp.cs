using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using DLAPI;
using BO;
using System.Collections;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        BO.Line LineDoBoAdapter(DO.Line LineDO) //convert  do to bo
        {
            BO.Line LineBO = new BO.Line();
            int Id = LineDO.Id;
            LineBO.Stations = dl.RequestStationsByLine(Id);
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
            DO.Line LineDO = new DO.Line();
            line.CopyPropertiesTo(LineDO);//copys line properties into LineDO
            int count= GetAlllines().Count( l=>l.Code==line.Code);
            if (count >= 2)// throws exception if line already appears twice in list.
            {
                throw new BO.LineIdException(line.Code,"Line Number already has back and forth buses");
            }
            if (count == 1)

            {
                DO.Line Line1 = dl.RequestLine(line.Id);
                if(Line1.FirstStation!=LineDO.LastStation|| LineDO.FirstStation != Line1.LastStation)
                    throw new BO.LineIdException(line.Code, "The line is not traveling in the opposite direction so can't be added");
                dl.AddLine(LineDO);

            }
            if (count == 0)
            {
                dl.AddLine(LineDO);
            }

        }
        
        public void UpdateLine(BO.Line line)//updates a line
        {
            DO.Line LineDO = new DO.Line();
            line.CopyPropertiesTo(LineDO);//copys line properties into LineDO
            try
            {
                dl.UpdateLine(LineDO);//updates
            }
            catch (DO.LineIdException ex)
            {
                throw new BO.LineIdException("line Id does not exist", ex);
            }
        }


        public void DeleteLine(int Id)//deletes a line
        {
            try {
                dl.DeleteLine(Id);
                dl.DeleteLineStationbyLine(Id);
                
                 }
            catch (DO.LineIdException ex)
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
                StationDO = dl.RequestStation(code);
            }
            catch (DO.LineIdException ex)
            {
                throw new BO.StationCodeException("Station Id does not exist", ex);
            }
            return StationDoBoAdapter(StationDO);
        }
        public IEnumerable<BO.Station> GetAllStations()//returns all stations
        {
            return from stationDO in dl.RequestAllStations()//gets all stations from the function RequestAllStations
                   orderby stationDO.Code//orders by station code
                   select StationDoBoAdapter(stationDO);//each bus 
        }
        public void AddStation(BO.Station station)//adds station
        { }

   
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
        public void AddStationToLine(BO.LineStation lineStation)//add station to line
        {

        }
        public void UpdateLineStation(BO.LineStation lineStation) //updating line station
        {
        }
        public void DeleteLineStation(int lineId, int code)//deletes line station
        {
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
