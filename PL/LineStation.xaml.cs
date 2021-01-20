using BLAPI;
using System.Windows;
namespace PL
{
    /// <summary>
    /// Interaction logic for LineStation.xaml
    /// </summary>
    public partial class LineStation : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LineStation(BO.Line line)
        {
            InitializeComponent();
            lineStationDataGrid.DataContext = bl.GetStationsForLine(line.Id);//gets all the stations for line
            lineStationDataGrid.IsReadOnly = true;
        }

        private void Update_Click(object sender, RoutedEventArgs e)//updates distance and time for lineStation
        {
            BO.LineStation st = lineStationDataGrid.SelectedItem as BO.LineStation;
            UpdateLineStation window = new UpdateLineStation(st);
            window.ShowDialog();//opens window to update
            try 
            { 
                bl.UpdateLineStation(st);//updates 
            }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);//if exception was thrown will show message
            }
            catch (BO.CantBeMinusException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Delete_Click(object sender, RoutedEventArgs e)//deletes line station
        {
            BO.LineStation st = lineStationDataGrid.SelectedItem as BO.LineStation;//the wanted line station

            try
            {
                bl.DeleteLineStation(st);//deletes
            }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message); //if line doesnt exist or has 2 stations
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);//if station code doesnt exist
            }

        }
    }
}
