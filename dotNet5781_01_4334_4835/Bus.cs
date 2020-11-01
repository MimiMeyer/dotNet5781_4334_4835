using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_01_4334_4835
{
    public class Bus
    {
        private string licensePlate;
        private DateTime start_Date;
        private int km;
        private const int fullTank = 1200;//max
        public int Tank { get; set; }//current amount of fuel

        public string License_Plate
        {
            get
            {
                return licensePlate;
            }
            private set
            {
                if ((start_Date.Year < 2018 && value.Length == 7) || (start_Date.Year >= 2018 && value.Length == 8))
                {
                    licensePlate = value;
                }
                else
                {
                    throw new Exception("licsence plate not valid");
                }
            }
        }
        public int Km
        {
            get { return km; }
            set
            {
                if (value >= 0)
                {
                    km = value;
                }
            }
        }
        public void Gas(int gas)
        {
            Tank = fullTank;
        }

        public Bus()
        {
            Console.WriteLine("Enter starting date: ");

            bool success = DateTime.TryParse(Console.ReadLine(), out start_Date);
            if (!success)
            {
                throw new Exception("Invalid date!");
            }
            Console.WriteLine("Enter license plate number:");
            License_Plate = Console.ReadLine();
            
            


        }
    }
}