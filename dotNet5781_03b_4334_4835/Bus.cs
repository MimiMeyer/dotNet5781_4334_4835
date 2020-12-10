
using System;
using System.Collections.Generic;

namespace dotNet5781_03b_4334_4835
{
    public class Bus
    {
        private string licensePlate;
        private DateTime start_Date;
        private DateTime checkupDate;
        private const int fullTank = 1200;//max
        public int sumKm{get;set;}//the total KM traveled
        public int gas { get; set; }
        private string status;
        private List<string> State = new List<string>()
        { "Ready","In the middle","In checkup","In refuel" };//list of diffrent typesof states for status
       
        public string Status
        {
            get
            {
                return status;
            }
            private set
            {
                bool x = false;
                foreach (string s in State)//making sure the status exists
                { if (value == s)
                    {
                        x = true; 
                    }

                } 
                if(x)
                { status = value; 
                }
                else
                {
                    throw new ArgumentException("Not one of the possible states");
                }

            }
        }
        public DateTime Start_Date { 
            get { return start_Date; }
            set { start_Date = value; }
        }
    
        //get and set licensePlate
        public string License_Plate
        {
            get
            {
                return licensePlate;
            }
            private set
            {
                //checking if license plate is valid.
                if ((start_Date.Year < 2018 && value.Length == 7) || (start_Date.Year >= 2018 && value.Length == 8))
                {
                    licensePlate = value;
                }
                else
                {
                    throw new ArgumentException("License plate not valid");
                }
            }
        }

        /**constructor**/
        public Bus(List<Bus> busses)
        {
            gas = 0;
            sumKm = 0;
            checkupDate = start_Date;
            Console.WriteLine("Enter starting date: ");
            bool success = DateTime.TryParse(Console.ReadLine(), out start_Date);
            if (!success)
            {
                throw new ArgumentException("Invalid date!");
            }
            Console.WriteLine("Enter license plate number:");
            License_Plate = Console.ReadLine();
            //checks if license already exists and if it does throws an ecexption
            foreach (Bus bus in busses)
            {
                if (this.licensePlate == License_Plate)
                {
                    throw new ArgumentException("Invalid license plate");
                }
            }


        }
        public Bus(List<Bus> busses,String license,DateTime start,int fuel, int sum)
        {
            foreach (Bus bus in busses)
            {
                if (license == License_Plate)
                {
                    throw new ArgumentException("Invalid license plate");
                }
            }

            gas = fuel;
            sumKm = sum;
            Start_Date = start;
            checkupDate = start;
            License_Plate = license;
            Status = "Ready";
            //checks if license already exists and if it does throws an ecexption
            
        }
        //returns the fixed format of license plate and the km traveled.
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
                // if equals 7 then the fixed format should be xx-xxx-xx
                begining = licensePlate.Substring(0, 2);
                middle = licensePlate.Substring(2, 3);
                end = licensePlate.Substring(5, 2);
                fixedLicense = String.Format("{0}-{1}-{2}", begining, middle, end);


            }
            return String.Format("License is: {0,-10}, Total km: {1}", fixedLicense,sumKm );
        }
        //checks if bus is able to travel
        public void CheckIfOK(int km)
        {
            Status = "Ready";
            TimeSpan s = DateTime.Today - this.checkupDate;//the difference between today and the last checkup date
            double diffrence = s.TotalDays;//the difference in days
            /*checks if there's enough gas and if it needs a checkup*/
            if (( gas < km)&& (km + this.sumKm >= 20000 || diffrence > 365)) 
            { 
                throw new ArgumentException("Needs a checkup and to fill up gas"); 
            }
            /*checks if it only needs a checkup*/
            if (km + this.sumKm >= 20000 || diffrence > 365)
            {
                throw new ArgumentException("Needs a checkup");
            }
            /*checks if it only needs gas*/
            if ( gas < km)
            {
                throw new ArgumentException("Needs to fill up gas");
            }
            /*updates the gas used and the km traveled*/
            
            else
            {
                this.sumKm = this.sumKm + km;
                this.gas = this.gas - km;
                Status = "In the middle";

            }

        }

        /***fills tank***/
        public void Refuel()
        {
            this.gas = fullTank;
            Status = "In refuel";
        }

        /*after a checkup updates the km to 0 and the checkup date to today and also refills gas if needed*/
        public void Checkup()
        {
            if (gas < 500) //???????
            { Refuel(); }
                this.sumKm = 0;
            this.checkupDate = DateTime.Today;
            Status = "In checkup";
            
        }
        

    }
}
