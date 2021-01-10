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
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation st = lineStationDataGrid.SelectedItem as BO.LineStation;
            UpdateLineStation window = new UpdateLineStation(st);
            window.ShowDialog();
            try { bl.UpdateLineStation(st); }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation st = lineStationDataGrid.SelectedItem as BO.LineStation;
            try
            {
                bl.DeleteLineStation(st.LineId, st.Station);
            }
            catch (BO.LineIdException ex)
            {
                MessageBox.Show(ex.Message); 
            }
            catch (BO.StationCodeException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
