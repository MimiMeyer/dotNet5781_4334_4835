using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4334_4835
{
    static class Program
    {
        
        private static Random rand = new Random();
       

        static void Main(string[] args)
        {
            BusLineGroup BusCompany = new BusLineGroup();
            GenerateBusLines(BusCompany);
            
            
        }
       
        private static void  GenerateBusLines(BusLineGroup BusCompany)
        {
            for (int i = 0; i < 10; i++)
            {
                BLine busLine = getRandomBusLine();
                BusCompany.AddLine(busLine);
            }
        }
        private static BLine getRandomBusLine() 
        {
            int busLineNumber = rand.Next(1,999);
            BusStopLine first = generateRandomStation();
            BusStopLine last = generateRandomStation();
            District area = (District)rand.Next(Enum.GetNames(typeof(District)).Length);
            BLine busLine = new BLine();
            busLine.BusLine = busLineNumber;
            busLine.FirstStation = first;
            busLine.LastStation=last;
            busLine.Area = area;
            for(int i = 0; i < 4; i++)
            {
                busLine.AddStation(i, generateRandomStation());
            }

            return busLine;
        }
        private static BusStopLine generateRandomStation() 
        {
            int stationcode = rand.Next(1, 999999);// random number till 6 digits.
            double latitude=rand.NextDouble()*(33.3 - 31) + 31;//random number between 31 to 33.3 in Israel.
            double longitude= rand.NextDouble() * (35.5 - 34.3) + 34.3;//random number between 34.3 to 35.5 in Israel.

            return new BusStopLine(stationcode, latitude, longitude);
                
                
        }
    }

}
