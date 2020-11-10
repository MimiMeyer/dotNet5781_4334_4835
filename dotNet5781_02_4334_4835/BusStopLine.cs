using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNet5781_02_4334_4835
{
   public class BusStopLine:BusStop
    {
        public double Distance { get; set; }
        public TimeSpan TravelTime { get; set; }
        
        

    }
}
