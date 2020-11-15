using System;
using System.Collections;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
    public class BusLineGroups : IEnumerable<BLine>
    {
        private List<BLine> lines;


        /*constructor*/
        public BusLineGroups()
        {
            lines = new List<BLine>();
        }
        public void Add(BLine line)
        { 
            int count = 0,i=0,j=0;
            foreach (BLine bus in lines)
            {
                if (bus.BusLine == line.BusLine)
                { count++;
                     j = i;//index where bus is in busline to use incase the line is in the list once.
                }
                i++;
                
            }
            if (count >= 2)// throws exception if line already appears twice in list.
            {
                throw new ArgumentException("line already has back and forth busses");
            }
            if (count == 1)
            {
                if (line.FirstStation != lines[j].LastStation) 
                { 
                    throw new ArgumentException("Line must be the retrun bus, so first station must equal the last station");
                }
                if (line.LastStation != lines[j].FirstStation)
                {
                    throw new ArgumentException("Line must be the retrun bus, so last station must equal the first station");
                }
                lines.Add(line);
                
            }
            else { 
            lines.Add(line);//line did not exist in the list prior;
            }

        }
        public void Remove() { }

        public IEnumerator<BLine> GetEnumerator()
        {
            return lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



    }
}
