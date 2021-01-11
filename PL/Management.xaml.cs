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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        public Management()
        {
            InitializeComponent();
        }
        private void StationDisplay_Click(object sender, RoutedEventArgs e)//opens Station Display
        {
            StationDisplay window = new StationDisplay();
            window.ShowDialog();

        }

        private void LineDisplay_Click(object sender, RoutedEventArgs e)//opens Line Display
        {
            LineDisplay window = new LineDisplay();
            window.ShowDialog();

        }
    }
}
