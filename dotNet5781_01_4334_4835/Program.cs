using System;
using System.Collections.Generic;


namespace dotNet5781_01_4334_4835
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Bus> busses = new List<Bus>();//create a list for busses
            Choices choice;// enum choices
            bool success;//helps to check if the user choice is valid
            RM_Busses(busses, out choice, out success);//calls on the function RM_Busses
        }
        private static void RM_Busses(List<Bus> busses, out Choices choice, out bool success)
        {
            /*as long as the user choice is not EXIT keep inserting*/
            do
            {
                /*as long as the user choice is not valid keep inserting*/
                do
                {
                    Console.WriteLine("Choose an action");
                    Console.WriteLine("ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1");
                    success = Enum.TryParse(Console.ReadLine(), out choice);
                }
                while (success == false);
                switch (choice)
                {
                    /*adds a new bus to the list*/
                    case Choices.ADD:
                        try
                        {
                            busses.Add(new Bus(busses));

                        }
                        catch (Exception exception)//catches if starting date or license number is not valid
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;
                    /*checks if the chosen bus is able to travel*/
                    case Choices.PICK:
                        Console.WriteLine("enter a license plate number");
                        string license = Console.ReadLine();
                        Random r = new Random(DateTime.Now.Millisecond); //choosing a random number for km
                        int ridingKm = r.Next(1, 1200);//the range is 1-1200
                        //checks if the bus exists in the list and if it does returns it
                        Bus foundBus = FindBus(busses, license);
                        if (foundBus != null)//if the bus is found
                        {
                            try
                            {
                                foundBus.CheckIfOK(ridingKm);

                            }
                            catch (Exception exception)
                            {
                                Console.WriteLine(exception.Message);
                            }
                        }
                        else//the bus is not found
                        {
                            Console.WriteLine("bus does not exist");
                        }
                        break;
                    //fills up gas or does checkup based on user's request.
                    case Choices.GAS_CHECKUP:
                        Console.WriteLine("enter a license plate number");
                        string l = Console.ReadLine();
                        Bus Help = FindBus(busses, l);//checks if the bus exists in the list and if it does returns it
                        if (Help == null)//if the bus is not found.
                        {
                            Console.WriteLine("bus does not exist");
                        }
                        else//the bus is found.
                        {
                            Console.WriteLine("If you want to put in gas enter GAS and if you want a checup enter CHECK");
                            string action = Console.ReadLine();
                            if (action == "GAS")//fills up gas
                            {
                                Help.Gas();
                            }
                            if (action == "CHECK")//does checkup
                            {
                                Help.Checkup();
                            }

                            if (action != "GAS" && action != "CHECK")//invalid request
                            {
                                Console.WriteLine("invalid request");
                            }
                        }
                        break;
                    //prints out the the license plate and total km traveled for busses in the list. 
                    case Choices.TOTAL:
                        foreach (Bus bus in busses)
                        {
                            Console.WriteLine(bus);
                        }
                        break;
                    //exit the actions
                    case Choices.EXIT:
                        break;
                }

            } while (choice != Choices.EXIT);

        }

        //checks if bus exists in the list and returns it.
        private static Bus FindBus(List<Bus> busses, string license)
        {
            Bus found = null;
            foreach (Bus bus in busses)
            {
                if (bus.License_Plate == license)
                {
                    return bus;
                }

            }
            return found;
        }
    }
}


/*GAS_CHECKUP
enter a license plate number
12345678
If you want to put in gas enter GAS and if you want a checup enter CHECK
GAS
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
PICK
enter a license plate number
12345678
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
TOTAL
license is: 123-45-678, Total km: 394
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
ADD
Enter starting date:
02/02/2002
Enter license plate number:
1234567
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
GAS_CHECKUP
enter a license plate number
1234567
If you want to put in gas enter GAS and if you want a checup enter CHECK
GAS
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
GAS_CHECKUP
enter a license plate number
1234567
If you want to put in gas enter GAS and if you want a checup enter CHECK
CHECK
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
TOTAL
license is: 123-45-678, Total km: 394
license is: 12-345-67 , Total km: 0
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
PICK
enter a license plate number
1234567
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
TOTAL
license is: 123-45-678, Total km: 394
license is: 12-345-67 , Total km: 458
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
GAS_CHECKUP
enter a license plate number
1234
bus does not exist
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1
GAS_CHECKUP
enter a license plate number
1234567
If you want to put in gas enter GAS and if you want a checup enter CHECK
123
invalid request
Choose an action
ADD, PICK, GAS_CHECKUP, TOTAL, EXIT = -1*/

