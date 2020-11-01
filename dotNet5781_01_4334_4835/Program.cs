using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_4334_4835
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<Bus> busses = new List<Bus>();//create a list for busses
            Choices choice;
            bool success;
            RM_Busses(busses, out choice, out success);//make actions with it
        }
        private static void RM_Busses(List<Bus> busses, out Choices choice, out bool success)
        {
            do
            {
                do
                {
                    Console.WriteLine("Choose an action");
                    Console.WriteLine("ADD, PICK, GAS_MAINTENANCE, TOTAL, EXIT = -1");
                    success = Enum.TryParse(Console.ReadLine(), out choice);//if true in choosing one of the enum
                }
                while (success == false);
                switch(choice)
                {
                    case Choices.ADD:
                        try 
                        {
                            busses.Add(new Bus());
                                
                        }
                        catch(Exception exception) {
                            Console.WriteLine(exception.Message);// from Bus class
                        }
                        /*foreach(Bus bus in busses)
                        {
                            Console.WriteLine(bus)\
                        }*/
                        break;
                    case Choices.PICK:
                        Console.WriteLine("enter a license number");
                        string license = Console.ReadLine().Replace("-", String.Empty);
                        Bus findBus = null;
                        foreach (Bus bus in busses)
                        {
                            if (bus.License_Plate == license)
                            {
                                findBus = bus;//bus is found 
                                break;
                            }
                        }
                        if (findBus != null)
                        {
                            Console.WriteLine(findBus);
                        }
                        Random ridingKm=new Random(DateTime.Now.Millisecond);
                    
                        break;
                    case Choices.GAS_MAINTENANCE:
                        break;
                    case Choices.TOTAL:
                        break;
                    case Choices.EXIT:
                        break;
                }
            } while (choice != Choices.EXIT);
        }
    }

}
