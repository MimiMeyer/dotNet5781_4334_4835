using System;
using System.Collections.Generic;

namespace dotNet5781_02_4334_4835
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLineGroup BusCompany = new BusLineGroup();//new bus Company
            
            GenerateBusLines(BusCompany);
            bool success;//helps to check if the user choice is valid
            CHOICE choice;//choices from enum
            RM_Busses(BusCompany,  out choice, out success);//calls on the function RM_Busses

        }
        private static Random rand = new Random();//helps with generating random numbers


        private static void RM_Busses(BusLineGroup BusCompany, out CHOICE choice, out bool success)
        {
            /*as long as the user choice is not EXIT keep inserting*/
            do
            {
                /*as long as the user choice is not valid keep inserting*/
                do
                {
                    Console.WriteLine("Choose an action");
                    Console.WriteLine("ADD, DELETE, FIND, PRINT, EXIT = -1");

                    success = Enum.TryParse(Console.ReadLine(), out choice);
                    Console.ReadKey();
                }
                while (success == false);
                switch (choice)
                {
                    case CHOICE.ADD:
                        Console.WriteLine("write ADDBUS to add a bus or ADDSTOP to add a stop");
                        string x = Console.ReadLine();
                        if (x != "ADDBUS" && x != "ADDSTOP") //throws exception if input is invalid.
                        { throw new Exception("invalid input"); }
                        if (x == "ADDBUS")
                        {
                            BLine busLine = new BLine();
                            busLine.AddBus();
                            try { BusCompany.AddLine(busLine); }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                        }
                        else if (x == "ADDSTOP")
                        {

                        }
                        break;
                    case CHOICE.DELETE:
                        break;
                    case CHOICE.FIND:
                        break;
                    case CHOICE.PRINT:
                        foreach (BLine bus in BusCompany)
                        {
                            Console.WriteLine(bus);
                        }
                        break;
                    case CHOICE.EXIT:
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);

        }
        /*adds lines to bus company*/
        private static void GenerateBusLines(BusLineGroup BusCompany)
        {
            List<BusStopLine> tenStations = new List<BusStopLine>();//list to make sure 10 stops have more than one bus.

            for (int i = 0; i < 10; i++)
            {

                tenStations.Add(generateRandomStation());//adding random stations to list

            }
            for (int i = 0; i < 10; i++)//adding 10 bus lines with random stations
            {
                int x = 10;
                BLine busLine = getRandomBusLine(x, tenStations);
                try { BusCompany.AddLine(busLine); }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                }
            }

            for (int i = 0; i < 2; i++)//adding 2 bus lines with the stations of tenStations to make sure 10 stops have more than one bus.
            {
                int x = 2;
                BLine busLine = getRandomBusLine(x, tenStations);
                try { BusCompany.AddLine(busLine); }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                }
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
                busLine.AddFirst(first);// new lines first station
                busLine.AddLast(last);//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 0; i < 2; i++)//adss two more stations to the begining

                {
                    busLine.AddStation(i, generateRandomStation());
                }
            }
            else// if x==2
            {
                BusStopLine first = tenStations[0];//first station from list 
                BusStopLine last = tenStations[9];//last station from list
                busLine.BusLine = busLineNumber;//new lines bus number
                busLine.AddFirst(first);// new lines first station
                busLine.AddLast(last);//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 0; i < 8; i++)//adds anothe 8 stops from list

                {
                    busLine.AddStation(i, tenStations[i]);//adds stations from list in order.
                }
            }


            return busLine;//new bus line
        }

        private static BusStopLine generateRandomStation()
        {


            int stationcode = rand.Next(1, 999999);// random number till 6 digits.

            double latitude = rand.NextDouble() * (33.3 - 31) + 31;//random number between 31 to 33.3 in Israel.
            double longitude = rand.NextDouble() * (35.5 - 34.3) + 34.3;//random number between 34.3 to 35.5 in Israel.
            BusStopLine stop = new BusStopLine(stationcode, latitude, longitude);
            return stop;//return new bus stop


        }
    }


}



