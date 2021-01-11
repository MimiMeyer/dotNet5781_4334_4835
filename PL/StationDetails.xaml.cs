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
    /// Interaction logic for StationDetails.xaml
    /// </summary>
    public partial class StationDetails : Window
    {IBL bl = BLFactory.GetBL("1");
        public StationDetails(BO.Station station)
        {
            InitializeComponent();
            StationGrid.DataContext = station;//station details

            lineDataGrid.DataContext = bl.GetAlllinesByStation(station.Code);//details of lines that go through station
            lineDataGrid.IsReadOnly = true;
           


        }

      
    }
}
