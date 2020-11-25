using System;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
   public class BLine : IComparable<BLine>
    {
        private List<BusStopLine> stations = new List<BusStopLine>();//list of stations in bus
        public int BusLine { get; set; }//number of the line.
        public BusStopLine FirstStation { get; set; }//first station
        public BusStopLine LastStation { get; set; }//last station
        public District Area { get; set; }//enum
        
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
        /**for the tostring prints out station codes***/
      
      public List<int> PrintStationCodes(List<BusStopLine> S)//gets list of stations
        {
            List<int> listOfStops = new List<int>();//

            foreach (BusStopLine station in S)// goes over the list


            {
                listOfStops.Add(station.BusStationKey);// adding station code to list

            }
            return listOfStops;// list of station codes of the bus stops of the line.

        }/*tostring*/
        public override string ToString()
        {
            string result = "Bus line number is: " + BusLine + "\n";
            result += "The district is:" + Area + "\n";
            result+= "List of station numbers:" + "\n" ;
            foreach(BusStopLine stop in stations) 
            {
                result += stop;
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
                if (i > stations.Count)//if i is bigger then the number bus stations throw an exception
                {
                    throw new ArgumentException("incorrect index input must be smaller or bigger then the number of bus stops");
                }
                if (i == stations.Count)//add to last
                {

                    AddLast(busStation);
                }
                else if(i < stations.Count) //add in the middle
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
                foreach (BusStopLine station in stations)
                {
                    if (station == busStation)
                    {
                        stations.Remove(station);
                    }
                }
            }
            else throw new Exception("station does not exist");
        }
        /*checks if station exists*/
        public bool Found(BusStopLine busStation)
        {

            foreach (BusStopLine station in stations)
            {
                if (station == busStation)
                {
                    return true;
                }

            }
            return false;
        }
        //needs looking into
        public double DistanceBetween(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1)) { throw new Exception("station does not exist"); }
            if (!Found(station2)) { throw new Exception("station does not exist"); }
            return station1.Distance - station2.Distance;


        }
        /*time between bus stops*/
        public double TimeBetween(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1))//throws exception if station 1 does not exist
            {
                throw new Exception("first station does not exist");
            }
            if (!Found(station2))//throws exception if station 2 does not exist
            {
                throw new Exception("second station does not exist");

            }
            return station1.TravelTime.Subtract(station2.TravelTime).TotalMinutes;//returns total minutes between bus stops.
        }
        /*sub route of the bus*/
        public BLine StationPath(BusStopLine station1, BusStopLine station2)
        {
            BLine stationPath=null;
            if (!Found(station1))//station 1 not found
            {
                throw new Exception("first station does not exist");
            }
            if (!Found(station2))//station2 not found
            {
                throw new Exception("second station does not exist");

            }
            else if(Found(station2)&& Found(station2))//both bus stops are in the list.
            {
                int index1 = 0, index2 = 0, counter = 0,i;//help 
                foreach (BusStopLine station in stations)
                {
                    if (station == station1)//finding index of first stop 
                    {
                        index1 = counter;
                    }
                    if (station == station2)//finding index of second stop
                    {
                        index2 = counter;
                    }
                    counter++;//counter for the index

                }
                if (index1 > index2)//user typed in bus stop in the wrong order.
                {
                    throw new Exception("Bus stops must be inorder of travel");
                }
                if (index1 == index2)//user typed in same bus stop twice.
                {
                    throw new Exception("Bus Stops must be differnt");
                }
                else if (index1 < index2)//user input correct
                {
                    stationPath.BusLine = BusLine;//same bus number
                    stationPath.FirstStation = stations[index1];//updates first station to be users first station.
                    stationPath.LastStation = stations[index2];//updates second station to be users second station.
                    stationPath.Area = Area;//same bus area
                    for(i=index1; i==index2; i++)//the  sub-route of the bus.
                    {
                        stationPath.Stations.Add(stations[i]);//adding stops to the list of stations
                    }
                    

                }
            }
            return stationPath;
        }
        /*route of the bus time */
        public  double SumTime()
        {
            double sum = 0;
            for (int i = 0; i < stations.Count - 1; i++)
            {
                sum += TimeBetween(stations[i], stations[i + 1]);
            }

            return sum;
        }/*helps user choose shortset trael time to destionanion*/
        public int CompareTo(BLine other)
        {
            double mySum = SumTime();
            double otherSum = other.SumTime();

            return mySum.CompareTo(otherSum);
        }
        /*for user to insert a  new bus line*/
        public  void AddBus()
        {
            bool success = false;
            Console.WriteLine("Enter bus line number under 4 digits:");
            this.BusLine = Convert.ToInt32(Console.ReadLine());
            BusStopLine first=new BusStopLine();
            BusStopLine last= new BusStopLine(); ;
            first.AddStationUser();
            last.AddStationUser();

            this.AddFirst(first);// new lines first station
            this.AddLast(last); ;//new lines last station
            while (success == false) 
            { 
            Console.WriteLine("Enter area GENERAL, SOUTHERN, NORTHERN, CENTERAL, JERUSALEM");
            District area;
            success = Enum.TryParse(Console.ReadLine(), out area);
            if (success == false) { Console.WriteLine("invalid input"); }
            this.Area=area; //new lines area
            }
           

    }

    }
}



