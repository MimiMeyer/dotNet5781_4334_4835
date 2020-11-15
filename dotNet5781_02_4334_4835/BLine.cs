using System;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
   public class BLine : IComparable<BLine>
    {
        private List<BusStopLine> stations = new List<BusStopLine>();
        public List<BusStopLine> Stations
        {
            get
            {
                List<BusStopLine> temp = new List<BusStopLine>(stations);
                return temp;
            }
            set { value = stations; }

        }
        public int BusLine { get; set; }
        public BusStopLine FirstStation { get; set; }
        public BusStopLine LastStation { get; set; }
        public District Area { get; set; }//enum
        private static List<int> PrintStationCodes(List<BusStopLine> S)
        {
            List<int> help = new List<int>();

            foreach (BusStopLine station in S)


            {
                help.Add(station.BusStationKey);

            }
            return help;

        }
        public override string ToString()
        {

            return String.Format("Bus line number is: {0}, The district is: {1}, List of station numbers:{2}", BusLine, Area, PrintStationCodes(Stations));

        }
        /*adds the first bus station*/
        public void AddFirst(BusStopLine busStation)
        {
            stations.Insert(0, busStation);
            FirstStation = stations[0];
        }
        /*adds the last bus station*/
        public void AddLast(BusStopLine busStation)
        {
            stations.Add(busStation);
            LastStation = stations[stations.Count - 1];
        }

        public void Add(int i, BusStopLine busStation)
        {
            if (i == 0)//add to first
            {
                AddFirst(busStation);
            }
            else
            {
                if (i > stations.Count)//if i is bigger then the number bus stations throw an exception
                {
                    throw new ArgumentOutOfRangeException("index", "index should be less than or equal to" + stations.Count);
                }
                if (i == stations.Count)//add to last
                {

                    AddLast(busStation);
                }
                else//add in the middle
                {
                    stations.Insert(i, busStation);


                }


            }

        }
        /*removes station from list of stations*/
        public void Remove(BusStopLine busStation)
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
        /*time between busses*/
        public double TimeBetween(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1))
            {
                throw new Exception("first station does not exist");
            }
            if (!Found(station2))
            {
                throw new Exception("second station does not exist");

            }
            return station1.TravelTime.Subtract(station2.TravelTime).TotalMinutes;
        }
        public void StationPath(BusStopLine station1, BusStopLine station2)
        {
            if (!Found(station1))
            {
                throw new Exception("first station does not exist");
            }
            if (!Found(station2))
            {
                throw new Exception("second station does not exist");

            }
            int index1 = 0, index2 = 0;
            int counter = 0, i;

            foreach (BusStopLine station in stations)
            {
                if (station == station1)
                {
                    index1 = counter;
                }
                if (station == station2)
                {
                    index2 = counter;
                }
                counter++;

            }
            if (index1 > index2)
            {
                throw new Exception("Bus stops must be inorder of travel");
            }
            if (index1 == index2)
            {
                throw new Exception("Bus Stops must be differnt");
            }
            else
            {

                for (i = index1; i <= index2; i++)
                {
                    Console.WriteLine(stations[i]);
                }
            }
        }

        private double SumTime()
        {
            double sum = 0;
            for (int i = 0; i < stations.Count - 1; i++)
            {
                sum += TimeBetween(stations[i], stations[i + 1]);
            }

            return sum;
        }
        public int CompareTo(BLine other)
        {
            double mySum = SumTime();
            double otherSum = other.SumTime();

            return mySum.CompareTo(otherSum);
        }

    
    }
}



