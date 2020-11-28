using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_4334_4835
{
    public class BusLineGroup : IEnumerable<BLine>
    {
        private List<BLine> lines = new List<BLine>();


     bool NotEqualBackandforth(BLine Bus1, BLine Bus2)/* use for addline to make sure a line is added if its the same line going the opposite way.*/
        {
            bool equal = true;
            if (Bus1.FirstStation.BusStationKey == Bus2.LastStation.BusStationKey & Bus1.FirstStation.Latitude==Bus2.LastStation.Latitude&&
                Bus1.FirstStation.Longitude == Bus2.LastStation.Longitude) { equal = false; }
            return equal;
        }
        
        /*adds line to list*/
        public void AddLine(BLine line)
        {
            
            int count = 0, i = 0, j = 0;
            foreach (BLine bus in lines)
            {
                if (bus.BusLine == line.BusLine)
                {
                    count++;//checks how many times it's in the list
                    j = i;//index where bus is in busline to use incase the line is in the list once.
                }
                i++;//to update the j for the index

            }
            if (count >= 2)// throws exception if line already appears twice in list.
            {
                throw new ArgumentException("line already has back and forth busses");
            }
            if (count == 1)
                
            {
                
                if (NotEqualBackandforth(line, lines[j]))
                {
                    throw new ArgumentException("Line must be the retrun bus, so first station must equal the last station");
                }
                
                if (NotEqualBackandforth(lines[j],line))
                {
                    throw new ArgumentException("Line must be the retrun bus, so last station must equal the first station");
                }
               
                    lines.Add(line);
              

            }
            if (count == 0)
            {
                lines.Add(line);//line did not exist in the list prior;
            }

        }
        /*removes line from list*/
        public void RemoveLine(BLine line,List<BusStopLine> BusStops)
        {
            int count = 0;
            foreach (BLine bus in lines.ToList())
            {
                if (bus.BusLine == line.BusLine)
                {
                    count++;//Will delete the bus twice or once or not at all.
                    foreach (BusStopLine b in bus.Stations) 
                    {
                        BusStops.Remove(b);
                    }
                    lines.Remove(bus);
                    
                }
              }
           

        }
        /*Returns the lines that go through requested bus stop*/
        public List<BLine> ListOfLines(int stop)
        {
            List<BLine> stationLines = new List<BLine>();// new list of lines that go through the same bus stop
            foreach (BLine bus in lines)
            {
                 foreach (BusStopLine station in bus.Stations)
                {
                    if (station.BusStationKey == stop)
                    {
                        stationLines.Add(bus);
                       
                    }
                }

            }
            if (stationLines.Count == 0)
            { 
                throw new ArgumentException("stop does not exist");
            }
            return stationLines;
        }
        /*returns sorted list of bus lines according to sum of travel*/
        public List<BLine> ListOfSortedLines()
        {
            List<BLine> SortedLines = lines;
            BLine temp;//help
            for (int j = 0; j <= SortedLines.Count - 2; j++)
            {//used bubble sort
                for (int i = 0; i <= SortedLines.Count - 2; i++)
                {
                    if (SortedLines[i].SumTime() > SortedLines[i + 1].SumTime())
                    {
                        temp = SortedLines[i + 1];
                        SortedLines[i + 1] = SortedLines[i];
                        SortedLines[i] = temp;
                    }
                }
            }
            return SortedLines;//sorted list of bus lines according to sum of travel.
        }

        /*indexer*/
        public BLine this[int index]//allows to access lines as an array instaed of as a list(lines is a field of the class).
        {

            get
            {
                BLine b = lines.Find(bus => bus.BusLine == index);
                if (b == null)//line does exist
                {
                    throw new ArgumentException("bus line does not exist");//line does not exist
                }

                return b;//returns the number bus in the index
            }

            set
            {

                lines[index] = value;
            }
        }
       
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
