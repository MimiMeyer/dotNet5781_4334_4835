using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Bus
    {
        public int LicenseNum { get; set; }
        public DateTime FromDate { get; set; }
        public double ToatalTrip { get; set; }
        public double FuelRemain { get; set; }
        public BusStatus status { get; set; }
        public override string ToString()
        {
            string begining, middle, end, fixedLicense, licensePlate=LicenseNum.ToString();
            
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
            return String.Format("License is: {0,-10}, Total km: {1}", fixedLicense, ToatalTrip);
        }

    }
}
