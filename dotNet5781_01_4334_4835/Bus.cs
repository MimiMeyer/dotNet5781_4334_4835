using System;
using System.Collections.Generic;

namespace dotNet5781_01_4334_4835
{
    public class Bus
    {
        private string licensePlate;
        private DateTime start_Date;
        private DateTime checkupDate;
        private const int fullTank = 1200;//max
        public int sumKm;
        private int gas;


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
                    throw new Exception("License plate not valid");
                }
            }
        }

        /**constructer**/
        public Bus(List<Bus> busses)
        {
            gas = 0;
            sumKm = 0;
            checkupDate = start_Date;
            Console.WriteLine("Enter starting date: ");
            bool success = DateTime.TryParse(Console.ReadLine(), out start_Date);
            if (!success)
            {
                throw new Exception("Invalid date!");
            }
            Console.WriteLine("Enter license plate number:");
            License_Plate = Console.ReadLine();
            //checks if license already exists in list
            foreach (Bus bus in busses)
            {
                if (this.licensePlate == License_Plate) {
                    throw new Exception("Invalid license plate");
                }
            }
        
       
        } 

        public override string ToString()
        {
            string begining, middle, end, fixedLicense;

            if (licensePlate.Length == 8)
            { // if equals 8 then the fixed format should be xxx-xx-xxx
                begining = licensePlate.Substring(0, 3);
                middle = licensePlate.Substring(3, 2);
                end = licensePlate.Substring(5, 3);
                fixedLicense = String.Format("{0}-{1}-{2}", begining, middle, end);
            }
            else
            {
                // if equals 7 then the fixed format should bexx-xxx-xx
                begining = licensePlate.Substring(0, 2);
                middle = licensePlate.Substring(2, 3);
                end = licensePlate.Substring(5, 2);
                fixedLicense = String.Format("{0}-{1}-{2}", begining, middle, end);


            }
            return String.Format("license is: {0,-10}, Total km: {1}", fixedLicense,sumKm );
        }

        public void CheckIfOK(int km)
        {
            TimeSpan s = DateTime.Today - this.checkupDate;
            double diffrence = s.TotalDays;
            if (( gas < km)&& (km + this.sumKm >= 20000 || diffrence > 365)) 
            { throw new Exception("need a checkup and fill up gas"); }
            if (km + this.sumKm >= 20000 || diffrence > 365)
            {
                throw new Exception("need a checkup");
            }

            if ( gas < km)
            {
                throw new Exception("Need to fill up gas");
            }
            else
            {
                this.sumKm = this.sumKm + km;
                this.gas = this.gas - km;

            }

        }

        /***fills tank***/
        public void Gas()
        {
            this.gas = fullTank;
        }
        public void Checkup()
        {
            this.sumKm = 0;
            this.checkupDate = DateTime.Today;
        }

    }
}
