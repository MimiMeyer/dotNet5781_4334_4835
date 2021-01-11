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
    /// Interaction logic for StationDisplay.xaml
    /// </summary>
    public partial class StationDisplay : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public StationDisplay()
        {
            InitializeComponent();
            stationDataGrid.DataContext = bl.GetAllStations();//all stations
            stationDataGrid.IsReadOnly = true;
        }
        private void Details_Click(object sender, RoutedEventArgs e)//opens StationDetails window 
        {
            StationDetails window = new StationDetails(stationDataGrid.SelectedItem as BO.Station);//sending line that was chosen to LineDetails
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//opens StationCrud window
        {
            StationCrud window= new StationCrud();
            window.Show();
        }
    }
}
