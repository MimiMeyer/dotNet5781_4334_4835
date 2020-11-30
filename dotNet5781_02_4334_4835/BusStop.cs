
using System;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
    public class BusStop
    {
       
        private int stationCode;
        private double latitude;
        private double longitude;
       /*get and set for station code of bus stop*/
        public int BusStationKey
        {
            get => stationCode; 
            set
            {
              
                if (value <0 || value >1000000)
                {
                    throw new ArgumentOutOfRangeException("Input must be under 7 digits");//makes sure bus stop code is under 7 digits
                    
                }
                stationCode = value;
                
            }
            
        }
        /*get and set for latitude*/
        public double Latitude
        {
            get => latitude;
            set
            {
                if (value >= -90 && value <= 90)
                {
                    
                    latitude = value;
                }
                else throw new ArgumentOutOfRangeException("Value must be between -90 to 90");//makes sue value is between -90 to 90
            }
        }
        /*get and set for longitude*/
        public double Longitude
        {
            get => longitude;
            set
            {
                if (value >= -180 && value <= 180)//makes sue value is between -180 to 180
                {
                    longitude = value;


                }
                else throw new ArgumentOutOfRangeException("value must be between -180 to 180");
            }
        }
        /*get and set for address*/
        public String Address
        { get; set; }
        /*returns BusStop in string representation*/
        public override string ToString()
        {
            return String.Format("Bus Station Code: {0}, {1}°N {2}°E", BusStationKey, Latitude, Longitude);
        }
        

    }
}

