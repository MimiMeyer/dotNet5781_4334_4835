using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNet5781_02_4334_4835
{
    public class Program
    {
        static void Main(string[] args)
        {
            BusLineGroup BusCompany = new BusLineGroup();//new bus Company
            List<BusStopLine> BusStops = new List<BusStopLine>();//list to help making sure station without the same cordinates don't have the same station code.
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
                        string aInput = Console.ReadLine();
                        try
                        {
                            if (aInput != "ADDBUS" && aInput != "ADDSTOP") //throws exception if input is invalid.
                                throw new ArgumentException("Input must be ADDSTOP or ADDBUS");
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        if (aInput == "ADDBUS")// adds bus to the bus company
                        {
                            BLine busLine = new BLine();//new busline
                            busLine.AddBus(BusStops);//busline gets values from user using Addbus
                            try { BusCompany.AddLine(busLine); }//makes sure if line exists its the same bus just the way back.
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }

                        }
                        else if (aInput == "ADDSTOP")//adds stop to  requested bus line number.
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
                                stop.CheckStation(BusStops);//making sure that if the station exists its the same station if not will go to ctach
                                line.AddStation(index, stop);//adds station if index is correct
                            }
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        break;
                    case CHOICE.DELETE:
                        Console.WriteLine("write DELBUS to delete a bus or DELSTOP to delete a stop");
                        string dInput = Console.ReadLine();
                        try
                        {
                            if (dInput != "DELBUS" && dInput != "DELSTOP") //throws exception if input is invalid.

                                throw new ArgumentException("Input must be DELBUS or DELSTOP");
                        }

                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        if (dInput == "DELBUS")// deletes the bus line from the bus company.
                        {

                            Console.WriteLine("Enter which line you would like to delete");
                            int busLine = Convert.ToInt32(Console.ReadLine());//getting bus line number from user
                            try
                            {

                                BLine line = BusCompany[busLine];//using indexer to get value if bus doesnt exist will go to catch
                                BusCompany.RemoveLine(line, BusStops);//removes line from bus comapny and the stations from busstops once

                            }
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }

                        else if (dInput == "DELSTOP")// deletes stop from requested bus line number
                        {
                            Console.WriteLine("Enter which line you would like to delete statiom from");
                            int busLine = Convert.ToInt32(Console.ReadLine());//getting bus line number from user
                            try
                            {
                                BLine line = BusCompany[busLine];// checking if bus exists if not will go to catch
                                Console.WriteLine("Enter station you want to delete:");
                                int B = Convert.ToInt32(Console.ReadLine());// gets station code from user

                                foreach (BusStopLine s in line.Stations.ToList())
                                {
                                    if (B == s.BusStationKey)
                                    {
                                        line.RemoveStation(s);//remove from line
                                        BusStops.Remove(s);//remove from list of stations
                                    }
                                }
                            }
                            catch (ArgumentException exception)// throws exception
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        break;
                    case CHOICE.FIND:
                        Console.WriteLine("write FINDBUS to find lines that go through that station or FINDROUTE to find a route");
                        string fInput = Console.ReadLine();
                        try
                        {
                            if (fInput != "FINDBUS" && fInput != "FINDROUTE") //throws exception if input is invalid.

                                throw new ArgumentException("Input must be FINDBUS or FINDROUTE");
                        }

                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        if (fInput == "FINDBUS")//gets stop and returns the busses that go through it
                        {
                            Console.WriteLine("Enter station code you want lines printed out for");
                            int stop = Convert.ToInt32(Console.ReadLine());//input of user
                            try//to make sue stop exists
                            {
                                List<BLine> lines = BusCompany.ListOfLines(stop);//list of lines that go through station
                                Console.WriteLine("The busses are: ");
                                foreach (BLine bus in lines)
                                {
                                    Console.WriteLine(bus.BusLine); //prints each line
                                }
                            }
                            catch (ArgumentException exception)//if bus does not exist
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        else if (fInput == "FINDROUTE")//gets 2 stations from user and returns the  sorted list of buses that go through that route.
                        {
                            Console.WriteLine("Enter station code of first stop");
                            int c1 = Convert.ToInt32(Console.ReadLine());//Station code of first stop
                            Console.WriteLine("Enter station code of second stop");
                            int c2 = Convert.ToInt32(Console.ReadLine());//station code of second stop
                            BusStopLine stop1 = new BusStopLine();
                            BusStopLine stop2 = new BusStopLine();
                            int count = 0;
                            bool exists = false;
                            foreach (BusStopLine s in BusStops)//finding stops;
                            {
                                if (c1 == s.BusStationKey)
                                {
                                    stop1 = s;
                                    count++;
                                }
                                if (c2 == s.BusStationKey)
                                {
                                    stop2 = s;
                                    count++;
                                }
                            }
                            try
                            {
                                if (count < 2) { throw new ArgumentException("bus station code does not exist"); }// if 1 of the bus stops does not exist
                            }

                            catch (ArgumentException exception)//throws exception
                            {
                                Console.WriteLine(exception.Message);
                            }

                            BusLineGroup Sub = new BusLineGroup();//New bus line group             
                            foreach (BLine b in BusCompany)//checking all the busses in BusCompany
                            {
                                bool found = true;
                                int index1 = 0, index2 = 0, counter = 0;//help
                                if (!b.Found(stop1) || !b.Found(stop2))// cheks if stops exist in line
                                
                                    found = false;
                                    
                                if(found)// if both stops exist in line
                                { 
                                    foreach (BusStopLine station in b.Stations)
                                    {
                                        if (station.BusStationKey == stop1.BusStationKey)//finding index of first stop 
                                        {
                                            index1 = counter;
                                        }
                                        if (station.BusStationKey == stop2.BusStationKey)//finding index of second stop
                                        {
                                            index2 = counter;
                                        }
                                        counter++;//counter for the index

                                    }
                                    if (index1 > index2 || (index1 == index2))//bus stops in the wrong order in the line.
                                    {
                                        found = false;
                                    }
                                }
                                 if (found)// stops exist and in the correct order
                                {
                                    BLine Bus = b.StationPath(stop1, stop2);//returns a the bus with the sub route.
                                    Sub.AddLine(Bus);// adds line to new BusLineGroup Sub
                                    exists = true;//checks if stops were ever found
                                    
                                }
                            }
                            try
                            {
                                if (!exists)// none of the buses had the stops in the correct order or had both stops
                                    throw new ArgumentException("stations were not in the correct order or were not in the same bus");
                            }
                            catch (ArgumentException exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                            List<BLine> busses = Sub.ListOfSortedLines();//new list of the buses with the sub route sorted by sum of travel.
                            Console.WriteLine("List of busses: ");
                            foreach (BLine bus in busses)
                            {
                                Console.WriteLine(bus.BusLine);// prints te busses
                            }

                        }

                        break;
                
                    case CHOICE.PRINT:
                        Console.WriteLine("write PRINTBUS to print all the bus or PRINTSTOP to print all the stops and the lines that go through them");
                        string pInput = Console.ReadLine();
                        try
                        {
                            if (pInput != "PRINTBUS" && pInput != "PRINTSTOP") //throws exception if input is invalid.

                                throw new ArgumentException("Input must be PRINTBUS or PRINTSTOP");
                        }

                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        if (pInput == "PRINTBUS")//prints busses
                        {
                            foreach (BLine bus in BusCompany)
                            {
                                Console.WriteLine(bus);//prints out all the busses with there stops
                            }
                        }
                        else if (pInput == "PRINTSTOP")//prints the stations and the buses that go through them.
                        {
                            string result = "list of stations: " + "\n";
                            List<BusStopLine> noMult = BusStops.Distinct().ToList();//makes new list with no multiple bus stations

                            foreach (BusStopLine s in noMult)//goes over list
                            {
                                result += "The Station is: " + s + "\n" + "The lines that go through this station are: " + "\n";//prints station

                                List<BLine> lines = BusCompany.ListOfLines(s.BusStationKey);//list of lines that go through station

                                foreach (BLine bus in lines)//goes over the list of lines
                                {
                                    result += bus.BusLine + "\n";//adding the line to print
                                }
                            }
                            Console.WriteLine(result);// prints the whole string
                        }

                        break;
                    case CHOICE.EXIT:// leave the loop
                        break;
                    default:
                        break;
                }

            } while (choice != CHOICE.EXIT);

        }



        /*adds lines to bus company*/
        public static void GenerateBusLines(BusLineGroup BusCompany, List<BusStopLine> busStops)
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
                    BusCompany.AddLine(busLine);//adding line to bus company

                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);

                }

            }


            for (int i = 0; i < 2; i++)//adding 2 bus lines with the stations of tenStations to make sure 10 stops have more than one bus.
            {
                int x = 2;
                BLine busLine = getRandomBusLine(x, tenStations, busStops);//gets random bus line
                try
                {
                    BusCompany.AddLine(busLine);// checks if bus line already exists and if it does has to be the way back route.
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);

                }
            }
        }
        /*returns random bus line*/
        public static BLine getRandomBusLine(int x, List<BusStopLine> tenStations, List<BusStopLine> busStops)
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
                    busLine.AddStation(i, GenerateRandomStation(busStops));//adds 2 stops
                }
            }

            else// if x==2
            {
                BusStopLine first = tenStations[0];//first station from list 
                BusStopLine last = tenStations[9];//last station from list
                try
                {
                    first.CheckStation(busStops);//throws exception if bus stop already exists with diffrent coordinates.
                    last.CheckStation(busStops);//throws exception if bus stop already exists with diffrent coordinates.

                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                busLine.BusLine = busLineNumber;//new lines bus number
                busLine.AddFirst(first);// new lines first station
                busLine.AddLast(last);//new lines last station
                busLine.Area = area;//new lines area
                for (int i = 1; i < 9; i++)//adds anothe 8 stops from list

                {
                    busLine.AddStation(i, tenStations[i]);//adds stations from list in order.
                }
            }


            return busLine;//new bus line
        }
        /*didn't add random stops to list*/
        public static BusStopLine GenerateRandomStation(List<BusStopLine> BusStops)
        {

            int stationcode = rand.Next(1, 999999);// random number till 6 digits.
            double latitude = Math.Round(rand.NextDouble() * (33.3 - 31) + 31, 5);//random number between 31 to 33.3 in Israel.
            double longitude = Math.Round(rand.NextDouble() * (35.5 - 34.3) + 34.3,5);//random number between 34.3 to 35.5 in Israel.
            
            BusStopLine stop = new BusStopLine(stationcode, latitude, longitude);

            try
            {
                stop.CheckStation(BusStops);//throws exception if bus stop already exists with diffrent coordinates.

            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return stop;
        }


    }
}



