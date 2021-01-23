using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DO
{
    public class LineTrip
    {

        public int LineId { get; set; }//bus id
        [XmlIgnore]
        public TimeSpan StartAt { get; set; }
        [XmlElement(ElementName = "StartAt")]
        public double StartAtTotalSeconds//for XML 
        {
            get
            {
                return StartAt.TotalSeconds;
            }
            set
            {
                StartAt = new TimeSpan(0,0, 0, (int)value);
            }
        }


        // public TimeSpan Frequency { get; set; }
        //  public TimeSpan FinishAt { get; set; }
    }
}