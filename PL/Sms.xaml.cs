using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for Sms.xaml
    /// </summary>
    public partial class Sms : Window
    {
        IBL bl = BLFactory.GetBL("1");
        int bus;
        TimeSpan time;
        public Sms(int code)
        {
            InitializeComponent();
            busCB.ItemsSource = bl.GetAlllineNumberaByStation(code);
           


        }
        private bool handle = true;
        private bool handleT = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }
        private void Handle()
        {
            bus = (int)busCB.SelectedItem;
            TimeCB.ItemsSource = bl.GetAllStartAtTimesForLine(bus);

        }
        private void ComboBox_DropDownClosedTime(object sender, EventArgs e)
        {
            if (handleT) HandleT();
            handleT = true;
        }

        private void ComboBox_SelectionChangedTime(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handleT = !cmb.IsDropDownOpen;
            HandleT();
        }
       
        private void HandleT()
        {
            time = (TimeSpan)TimeCB.SelectedItem;
        }
        public string Number { get { return numberText.Text; } }//returns user input 
        public int Bus { get { return bus; } }
        public TimeSpan Hour { get { return time; } }


    }
}
