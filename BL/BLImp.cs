using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLAPI;
using DLAPI;
using BO;

namespace BL
{
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();
        #region Line
        BO.Line LineDoBoAdapter(DO.Line LineDO) //convert  do to bo
        {
            BO.Line LineBO = new BO.Line();
            
        }
        public BO.Station GetLine(int id)//returns requested line
        {
        }
        public IEnumerable<BO.Line> GetAlllines()//returns all lines
        {
        }
        public IEnumerable<BO.Line> GetIDLineList()//returns only lines ids.
        {

        }

        public IEnumerable<BO.Line> GetLinesBy(Predicate<BO.Line> predicate)//returns lines that satisfies the predicate.
        {
        }

        public void UpdateLinePersonalDetails(BO.Line line)//updates a line
        {

        }

        public void DeleteLine(int Id)//deletes a line
        {
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

        }
        public IEnumerable<BO.Station> GetAllStations()//returns all stations
        {

        }
        public IEnumerable<BO.Station> GetCodeStationList() //returns station codes
        {

        }

        public IEnumerable<BO.Station> GetStationBy(Predicate<BO.Station> predicate)//returns stations that satisfies the predicate.
        {

        }

        public void UpdateStation(BO.Station station) //updates station
        {

        }

        public void DeleteStation(int code) //deletes station
        {
        }

        #endregion
        #region LineStation
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
