using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4334_4835
{
   public class BusLineGroups : IEnumerable<BLine>
    {
        private List<int> lines = new List<int>();
        private List<BLine> busses;
   
       /*constructor*/
        public BusLineGroups()
        {
            busses = new List<BLine>();
        }
        public void Add(BLine)
        {
            
        }
        public IEnumerator<BLine> GetEnumerator()
        {
            return busses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

       
        
    }
}
