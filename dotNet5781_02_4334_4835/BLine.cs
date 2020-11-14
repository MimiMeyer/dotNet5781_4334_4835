using System;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
    class BLine
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
            if (i == 0 && stations[0] == null)//add to first
            {
                AddFirst(busStation);
            }
            else
            {
                if (i > stations.Count)//if i is bigger then the number bus stations throw an exception
                {
                    throw new ArgumentOutOfRangeException("index", "index should be less than or equal to" + stations.Count);
                }
                if (i == stations.Count && stations[i] == null)//add to last
                {

                    AddLast(busStation);
                }
                if (stations[i] == null)//add in the middle
                {
                    stations.Insert(i, busStation);


                }
                else throw new Exception("already has a station there");// already has a bus in that index

            }
            
        }
        /*removes station from list of stations*/
        public void remove( BusStopLine busStation)
        {
            if (found(busStation))
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
        public bool found(BusStopLine busStation)
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

    }
   
}
