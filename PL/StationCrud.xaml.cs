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
            stationDataGrid.DataContext = bl.GetAllStations();//shows all stations
            stationDataGrid.IsReadOnly = true;//can't change

        }
        private void Update_Click(object sender, RoutedEventArgs e)//updating coordinets the name and the address.
        {
            BO.Station st = stationDataGrid.SelectedItem as BO.Station;//the selected station
            UpdateStation window = new UpdateStation(st);
            window.ShowDialog();//opens up updateStation window inorder to update station
            try
            {
                bl.UpdateStation(st);//updating station
                    
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }
 
            catch (BO.StationCoordinatesException ex)//if coordiantes isnt good
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Delete_Click(object sender, RoutedEventArgs e)//deletes station
        {
            BO.Station st = stationDataGrid.SelectedItem as BO.Station;//the requested station
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

        private void Button_Click(object sender, RoutedEventArgs e)//adding a Station
        {
            AddStation window = new AddStation();//opens up window addstation
            window.ShowDialog();
            BO.Station station = window.NewStation;//gets new station 
            try
            {
                bl.AddStation(station);//adds station
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);//if station already exists will show message
            }
            catch (BO.StationCoordinatesException ex)
            {
                MessageBox.Show(ex.Message);//if the coordinates aren't good will show message
            }
        }
    }
}
