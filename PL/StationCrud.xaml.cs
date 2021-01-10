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
    /// Interaction logic for StationCrud.xaml
    /// </summary>
    public partial class StationCrud : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public StationCrud()
        {
            InitializeComponent();
            stationDataGrid.DataContext = bl.GetAllStations();
            stationDataGrid.IsReadOnly = true;

        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            BO.Station st = stationDataGrid.SelectedItem as BO.Station;
            try
            {
                bl.DeleteStation(st.Code);//deletes station
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(BO.LineIdException ex) 
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStation window = new AddStation();
            window.ShowDialog();
            BO.Station station = window.NewStation;
            try
            {
                bl.AddStation(station);
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (BO.StationCoordinatesException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
