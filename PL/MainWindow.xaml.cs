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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void StationDisplay_Click(object sender, RoutedEventArgs e)//opens Station Display
        {
            StationDisplay window = new StationDisplay();
            window.ShowDialog();//cant do anything in other windows till you close it

        }

        private void LineDisplay_Click(object sender, RoutedEventArgs e)//opens Line Display
        {
            LineDisplay window = new LineDisplay();
            window.ShowDialog();

        }
        private void User_Click(object sender, RoutedEventArgs e)//opens user window
        {
            User window = new User();
            window.ShowDialog();
        }
        private void BusDisplay_Click(object sender, RoutedEventArgs e)//opens user window
        {
           BusDisplay window = new BusDisplay();
            window.ShowDialog();
        }
    }
}

