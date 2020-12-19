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

        private static Random r = new Random();
        private static BackgroundWorker backgroundWorker3 = new BackgroundWorker();
       

      /*makes sure user input is int*/
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static Bus bus { get; set; }
        public int Km { get; set; }
       
        public Travel(Bus b)
        {
           InitializeComponent();
           bus = b;
           backgroundWorker3.DoWork += Backroundworker_DoWork;
           backgroundWorker3.RunWorkerCompleted += Backroundworker_WorkerCompleted;
          
            

        }


        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e == null) { return; }
            if (km_textbox == null) { return; }
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                Km = int.Parse(km_textbox.Text);

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
                    if (!backgroundWorker3.IsBusy)
                    {
                        backgroundWorker3.RunWorkerAsync();//call on Backroundworker_DoWork
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
