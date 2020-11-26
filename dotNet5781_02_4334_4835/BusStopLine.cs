using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_4334_4835
{

    public class BusStopLine : BusStop
    {

        private double distance;//distance from the last busStopStation
        private TimeSpan time;//time of travel from the last busStopStation

        /*constructors*/
        public BusStopLine()
        { }
        //??
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
                distance = r.NextDouble() * (40 - 0.1) + 0.1;//sets a random number from 0.1-40km from the last station
            }

        }
        /*Travel time in minutes*/
        public TimeSpan TravelTime
        {
            get { return time; }
            set
            {
                TimeSpan time1 = TimeSpan.FromMinutes(2 * distance);//on assumption that 1 km takes 2 minutes
                time.Add(time1);
            }
        }
        /*checks if station code already exists and makes sure that its the same station*/
        public void CheckStation(List<BusStopLine> BusStops)
        {
            if (BusStops.Count == 0)
            { BusStops.Add(this); }

            foreach (BusStopLine stop in BusStops.ToList())
            {
                if (this.BusStationKey == stop.BusStationKey)
                {
                    if (this.Latitude != stop.Latitude)
                    { 
                        throw new ArgumentException("bus already exists must have same latitude look at the list of stations to find the correct one"); }

                    if (this.Longitude != stop.Longitude)
                    { 
                        throw new ArgumentException("bus already exists must have same latitude look at the list of stations to find the correct one"); }
                    
                }

            }
            BusStops.Add(this);
            
        }

        /*allows user to add station*/
        public void AddStationUser()
        {
            bool input = false;


            while (input == false)//incase of exception will ask user again for station code
            {
                Console.WriteLine("Enter station code");
                try
                {
                    this.BusStationKey = Convert.ToInt32(Console.ReadLine());//checks if user input is under 7 digits
                    input = true;//if user input is good then it could leave loop
                }
                catch (ArgumentOutOfRangeException exception)// catches exception
                {
                    Console.WriteLine(exception.Message);

                }

            }
            input = false;//station key number is valid and now checking for latitide.
            while (input == false)//incase of exception will ask user again for Latitude
            {
                Console.WriteLine("Enter Latitude");

                try
                {
                    this.Latitude = Convert.ToDouble(Console.ReadLine());//checks that the user input is correct
                    input = true;//if user input is good then it could leave loop
                }
                catch (ArgumentOutOfRangeException exception)// catches exception
                {
                    Console.WriteLine(exception.Message);

                }
            }
            input = false;//station key number is valid and now checking for longitude.
            while (input == false)//incase of exception will ask user again for Longitude
            {
                Console.WriteLine("Enter Longitude");
                try
                {
                    this.Longitude = Convert.ToDouble(Console.ReadLine());//checks that the user input is correct
                    input = true;//if user input is good then it could leave loop
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);

                }

            }






        }

    }
}
