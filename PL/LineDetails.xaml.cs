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
    /// Interaction logic for LineDetails.xaml
    /// </summary>
    public partial class LineDetails : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public LineDetails(BO.Line line)
        {
            InitializeComponent();
            LineDataGrid.DataContext = line;//gets line
            lineStationDataGrid.IsReadOnly = true;
            lineStationDataGrid.DataContext = bl.GetStationsForLine(line.Id);//gets all the stations for line
            lineStationDataGrid.IsReadOnly = true;

        }
 
    }
}
