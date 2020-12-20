using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;


using System.ComponentModel;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for Travel.xaml
    /// </summary>
    public partial class Travel : Window
    {

        private static Random r = new Random();//random number
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();
       

      /*makes sure user input is int in textbox*/
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static Bus bus { get; set; }// new bus
        public int Km { get; set; }// number of km that user will enter
       
        public Travel(Bus b)
        {
           InitializeComponent();
           bus = b;//the bus that the user pressed the button travel for
           backgroundWorker.DoWork += Backroundworker_DoWork;////calling on new thread
            backgroundWorker.RunWorkerCompleted += Backroundworker_WorkerCompleted;////once thread is complete



        }

        /* Checks user input. If input is int the user can enter the number ok km and this function checks if requested bus can travel*/
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null) { return; }
            if (km_textbox == null) { return; }//if no input was entered
            if (e.Key == Key.Return || e.Key == Key.Enter)//if key =enter
            {
                Km = int.Parse(km_textbox.Text);//gets user input in km

                bus.Status = "Ready";
                TimeSpan s = DateTime.Today - bus.checkupDate;//the difference between today and the last checkup date
                double diffrence = s.TotalDays;//the difference in days
                /*checks if there's enough gas and if it needs a checkup*/
                if ((bus.gas < Km) || (Km + bus.sumKm > 20000 || diffrence > 365))
                {
                    if ((bus.gas < Km) && (Km + bus.sumKm > 20000 || diffrence > 365))
                    {
                        MessageBox.Show("Needs a checkup and to fill up gas");
                    }
                    /*checks if it only needs a checkup*/
                    if (Km + bus.sumKm > 20000 || diffrence > 365)
                    {
                        MessageBox.Show("Needs a checkup");
                    }
                    /*checks if it only needs gas*/
                    if (bus.gas < Km)
                    {
                        MessageBox.Show("Needs to fill up gas");
                    }
                    /*updates the gas used and the km traveled*/
                }
                else//is good to travel
                {
                    bus.Status = "In the middle";
                    if (!backgroundWorker.IsBusy)//makes sure backround workeris not busy
                    {
                        backgroundWorker.RunWorkerAsync();//call on Backroundworker_DoWork
                    }


                }

            }

        }
        private void Backroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (Km / r.Next(20, 50)) * 6;//time=distance/speed times 6 because each hour is 6 seconds
           
            for (int i = 0; i <= count; i++) 
            {
                System.Threading.Thread.Sleep(1000);//sleeps for 1 second
                
                
            }
            /*updating feilds*/
            bus.sumKm = bus.sumKm + Km;
            bus.gas = bus.gas - Km;
            bus.Status = "Ready";
            
        }
      

        private void Backroundworker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Bus has traveled");//will show when Backroundworker3 ia finished
        }

    }


}
