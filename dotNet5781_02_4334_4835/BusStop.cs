
using System;

namespace dotNet5781_02_4334_4835
{
    public class BusStop
    {
        //need to take care of if user outs in the same stationcode twice

        private int stationCode;
        private double latitude;
        private double longitude;
        public int BusStationKey
        {
            get { return stationCode; }
            set
            {
                if (value > 0 && value < 1000000)
                {
                    stationCode = value;
                }
                else throw new Exception("input not valid");
            }
        }
        public double Latitude
        {
            get => latitude;
            set
            {
                if (value >= -90 && value <= 90)
                {
                    latitude = value;
                }
                else throw new Exception("value must be between -90 to 90");
            }
        }
        public double Longitude
        {
            get => longitude;
            set
            {
                if (value >= -180 && value <= 180)
                {
                    latitude = value;
                }
                else throw new Exception("value must be between -180 to 180");
            }
        }
        public String Address
        { get; set; }
        public override string ToString()
        {
            return String.Format("Bus Station Code: {0}, {1}°N {2}°E", BusStationKey, Latitude, Longitude);
        }

    }
}

