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

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for BusStatus.xaml
    /// </summary>
    public partial class BusStatus : Window
    {
        public static Bus bus { get; set; }
        public BusStatus(Bus b)
        {


            InitializeComponent();

            busStatusDataGrid.DataContext = b;
            bus = b;

    }
        

        private void Button_Refuel(object sender, RoutedEventArgs e)
        {
            bus.Refuel();
           
        }

        private void Button_CHECK(object sender, RoutedEventArgs e)
        {
            bus.Checkup();
            
        }
    }
}
