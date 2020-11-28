using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_4334_4835
{
    /*class that represents a bus line*/
    public class BLine : IComparable<BLine>
    {
        private List<BusStopLine> stations = new List<BusStopLine>();//list of stations in bus
        public int BusLine { get; set; }//number of the line.
        public BusStopLine FirstStation { get; set; }//first station
        public BusStopLine LastStation { get; set; }//last station
        public District Area { get; set; }//enum of line district

        /*constructors*/
        public List<BusStopLine> Stations// get and set for stations
        {
            get
            {
                List<BusStopLine> temp = new List<BusStopLine>(stations);
                return temp;
            }
            set { value = stations; }

        }
     
        /*tostring*/
        public override string ToString()
        {
            string result = "Bus line number is: " + BusLine + "\n";
            result += "The district is:" + Area + "\n";
            result += "List of station numbers:" + "\n";
            foreach (BusStopLine stop in stations)
            {
                result += stop + "\n";
            }
            return result;

        }
        /*adds the first bus station*/
        public void AddFirst(BusStopLine busStation)
        {
            stations.Insert(0, busStation);//adds station to beginging of list
            FirstStation = stations[0];//new first station
        }
        /*adds the last bus station*/
        public void AddLast(BusStopLine busStation)
        {
            stations.Add(busStation);//adds to end of list
            LastStation = stations[stations.Count - 1];//new last station
        }
        /*adds bus to list*/
        public void AddStation(int i, BusStopLine busStation)
        {
            if (i == 0)//add to first
            {
                AddFirst(busStation);
            }
            else
            {
                if (i > stations.Count)//if i is bigger then the number bus stations throws an exception
                {
                    throw new ArgumentOutOfRangeException("index", "index should be less than or equal to" + stations.Count);
                }
                if (i == stations.Count)//adds to last
                {

                    AddLast(busStation);
                }
                else if (i < stations.Count) //adds to the middle
                {
                    stations.Insert(i, busStation);


                }


            }

        }
        /*removes station from list of stations*/
        public void RemoveStation(BusStopLine busStation)
        {
            if (Found(busStation))
            {
                foreach (BusStopLine station in stations.ToList())
                {
                    if (station == busStation)
                    {
                        stations.Remove(station);
                    }
                }
            }
            else throw new ArgumentException("station does not exist");
        }
        /*checks if station exists*/
        public bool Found(BusStopLine busStation)
        {
            bool success = false;
            foreach (BusStopLine station in stations.ToList())
            {
                if (station.BusStationKey == busStation.BusStationKey && 
                    station.Latitude== busStation.Latitude&& 
                    station.Longitude == busStation.Longitude)
                {
                    success= true;
                }

            }
            return success;
        }
        //needs looking into
        public double DistanceBetween(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1)) { throw new ArgumentException("station does not exist"); }
            if (!Found(station2)) { throw new ArgumentException("station does not exist"); }
            return station1.Distance - station2.Distance;


        }
        /*time between bus stops*/
        public double TimeBetween(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1))//throws exception if station 1 does not exist
            {
                throw new ArgumentException("first station does not exist");
            }
            if (!Found(station2))//throws exception if station 2 does not exist
            {
                throw new ArgumentException("second station does not exist");

            }
            double result = Math.Abs(station1.TravelTime-station2.TravelTime);
            return result;//returns total minutes between bus stops.
        }
        /*sub route of the bus*/
        public BLine StationPath(BusStopLine station1, BusStopLine station2)
        {
            BLine stationPath=new BLine();
            if (!Found(station1))//station 1 not found
            {
                throw new ArgumentException("first station does not exist");
            }
            if (!Found(station2))//station2 not found
            {
                throw new ArgumentException("second station does not exist");

            }
            else if (Found(station1) && Found(station2))//both bus stops are in the list.
            {
                int index1 = 0, index2 = 0, counter = 0, i;//help 
                foreach (BusStopLine station in stations)
                {
                    if (station.BusStationKey == station1.BusStationKey)//finding index of first stop 
                    {
                        index1 = counter;
                    }
                    if (station .BusStationKey== station2.BusStationKey)//finding index of second stop
                    {
                        index2 = counter;
                    }
                    counter++;//counter for the index

                }
                if (index1 > index2)//user typed in bus stop in the wrong order.
                {
                    throw new ArgumentException("Bus stops must be inorder of travel");
                }
                if (index1 == index2)//user typed in same bus stop twice.
                {
                    throw new ArgumentException("Bus Stops must be differnt");
                }
                else if (index1 < index2)//user input correct
                {
                    stationPath.BusLine = BusLine;//same bus number
                    stationPath.AddFirst(stations[index1]);//updates first station to be users first station.
                    stationPath.AddLast(stations[index2]);//updates second station to be users second station.
                    stationPath.Area = Area;//same bus area
                    int j = 1;
                    for (i = index1+1; i < index2; i++)//the  sub-route of the bus.
                    {
                        stationPath.AddStation(j,stations[i]);//adding stops to the list of stations
                        j++;
                    }


                }
            }
            return stationPath;//returns new BLine
        }
        /*route of the bus time */
        public double SumTime()
        {
            double sum = 0;
            for (int i = 0; i < stations.Count - 1; i++)
            {
                sum += TimeBetween(stations[i], stations[i + 1]);
            }
             return sum;
        }/*helps user choose shortset travel time to destionanion by travel times*/
        public int CompareTo(BLine other)
        {
            double mySum = SumTime();
            double otherSum = other.SumTime();

            return mySum.CompareTo(otherSum);
        }
        /*for user to insert a  new bus line*/
        public void AddBus(List<BusStopLine> BusStops)
        {
            bool success = false;
            /*adding busline number*/
            Console.WriteLine("Enter bus line number under 4 digits:");
            this.BusLine = Convert.ToInt32(Console.ReadLine());//gets the number in int
            /*adding firststation*/
            BusStopLine first = new BusStopLine();//initialzing type 

            while (success == false)//will stay in loop until user input is correct
            {
                Console.WriteLine("Enter first station");
                first.AddStationUser();//calling on the function AddStationUser() to add station.

                try
                {
                    first.CheckStation(BusStops);//checks to see if stationcode already exists if it does must be same satation.
                    this.AddFirst(first);//if station is valid will add the station to firststation
                    success = true;//leave the loop
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);//cathes exception if user input not valid.

                }
            }
            while (success == true)//will stay in loop until user input is correct
            {
                /*adding last stop*/
                BusStopLine last = new BusStopLine();//initialzing type
                Console.WriteLine("Enter last station");
                last.AddStationUser();//calling on the function AddStationUser() to add station.

                try
                {
                    last.CheckStation(BusStops);//checks to see if stationcode already exists if it does must be same satatio
                    this.AddLast(last);//if station is valid will add the station to laststation
                    success = false;//leaves the loop
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);//cathes exception if user input not valid.

                }
            }


            /*adding area*/
            while (success == false)//will stay in loop until user input is correct
            {
                Console.WriteLine("Enter area GENERAL, SOUTHERN, NORTHERN, CENTERAL, JERUSALEM");
                District area;
                success = Enum.TryParse(Console.ReadLine(), out area);//if user input is correct success will be true
                if (success == false) { Console.WriteLine("invalid input"); }//wrting user that his input is not valid
                this.Area = area; //new lines area
            }


        }

    }
}



