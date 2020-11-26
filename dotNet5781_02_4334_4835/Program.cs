using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_4334_4835
{
    class Program
    {
        static void Main(string[] args)
        {
            BusLineGroup BusCompany = new BusLineGroup();//new bus Company
            List<BusStopLine> BusStops = new List<BusStopLine>();//list to help make sure station without the same cordinates don't have the same station code.
            GenerateBusLines(BusCompany, BusStops);
            bool success;//helps to check if the user choice is valid
            CHOICE choice;//choices from enum
            RM_Busses(BusCompany, BusStops, out choice, out success);//calls on the function RM_Busses


        }
        private static Random rand = new Random();//helps with generating random numbers


        private static void RM_Busses(BusLineGroup BusCompany, List<BusStopLine> BusStops, out CHOICE choice, out bool success)
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
                        { Console.WriteLine("invalid input"); }
                        if (x == "ADDBUS")
                        {
                            BLine busLine = new BLine();//new busline
                            busLine.AddBus(BusStops);
                            try { BusCompany.AddLine(busLine); }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                        }
                        else if (x == "ADDSTOP")
                        {
                            Console.WriteLine("Enter which line you would like to add a station to");
                            int busLine = Convert.ToInt32(Console.ReadLine());//getting bus line number from user
                            try
                            {
                                BLine line = BusCompany[busLine];//cheking if busline number exists if not will go to cath
                                Console.WriteLine("Enter the index in which you would like to add the station");
                                int index = Convert.ToInt32(Console.ReadLine());//getting the index of where to add the bus stop.
                                Console.WriteLine("Enter station details:");
                                BusStopLine stop = new BusStopLine();//initializing stop
                                stop.AddStationUser();//getting station details from user


                                stop.CheckStation(BusStops);//making sure that if the station exists its the same station

                                line.AddStation(index, stop);//adds station if index is correct


                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        break;
                    case CHOICE.DELETE:
                        Console.WriteLine("write DELBUS to delete a bus or DELSTOP to delete a stop");
                        string input = Console.ReadLine();
                        if (input != "DELBUS" && input != "DELSTOP") //throws exception if input is invalid.
                        {
                            Console.WriteLine("invalid input");
                        }
                        if (input == "DELBUS")
                        {

                            Console.WriteLine("Enter which line you would like to delete");
                            int busLine = Convert.ToInt32(Console.ReadLine());//getting bus line number from user
                            try
                            {

                                BLine line = BusCompany[busLine];
                                BusCompany.RemoveLine(line, BusStops);

                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                        }

                        else if (input == "DELSTOP")
                        {
                            Console.WriteLine("Enter which line you would like to delete statiom from");
                            int busLine = Convert.ToInt32(Console.ReadLine());//getting bus line number from user
                            try
                            {
                                BLine line = BusCompany[busLine];
                                Console.WriteLine("Enter station you want to delete:");
                                int B = Convert.ToInt32(Console.ReadLine());
                                
                                foreach(BusStopLine s in line.Stations.ToList()) 
                                {
                                    if (B == s.BusStationKey)
                                    {
                                        line.RemoveStation(s);
                                        BusStops.Remove(s);
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
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
        private static void GenerateBusLines(BusLineGroup BusCompany, List<BusStopLine> busStops)
        {
            List<BusStopLine> tenStations = new List<BusStopLine>();//list to make sure 10 stops have more than one bus.

            for (int i = 0; i < 10; i++)
            {

                tenStations.Add(GenerateRandomStation(busStops));//adding random stations to list

            }
            for (int i = 0; i < 10; i++)//adding 10 bus lines with random stations
            {
                int x = 10;
                BLine busLine = getRandomBusLine(x, tenStations, busStops);
                try
                {
                    BusCompany.AddLine(busLine);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                }

            }


            for (int i = 0; i < 2; i++)//adding 2 bus lines with the stations of tenStations to make sure 10 stops have more than one bus.
            {
                int x = 2;
                BLine busLine = getRandomBusLine(x, tenStations, busStops);
                try
                {
                    BusCompany.AddLine(busLine);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);

                }
            }
        }
        private static BLine getRandomBusLine(int x, List<BusStopLine> tenStations, List<BusStopLine> busStops)
        {
            BLine busLine = new BLine();//the new line

            int busLineNumber = rand.Next(1, 999);//random bus number
            District area = (District)rand.Next(Enum.GetNames(typeof(District)).Length);//random area

            if (x == 10)
            {
                BusStopLine first = GenerateRandomStation(busStops);//random first station
                BusStopLine last = GenerateRandomStation(busStops);//random last station

                busLine.BusLine = busLineNumber;//new lines bus number
                busLine.AddFirst(first);// new lines first station
                busLine.AddLast(last);//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 0; i < 2; i++)//adss two more stations to the begining

                {
                    busLine.AddStation(i, GenerateRandomStation(busStops));
                }
            }

            else// if x==2
            {
                BusStopLine first = tenStations[0];//first station from list 
                BusStopLine last = tenStations[9];//last station from list
                try
                {
                    first.CheckStation(busStops);
                    last.CheckStation(busStops);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
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
        /*didn't add random stops to list*/
        private static BusStopLine GenerateRandomStation(List<BusStopLine> BusStops)
        {

            int stationcode = rand.Next(1, 999999);// random number till 6 digits.
            double latitude = rand.NextDouble() * (33.3 - 31) + 31;//random number between 31 to 33.3 in Israel.
            double longitude = rand.NextDouble() * (35.5 - 34.3) + 34.3;//random number between 34.3 to 35.5 in Israel.
            BusStopLine stop = new BusStopLine(stationcode, latitude, longitude);

            try
            {
                stop.CheckStation(BusStops);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return stop;
        }


    }
}



