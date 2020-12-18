using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for Travel.xaml
    /// </summary>
    public partial class Travel : Window
    {

        private static Random r = new Random();
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();
        private int _time;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Time
        {
            get { return _time; }
            set
            {
                _time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Time"));

            }

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]$");
            e.Handled = regex.IsMatch(e.Text);
        }
        public static Bus bus { get; set; }
        public int Number { get; set; }
       
        public Travel(Bus b)
        {
            InitializeComponent();
            bus = b;
           // backgroundWorker.DoWork += TextBox_PreviewKeyDown;

        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e==null) { return; }
            if (km_textbox == null) { return; }
            if (e.Key==Key.Return||e.Key==Key.Enter) 
            {
                Number = int.Parse(km_textbox.Text);
                
                    bus.Status = "Ready";
                    TimeSpan s = DateTime.Today - bus.checkupDate;//the difference between today and the last checkup date
                    double diffrence = s.TotalDays;//the difference in days
                /*checks if there's enough gas and if it needs a checkup*/
                if ((bus.gas < Number) || (Number + bus.sumKm >= 20000 || diffrence > 365))
                {
                    if ((bus.gas < Number) && (Number + bus.sumKm >= 20000 || diffrence > 365))
                    {
                        MessageBox.Show("Needs a checkup and to fill up gas");
                    }
                    /*checks if it only needs a checkup*/
                    if (Number + bus.sumKm >= 20000 || diffrence > 365)
                    {
                        MessageBox.Show("Needs a checkup");
                    }
                    /*checks if it only needs gas*/
                    if (bus.gas < Number)
                    {
                        MessageBox.Show("Needs to fill up gas");
                    }
                    /*updates the gas used and the km traveled*/
                }
                else
                {
                    //for (int i = 0; i <= (r.Next(20,50)*Number); i++)
                    //{
                    //    System.Threading.Thread.Sleep(1000);
                    //    Time = i;
                    //}
                    bus.sumKm = bus.sumKm + Number;
                    bus.gas = bus.gas - Number;
                    bus.Status = "In the middle";
                    MessageBox.Show("Bus has travled");

                }

                }

            }
        
      

    }


}
