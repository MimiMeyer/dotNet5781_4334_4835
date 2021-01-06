using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int Code { get; set; }//code of station
        public string Name { get; set; }//name of station
        public double Longitude { get; set; }
        public double Lattitude { get; set; }

        public string Address { get; set; }//כתובת
    }
}
