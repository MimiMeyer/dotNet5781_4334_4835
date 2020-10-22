using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_00_4334_4835
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4835();
            Welcome4334();
            Console.ReadKey();
        }
        static partial void Welcome4334();
 
      
        private static void Welcome4835()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, Welcome to my first console application", name);
        }
        

    } 
}
