using System;
using System.Collections.ObjectModel;
using System.Windows;


namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<Bus> busses = new ObservableCollection<Bus>();

        public MainWindow()
        {
            InitializeComponent();
            Busses(busses);
            busDataGrid.DataContext = busses;
            busDataGrid.IsReadOnly = true;



        }
        private void Busses(ObservableCollection<Bus> busses)
        {
            busses.Add(new Bus(busses, "12345078", new DateTime(2019, 05, 25), 1200, 19800));//Needs checkup for date and sum km
            busses.Add(new Bus(busses, "12005678", new DateTime(2019, 12, 25), 200, 800));//almost needs checkup for date
            busses.Add(new Bus(busses, "22345678", new DateTime(2020, 05, 30), 400, 19000));//good to go for another 1000 km
            busses.Add(new Bus(busses, "12945678", new DateTime(2020, 10, 12), 1000, 0));//good to go
            busses.Add(new Bus(busses, "12365678", new DateTime(2020, 07, 05), 10, 500));//low gas
            busses.Add(new Bus(busses, "18345678", new DateTime(2018, 08, 01), 1100, 600));//needs checkup
            busses.Add(new Bus(busses, "15345678", new DateTime(2020, 10, 02), 1150, 70));//ggod to go
            busses.Add(new Bus(busses, "12340678", new DateTime(2020, 05, 15), 300, 100));//ggod to go
            busses.Add(new Bus(busses, "12347878", new DateTime(2020, 09, 20), 250, 10000));//good to go
            busses.Add(new Bus(busses, "1234566", new DateTime(2017, 06, 30), 15, 4000));//needs checkup and low on gas*/


        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            AddBus window = new AddBus();
            window.ShowDialog();
            Bus b = window.NewBUS;
            try
            {
                foreach (Bus bus in busses)
                {
                    if (bus.License_Plate == b.License_Plate)
                    {
                        throw new ArgumentException("License plate already exists");
                    }
                }

                busses.Add(b);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }




        }
        private void TravelButton_Click(object sender, RoutedEventArgs e) { }
        private void RefuelButton_Click(object sender, RoutedEventArgs e) { }
    }
}
