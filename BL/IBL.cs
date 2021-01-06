using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BLAPI
{
    public interface IBL
    {
        #region Line
        BO.Station GetLine(int id);//returns requested line
        IEnumerable<BO.Line> GetAlllines();//returns all lines
        void AddLine(BO.Line line);//adds line
        void UpdateLine(BO.Line line);//updates a line

        void DeleteLine(int Id);//deletes a line
        #endregion
        #region Station
        BO.Station GetStation(int code);//returns requested station
        IEnumerable<BO.Station> GetAllStations();//returns all station
        void AddStation(BO.Station station);//adds station
        void UpdateStation(BO.Station station); //updates station

        void DeleteStation(int code);//deletes station

        #endregion
        #region LineStation
        void AddStationToLine(BO.LineStation lineStation);//add station to line
        void UpdateLineStation(BO.LineStation lineStation); //updating line station
        void DeleteLineStation(int lineId, int code);//deletes line station
        #endregion
        #region LineTrip
        void AddLineTrip(BO.LineTrip lineTrip);//add LineTrip
        void UpdateLineTrip(BO.LineTrip lineTrip); //updating lineTrip
        void DeleteLineTrip(int Id);//deletes lineTrip
        #endregion


    }
}
