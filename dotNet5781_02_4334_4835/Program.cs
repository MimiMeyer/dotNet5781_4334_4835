using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4334_4835
{
    static class Program
    {

        private static Random rand = new Random();//helps with generating random numbers


        static void Main(string[] args)
        {
            BusLineGroup BusCompany = new BusLineGroup();//new bus Company
            GenerateBusLines(BusCompany);
           
            
            CHOICE choice;
            do
            {
                Console.WriteLine("Choose an action");
                Console.WriteLine("ADD,DELETE,FIND,PRINT,EXIT= -1");
                bool success = Enum.TryParse(Console.ReadLine(), out choice);


                switch (choice)
                {
                    case CHOICE.ADD:
                        break;
                    case CHOICE.DELETE:
                        break;
                    case CHOICE.FIND:
                        break;
                    case CHOICE.PRINT:
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);
         
  

    
    }
        /*adds lines to bus company*/
    private static void  GenerateBusLines(BusLineGroup BusCompany)
        {
            List<BusStopLine> tenStations = new List<BusStopLine>();//list to make sure 10 stops have more than one bus.
            
            for (int i = 0; i < 10; i++)
            {

                tenStations.Add(generateRandomStation());//adding random stations to list

            }
            for (int i = 0; i < 10; i++)//adding 10 bus lines with random stations
            {
                int x = 8;
                BLine busLine = getRandomBusLine(x, tenStations);
                BusCompany.AddLine(busLine);
            }

            for (int i = 0; i < 2; i++)//adding 2 bus lines with the stations of tenStations to make sure 10 stops have more than one bus.
            {
                int x = 2;
                BLine busLine = getRandomBusLine(x, tenStations);
                BusCompany.AddLine(busLine);
            }
        }
        private static BLine getRandomBusLine(int x, List<BusStopLine> tenStations)
        {
            BLine busLine = new BLine();//the new line

            int busLineNumber = rand.Next(1, 999);//random bus number
            District area = (District)rand.Next(Enum.GetNames(typeof(District)).Length);//random area

            if (x == 10)
            {
                BusStopLine first = generateRandomStation();//random first station
                BusStopLine last = generateRandomStation();//random last station
                
                busLine.BusLine = busLineNumber;//new lines bus number
                busLine.FirstStation = first;// new lines first station
                busLine.LastStation = last;//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 0; i < 2; i++)//adss two more stations to the begining

                {
                    busLine.AddStation(i, generateRandomStation());
                }
            }
            else
            { 
                BusStopLine first = tenStations[0];//first station from list 
                BusStopLine last = tenStations[9];//last station from list
                busLine.BusLine = busLineNumber;//new lines bus number
                busLine.FirstStation = first;// new lines first station
                busLine.LastStation = last;//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 1; i < 9; i++)//adss two more stations to the begining

                {
                    busLine.AddStation(i,tenStations[rand.Next(0, 8)]);//adds stations from list in random order.
                }
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
