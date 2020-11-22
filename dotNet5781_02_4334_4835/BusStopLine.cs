using System;
using System.Collections;
using System.Collections.Generic;
namespace dotNet5781_02_4334_4835
{

    public class BusStopLine : BusStop
    {
        
        private double distance;
        private TimeSpan time;
        /*constructor*/
        public BusStopLine(int stationcode, double latitude, double longitude)
        {
            BusStationKey = stationcode;
            Latitude = latitude;
            Longitude = longitude;
            Distance = this.Distance;
            TravelTime = this.TravelTime;

        }
        public double Distance
        {
            get { return distance; }
            set
            {
                Random r = new Random();
                distance = r.NextDouble() * (40 - 0.1) + 0.1;//random number from 0.1-40km
            }

        }
        public TimeSpan TravelTime { 
            get { return time; } 
            set {
                TimeSpan time1 = TimeSpan.FromMinutes(2*distance);
                time.Add(time1);
            } 
        }



    }
}
