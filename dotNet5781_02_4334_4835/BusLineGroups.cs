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
        /*adds line to list*/
        public void Add(BLine line)
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
                if (line.FirstStation != lines[j].LastStation)
                {
                    throw new ArgumentException("Line must be the retrun bus, so first station must equal the last station");
                }
                if (line.LastStation != lines[j].FirstStation)
                {
                    throw new ArgumentException("Line must be the retrun bus, so last station must equal the first station");
                }
                else if (line.FirstStation == lines[j].LastStation && line.LastStation == lines[j].FirstStation)
                {
                    lines.Add(line);
                }

            }
            if (count == 0)
            {
                lines.Add(line);//line did not exist in the list prior;
            }

        }
        /*removes line from list*/
        public void Remove(BLine line)
        {
            int count = 0;
            foreach (BLine bus in lines)
            {
                if (bus.BusLine == line.BusLine)
                {
                    lines.Remove(bus);
                    count++;//Will delete the bus twice or once or not at all.
                }
                else if (count == 0)
                {
                    throw new ArgumentException("bus does not exist"); //lets the user know that the bus doesn't exist.
                }

            }
        }
        public List<BLine> ListOfLines(int stop)
        {
            List<BLine> stationLines = new List<BLine>();// new list of lines that go through the same bus stop
            foreach (BLine bus in lines)
            {
                List<int> busCodes = bus.PrintStationCodes(bus.Stations);
                foreach (int x in busCodes)
                {
                    if (x == stop)
                        stationLines.Add(bus);
                }

            }
            return stationLines;
        }
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
        public BLine this[int index]//allows to access lines as an array instaed of as a list
        {
            get
            {
                return lines.Find(bus => bus.BusLine == index); //returns the bus in the index
            }
            set
            {
                if (value != null)//line does exist
                {
                    lines[index] = value;
                }
                else
                {
                    throw new Exception("bus line does not exist");//line does not exist
                }
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
