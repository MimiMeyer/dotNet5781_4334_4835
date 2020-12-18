using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

using System.Threading;

namespace dotNet5781_03b_4334_4835
{
    /// <summary>
    /// Interaction logic for BusStatus.xaml
    /// </summary>
    public partial class BusStatus : Window, INotifyPropertyChanged
    {
        public static Bus bus { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();
        private static BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        private int _time;
        public int Time1
        {
            get { return _time; }
            set
            {
                _time = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Time"));
            }

        }
        public BusStatus(Bus b)
        {


            InitializeComponent();

            busStatusDataGrid.DataContext = b;
            bus = b;
            backgroundWorker.DoWork += Button_Refuel;
            backgroundWorker1.DoWork += Button_CHECK;
            
        }
        

        private void Button_Refuel(object sender, System.EventArgs e )
        {
            
            for (int i = 0; i <= 12; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Time1 = i;
            }
            backgroundWorker.RunWorkerAsync();
            bus.Refuel();
            MessageBox.Show("Bus has been refuled");

        }

        private void Button_CHECK(object sender, System.EventArgs e )
        {
            for (int i = 0; i <= 144; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Time1 = i;
            }
            backgroundWorker1.RunWorkerAsync();
            bus.Checkup();
            MessageBox.Show("Bus has been Checked");

        }
    }
}
