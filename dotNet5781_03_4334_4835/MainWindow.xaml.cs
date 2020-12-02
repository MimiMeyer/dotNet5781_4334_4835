using dotNet5781_02_4334_4835;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dotNet5781_03_4334_4835
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        BusLineGroup busCompany;
        private BLine currentDisplayBusLine;//saves the current line
        private static Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            busCompany = new BusLineGroup();
            List<BusStopLine> BusStops = new List<BusStopLine>();
            Program.GenerateBusLines(busCompany, BusStops);
            setComboBox();
        }
        /* loading and linking to the busLineGroup
         setting the itemSource of the combobox to the the busCompany which contains the lines, 
         setting the path for a selected object in the display, starting from the first in list.*/
        private void setComboBox()
        {
            cbBusLines.ItemsSource = busCompany.lines;
            cbBusLines.DisplayMemberPath = "BusLine ";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(((BLine)cbBusLines.SelectedItem).BusLine);
        }

        /*sets the event for a selection of the sender*/
        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as dotNet5781_02_4334_4835.BLine).BusLine);

        }
        /*shows data for a sended bus line */
        private void ShowBusLine(int index)
        {
            currentDisplayBusLine = busCompany[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.Stations;
        }

       
    }
}

