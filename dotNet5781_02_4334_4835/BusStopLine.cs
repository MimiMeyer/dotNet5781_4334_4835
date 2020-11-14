using System;

namespace dotNet5781_02_4334_4835
{

    public class BusStopLine : BusStop
    {
        private double distance;
        private double time;
     
        public double Distance
        {
            get { return distance; }
            set
            {
                Random r = new Random();
                distance = r.NextDouble() * (40 - 0.1) + 0.1;//random number from 0.1-40km
            }

        }
        public TimeSpan TravelTime { get; set; }



    }
}
