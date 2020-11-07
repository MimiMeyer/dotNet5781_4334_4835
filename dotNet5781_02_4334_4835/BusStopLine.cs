using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4334_4835
{
    class BusStopLine:BusStop
    {
        public double Distance { get; set; }
        public TimeSpan TravelTime { get; set; }
    }
}
