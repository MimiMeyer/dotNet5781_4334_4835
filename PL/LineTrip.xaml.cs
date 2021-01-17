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
    /// Interaction logic for LineTrip.xaml
    /// </summary>
    public partial class LineTrip : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LineTrip(BO.Line line)
        {
            InitializeComponent();
            lineTripDataGrid.DataContext = bl.GetLineTripsForLine(line.Id);
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            BO.LineTrip lineTrip = lineTripDataGrid.SelectedItem as BO.LineTrip;//wanted lineTrip
            bl.DeleteLineTrip(lineTrip.LineId, lineTrip.StartAt);
        }
       
       
    }
}
