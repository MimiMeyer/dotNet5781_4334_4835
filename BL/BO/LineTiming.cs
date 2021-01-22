using System;

namespace BO
{
    public class LineTiming
    {
        public int Id { get; set; }//line number
        public int Code { get; set; }//stop
        public TimeSpan ArrivalTime { get; set; }
        public int MinutesTillArival { get; set; }
        //public int LastStation { get; set; }
    }
}
