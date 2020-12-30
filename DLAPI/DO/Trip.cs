using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class Trip
    {
        public int Id { get; set; }//id for trip
        public int UserName { get; set; }
        public int LineId { get; set; }
        public int InStation { get; set; }
        public TimeSpan InAt { get; set; }
        public int OutStation { get; set; }
        public TimeSpan OutAt { get; set; }

    }
}
