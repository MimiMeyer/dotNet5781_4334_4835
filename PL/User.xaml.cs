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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public User()
        {
            InitializeComponent();
            stationDataGrid.DataContext = bl.GetAllStations();
            stationDataGrid.IsReadOnly = true;

        }
        private void Show_Lines(object sender, RoutedEventArgs e)//adding a Station
        {
            BO.Station st = stationDataGrid.SelectedItem as BO.Station;
            lineDataGrid.DataContext = bl.GetAlllinesByStation(st.Code);
            lineDataGrid.IsReadOnly = true;
            Sms window1 = new Sms(st.Code);
            window1.ShowDialog();
            int Bus = window1.Bus;//gets the bus from user for sms
            string Number = window1.Number;//gets the number fos sms
            TimeSpan time = window1.Hour;//gets the hour for sms


            Simulation window = new Simulation(st.Code,Bus,Number,time);
            window.Show();
           
        }

       
    }
    
}
