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
    /// Interaction logic for BusCrud.xaml
    /// </summary>
    public partial class BusCrud : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public BusCrud()
        {
            InitializeComponent();
            BusDataGrid.DataContext = bl.GetAlllBuses();//gets all busses
            BusDataGrid.IsReadOnly = true;


        }
        private void Window_Closed(object sender, EventArgs e)
        {
            BusDataGrid.DataContext = bl.GetAlllBuses();//gets all busses
            BusDataGrid.IsReadOnly = true;
        }
            private void Button_Click(object sender, RoutedEventArgs e)//adding a Bus
        {
            AddBus window = new AddBus();//opens up window addBus
            window.ShowDialog();
            BO.Bus bu = window.NewBus;//gets new Bus
            try
            {
                bl.AddBus(bu);//adds Bus
            }
            catch (BO.BusException ex)
            {
                MessageBox.Show(ex.Message);
            }
            window.Closed += Window_Closed;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)//Deleting the bus
        {
            BO.Bus bu = BusDataGrid.SelectedItem as BO.Bus;//the requested bus
            try
            {
                bl.DeleteBus(bu.LicenseNum);//deletes bus
            }
            catch (BO.BusException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
            
        private void Refuel_Click(object sender, RoutedEventArgs e)//updating the bus
        {
            BO.Bus bu = BusDataGrid.SelectedItem as BO.Bus;//the requested bus
            bl.Refuel(bu);
            
         
        }
        private void CheckUp_Click(object sender, RoutedEventArgs e)//updating the bus
        {
            BO.Bus bu = BusDataGrid.SelectedItem as BO.Bus;//the requested bus
            bl.Checkup(bu);
        }

    }
}
