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
                return stations;
            }

        }
        public int BusLine { get; set; }
        public BusStopLine FirstStation { get; set; }
        public BusStopLine LastStation { get; set; }
        public District Area { get; set; }//enum
        public override string ToString()
        {
            return String.Format("Bus line number is: {0}, The district is: {1}, List of station numbers:", BusLine, Area);
          
        }
    }

}
