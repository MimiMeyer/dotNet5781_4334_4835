using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
  public  class LineStation
    {
        public int LineId { get; set; }//bus ID
        public int Station { get; set; }//code station
        public int LineStationIndex { get; set; }
        public double Distance { get; set; }
        public double Time { get; set; }
    }
}
