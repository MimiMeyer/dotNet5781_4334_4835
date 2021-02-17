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
        BO.Line GetLine(int id);//returns requested line
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
        IEnumerable<BO.LineStation> GetStationsForLine(int Id);//returns all stations that go through line

        IEnumerable<BO.Line> GetAlllinesByStation(int code);//returns all lines that go through requested station#
        IEnumerable<int> GetAlllineNumberaByStation(int code);//returns all lines that go through requested station
        void AddStationToLine(BO.LineStation lineStation);//add station to line
        void UpdateLineStation(BO.LineStation lineStation); //updating line station
        void DeleteLineStation(BO.LineStation lineStation);//deletes line station
        #endregion
        #region LineTrip
        IEnumerable<BO.LineTrip> GetLineTripsForLine(int Id);//returns all LineTrips for requested line
        IEnumerable<TimeSpan> GetAllStartAtTimesForLine(int Id,int code);//returns all the arrival times for station
        void AddLineTrip(BO.LineTrip lineTrip);//add LineTrip
        void UpdateLineTrip(BO.LineTrip lineTrip); //updating lineTrip
        void DeleteLineTrip(int lineId, TimeSpan StartAt);//deletes lineTrip
        #endregion
        #region simulation
        IEnumerable<BO.LineTiming> GetLineTimingForSimulator(TimeSpan startTime, int Code);//return all data for the simulator
        int LastBusInStation(TimeSpan startTime, int Code);//for last bus in station
        void Sms(int bus, TimeSpan hour, String number, TimeSpan time,int code);//for user to get an update a minute before the bus comes

        #endregion
        #region Bus
        BO.Bus GetBus(int license);//returns requested bus
        IEnumerable<BO.Bus> GetAlllBuses();//returns all buses
        void AddBus(BO.Bus bus);//add Bus
        void UpdateBus(BO.Bus bus); //updating bus
        void DeleteBus(int license);//deletes bus
        
        void Refuel(BO.Bus bus);//fills tank

        void Checkup(BO.Bus bus);//after a checkup updates the km to 0 and the checkup date to today and also refills gas if needed


        #endregion


    }
}
