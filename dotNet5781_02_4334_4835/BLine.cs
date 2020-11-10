using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        { List<int> help = new List<int>();
            
            foreach (BusStopLine station in S )
 

            {
                help.Add(station.BusStationKey);
                
            }
            return help;
            
        }
        public override string ToString()
        {
            
            return String.Format("Bus line number is: {0}, The district is: {1}, List of station numbers:{3}", BusLine, Area, PrintStationCodes(Stations));
          
        }
    }

}
